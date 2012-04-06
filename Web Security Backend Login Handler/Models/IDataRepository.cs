using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web_Security_Backend_Login_Handler.Models
{
    public interface IDataRepository
    {
        bool check_for_unique_key(string key);
        bool check_for_unique_session_id(int id);
        bool check_for_unique_data_string(string data);
        bool check_that_initialize_is_not_locked();

        void store_failed_initialize_attempt(string key);
        void store_initialize_data(Session_Holder session);
        Session_Holder get_session(int id);

        void expire_session(int id);
    }
}
