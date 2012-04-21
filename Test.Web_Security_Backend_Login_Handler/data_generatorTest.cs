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
        //    IDataRepository db = new Test_Database();
        //    string expected = "Picture1=icon.gif;";
        //    string actual;
        //    actual = data_generator.get_random_data(db);
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod()]
        //public void getStringTest()
        //{
        //    string expected = "Picture1=icon.gif;";
        //    string actual;
        //    actual = data_generator_Accessor.getString();
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
