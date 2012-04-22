using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class data_failed_login_attempt
    {
        [Key]
        public int id { get; set; }
        string public_key { get; set; }
        long shared_key { get; set; }
        DateTime attempt_time { get; set; }
        public data_failed_login_attempt(string pub_key, long shared_key)
        {
            this.public_key = pub_key;
            this.shared_key = shared_key;
            this.attempt_time = DateTime.Now;
        }
    }
}