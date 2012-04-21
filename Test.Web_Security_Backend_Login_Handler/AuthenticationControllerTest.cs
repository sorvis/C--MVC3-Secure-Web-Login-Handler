using Web_Security_Backend_Login_Handler.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for AuthenticationControllerTest and is intended
    ///to contain all AuthenticationControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuthenticationControllerTest
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
        public void initializeTest_when_given_good_key_should_return_real_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43235359345345345"; // includes key checking items
            ulong shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreNotEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }

        [TestMethod()]
        public void initializeTest_when_given_bad_key_should_return_fake_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43335359345345345"; // does not include key checking items
            ulong shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }

        [TestMethod()]
        public void initializeTest_when_given_string_in_pubKey_should_return_fake_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43235359asdfasdf5"; // includes key checking items
            ulong shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }


        [TestMethod()]
        public void authenticateTest()
        {
            AuthenticationController target = new AuthenticationController(); // TODO: Initialize to an appropriate value
            string data = string.Empty; // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.authenticate(data, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
