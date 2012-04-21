using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Generic_data : IData
    {
        public string Name { get; set; }
        protected string _selected_value;
        protected List<string> _choices;

        public Generic_data(string name, List<string> available_choices)
        {
            Name = name;
            _choices = available_choices;
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
        public string calculate_key(int key)
        {
            return Convert.ToString(int.Parse(Convert.ToString(key)[GetIndex()].ToString()) * key);
        }

        string IData.GetDataString()
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