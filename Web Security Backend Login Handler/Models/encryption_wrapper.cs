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
            return message;
        }
        public static string decrypt_message(string private_key, string message)
        {
            return message;
        }
        public static Server_keys get_keys()
        {
            return new Server_keys();
        }
    }
}