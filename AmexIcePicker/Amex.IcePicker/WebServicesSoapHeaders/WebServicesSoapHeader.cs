using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services.Protocols;

namespace Amex.IcePicker.WebServicesSoapHeaders
{
    public class WebServiceSoapHeader : SoapHeader
    {
        public string ClientId { get; set; }
        public string Locale { get; set; }
        public string AuthKey { get; set; }
    }
}
