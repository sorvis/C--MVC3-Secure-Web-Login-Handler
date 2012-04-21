using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class DataEntities:IDataRepository
    {

        public bool check_for_unique_pub_key(string key)
        {
            return true;
        }

        public bool check_for_unique_session_id(int id)
        {
            return true;
        }

        public bool check_for_unique_data_string(string data)
        {
            return true;
        }

        public bool check_that_initialize_is_not_locked()
        {
            return true;
        }

        public void store_failed_initialize_attempt(string public_key, ulong shared_key)
        {
            throw new NotImplementedException();
        }

        public void store_session(Session_Holder session)
        {

        }

        public Session_Holder get_session(int id)
        {
            throw new NotImplementedException();
        }

        public void expire_session(int id)
        {
            throw new NotImplementedException();
        }
    }
}