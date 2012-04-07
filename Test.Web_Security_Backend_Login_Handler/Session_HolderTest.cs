using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for Session_HolderTest and is intended
    ///to contain all Session_HolderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Session_HolderTest
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
        public void validateloginTest_should_return_true_when_SessionHolder_contains_at_least_one_same_element()
        {
            Session_Holder target = new Session_Holder();
            target.calulated_key = new Hashtable();
            target.calulated_key.Add("test", "test_value");

            Hashtable login_attempt = new Hashtable();
            login_attempt.Add("a random thing", "anything");
            login_attempt.Add("test", "test_value");
            login_attempt.Add("sdf", "sdf");

            bool expected = true;
            bool actual;
            actual = target.validate_login(login_attempt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validateloginTest_should_return_false_when_SessionHolder_contains_same_key_but_different_value()
        {
            Session_Holder target = new Session_Holder();
            target.calulated_key = new Hashtable();
            target.calulated_key.Add("test", "test_value");

            Hashtable login_attempt = new Hashtable();
            login_attempt.Add("a random thing", "anything");
            login_attempt.Add("test", "different_value");
            login_attempt.Add("sdf", "sdf");

            bool expected = false;
            bool actual;
            actual = target.validate_login(login_attempt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validateloginTest_should_return_false_when_SessionHolder_does_not_contain_same_values()
        {
            Session_Holder target = new Session_Holder();
            target.calulated_key = new Hashtable();
            target.calulated_key.Add("test", "test_value");

            Hashtable login_attempt = new Hashtable();
            login_attempt.Add("a random thing", "anything");
            login_attempt.Add("sdf", "sdf");

            bool expected = false;
            bool actual;
            actual = target.validate_login(login_attempt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validateloginTest_should_return_false_when_SessionHolder_contains_no_values()
        {
            Session_Holder target = new Session_Holder();
            target.calulated_key = new Hashtable();

            Hashtable login_attempt = new Hashtable();
            login_attempt.Add("a random thing", "anything");
            login_attempt.Add("sdf", "sdf");

            bool expected = false;
            bool actual;
            actual = target.validate_login(login_attempt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validateloginTest_should_return_false_when_login_attempt_is_empty()
        {
            Session_Holder target = new Session_Holder();
            target.calulated_key = new Hashtable();
            target.calulated_key.Add("test", "test_value");

            Hashtable login_attempt = new Hashtable();

            bool expected = false;
            bool actual;
            actual = target.validate_login(login_attempt);
            Assert.AreEqual(expected, actual);
        }
    }
}
