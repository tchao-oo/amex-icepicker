using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amex.IcePicker.Properties;
using Amex.IcePicker.Data;
using System.Xml.Serialization;
using System.IO;

namespace Amex.IcePicker.Properties
{
    public class PropertyManager
    {
        public static Property SetProperty(Property property)
        {
            return PropertyDataProvider.Instance.SetProperty(property);
        }

        public static Property GetProperty(string name)
        {
            return PropertyDataProvider.Instance.GetProperty(name);
        }

        public static Property Deserialize(string xml)
        {
            return (Property)Xml.Serialization.Deserialize(xml, typeof(Property));
        }

        public static string GetSerializedProperty(string name)
        {
            return Xml.Serialization.Serialize(GetProperty(name), typeof(Property));
        }

        public static string Serialized(Property property)
        {
            return Xml.Serialization.Serialize(property, typeof(Property));
        }

        public static string SetAndSerializeProperty(Property property)
        {
            return Xml.Serialization.Serialize(SetProperty(property), typeof(Property));
        }
    }
}
