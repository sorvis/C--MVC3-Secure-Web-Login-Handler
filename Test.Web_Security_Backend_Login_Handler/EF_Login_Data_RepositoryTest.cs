using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Entity;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for EF_Login_Data_RepositoryTest and is intended
    ///to contain all EF_Login_Data_RepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EF_Login_Data_RepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private long _sample_pub_key = 5;
        private long _sample_priv_key = 602381;
        private long _sample_shared_key = 1005973;
        private long _sample_remote_pub_key = 3;
        private long _sample_remote_priv_key = 918667;
        private long _sample_remote_shared_key=1380361;

        
        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_return_true_when_key_does_not_exist_in_db()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            long key = 34534534534545;
            bool expected = true;
            bool actual;
            actual = target.check_for_unique_pub_and_shared_key(4, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_return_false_when_the_same_SERVER_key_exists()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            //Server_keys server_key = new Server_keys(_sample_pub_key, _sample_priv_key, _sample_shared_key);
            //db.server_keys.Add(server_key);
            Session_Holder session = new Session_Holder();
            session.remote_pub_key = _sample_pub_key;
            session.remote_shared_key = _sample_shared_key;
            db.Session.Add(session);
            db.SaveChanges();

            Assert.IsFalse(target.check_for_unique_pub_and_shared_key(_sample_pub_key, _sample_shared_key));
        }

        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_return_false_when_the_same_REMOTE_key_exists()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_remote_shared_key);
            target.store_session(session);

            Assert.IsFalse(target.check_for_unique_pub_and_shared_key(_sample_remote_pub_key, _sample_remote_shared_key));
        }

        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_return_True_when_a_different_REMOTE_key_exists()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_remote_shared_key);
            target.store_session(session);

            Assert.IsTrue(target.check_for_unique_pub_and_shared_key(_sample_pub_key, _sample_remote_shared_key));
        }

        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_return_True_when_a_different_SERVER_key_exists()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Server_keys server_key = new Server_keys(_sample_pub_key, _sample_priv_key, _sample_shared_key);
            db.server_keys.Add(server_key);
            db.SaveChanges();

            Assert.IsTrue(target.check_for_unique_pub_and_shared_key(_sample_remote_pub_key, _sample_shared_key));
        }

        [TestMethod()]
        public void check_for_unique_data_stringTest_should_return_true_when_string_is_not_found_in_db()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            string data = "this string is not in the database";
            bool expected = true;
            bool actual;
            actual = target.check_for_unique_data_string(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void check_for_unique_data_stringTest_should_return_false_when_string_is_found_in_db()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);

            Assert.IsFalse(target.check_for_unique_data_string(session.data));
        }

        [TestMethod()]
        public void check_for_unique_session_idTest_should_return_true_when_id_is_not_found_in_db()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            int id = 344252345;
            bool expected = true; 
            bool actual;
            actual = target.check_for_unique_session_id(id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void check_for_unique_session_idTest_should_return_false_when_id_is_found_in_db()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);

            int id = session.session_id;
            bool actual;
            actual = target.check_for_unique_session_id(id);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void check_that_initialize_is_not_lockedTest_should_return_true_when_it_is_not_locked()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            bool expected = true;
            bool actual;
            actual = target.check_that_initialize_is_not_locked();
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //public void check_that_initialize_is_not_lockedTest_should_return_false_when_failed_login_attempt_has_happened_within_last_minute()
        //{
        //    Assert.Inconclusive();
        //}

        [TestMethod()]
        public void expire_sessionTest()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);

            int id = session.session_id;
            Assert.IsFalse(target.get_session(session.session_id).expired);
            target.expire_session(id);
            Assert.IsTrue(target.get_session(session.session_id).expired);
        }

        [TestMethod()]
        public void get_sessionTest()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();
            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);

            int id = session.session_id;
            Session_Holder expected = session;
            Session_Holder actual;
            actual = target.get_session(id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void get_sessionTest_should_return_null_when_session_is_not_found()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            int id = 54;
            Session_Holder actual;
            actual = target.get_session(id);
            Assert.IsNull(actual);
        }

        [TestMethod()]
        public void store_failed_initialize_attemptTest()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            string public_key = "this key is fake";
            long shared_key = _sample_shared_key;
            data_failed_login_attempt attempt = new data_failed_login_attempt(public_key, Convert.ToString(shared_key));
            target.store_failed_initialize_attempt(attempt);
            Assert.IsNotNull(db.failed_logins.Find(attempt.id));
        }

        [TestMethod()]
        public void store_sessionTest()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);
            Assert.IsNotNull(target.get_session(session.session_id));
        }

        [TestMethod()]
        public void store_sessionTest_should_allow_multiple_sessions_to_be_stored()
        {
            DataEntities db = new DataEntities();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            Session_Holder session = new Session_Holder(target, _sample_remote_pub_key, _sample_shared_key);
            target.store_session(session);
            Assert.IsNotNull(target.get_session(session.session_id));

            session = new Session_Holder(target, _sample_remote_pub_key+1, _sample_shared_key+1);
            target.store_session(session);
            Assert.IsNotNull(target.get_session(session.session_id));

            session = new Session_Holder(target, _sample_remote_pub_key + 2, _sample_shared_key + 2);
            target.store_session(session);
            Assert.IsNotNull(target.get_session(session.session_id));
        }

        /*
         * Helper functions
         * */
    }
}
