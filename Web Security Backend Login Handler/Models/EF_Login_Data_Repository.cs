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
            _db.Database.Initialize(true);
        }

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