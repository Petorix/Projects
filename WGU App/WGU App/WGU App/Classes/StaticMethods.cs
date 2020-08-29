using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace WGU_App.Classes
{
    public static class StaticMethods
    {
        public static int HashMaker(string input)
        {
            var rand = new Random(10000);
            string randomInput = input + rand.Next().ToString();
            string hash;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(randomInput));
                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                hash = sBuilder.ToString();
            }

            return hash.GetHashCode();
        }
    }
}
