using Web_Security_Backend_Login_Handler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for Raw_Data_BuilderTest and is intended
    ///to contain all Raw_Data_BuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Raw_Data_BuilderTest
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
        public void Raw_Data_BuilderConstructorTest()
        {
            string plain_text_data = "Name=me;id=32;";
            Raw_Data_Builder_Accessor target = new Raw_Data_Builder_Accessor(plain_text_data);
            Hashtable expected = new Hashtable();
            expected.Add("Name", "me");
            expected.Add("id", "32");
            CollectionAssert.AreEqual(expected, target._data);
        }
    }
}
