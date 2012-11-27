using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Amex.IcePicker.Results;
using Amex.IcePicker;
using Amex.IcePicker.Properties;
using Amex.IcePicker.WebServicesSoapHeaders;

namespace AmexIcePickerWebservices
{
    /// <summary>
    /// Summary description for PropertyManager
    /// </summary>
    [WebService(Namespace = "http://amex.icepicker.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PropertyWebservice : System.Web.Services.WebService
    {
        public WebServiceSoapHeader PropertyManagerSoapHeader { get; set; }

        [WebMethod(MessageName = "SetProperty"), SoapHeader("PropertyManagerSoapHeader", Direction = SoapHeaderDirection.In)]
        public string SetProperty(string name, string value)
        {
            Result result = ServiceHelper.CheckSoapHeader(PropertyManagerSoapHeader);

            if (result.Status == 0)
            {
                Property property = new Property();
                if (!String.IsNullOrEmpty(name))
                    property.Name = name;
                property.Value = value;
                property.ClientId = PropertyManagerSoapHeader.ClientId;
                property.Locale = PropertyManagerSoapHeader.Locale;
                property.Value = value;
                return ResultManager.SetPropertyAndSerializeResult(property);
            }

            return ResultManager.Serialize(result);
        }

        [WebMethod(MessageName = "UpdateProperty"), SoapHeader("PropertyManagerSoapHeader", Direction = SoapHeaderDirection.In)]
        public string UpdateProperty(string name, string value)
        {
            Result result = ServiceHelper.CheckSoapHeader(PropertyManagerSoapHeader);

            if (result.Status == 0)
            {
                Property property = new Property();
                property.Value = value;
                property.ClientId = PropertyManagerSoapHeader.ClientId;
                property.Locale = PropertyManagerSoapHeader.Locale;
                property.Value = value;
                property.Name = name;
                return ResultManager.SetPropertyAndSerializeResult(property);
            }

            return ResultManager.Serialize(result);
        }

        [WebMethod, SoapHeader("PropertyManagerSoapHeader", Direction = SoapHeaderDirection.In)]
        public string GetProperty(string name)
        {
            Result result = ServiceHelper.CheckSoapHeader(PropertyManagerSoapHeader);
            if (result.Status == 0)
            {
                return ResultManager.GetSerializedResult(name);

            }
            return ResultManager.Serialize(result);
        }
    }
}
