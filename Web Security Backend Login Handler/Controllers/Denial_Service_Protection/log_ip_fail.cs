using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection
{
    [Serializable()]
    public class log_ip_fail : ISerializable
    {
        public string IP_Address { get; set; }
        public DateTime Last_Attempt { get; set; }
        public int Fail_Count { get; set; }

        public log_ip_fail(string ip)
        {
            IP_Address = ip;
            Last_Attempt = DateTime.Now;
            Fail_Count = 1; // This is the first instance of this ip so there is only one fail
        }
        public void Record_Failed_Attempt()
        {
            Last_Attempt = DateTime.Now;
            Fail_Count++;
        }
        public long Ticks_Since_Last_Failed_Attempt()
        {
            return DateTime.Now.Ticks - Last_Attempt.Ticks;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IP_Address", IP_Address);
            info.AddValue("Last_Attempt", Last_Attempt);
            info.AddValue("Fail_Count", Fail_Count);
        }
        public log_ip_fail(SerializationInfo info, StreamingContext ctxt)
        {
            IP_Address = (string)info.GetValue("IP_Address", typeof(string));
            Last_Attempt = (DateTime)info.GetValue("Last_Attempt", typeof(DateTime));
            Fail_Count = (int)info.GetValue("Fail_Count", typeof(int));
        }
    }
}