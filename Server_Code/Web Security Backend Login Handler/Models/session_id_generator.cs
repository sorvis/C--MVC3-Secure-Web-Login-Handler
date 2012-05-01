using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models
{
    public static class session_id_generator
    {
        public static int make_random_id(IDataRepository db)
        {
            Random rand = new Random();
            int i = rand.Next();
            while (!db.check_for_unique_session_id(i))
            {
                i = rand.Next();
            }
            return i;
        }
    }
}