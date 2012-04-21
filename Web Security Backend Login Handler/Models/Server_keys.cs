using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class Server_keys
    {
        public ulong public_key { get; set; }
        public ulong private_key { get; set; }
        public ulong shared_key { get; set; }

        public void set_private_key(string key)
        {
            private_key = UInt64.Parse(key);
        }

        public Server_keys()
        {

        }
        public Server_keys(ulong pubKey, ulong privKey, ulong sharedKey)
        {
            this.public_key = pubKey;
            this.private_key = privKey;
            this.shared_key = sharedKey;
        }
    }
}