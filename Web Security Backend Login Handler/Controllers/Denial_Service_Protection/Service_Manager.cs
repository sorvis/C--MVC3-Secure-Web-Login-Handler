using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection
{
    public class Service_Manager
    {
        private List<log_ip_fail> attempts = new List<log_ip_fail>();

        public void record_failed_attempt(string ip)
        {
            log_ip_fail ip_attempt = find_attempt_by_ip(ip);

            if (ip_attempt == null)
            {
                ip_attempt = new log_ip_fail(ip);
            }
            else
            {
                ip_attempt.Record_Failed_Attempt();
            }
            attempts.Add(ip_attempt);
        }

        private log_ip_fail find_attempt_by_ip(string ip)
        {
            return attempts.Find(
                delegate (log_ip_fail item)
                {
                    return item.IP_Address == ip;
                });
        }
    }
}