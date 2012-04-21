using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Stage_1_picture : Generic_data, IData
    {
        public Stage_1_picture():base("Stage_1_Pic", new List<string> { "0", "1", "2", "3", "4", "5" })
        {
        }
    }
}