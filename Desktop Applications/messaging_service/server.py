import argparse
import socket
import sys
import errno
import select
import Crypto

class Server(object):
    """ Main Web Server """
    def __init__(self):
        self.host = ""
        self.port = 5000
        self.clients = {}
        self.cache = {}
        self.messages = {}
        self.clientKey = {}
        self.size = 1024

        self.parse_arguments()
        self.open_socket()

    def parse_arguments(self):
        ''' parse arguments, which include '-p' for port '''
        parser = argparse.ArgumentParser(prog='Messaging Server', description='A simple messaging server', add_help=True)
        parser.add_argument('-p', '--port', type=int, action='store', help='port the server will bind to',default=5000)
        parser.add_argument('-d', '--debug', action='store_true', help='Print debugging information')
        self.args = parser.parse_args()
        self.port = self.args.port

    def open_socket(self):
        """ Setup the socket for incoming clients """
        try:
            self.server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR,1)
            self.server.bind((self.host,self.port))
            self.server.listen(5)
            self.server.setblocking(0)
        except socket.error, (value,message):
            if self.server:
                self.server.close()
            print "Could not open socket: " + message
            sys.exit(1)

    def run(self):
        """ Use poll() to handle each incoming client."""
        self.poller = select.epoll()
        self.pollmask = select.EPOLLIN | select.EPOLLHUP | select.EPOLLERR
        self.poller.register(self.server,self.pollmask)
        while True:
            # poll sockets
            try:
                fds = self.poller.poll(timeout=30)
            except:
                return
            for (fd,event) in fds:
                # handle errors
                if event & (select.POLLHUP | select.POLLERR):
                    self.handleError(fd)
                    continue
                # handle the server socket
                if fd == self.server.fileno():
                    self.handleServer()
                    continue
                # handle client socket
                self.handleClient(fd)

    def handleError(self,fd):
        self.poller.unregister(fd)
        if fd == self.server.fileno():
            # recreate server socket
            self.server.close()
            self.open_socket()
            self.poller.register(self.server,self.pollmask)
        else:
            # close the socket
            self.clients[fd].close()
            del self.clients[fd]

    def handleServer(self):
        # accept as many clients as possible
        while True:
            try:
                (client,address) = self.server.accept()
            except socket.error, (value,message):
                # if socket blocks because no clients are available,
                # then return
                if value == errno.EAGAIN or errno.EWOULDBLOCK:
                    return
                print traceback.format_exc()
                sys.exit()
            # set client socket to be non blocking
            client.setblocking(0)
            self.clients[client.fileno()] = client
            self.poller.register(client.fileno(),self.pollmask)

    def handleClient(self, fd):
        try:
            data = self.clients[fd].recv(self.size)
        except socket.error, (value,message):
            # if no data is available, move on to another client
            if value == errno.EAGAIN or errno.EWOULDBLOCK:
                return
            print traceback.format_exc()
            sys.exit()
        if fd in self.cache:
            self.cache[fd] += data
        else:
            self.cache[fd] = data
        message  = self.read_message(fd)
        if not message:
            return
        self.handle_message(fd,message)

    def read_message(self,fd):
        index = self.cache[fd].find("\n")
        if index == "-1" or index == -1:
            return None
        message = self.cache[fd][0:index+1]
        self.cache[fd] = self.cache[fd][index+1:]
        return message

    def handle_message(self,fd,message):
        response = self.parse_message(fd,message)
        self.send_response(fd,response)

    def parse_message(self,fd,message):
        fields = message.split()
        if not fields:
            return('error invalid message: bad fields\n')
        if fields[0] == 'reset':
            self.messages = {}
            return "OK\n"
        if fields[0] == 'put':
            try:
                name = fields[1]
                subject = fields[2]
                length = int(fields[3])
            except:
                return('error invalid message: put1\n')
            data = self.read_put(fd,length)
            if data == None:
                return 'error could not read entire message: put2\n'
            self.store_message(name,subject,data)
            return "OK\n"
        if fields[0] == 'list':
            try:
                name = fields[1]
            except:
                return('error invalid message: list\n')
            subjects,length = self.get_subjects(name)
            response = "list %d\n" % length
            response += subjects
            return response
        if fields[0] == 'get':
            try:
                name = fields[1]
                index = int(fields[2])
            except:
                return('error invalid message: get\n')
            subject,data = self.get_message(name,index)
            if not subject:
                return "error no such message for that user\n"
            response = "message %s %d\n" % (subject,len(data))
            response += data
            return response
        if fields[0] == 'store_key':
            try:
                name = fields[1]
                length = fields[2]
            except:
                return "error invalid message: store_key\n"
            data = self.read_storeKey(name,fd,int(length))
            if data == None:
                return "Username taken, try again.\n"
            return 'OK\n'
        if fields[0] == 'get_key':
            try:
                name = fields[1]
            except:
                return "error invalid message: get_key\n"
            if name in self.clientKey:
                response = "key "
                response += str(len(self.clientKey[name])) + "\n"
                response += self.clientKey[name]
                return response
            else:
                return "error invalid message: incorrect name\n"
        return('error invalid message: invalid request --> ' + fields[0] + ' <--\n')

    #may give an error because fd is not passed in
    def store_message(self,name,subject,data):
        if name not in self.messages:
            self.messages[name] = []
        self.messages[name].append((subject,data))

    def get_subjects(self,name):
        if name not in self.messages:
            return "",0
        response = ["%d %s\n" % (index+1,message[0]) for index,message in enumerate(self.messages[name])]
        return "".join(response),len(response)

    def get_message(self,name,index):
        if index <= 0:
            return None,None
        try:
            return self.messages[name][index-1]
        except:
            return None,None

    def read_storeKey(self,name,fd,length):
        #if name in self.clientKey:
        #    self.cache[fd] = ""
        #    return None
        #else:
        data = self.cache[fd]
        self.cache[fd] = ""
        while len(data) < length:
            d = self.clients[fd].recv(self.size)
            if not d:
                return None
            data += d
        if len(data) > length:
            #self.cache[fd] = data[length:]
            #data = data[:length]
            print "SERVER NOTIFICATION: data is bigger than length"
        self.clientKey[name] = data
        return self.clientKey[name]

    def read_put(self,fd,length):
        data = self.cache[fd]
        while len(data) < length:
            d = self.clients[fd].recv(self.size)
            if not d:
                return None
            data += d
        if len(data) > length:
            self.cache[fd] = data[length:]
            data = data[:length]
        else:
            self.cache[fd] = ''
        return data

    def send_response(self,fd,response):
        self.clients[fd].sendall(response)


if __name__ == '__main__':
    s = Server()
    try:
        s.run()
    except KeyboardInterrupt:
        pass
