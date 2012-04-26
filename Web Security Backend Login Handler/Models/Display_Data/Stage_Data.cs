using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Stage_Data:IData
    {
        private static List<string> colors = new List<string> { 
                "0xFF0000"/*red*/, 
                "0xFF6600"/*orange*/,
                "0xFFFF00"/*yellow*/,
                "0x009900"/*green*/,
                "0x0099FF"/*blue*/,
                "0x660099"/*indigo*/,
                "0x787878"/*grey*/            
            };
        private static List<string> images = new List<string> { "0","1","2","3"};
        public string Name { get; set; }
        private string _stage_name;
        private List<Generic_data> data_items = new List<Generic_data>();

        public Stage_Data(string stage_name)
        {
            _stage_name = stage_name;

        }

        private string pick_image()
        {
            return DataChooser.Get_Random(images);
        }
        private string pick_color()
        {
            return DataChooser.Get_Random(colors);
        }

        public string GetDataString()
        {
            throw new NotImplementedException();
        }

        public int calculate_key(int key)
        {
            throw new NotImplementedException();
        }

        public string pick_random_item()
        {
            throw new NotImplementedException();
        }


        public string Key_Name
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.Hashtable CalculatedKey
        {
            get { throw new NotImplementedException(); }
        }
    }
}