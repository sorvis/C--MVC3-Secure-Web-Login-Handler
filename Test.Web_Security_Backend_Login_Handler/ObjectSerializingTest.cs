using Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for ObjectSerializingTest and is intended
    ///to contain all ObjectSerializingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObjectSerializingTest
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
        public void Service_Manager_object_should_still_hold_attempts_when_deserialized()
        {
            string filename = "temp_Service_Manager.data";
            Service_Manager service = new Service_Manager();
            string ip= "my ip";
            service.record_failed_attempt(ip);
            object objectToSerialize = service;
            ObjectSerializing.SerializeObject(filename, objectToSerialize);
            Service_Manager retrieved_service = (Service_Manager)ObjectSerializing.DeSerializeObject(filename);
            Assert.IsNotNull(retrieved_service);
            Assert.IsNotNull(retrieved_service.Attempts[0]);
        }
    }
}
