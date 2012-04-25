using Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for Service_ManagerTest and is intended
    ///to contain all Service_ManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Service_ManagerTest
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


        [TestMethod()]
        public void record_failed_attemptTest_should_create_a_new_ip_record_when_none_is_found()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "make belive IP";
            target.record_failed_attempt(ip);
            Assert.IsNotNull(target.find_attempt_by_ip(ip));
        }

        [TestMethod()]
        public void record_failed_attemptTest_should_update_ip_record_when_ip_is_found()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "make belive IP";
            target.record_failed_attempt(ip);
            target.record_failed_attempt(ip);

            Assert.AreEqual(1, target._attempts.Count);
            Assert.AreEqual(2, target.find_attempt_by_ip(ip).Fail_Count);
        }

        [TestMethod()]
        public void is_ip_lockedTest_users_should_lock_out_after_four_attempts_even_though_time_between_attempts()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "some address";

            log_ip_fail ip_attempt = new log_ip_fail(ip);
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Record_Failed_Attempt();
            //ip_attempt.Last_Attempt = new DateTime(1990,3,3);
            target._attempts.Add(ip_attempt);

            bool expected = true; // account should be locked
            bool actual;
            actual = target.is_ip_locked(ip);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void is_ip_lockedTest_users_should_unlocklock_out_after_four_attempts_if_unlock_period_has_been_exceeded()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "some address";

            log_ip_fail ip_attempt = new log_ip_fail(ip);
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Last_Attempt = new DateTime(1990,3,3);
            target._attempts.Add(ip_attempt);

            bool expected = false; // account should not be locked
            bool actual;
            actual = target.is_ip_locked(ip);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void is_ip_lockedTest_users_should_not_lock_out_after_three_attempts_when_time_between_attempts_is_greater_then_needed()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "some address";

            log_ip_fail ip_attempt = new log_ip_fail(ip);
            ip_attempt.Record_Failed_Attempt();
            ip_attempt.Last_Attempt = new DateTime(1990, 3, 3);
            target._attempts.Add(ip_attempt);

            bool expected = false; // account should not be locked
            bool actual;
            actual = target.is_ip_locked(ip);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void is_ip_lockedTest_users_should_not_lock_out_an_unknown_ip()
        {
            Service_Manager_Accessor target = new Service_Manager_Accessor();
            string ip = "some address";

            bool expected = false; // account should not be locked
            bool actual;
            actual = target.is_ip_locked(ip);
            Assert.AreEqual(expected, actual);
        }
    }
}
