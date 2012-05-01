using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models.Display_Data
{
    interface IData
    {
        /// <summary>
        /// Gets a random choice from the list of avaliable elements in the class
        /// </summary>
        /// <returns></returns>
        string GetDataString();
        string Name { get;}
        string Key_Name { get;}
        Hashtable CalculatedKey { get;}
        string pick_random_item();
    }
}
