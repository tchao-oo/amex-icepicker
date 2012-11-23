using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amex.IcePicker.Results;
using Amex.IcePicker.WebServicesSoapHeaders;
using Amex.IcePicker.Configuration;
using System.Net;
using System.Xml;
using Amex.IcePicker.Xml;

namespace Amex.IcePicker
{
    public class ServiceHelper
    {
        
        public static Result CheckSoapHeader(WebServiceSoapHeader MailSoapHeader)
        {
            Result result = new Result();

            if (MailSoapHeader == null)
            {
                result.Status = 3;
                result.Message = "Authentication failed";
                return result;
            }

            if(!_isValidClient(MailSoapHeader))
            {
                result.Status = 4;
                result.Message = "Authentication failed";
                return result;
            }

            return result;
        }

        private static bool _isValidClient(WebServiceSoapHeader mailSoapHeader)
        {
            foreach (AuthCredentialElement authCred in AuthCredentialsSection.AuthCredentialSettings.AuthCredentials)
            {
                if (authCred.ClientId.Equals(mailSoapHeader.ClientId) && authCred.AuthKey.Equals(mailSoapHeader.AuthKey))
                    return true;
            }

            return false;
        }

        public static string GetHttpWebResponse(string baseUrl)
        {
            XmlDocument xmlDoc = null;
            try
            {
                HttpWebRequest hwRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl));
                hwRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.4) Gecko/20070515 Firefox/2.0.0.4";
                using (HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse())
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(hwResponse.GetResponseStream());
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return Serialization.Serialize(xmlDoc, typeof(XmlDocument));
        }

        //public static string GetDefaultClientId()
        //{
        //    foreach (AuthCredentialElement authCred in AuthCredentialsSection.AuthCredentialSettings.AuthCredentials)
        //    {
        //        if (authCred.DefaultClient)
        //            return authCred.ClientId;
        //    }

        //    return string.Empty;
        //}
    }
}
