using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        string calculate_key(int key);
        string pick_random_item();
    }
}
