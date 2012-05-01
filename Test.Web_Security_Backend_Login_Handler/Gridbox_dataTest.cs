using Web_Security_Backend_Login_Handler.Models.Display_Data.Stages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Web_Security_Backend_Login_Handler.Models.Display_Data;
using System.Collections.Generic;
using System.Collections;

namespace Test.Web_Security_Backend_Login_Handler
{
    
    
    /// <summary>
    ///This is a test class for Gridbox_dataTest and is intended
    ///to contain all Gridbox_dataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Gridbox_dataTest
    {
        private static List<string> list_of_colors = new List<string> { 
                "0xFF0000"/*red*/, 
                "0xFF6600"/*orange*/,
                "0xFFFF00"/*yellow*/,
                "0x009900"/*green*/,
                "0x0099FF"/*blue*/,
                "0x660099"/*indigo*/,
                "0x787878"/*grey*/            
            };
        private static List<string> list_of_images = new List<string> { "0", "1", "2", "3" };

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
        public void Gridbox_dataConstructorTest()
        {
            int master_key = 12345678;
            List<Generic_data> dataList = new List<Generic_data>{
                new Generic_data("stage2_color", "not set", master_key, list_of_colors),
                new Generic_data("stage2_img","not set", master_key, list_of_images)};
            string gridbox_key_suffix = "box";
            int number_of_gridboxes = 25;
            Gridbox_data target = new Gridbox_data(dataList, gridbox_key_suffix, number_of_gridboxes);
            foreach (DictionaryEntry item in target.CalculatedKey)
            {
                Assert.IsTrue(Int32.Parse((string)item.Value) > 0);
            }
        }
    }
}
