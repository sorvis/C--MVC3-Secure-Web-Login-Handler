using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Web_Security_Backend_Login_Handler.Models
{
    public class db_calculatedKey
    {
        [Key]
        public int id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public db_calculatedKey()
        {

        }
        public db_calculatedKey(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static List<db_calculatedKey> convert_Hashtable_to_list_of_calculatedKey(Hashtable hash)
        {
            List<db_calculatedKey> keyList = new List<db_calculatedKey>();
            foreach (DictionaryEntry item in hash)
            {
                keyList.Add(new db_calculatedKey((string)item.Key, Convert.ToString(item.Value)));
            }
            return keyList;
        }

        public static Hashtable convert_list_of_calculatedKey_to_Hashtable(List<db_calculatedKey> list)
        {
            Hashtable hash = new Hashtable();
            foreach (db_calculatedKey item in list)
            {
                hash.Add(item.Key, item.Value);
            }
            return hash;
        }
    }
}