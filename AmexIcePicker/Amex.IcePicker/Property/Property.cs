using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;

namespace Amex.IcePicker.Properties
{
    [XmlRoot("Property")]
    public class Property
    {
        //public string Brand { get; set; }
        //public string Project { get; set; }
        public string ClientId { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        
        /*
        private static Byte[] StringToUTF8ByteArray(String xmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(xmlString);
            return byteArray;
        }

        public static Property Deserialize(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Property));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (Property)xs.Deserialize(memoryStream);
        }
        */

    }
}