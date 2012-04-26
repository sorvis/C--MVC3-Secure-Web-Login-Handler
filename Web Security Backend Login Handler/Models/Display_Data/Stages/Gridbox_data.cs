using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data.Stages
{
    public class Gridbox_data : IData
    {
        public string Name { get; set; }
        public string Key_Name { get; set; }
        public Hashtable CalculatedKey { get; set; }
        private List<Generic_data> _dataList;
        private int _number_of_gridboxes;
        private string _gridbox_key_suffix;

        public Gridbox_data(List<Generic_data> dataList, string gridbox_key_suffix, int number_of_gridboxes)
        {
            _dataList = dataList;
            _number_of_gridboxes = number_of_gridboxes;
            _gridbox_key_suffix = gridbox_key_suffix;
            CalculatedKey = new Hashtable();
            pick_random_item();
        }

        public string GetDataString()
        {
            string dataString = "";
            foreach (Generic_data item in _dataList)
            {
                dataString += item.GetDataString()+";";
            }
            if (dataString.Length > 1) // drop off trailing ";"
            {
                dataString = dataString.Remove(dataString.Length - 1, 1);
            }
            return dataString;
        }

        public string pick_random_item()
        {
            int multiplied_key = 1;
            foreach (Generic_data item in _dataList)
            {
                item.pick_random_item();
                multiplied_key *= item.calculate_key();
            }

            int quotient = multiplied_key / _number_of_gridboxes;
            int remainder = multiplied_key % _number_of_gridboxes;

            CalculatedKey[make_box_label(_gridbox_key_suffix, remainder+1)] = Convert.ToString(quotient);
            return null;
        }

        private string make_box_label(string suffix, int boxNumber)
        {
            return suffix + Convert.ToString(boxNumber).TrimStart('-');
        }

        private List<string> make_list_of_box_labels(string suffix, int number_of_boxes)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < number_of_boxes; i++)
            {
                list.Add(make_box_label(suffix, i+1));
            }
            return list;
        }
    }
}