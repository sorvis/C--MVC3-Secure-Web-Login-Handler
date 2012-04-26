using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for data_generatorTest and is intended
    ///to contain all data_generatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class data_generatorTest
    {
        private long _sample_pub_key = 5;
        private long _sample_priv_key = 602381;
        private long _sample_shared_key = 1005973;
        private long _sample_remote_pub_key = 3;
        private long _sample_remote_priv_key = 918667;
        private long _sample_remote_shared_key = 1380361;

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


        //[TestMethod()]
        //public void get_random_dataTest()
        //{
        //    IDataRepository db = new Database_mock_up();
        //    string expected = "Picture1=icon.gif;";
        //    string actual;
        //    data_generator data = new data_generator(db, 1234);
        //    actual = data.LoginData;
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod()]
        //public void getStringTest()
        //{
        //    IDataRepository db = new Database_mock_up();
        //    string expected = "Picture1=icon.gif;";
        //    string actual;
        //    data_generator_Accessor data = new data_generator_Accessor(db, 1234);
        //    actual = data.getString();
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod()]
        public void data_generatorConstructorTest_smoke_test()
        {
            IDataRepository db = new Database_mock_up(_sample_remote_pub_key, _sample_remote_shared_key);
            int key = 1234567;
            data_generator target = new data_generator(db, key);
            Assert.IsNotNull(target.LoginData);
        }
    }
}
