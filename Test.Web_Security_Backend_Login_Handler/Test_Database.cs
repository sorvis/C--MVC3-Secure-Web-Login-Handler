using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_Security_Backend_Login_Handler.Models;

namespace Test.Web_Security_Backend_Login_Handler
{
    class Test_Database:IDataRepository
    {

        public bool check_for_unique_pub_key(ulong key)
        {
            throw new NotImplementedException();
        }

        public bool check_for_unique_session_id(int id)
        {
            throw new NotImplementedException();
        }

        public bool check_for_unique_data_string(string data)
        {
            throw new NotImplementedException();
        }

        public bool check_that_initialize_is_not_locked()
        {
            throw new NotImplementedException();
        }

        public void store_failed_initialize_attempt(string public_key, ulong shared_key)
        {
            throw new NotImplementedException();
        }

        public void store_session(Session_Holder session)
        {
            throw new NotImplementedException();
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
