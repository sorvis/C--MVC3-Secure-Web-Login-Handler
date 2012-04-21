﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Security_Backend_Login_Handler.Models.Display_Data;

namespace Web_Security_Backend_Login_Handler.Models
{
    public static class data_generator
    {
        private static List<IData> _data= new List<IData>{new Picture1(), new Stage_1_picture()};
        private static string getString()
        {
            string temp="";
            foreach(IData item in _data)
            {
                temp+=item.ToString()+";";
            }
            return temp;
        }
        public static string get_random_data(IDataRepository db)
        {
            string random_data = getString();
            int i = 0;
            while (!db.check_for_unique_data_string(random_data))
            {
                random_data = getString();
                i++;

                // stop infinint loop incase we run out of possible login combinations
                if (i > 100)
                {
                    return random_data;
                }
            }
            return random_data;
        }
    }
}