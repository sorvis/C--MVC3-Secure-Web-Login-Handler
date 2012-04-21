using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class data_failed_login_attempt
    {
        string public_key { get; set; }
        ulong shared_key { get; set; }
        DateTime attempt_time { get; set; }
        public data_failed_login_attempt(string pub_key, ulong shared_key)
        {
            this.public_key = pub_key;
            this.shared_key = shared_key;
            this.attempt_time = DateTime.Now;
        }
    }
}