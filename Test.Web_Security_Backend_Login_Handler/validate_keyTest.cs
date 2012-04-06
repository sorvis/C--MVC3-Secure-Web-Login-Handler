using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for validate_keyTest and is intended
    ///to contain all validate_keyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class validate_keyTest
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
        public void validateTest()
        {
            string key = "se2hgyt9875hgkjhjf";
            bool expected = true;
            bool actual;
            actual = validate_key.validate(key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void dirty_keyTest()
        {
            string key = "sehgyt875hgkjhjf";
            string expected = "se2hgyt9875hgkjhjf";
            string actual;
            actual = validate_key.dirty_key(key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void clean_keyTest()
        {
            string key = "se2hgyt9875hgkjhjf";
            string expected = "sehgyt875hgkjhjf";
            string actual;
            actual = validate_key.clean_key(key);
            Assert.AreEqual(expected, actual);
        }
    }
}
