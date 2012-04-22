using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

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

        [TestMethod()]
        public void check_for_unique_pub_keyTest_should_allow_a_new_key_to_be_used()
        {
            DataEntities db = new DataEntities();
            //db.failed_logins.Add(new data_failed_login_attempt("sdfrsdf", 2345));
            //db.SaveChanges();
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(db);
            target.reset_db();

            ulong key = 34534534534545;
            bool expected = true;
            bool actual;
            actual = target.check_for_unique_pub_key(key);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for check_for_unique_data_string
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void check_for_unique_data_stringTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            string data = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.check_for_unique_data_string(data);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for check_for_unique_session_id
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void check_for_unique_session_idTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.check_for_unique_session_id(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for check_that_initialize_is_not_locked
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void check_that_initialize_is_not_lockedTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.check_that_initialize_is_not_locked();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for expire_session
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void expire_sessionTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            target.expire_session(id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for get_session
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void get_sessionTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Session_Holder expected = null; // TODO: Initialize to an appropriate value
            Session_Holder actual;
            actual = target.get_session(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for store_failed_initialize_attempt
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void store_failed_initialize_attemptTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            string public_key = string.Empty; // TODO: Initialize to an appropriate value
            ulong shared_key = 0; // TODO: Initialize to an appropriate value
            target.store_failed_initialize_attempt(public_key, shared_key);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for store_session
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Web Security Backend Login Handler\\Web Security Backend Login Handler", "/")]
        [UrlToTest("http://localhost:53292/")]
        public void store_sessionTest()
        {
            EF_Login_Data_Repository target = new EF_Login_Data_Repository(); // TODO: Initialize to an appropriate value
            Session_Holder session = null; // TODO: Initialize to an appropriate value
            target.store_session(session);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
