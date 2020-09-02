import fileinput
import optparse
import socket
import sys
from Crypto.PublicKey import RSA
from Crypto import Random


class Client(object):
    def __init__(self,host,port):
        self.host = host
        self.port = port
        self.server = None
        self.cache = ''
        self.messages = {}
        self.size = 1024
        self.key = 0
        self.parse_options()
        self.open_socket()
        self.run()

    def parse_options(self):
        parser = optparse.OptionParser(usage = "%prog [options]",
                                       version = "%prog 0.1")

        parser.add_option("-p","--port",type="int",dest="port",
                          default=5000,
                          help="port to connect to")

        parser.add_option("-s","--server",type="string",dest="host",
                          default='localhost',
                          help="server to connect to")

        (options,args) = parser.parse_args()
        self.host = options.host
        self.port = options.port

    def open_socket(self):
        """ Connect to the server """
        try:
            self.server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.server.connect((self.host,self.port))
        except socket.error, (value,message):
            if self.server:
                self.server.close()
            print "Could not connect to server: " + message
            sys.exit(1)

    def run(self):
        while True:
            # get input from users
            self.prompt()
            command = sys.stdin.readline()
            result = self.parse_command(command)
            if not result:
                print "I don't recognize that command."

    def prompt(self):
        sys.stdout.write("% ")

    def parse_command(self,command):
        fields = command.split()
        if not fields:
            return('error invalid message\n')
        if fields[0] == 'quit':
            sys.exit()
        if fields[0] == 'send':
            ### send message ###
            try:
                name = fields[1]
                subject = fields[2]
            except:
                return False
            try:
                self.request_publicKey(name)
                importedKey = self.response_getKey()
                public_key = RSA.importKey(importedKey)
                data = self.get_user_message()
                newData = public_key.encrypt(data,0)[0]
                self.send_put(name,subject,newData)
                self.response_to_put()
            except:
                print "User does not exist."
            return True
        if fields[0] == 'list':
            ### list messages ###
            try:
                name = fields[1]
            except:
                return False
            self.send_list(name)
            self.response_to_list()
            return True
        if fields[0] =='read':
            try:
                name = fields[1]
                index = int(fields[2])
            except:
                return False
            self.send_read(name,index)
            subject, data = self.response_to_read()
            newData = self.key.decrypt(data)
            print subject
            print newData
            return True
        if fields[0] == 'login':
            try:
                user = fields[1]
            except:
                return False
        if fields[0] == 'peek':
            try:
                name = fields[1]
                index = int(fields[2])
            except:
                return False
            self.send_read(name,index)
            self.response_to_peek()
            return True
        if fields[0] == 'login':
            try:
                user = fields[1]
            except:
                return False
            random_generator = Random.new().read
            self.key = RSA.generate(2048, random_generator)
            public_key = self.key.publickey()
            export = public_key.exportKey()
            length = len(export)
            self.send_login(user,length,export)
            self.response_to_login()
            return True
        return False

    def get_response(self):
        # get a response from the server
        while True:
            data = self.server.recv(self.size)
            if not data:
                print "Connection to server closed."
                sys.exit()
            self.cache += data
            message = self.read_message()
            if not message:
                continue
            return message

    def read_message(self):
        # read until we have a newline and store excess in cache
        index = self.cache.find("\n")
        if index == "-1":
            return None
        message = self.cache[0:index+1]
        self.cache = self.cache[index+1:]
        return message

    def send_request(self,request):
        self.server.sendall(request)

    ### Handling send ###

    def send_put(self,name,subject,data):
        self.send_request("put %s %s %d\n%s" % (name, subject, len(data), data))

    def get_user_message(self):
        print "- Type your message. End with a blank line -"
        message = ""
        while True:
            # get input from user
            data = sys.stdin.readline()
            if data == "\n":
                return message
            message += data

    def response_to_put(self):
        message = self.get_response()
        if message != "OK\n":
            print "Server returned bad message:",message
            return

    ### Handling list ###

    def send_list(self,name):
        self.send_request("list %s\n" % name)

    def response_to_list(self):
        message = self.get_response()
        fields = message.split()
        try:
            if fields[0] != 'list':
                print "Server returned bad message:",message
                return
            num = int(fields[1])
        except:
            print "Server returned bad message:",message
            return
        self.read_list_response(num)


    def read_list_response(self,num):
        total = 0
        while (total < num):
            data = self.read_message()
            print data,
            total += 1

    ### Handling read ###

    def send_read(self,name,index):
        self.send_request("get %s %s\n" % (name, index))

    def response_to_peek(self):
        message = self.get_response()
        fields = message.split()
        try:
            if fields[0] != 'message':
                print "Server returned bad message:",message
                return
            subject = fields[1]
            length = int(fields[2])
        except:
            print "Server returned bad message:",message
            return
        self.peek_message_response(subject,length)

    def peek_message_response(self,subject,length):
        data = self.cache
        while len(data) < length:
            d = self.server.recv(self.size)
            if not d:
                self.cache = ''
                print "Server did not send the whole message:",data
                return None
            data += d
        if data > length:
            self.cache = data[length:]
            data = data[:length]
        else:
            self.cache = ''
        print subject
        print data

    def send_login(self,name,length,public_key):
        self.send_request("store_key %s %s\n%s" % (name, length, public_key))

    def response_to_login(self):
        message = self.get_response()
        if message != "OK\n":
            index = message.find("\n")
            message = message[0:index]
            print "Server returned bad message:",message
            return
    def request_publicKey(self,name):
        self.send_request("get_key %s\n" % (name))

    def response_getKey(self):
        response = self.get_response()
        fields = response.split()
        if not fields:
            return None
        if fields[0] == 'key':
            try:
                length = int(fields[1])
            except:
                return None
            public_key = self.read_getKey(length)
            if not public_key:
                return None
            return public_key
        else:
            return None

    def read_getKey(self,length):
        data = self.cache
        while len(data) < length:
            d = self.server.recv(self.size)
            if not d:
                self.cache = ''
                print "Server did not send the whole message:",data
                return None
            data += d
        if len(data) > length:
            self.cache = data[length:]
            data = data[:length]
        else:
            self.cache = ''
        return data

    def response_to_read(self):
        message = self.get_response()
        fields = message.split()
        try:
            if fields[0] != 'message':
                print "Server returned bad message:",message
                return
            subject = fields[1]
            length = int(fields[2])
        except:
            print "Server returned bad message:",message
            return
        subjct,data = self.read_message_response(subject,length)
        return subject,data

    def read_message_response(self,subject,length):
        data = self.cache
        while len(data) < length:
            d = self.server.recv(self.size)
            if not d:
                self.cache = ''
                print "Server did not send the whole message:",data
                return None
            data += d
        if data > length:
            self.cache = data[length:]
            data = data[:length]
        else:
            self.cache = ''
        return subject, data

if __name__ == '__main__':
    c = Client('',5000)
