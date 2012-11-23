using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using Amex.IcePicker.Results;
using Amex.IcePicker.Emails;
using Amex.IcePicker.Configuration;
using Amex.IcePicker;
using Amex.IcePicker.WebServicesSoapHeaders;

namespace AmexIcePickerWebservices
{
    /// <summary>
    /// Summary description for MailWebService
    /// </summary>
    [WebService(Namespace = "http://platform.ogilvyeurope.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MailWebService : System.Web.Services.WebService
    {
        public WebServiceSoapHeader MailSoapHeader { get; set; }

        [WebMethod(MessageName = "SendBasicEmail"), SoapHeader("MailSoapHeader", Direction = SoapHeaderDirection.In)]
        public string SendBasicEmail(string subject, string body, string fromEmail, string toEmail)
        {
            return SendHtmlEmail(subject, body, false, fromEmail, fromEmail, toEmail, toEmail);
        }

        [WebMethod(MessageName = "SendBasicHtmlEmail"), SoapHeader("MailSoapHeader", Direction = SoapHeaderDirection.In)]
        public string SendBasicHtmlEmail(string subject, string htmlBody, string fromEmail, string toEmail)
        {
            return SendHtmlEmail(subject, htmlBody, true, fromEmail, fromEmail, toEmail, toEmail);
        }

        [WebMethod(MessageName = "SendHtmlEmail"), SoapHeader("MailSoapHeader", Direction = SoapHeaderDirection.In)]
        public string SendHtmlEmail(string subject, string body, bool isHtml, string fromEmail, string fromName, string toEmail, string toName)
        {
            Result result = ServiceHelper.CheckSoapHeader(MailSoapHeader);

            if (result.Status == 0)
            {
                try
                {
                    result.Message = EmailManager.SendEmail(subject, body, isHtml, fromEmail, fromEmail, toEmail, toEmail);

                    if (result.Message.Equals("success"))
                    {
                        Email email = new Email();
                        email.ClientId = MailSoapHeader.ClientId;
                        email.Subject = subject;
                        email.HtmlBody = body;
                        email.ToEmail = toEmail;
                        email.ToName = toName;
                        email.FromEmail = fromEmail;
                        email.FromName = fromName;

                        result.Message = EmailManager.SaveEmail(email);
                    }
                }
                catch (Exception ex)
                {
                    result.Status = 1;
                    result.Message = ex.Message;
                }
            }

            return ResultManager.Serialize(result);
        }

    }
}
