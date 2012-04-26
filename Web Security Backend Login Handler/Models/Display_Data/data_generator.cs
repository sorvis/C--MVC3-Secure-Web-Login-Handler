using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Security_Backend_Login_Handler.Models.Display_Data;
using System.Collections;
using Web_Security_Backend_Login_Handler.Models.Display_Data.Stages;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class data_generator
    {
        //private static List<string> colors = new List<string>{"Red", "Orange", "Yellow","Green", "Blue","Indigo"};
                private static List<string> list_of_colors = new List<string> { 
                "0xFF0000"/*red*/, 
                "0xFF6600"/*orange*/,
                "0xFFFF00"/*yellow*/,
                "0x009900"/*green*/,
                "0x0099FF"/*blue*/,
                "0x660099"/*indigo*/,
                "0x787878"/*grey*/            
            };
        private static List<string> list_of_images = new List<string> { "0","1","2","3"};

        private List<IData> _data;

        public string LoginData { get; set; }
        public Hashtable CalulatedKey { get; set; }
        private int _key;

        public data_generator(IDataRepository db, int key)
        {
            this._key = key;
            this.CalulatedKey = new Hashtable();
            initialize_data_list(key);
            this.LoginData = get_random_data(db);
        }

        private void initialize_data_list(int master_key)
        {
            _data = new List<IData>{
            new Generic_data("stage1_color","stage1_password1", master_key, list_of_colors),
            new Generic_data("stage1_img","stage1_password2", master_key, list_of_images),

            new Gridbox_data(new List<Generic_data>{
                new Generic_data("stage2_color", "not set", master_key, list_of_colors),
                new Generic_data("stage2_img","not set", master_key, list_of_images)},
                "stage2_box", 25),

            new Generic_data("stage3_color", "stage3_password",master_key, list_of_colors),

            new Button_Key_data("stage1_btn1", true),
            new Button_Key_data("stage2_btn3", true),
            new Button_Key_data("stage3_btn1", true)
        };
            
        }

        private string getString()
        {
            string temp="";
            foreach(IData item in _data)
            {
                item.pick_random_item();
                if (item.Name != "DEFAULT OBJECT")
                {
                    temp += item.GetDataString() + ";";
                }
                add_hash_to_calculatedKey(item.CalculatedKey);
            }
            return temp;
        }
        private void add_hash_to_calculatedKey(Hashtable hash)
        {
            foreach (DictionaryEntry entry in hash)
            {
                CalulatedKey.Add(entry.Key,entry.Value);
            }
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