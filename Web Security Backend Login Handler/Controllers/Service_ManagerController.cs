using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection;
using System.IO;
using System.Web.Hosting;

namespace Web_Security_Backend_Login_Handler.Controllers
{
    public class Service_ManagerController : Controller
    {
        private Service_Manager _service_manager;
        private string _service_manager_save_file;
        public Service_ManagerController()
        {
            _service_manager_save_file = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "temp_Service_Manager.data");
            _service_manager = load_Service_Manger();
        }

        //
        // GET: /Service_Manager_/

        public ActionResult Index()
        {
            ViewBag.service_manager = _service_manager;
            return View();
        }

        private Service_Manager load_Service_Manger()
        {
            if (System.IO.File.Exists(_service_manager_save_file))
            {
                return (Service_Manager)ObjectSerializing.DeSerializeObject(_service_manager_save_file);
            }
            else
            {
                return new Service_Manager();
            }
        }

    }
}
