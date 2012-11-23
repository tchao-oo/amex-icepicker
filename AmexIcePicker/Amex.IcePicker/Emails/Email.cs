using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Amex.IcePicker.Emails
{
    [XmlRoot("Email")]
    public class Email
    {
        [XmlAttribute("fromEmail")]
        public string FromEmail { set; get; }
        [XmlAttribute("fromName")]
        public string FromName { set; get; }
        [XmlAttribute("subject")]
        public string Subject { set; get; }
        [XmlText]
        public string HtmlBody { set; get; }
        [XmlIgnore]
        public string ClientId { set; get; }
        [XmlIgnore]
        public string ToEmail { set; get; }
        [XmlIgnore]
        public string ToName { set; get; }
        
    }
}
