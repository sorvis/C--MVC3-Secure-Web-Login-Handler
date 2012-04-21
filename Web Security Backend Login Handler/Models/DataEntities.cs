using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class DataEntities:DbContext
    {
        public DbSet<Session_Holder> Session { get; set; }
        public DbSet<Server_keys> server_keys { get; set; }
        public DbSet<data_failed_login_attempt> failed_logins { get; set; }
    }
}