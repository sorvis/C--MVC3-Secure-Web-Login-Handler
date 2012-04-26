using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class EF_Login_Data_Repository : IDataRepository
    {
        private DataEntities _db;
        public EF_Login_Data_Repository()
        {
            _db = new DataEntities();
        }
        public EF_Login_Data_Repository(DataEntities db)
        {
            _db = db;
        }
        /// <summary>
        /// Drops all tables in database. Used for testing and for development.
        /// </summary>
        public void reset_db()
        {
            Database.SetInitializer<DataEntities>(new DropCreateDatabaseAlways<DataEntities>());
            _db.Database.CreateIfNotExists();
            _db.Database.Initialize(true);
        }
        /*
         * Begin database access code
         * */

        /// <summary>
        /// Checks both previously used server keys and previously used client pub keys
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the key has never been used before</returns>
        public bool check_for_unique_pub_and_shared_key(long pub_key, long shared_key)
        {
            Session_Holder remote = _db.Session.FirstOrDefault(d => d.remote_pub_key == pub_key && d.remote_shared_key == shared_key);
            Server_keys server = _db.server_keys.FirstOrDefault(d => d.public_key == pub_key && d.shared_key == shared_key);
            if (remote != null || server != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool check_for_unique_session_id(int id)
        {
            if (get_session(id) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool check_for_unique_data_string(string data)
        {
            if (_db.Session.FirstOrDefault(d => d.data == data) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool check_that_initialize_is_not_locked()
        {
            return true;
        }

        public void store_failed_initialize_attempt(data_failed_login_attempt attempt)
        {
            _db.failed_logins.Add(attempt);
            _db.SaveChanges();
        }

        public void store_failed_initialize_attempt(string public_key, string shared_key)
        {
            store_failed_initialize_attempt(new data_failed_login_attempt(public_key, shared_key));
        }

        public void store_session(Session_Holder session)
        {
            _db.Session.Add(session);
            _db.SaveChanges();
        }

        public Session_Holder get_session(int id)
        {
            //return _db.Session.Find(id);
            return _db.Session
                .Include("server_key")
                .Include("calulated_key")
                .FirstOrDefault(d => d.session_id == id);
        }

        public void expire_session(int id)
        {
            get_session(id).expired = true;
            _db.SaveChanges();
        }

        public void mark_session_successful(int id)
        {
            get_session(id).successful_login = true;
            _db.SaveChanges();
        }
    }
}