using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public static class DataChooser
    {
        private static Random _rand = null;

        private static Random getRand()
        {
            if (_rand == null)
            {
                _rand = new Random();
            }
            return _rand;
        }

        public static string Get_Random(List<string> list)
        {
            Random rand = getRand();
            return list[rand.Next(list.Count)];
        }
    }
}