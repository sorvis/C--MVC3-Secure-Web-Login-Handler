using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static string decrypt_message(string private_key, ulong remote_shared_key, string message)
        {
            return decrypt_message(UInt64.Parse(private_key), remote_shared_key, message);
        }
        public static string decrypt_message(ulong private_key, ulong remote_shared_key, string message)
        {
            return message;
        }
        public static Server_keys get_keys()
        {
            // should be using scotts key generator
            Random rand = new Random();
            return new Server_keys((UInt64)rand.Next(100), (UInt64)rand.Next(100), (UInt64)rand.Next(100));
        }
    }
}