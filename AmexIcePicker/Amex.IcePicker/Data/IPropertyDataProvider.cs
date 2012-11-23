using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amex.IcePicker.Properties;

namespace Amex.IcePicker.Data
{
    public class PropertyDataProvider
    {
        static IPropertyDataProvider _instance = new PropertyDbDataProvider();

        public static IPropertyDataProvider Instance { get { return _instance; } }
    }

    public interface IPropertyDataProvider
    {
        Property SetProperty(Property property);
        Property GetProperty(string name);
    }
}
