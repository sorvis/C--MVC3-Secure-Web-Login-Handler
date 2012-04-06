using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        // GET: /Analysis/initialize?key=fdlkgjlfjasf&

        public ActionResult initialize(string key)
        {
            return View();
        }

        //
        // GET: /Analysis/authenticate?data=fdlkgjlfjasf&id=2354

        public ActionResult initialize(string data, int id)
        {
            return View();
        }

    }
}
