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
    }
}
