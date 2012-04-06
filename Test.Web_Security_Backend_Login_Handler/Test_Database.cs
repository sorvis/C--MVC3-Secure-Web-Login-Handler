using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_Security_Backend_Login_Handler.Models;

namespace Test.Web_Security_Backend_Login_Handler
{
    class Test_Database:IDataRepository
    {
        public bool check_for_unique_key(string key)
        {
            throw new NotImplementedException();
        }

        public bool check_for_unique_session_id(int id)
        {
            throw new NotImplementedException();
        }

        public bool check_for_unique_data_string(string data)
        {
            return true;
        }

        bool IDataRepository.check_for_unique_key(string key)
        {
            throw new NotImplementedException();
        }

        bool IDataRepository.check_for_unique_session_id(int id)
        {
            throw new NotImplementedException();
        }

        bool IDataRepository.check_for_unique_data_string(string data)
        {
            throw new NotImplementedException();
        }

        bool IDataRepository.check_that_initialize_is_not_locked()
        {
            throw new NotImplementedException();
        }

        void IDataRepository.store_failed_initialize_attempt(string key)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.store_initialize_data(Session_Holder session)
        {
            throw new NotImplementedException();
        }

        Session_Holder IDataRepository.get_session(int id)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.expire_session(int id)
        {
            throw new NotImplementedException();
        }
    }
}
