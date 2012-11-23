using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Net;
using Amex.IcePicker.Data;

namespace Amex.IcePicker.Emails
{
    public class EmailManager
    {

        public static string SendEmail(string subject, string body, string fromName, string fromEmail, string toName, string toEmail)
        {
            return SendEmail(subject, body, false, fromName, fromEmail, toName, toEmail);
        }

        public static string SendEmail(string subject, string body, bool isHtml, string fromName, string fromEmail, string toName, string toEmail)
        {
            try
            {
                //Send email to self
                MailMessage msg = new MailMessage();

                // build message contents
                msg.IsBodyHtml = isHtml;
                msg.To.Add(new MailAddress(toEmail, toName));
                msg.From = new MailAddress(fromEmail, fromName);
                msg.Subject = subject;
                msg.Body = body;

                SmtpClient mailClient = new SmtpClient();

                if (!string.IsNullOrEmpty(Configuration.ConfigurationManager.NetworkCredentialUsername) && !string.IsNullOrEmpty(Configuration.ConfigurationManager.NetworkCredentialPassword))
                    mailClient.Credentials = new NetworkCredential(Configuration.ConfigurationManager.NetworkCredentialUsername, Configuration.ConfigurationManager.NetworkCredentialPassword);

                mailClient.EnableSsl = Configuration.ConfigurationManager.EnableSsl;
                mailClient.Send(msg);   
                
             
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "success";
        }

        public static string SaveEmail(Email email)
        {
            return EmailDataProvider.Instance.SaveEmail(email);
        }
    }
}
