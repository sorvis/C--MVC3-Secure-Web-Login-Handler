using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Web_Security_Backend_Login_Handler.Controllers.Denial_Service_Protection
{
    class ObjectSerializing
    {
        public static void SerializeObject(string filename, object objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public static object DeSerializeObject(string filename)
        {
            object objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (object)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}