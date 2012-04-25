using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSAClasses;

namespace Web_Security_Backend_Login_Handler.Models
{
    public static class encryption_wrapper
    {
        //TODO: need to impliment with Scotts encrption

        public static string encrpty_message(string public_key, string message)
        {
            long long_pub_key = Int64.Parse(public_key);
            return message;
        }
        public static string decrypt_message(string private_key, long remote_shared_key, string message)
        {
            return decrypt_message(Int64.Parse(private_key), remote_shared_key, message);
        }
        public static string decrypt_message(long private_key, long remote_shared_key, string message)
        {
            return message;
        }
        public static Server_keys get_keys()
        {
             //RSA rsa = new RSA(
            // should be using scotts key generator
            Random rand = new Random();
            return new Server_keys((Int64)rand.Next(100), (Int64)rand.Next(100), (Int64)rand.Next(100));
        }
    }
}