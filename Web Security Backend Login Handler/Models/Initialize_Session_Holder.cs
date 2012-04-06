using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class Initialize_Session_Holder
    {
        [Key]
        public int id { get; set; }
        public string data { get; set; }
        public Server_keys server_key { get; set; }
        public string remote_pub_key { get; set; }
        public string encrypted_message { get; set; }

        public Initialize_Session_Holder()
        {

        }

        public Initialize_Session_Holder(IDataRepository db, string remote_key)
        {
            this.id = session_id_generator.make_random_id(db);
            this.data = data_generator.get_random_data(db);
            this.server_key = encryption_wrapper.get_keys();
            this.remote_pub_key = remote_key;
            this.encrypted_message = encryption_wrapper.encrpty_message(remote_key,
                "ID=" + id + ";" + "DATA=" + data + ";" + "PUB_KEY=" + server_key.public_key + ";");
            
        }
    }
}