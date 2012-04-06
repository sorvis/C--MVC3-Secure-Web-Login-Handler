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
        private IDataRepository db = new DataEntities();

        //
        // GET: /Authentication/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //
        // GET: /Authentication/initialize?key=fdlkgjlfjasf&

        public ActionResult initialize(string remote_public_key)
        {

            if (validate_key.validate(remote_public_key) &&
                db.check_for_unique_key(remote_public_key)&&
                db.check_that_initialize_is_not_locked())
            {
                remote_public_key = validate_key.clean_key(remote_public_key);
            }
            else//somone tried passing in a bad key
            {
                db.store_failed_initialize_attempt(remote_public_key);
                ViewBag.message = "lasdflj2fjlwjefljawlj3";
                return View();
            }

            Initialize_Session_Holder session = new Initialize_Session_Holder(db, remote_public_key);
            db.store_initialize_data(session);

            ViewBag.message = session.encrypted_message;
            return View();
        }

        //
        // GET: /Authentication/authenticate?data=fdlkgjlfjasf&id=2354

        public ActionResult authenticate(string data, int id)
        {
            return View();
        }

    }
}
