using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection
{
    [Serializable()]
    public class Service_Manager : ISerializable
    {
        private List<log_ip_fail> _attempts = new List<log_ip_fail>();
        public List<log_ip_fail> Attempts { get { return _attempts; } }
        private int _allowed_attempts = 3;
        private long _Ticks_between_attempts = 60 * 10000000;
        private long _Ticks_until_user_can_unlock = 180 * 10000000; // 10,000,000 is number of ticks in one second

        public Service_Manager()
        {

        }

        public void record_failed_attempt(string ip)
        {
            log_ip_fail ip_attempt = find_attempt_by_ip(ip);

            if (ip_attempt == null)
            {
                ip_attempt = new log_ip_fail(ip);
                _attempts.Add(ip_attempt);
            }
            else
            {
                ip_attempt.Record_Failed_Attempt();
            }
        }

        public bool is_ip_locked(string ip)
        {
            log_ip_fail ip_attempt = find_attempt_by_ip(ip);
            if (ip_attempt == null  // this ip has never failed an attempt so let it through
                || (ip_attempt.Fail_Count <= _allowed_attempts // allow ip through since it has not been locked by to many fails
                && ip_attempt.Ticks_Since_Last_Failed_Attempt() > _Ticks_between_attempts)) // check to see if lockout time still applies
            {
                return false;   // user is not locked
            }
            else if (_Ticks_until_user_can_unlock < ip_attempt.Ticks_Since_Last_Failed_Attempt())
            {// user's account is locked, but they have reached the time to unlock so reset users data
                ip_attempt = new log_ip_fail(ip);
                return false;
            }
            else
            {
                return true; // user is locked so he cannot access system
            }
        }

        private log_ip_fail find_attempt_by_ip(string ip)
        {
            return _attempts.Find(
                delegate (log_ip_fail item)
                {
                    return item.IP_Address == ip;
                });
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_attempts", _attempts);
        }
        public Service_Manager(SerializationInfo info, StreamingContext ctxt)
        {
            _attempts = (List<log_ip_fail>)info.GetValue("_attempts", typeof(List<log_ip_fail>));
        }
    }
}