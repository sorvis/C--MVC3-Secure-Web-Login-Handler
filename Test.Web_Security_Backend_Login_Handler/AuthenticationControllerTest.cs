﻿using Web_Security_Backend_Login_Handler.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Collections;
using Web_Security_Backend_Login_Handler.Models;

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

        private string _good_login_message = "Nuclear missle set to launch. Targeted impact point is: 40.771950, -80.321137 Estimated time of impact: 5 minutes radius of effect 5-miles.";
        private string _bad_login_message = "Failed login";

        [TestMethod()]
        public void initializeTest_when_given_good_key_should_return_real_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43235359345345345"; // includes key checking items
            long shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreNotEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }

        [TestMethod()]
        public void initializeTest_when_given_bad_key_should_return_fake_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43335359345345345"; // does not include key checking items
            long shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }

        [TestMethod()]
        public void initializeTest_when_given_string_in_pubKey_should_return_fake_data()
        {
            AuthenticationController target = new AuthenticationController(new Database_mock_up());
            string remote_public_key = "43235359asdfasdf5"; // includes key checking items
            long shared_key = 4325465423452345;
            ViewResult actual = target.initialize(remote_public_key, shared_key) as ViewResult;
            Assert.IsNotNull(actual.ViewBag.message);
            Assert.AreEqual("lasdflj2fjlwjefljawlj3", actual.ViewBag.message);
        }

        private string make_Hashkey_to_string(Hashtable hash)
        {
            string keyString = string.Empty;
            foreach (DictionaryEntry item in hash)
            {
                keyString+=item.Key+"="+item.Value+";";
            }
            return keyString;
        }

        [TestMethod()]
        public void authenticateTest_should_launch_nuke_when_given_proper_login_data()
        {
            Database_mock_up db = new Database_mock_up();
            AuthenticationController target = new AuthenticationController(db);
            string data = validate_key.dirty_key(make_Hashkey_to_string(db.calculatedKey));
            int id = db.sessionID;
            ViewResult actual = target.authenticate(data,id) as ViewResult;
            Assert.AreEqual(_good_login_message, actual.ViewBag.message);
        }

        [TestMethod()]
        public void authenticateTest_should_expire_session_during_login_attempt()
        {
            Database_mock_up db = new Database_mock_up();
            AuthenticationController_Accessor target = new AuthenticationController_Accessor(db);
            string data = validate_key.dirty_key(make_Hashkey_to_string(db.calculatedKey));
            int id = db.sessionID;
            Assert.IsFalse(((Database_mock_up)((AuthenticationController_Accessor)target)._db).is_session_expired(id));
            ViewResult actual = target.authenticate(data, id) as ViewResult;
            Assert.IsTrue(((Database_mock_up)((AuthenticationController_Accessor)target)._db).is_session_expired(id));
        }

        private Hashtable seedHashWithBadValues(Hashtable hash)
        {
            Hashtable newHash = new Hashtable();
            foreach (DictionaryEntry item in hash)
            {
                newHash[item.Key] = 4444444;
            }
            return newHash;
        }

        [TestMethod()]
        public void authenticateTest_should_fail_login_when_given_incorrect_login_data()
        {
            Database_mock_up db = new Database_mock_up();
            AuthenticationController target = new AuthenticationController(db);
            db.calculatedKey = seedHashWithBadValues(db.calculatedKey);
            string data = validate_key.dirty_key(make_Hashkey_to_string(db.calculatedKey));
            int id = db.sessionID;
            ViewResult actual = target.authenticate(data, id) as ViewResult;
            Assert.AreEqual(_bad_login_message, actual.ViewBag.message);
        }

        [TestMethod()]
        public void authenticateTest_should_fail_login_when_given_bad_session_id()
        {
            Database_mock_up db = new Database_mock_up();
            AuthenticationController target = new AuthenticationController(db);
            string data = validate_key.dirty_key(make_Hashkey_to_string(db.calculatedKey));
            int id = 111111;
            ViewResult actual = target.authenticate(data, id) as ViewResult;
            Assert.AreEqual(_bad_login_message, actual.ViewBag.message);
        }
    }
}
