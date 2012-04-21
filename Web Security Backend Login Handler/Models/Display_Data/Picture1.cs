using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Picture1 : Generic_data, IData
    {
        public Picture1():base("Picture1", new List<string> { "icon.gif", "thing.ico", "different.png" })
        {
        }
    }
}