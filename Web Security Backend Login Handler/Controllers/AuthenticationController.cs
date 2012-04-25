﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Security_Backend_Login_Handler.Models;

namespace Web_Security_Backend_Login_Handler.Controllers
{
    public class AuthenticationController : Controller
    {
        private IDataRepository _db;

        public AuthenticationController()
        {
            _db = new EF_Login_Data_Repository();
        }
        public AuthenticationController(IDataRepository db)
        {
            _db = db;
        }

        //
        // GET: /Authentication/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //
        // GET: /authentication/initialize?remote_public_key=43235359345345345&shared_key=4325465423452345&

        public ActionResult initialize(string remote_public_key, long shared_key)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

            string cleaned_pub_key = validate_key.clean_key(remote_public_key);
            long long_remote_pub_key;
            if (validate_key.validate(remote_public_key) &&
                Int64.TryParse(cleaned_pub_key, out long_remote_pub_key)&&
                _db.check_for_unique_pub_key(long_remote_pub_key) &&
                _db.check_that_initialize_is_not_locked())
            {
                // incoming data seems to be good
            }
            else//somone tried passing in a bad key
            {
                _db.store_failed_initialize_attempt(remote_public_key, shared_key);
                ViewBag.message = "lasdflj2fjlwjefljawlj3";
                return View();
            }

            Session_Holder session = new Session_Holder(_db, long_remote_pub_key, shared_key);
            _db.store_session(session);
            ViewBag.message = session.encrypted_message;

            return View();
        }

        //
        // GET: /Authentication/authenticate?data=Picture1=icon.gif;Stage_1_Pic=5;&id=1983929640

        public ActionResult authenticate(string data, int id)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

            Session_Holder session = _db.get_session(id);
            if (session == null || session.expired || !validate_key.validate(data))
            {
                ViewBag.message = "Failed login";
                return View();
            }

            data = validate_key.clean_key(data);
            _db.expire_session(id);
            string decrypted_data = encryption_wrapper.decrypt_message(session.server_key.private_key, session.remote_shared_key, data);
            Raw_Data_Builder login_attempt = new Raw_Data_Builder(decrypted_data);

            if (session.validate_login(db_calculatedKey.convert_list_of_calculatedKey_to_Hashtable(login_attempt.Get_Login_Data)))
            {
                ViewBag.message = "Nuclear missle set to launch. Targeted impact point is: 40.771950, -80.321137 Estimated time of impact: 5 minutes. Radius of effect 5-miles.";
            }
            else
            {
                ViewBag.message = "Failed login";
            }

            return View();
        }

    }
}
