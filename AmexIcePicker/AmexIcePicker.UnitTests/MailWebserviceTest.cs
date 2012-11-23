using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amex.IcePicker.Results;

namespace AmexIcePicker.UnitTests
{
    [TestClass]
    public class MailWebserviceTest
    {
        protected string clientId = "Amex-IcePicker";
        protected string authKey = "0c8aef2a8f840f5b8e1237f736f46ec7";
        protected string subject = "test email";
        protected string htmlBody = "<b>Test Email</b> <br />Working";
        protected string body = "Test Email basic Working";
        protected string fromName = "Test From";
        protected string fromEmail = "teresateste04@gmail.com";
        protected string toName = "Teresa";
        protected string toEmail = "teresa.chao@ogilvy.com";

        [TestMethod()]
        public void SendBasicHtmlEmail()
        {
            MailWebService.WebServiceSoapHeader soapHeader = new MailWebService.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            MailWebService.MailWebServiceSoapClient target = new MailWebService.MailWebServiceSoapClient();

            string stringResult = target.SendBasicHtmlEmail(soapHeader, subject, htmlBody, fromEmail, toEmail);

            Result result = ResultManager.Deserialize(stringResult);

            Assert.AreEqual(result.Message, "success");
            Assert.AreEqual(result.Status, 0);
        }

        [TestMethod()]
        public void SendHtmlEmail()
        {
            MailWebService.WebServiceSoapHeader soapHeader = new MailWebService.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            MailWebService.MailWebServiceSoapClient target = new MailWebService.MailWebServiceSoapClient();

            string stringResult = target.SendHtmlEmail(soapHeader, subject, htmlBody, true, fromEmail, fromName, toEmail, toName);

            Result result = ResultManager.Deserialize(stringResult);

            Assert.AreEqual(result.Message, "success");
            Assert.AreEqual(result.Status, 0);
        }

        [TestMethod()]
        public void SendBasicEmail()
        {
            MailWebService.WebServiceSoapHeader soapHeader = new MailWebService.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            MailWebService.MailWebServiceSoapClient target = new MailWebService.MailWebServiceSoapClient();

            string stringResult = target.SendBasicEmail(soapHeader, subject, body, fromEmail, toEmail);

            Result result = ResultManager.Deserialize(stringResult);

            Assert.AreEqual(result.Message, "success");
            Assert.AreEqual(result.Status, 0);
        }
    }
}
