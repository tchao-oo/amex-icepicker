using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Amex.IcePicker.Data;
using Amex.IcePicker.Properties;

namespace Amex.IcePicker.Results
{
    public class ResultManager
    {
        public static Result SetProperty(Property property)
        {
            Result result = new Result();
            try { result.Message = PropertyManager.SetAndSerializeProperty(property); }
            catch (Exception ex)
            {
                result.Status = 2;
                result.Message = ex.Message;
            }
            return result;
        }

        public static Result GetProperty(string name)
        {
            Result result = new Result();
            try
            {
                result.Message = PropertyManager.GetSerializedProperty(name);
                result.Status = 0;
            }
            catch (Exception ex)
            {
                result.Status = 2;
                result.Message = ex.Message;
            }
            return result;
        }

        public static string GetSerializedResult(string name)
        {
            return Xml.Serialization.Serialize(GetProperty(name), typeof(Result));
        }

        public static string SetPropertyAndSerializeResult(Property property)
        {
            return Xml.Serialization.Serialize(SetProperty(property), typeof(Result));
        }

        public static string Serialize(Result result)
        {
            return Xml.Serialization.Serialize(result, typeof(Result));
        }

        public static Result Deserialize(string xml)
        {
            return (Result)Xml.Serialization.Deserialize(xml, typeof(Result));
        }
    }
}
