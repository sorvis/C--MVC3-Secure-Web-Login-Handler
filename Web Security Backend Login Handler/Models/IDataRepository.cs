using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web_Security_Backend_Login_Handler.Models
{
    public interface IDataRepository
    {
        /// <summary>
        /// Should check for a unique key used be both server and client
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool check_for_unique_pub_and_shared_key(long pub_key, long shared_key);
        bool check_for_unique_session_id(int id);
        bool check_for_unique_data_string(string data);
        bool check_that_initialize_is_not_locked();

        void store_failed_initialize_attempt(string public_key, string shared_key);
        void store_session(Session_Holder session);
        Session_Holder get_session(int id);

        void expire_session(int id);
        void mark_session_successful(int id);
    }
}
