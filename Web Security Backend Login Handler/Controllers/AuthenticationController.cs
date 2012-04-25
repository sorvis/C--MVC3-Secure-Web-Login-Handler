using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Security_Backend_Login_Handler.Models;
using Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection;
using System.ComponentModel;
using System.Web.Hosting;
using System.IO;

namespace Web_Security_Backend_Login_Handler.Controllers
{
    public class AuthenticationController : Controller
    {
        private IDataRepository _db;
        private Service_Manager _service_manager;
        private string _service_manager_save_file = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "temp_Service_Manager.data");

        public AuthenticationController()
        {
            _db = new EF_Login_Data_Repository();
            _service_manager = load_Service_Manger();
        }
        public AuthenticationController(IDataRepository db)
        {
            _db = db;
            _service_manager = load_Service_Manger();
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

        private void save_Service_Manager()
        {
            ObjectSerializing.SerializeObject(_service_manager_save_file, _service_manager);
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

            if (_service_manager.is_ip_locked(clientIPAddress))
            {
                ViewBag.message = "Server has been locked!";
                save_Service_Manager();
                return View();
            }

            string cleaned_pub_key = validate_key.clean_key(remote_public_key);
            long long_remote_pub_key;
            if ( validate_key.validate(remote_public_key) &&
                Int64.TryParse(cleaned_pub_key, out long_remote_pub_key)&&
                _db.check_for_unique_pub_key(long_remote_pub_key) &&
                _db.check_that_initialize_is_not_locked())
            {
                // incoming data seems to be good
            }
            else//somone tried passing in a bad key
            {
                _db.store_failed_initialize_attempt(remote_public_key, shared_key);
                _service_manager.record_failed_attempt(clientIPAddress);
                ViewBag.message = "lasdflj2fjlwjefljawlj3";
                save_Service_Manager();
                return View();
            }

            Session_Holder session = new Session_Holder(_db, long_remote_pub_key, shared_key);
            _db.store_session(session);
            ViewBag.message = session.encrypted_message;

            save_Service_Manager();
            return View();
        }

        //
        // GET: /Authentication/authenticate?data=Picture1=icon.gif;Stage_1_Pic=5;&id=1983929640

        public ActionResult authenticate(string data, int id)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

            Session_Holder session = _db.get_session(id);
            if (_service_manager.is_ip_locked(clientIPAddress) && session == null || session.expired || !validate_key.validate(data))
            {
                ViewBag.message = "Failed login";
                _service_manager.record_failed_attempt(clientIPAddress);
                save_Service_Manager();
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
                _service_manager.record_failed_attempt(clientIPAddress);
            }

            save_Service_Manager();
            return View();
        }

    }
}
