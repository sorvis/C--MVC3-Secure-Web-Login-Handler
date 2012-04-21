using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Security_Backend_Login_Handler.Models.Display_Data;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class data_generator
    {
        private static List<string> colors = new List<string>{"Red", "Orange", "Yellow","Green", "Blue","Indigo"};
        private static List<IData> _data= new List<IData>{new Generic_data("Stage_1_color",colors)};

        public string LoginData { get; set; }
        public Hashtable CalulatedKey { get; set; }
        private int _key;
        public data_generator(IDataRepository db, int key)
        {
            this._key = key;
            this.CalulatedKey = new Hashtable();
            this.LoginData = get_random_data(db);
        }
        private string getString()
        {
            string temp="";
            foreach(IData item in _data)
            {
                item.pick_random_item();
                temp+=item.GetDataString()+";";
                CalulatedKey[item.Name] = item.calculate_key(_key);
            }
            return temp;
        }
        private string get_random_data(IDataRepository db)
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