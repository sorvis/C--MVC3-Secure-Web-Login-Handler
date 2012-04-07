using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class Session_Holder
    {
        [Key]
        public int id { get; set; }
        public bool expired { get; set; }
        public string data { get; set; }
        public Server_keys server_key { get; set; }
        public string remote_pub_key { get; set; }
        public string encrypted_message { get; set; }
        public Hashtable calulated_key { get; set; }

        public Session_Holder()
        {

        }

        public Session_Holder(IDataRepository db, string remote_key)
        {
            this.id = session_id_generator.make_random_id(db);
            this.data = data_generator.get_random_data(db);
            this.server_key = encryption_wrapper.get_keys();
            this.remote_pub_key = remote_key;
            this.encrypted_message = encryption_wrapper.encrpty_message(remote_key,
                "ID=" + id + ";" + "DATA=" + data + ";" + "PUB_KEY=" + server_key.public_key + ";");
        }

        public bool validate_login( Hashtable login_attempt)
        {
            // fail automatically if there is no data to compare login attempt with
            if (calulated_key.Count <= 0)
            {
                return false;
            }

            foreach(DictionaryEntry item in calulated_key)
            {
                if (login_attempt[item.Key] != item.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}