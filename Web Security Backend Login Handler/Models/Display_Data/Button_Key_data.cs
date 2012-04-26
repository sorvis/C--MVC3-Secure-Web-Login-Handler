using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Button_Key_data:IData
    {
        public string Name { get { return "DEFAULT OBJECT"; } }
        public string Key_Name { get; set; }
        private bool _key;
        public Hashtable CalculatedKey { get { Hashtable temp = new Hashtable(); temp.Add(Key_Name, Convert.ToString(_key)); return temp; } }

        public Button_Key_data(string key_name, bool is_button_selected)
        {
            Key_Name = key_name;
            _key = is_button_selected;
        }

        public string GetDataString()
        {
            return "DEFAULT OBJECT";
        }

        public int calculate_key(int key)
        {
            return Convert.ToInt32(_key);
        }

        public string pick_random_item()
        {
            return "DEFAULT OBJECT";
        }
    }
}