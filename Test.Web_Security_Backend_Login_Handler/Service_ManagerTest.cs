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
        public void record_failed_attemptTest()
        {
            Service_Manager target = new Service_Manager();
            string ip = "make belive IP";
            target.record_failed_attempt(ip);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
