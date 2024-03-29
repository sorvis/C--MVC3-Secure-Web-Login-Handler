﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class Raw_Data_Builder
    {
        private List<db_calculatedKey> _data = new List<db_calculatedKey>();
        public List<db_calculatedKey> Get_Login_Data { get { return _data; } }
        public Raw_Data_Builder(string plain_text_data)
        {
            // strip off trailing semicolon
            if (plain_text_data[plain_text_data.Count()-1] == ';')
            {
                plain_text_data = plain_text_data.Substring(0, plain_text_data.Count() - 1);
            }
            foreach (string element in plain_text_data.Split(';'))
            {
                _data.Add(new db_calculatedKey(element.Split('=')[0], element.Split('=')[1]));
                //_data.Add(element.Split('=')[0], element.Split('=')[1]);
            }
        }
    }
}