using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_Security_Backend_Login_Handler.Models;

namespace Test.Web_Security_Backend_Login_Handler
{
    class Database_mock_up:IDataRepository
    {
        private List<Session_Holder> _sessions = new List<Session_Holder>();
        private List<data_failed_login_attempt> _attempts = new List<data_failed_login_attempt>();
        public bool _database_is_not_locked = true;

        public Database_mock_up()
        {
            _sessions.Add(new Session_Holder(this, 1234123435, 23412341234));
        }

        public bool check_for_unique_pub_key(string key)
        {
            foreach (Session_Holder session in _sessions)
            {
                if (session.remote_pub_key == UInt64.Parse(key))
                {
                    return false;
                }
            }
            return true;
        }

        public bool check_for_unique_session_id(int id)
        {
            foreach (Session_Holder session in _sessions)
            {
                if (session.id == id)
                {
                    return false;
                }
            }
            return true;
        }

        public bool check_for_unique_data_string(string data)
        {
            foreach (Session_Holder session in _sessions)
            {
                if (session.data == data)
                {
                    return false;
                }
            }
            return true;
        }

        public bool check_that_initialize_is_not_locked()
        {
            return _database_is_not_locked;
        }

        public void store_failed_initialize_attempt(string public_key, ulong shared_key)
        {
            _attempts.Add(new data_failed_login_attempt(public_key, shared_key));
        }

        public void store_session(Session_Holder session)
        {
            _sessions.Add(session);
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
