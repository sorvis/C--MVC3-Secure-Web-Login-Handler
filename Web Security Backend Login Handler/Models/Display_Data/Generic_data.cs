using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Generic_data : IData
    {
        public string Name { get; set; }
        public string Key_Name { get; set; }
        protected string _selected_value;
        public string Selected_Value { get { return _selected_value; } }
        protected List<string> _choices;
        private int _master_key;
        public Hashtable CalculatedKey { get { Hashtable temp = new Hashtable(); temp.Add(Key_Name, calculate_key()); return temp; } }

        public Generic_data(string name, string key_name, int key, List<string> available_choices)
        {
            Name = name;
            Key_Name = key_name;
            _choices = available_choices;
            _master_key = key;
            pick_random_item();
        }

        private int GetIndex()
        {
            return _choices.IndexOf(_selected_value);
        }

        /// <summary>
        /// Multiplies the key by the index of the key where the index is defined by the number of the chosen picture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int calculate_key()
        {
            return int.Parse(Convert.ToString(_master_key)[GetIndex()].ToString()) * _master_key;
        }

        public string GetDataString()
        {
            return Name + "=" + _selected_value;
        }

        /// <summary>
        /// Picks a random element out of the available emements and then sets classes _selected_value to that element
        /// </summary>
        /// <returns>In addition to saving element it returns chosen element.</returns>
        public string pick_random_item()
        {
            _selected_value = DataChooser.Get_Random(_choices);
            return _selected_value;
        }
    }
}