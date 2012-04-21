using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    public class Picture1 : IData
    {
        public string Name { get { return "Picture1"; } }
        private string selected_value;
        private List<string> choices = new List<string>{"icon.gif"};

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