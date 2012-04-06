using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Picture1 : IData
    {
        public string Name { get; set; }
        string IData.ToString()
        {
            return "Picture1=icon.gif";
        }
    }
}