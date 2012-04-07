using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class DataEntities:IDataRepository
    {
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

        void IDataRepository.store_session(Session_Holder session)
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