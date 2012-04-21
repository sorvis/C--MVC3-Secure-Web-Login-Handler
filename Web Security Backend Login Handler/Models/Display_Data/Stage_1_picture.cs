using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Stage_1_picture : IData
{
        public string Name { get { return "Stage_1_Pic"; } }
        private string selected_value;
        private List<string> choices = new List<string> { "0","1","2","3","4","5" };

        string IData.ToString()
        {
            selected_value = DataChooser.Get_Random(choices);
            return Name + "=" + selected_value;
        }

        public int GetIndex()
        {
            return choices.IndexOf(selected_value);
        }
    }
}