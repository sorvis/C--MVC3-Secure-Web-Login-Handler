using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class Server_keys
    {
        [Key]
        public int id { get; set; }
        public long public_key { get; set; }
        public long private_key { get; set; }
        public long shared_key { get; set; }

        public void set_private_key(string key)
        {
            private_key = Int64.Parse(key);
        }

        public Server_keys()
        {

        }
        public Server_keys(long pubKey, long privKey, long sharedKey)
        {
            this.public_key = pubKey;
            this.private_key = privKey;
            this.shared_key = sharedKey;
        }
    }
}