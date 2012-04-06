using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public static class validate_key
    {
        public static bool validate(string key)
        {
            if (key[2] == '2' && key[7] == '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string clean_key(string key)
        {
            return
                key.Substring(0, 2) +
                key.Substring(3, 4)+
                key.Substring(8);
        }
        public static string dirty_key(string key)
        {
            return
                key.Substring(0, 2) +
                '2' +
                key.Substring(2, 4) +
                '9' +
                key.Substring(6);
        }
    }
}