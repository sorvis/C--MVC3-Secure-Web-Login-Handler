using System;
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

        public ActionResult initialize(string key)
        {
            if (validate_key.validate(key) &&
                db.check_for_unique_key(key)&&
                db.check_that_initialize_is_not_locked())
            {
                key = validate_key.clean_key(key);
            }
            else//somone tried passing in a bad key
            {
                db.store_failed_initialize_attempt(key);
                ViewBag.message = "lasdflj2fjlwjefljawlj3";
                return View();
            }

            int session_id = session_id_generator.make_random_id(db);
            string session_data = data_generator.get_random_data(db);

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
