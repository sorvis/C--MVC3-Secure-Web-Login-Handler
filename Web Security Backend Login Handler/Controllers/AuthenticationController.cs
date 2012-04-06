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
            if (validate_key.validate(key))
            {
                key = validate_key.clean_key(key);
            }
            else//somone tried passing in a bad key
            {
                ViewBag.message = "lasdflj2fjlwjefljawlj3";
                return View();
            }

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
