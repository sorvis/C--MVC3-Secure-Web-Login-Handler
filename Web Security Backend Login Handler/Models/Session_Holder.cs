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
        public int session_id { get; set; }
        public bool expired { get; set; }
        public string data { get; set; }
        public Server_keys server_key { get; set; }
        public long remote_pub_key { get; set; }
        public long remote_shared_key { get; set; }
        public string encrypted_message { get; set; }
        //public Hashtable calulated_key { get; set; }
        public List<db_calculatedKey> calulated_key { get; set; }

        public Session_Holder()
        {

        }

        public Session_Holder(IDataRepository db, long remote_key, long remote_shared_key)
         {
            this.session_id = session_id_generator.make_random_id(db);
            
            data_generator login_data = new data_generator(db, User_Password.Password);
            this.data = login_data.LoginData;
            this.calulated_key = db_calculatedKey.convert_Hashtable_to_list_of_calculatedKey(login_data.CalulatedKey);

            int counter = 0;
            do//ensure a unique key is picked
            {
                this.server_key = encryption_wrapper.get_keys();
                counter++;
            }
            while (!db.check_for_unique_pub_key(this.server_key.public_key)||counter >100);

            this.remote_pub_key = remote_key;
            this.remote_shared_key = remote_shared_key;
            this.encrypted_message = encryption_wrapper.encrpty_message(Convert.ToString(remote_key),
                "ID=" + session_id + ";" + "PUB_KEY=" + server_key.public_key + ";"+"SHARED_KEY="+server_key.shared_key+";"+data);
        }

        public bool validate_login( Hashtable login_attempt)
        {
            // fail automatically if there is no data to compare login attempt with
            if (calulated_key.Count <= 0)
            {
                return false;
            }

            foreach(db_calculatedKey item in calulated_key)
            {
                if ((string)login_attempt[item.Key] != (string)item.Value.ToString())
                {
                    return false;
                }
            }
            return true;
        }
    }
}