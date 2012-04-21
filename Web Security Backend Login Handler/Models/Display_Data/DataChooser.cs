using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public static class DataChooser
    {
        public static string Get_Random(List<string> list)
        {
            Random rand = new Random();
            return list[rand.Next(list.Count)];
        }
    }
}