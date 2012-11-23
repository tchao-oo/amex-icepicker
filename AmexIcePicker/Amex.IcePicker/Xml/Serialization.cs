using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Amex.IcePicker.Xml
{
    public class Serialization
    {
        public static object Deserialize(string xml, Type objType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objType);
            using (StringReader stringReader = new StringReader(xml))
                return xmlSerializer.Deserialize(stringReader);
        }

        public static object DeserializeFromFile(string filename, Type objType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objType);
            using (FileStream fs = new FileStream(filename, FileMode.Open))
                return xmlSerializer.Deserialize(fs);
        }

        public static string Serialize(Object obj, Type objType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objType);
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}
