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
    }
}