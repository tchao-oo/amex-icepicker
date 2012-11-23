using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Amex.IcePicker.Emails;
using System.Data;

namespace Amex.IcePicker.Data
{
     public class EmailDbDataProvider : IEmailDataProvider
    {
        public string SaveEmail(Email email)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                using (DbCommand cmd = db.GetStoredProcCommand("Email_Insert"))
                {
                    db.AddInParameter(cmd, "@_clientId", DbType.String, email.ClientId);
                    db.AddInParameter(cmd, "@_fromEmail", DbType.String, email.FromEmail);
                    db.AddInParameter(cmd, "@_fromName", DbType.String, email.FromName);
                    db.AddInParameter(cmd, "@_toEmail", DbType.String, email.ToEmail);
                    db.AddInParameter(cmd, "@_toName", DbType.String, email.ToName);
                    db.AddInParameter(cmd, "@_htmlBody", DbType.String, email.HtmlBody);
                    db.AddInParameter(cmd, "@_subject", DbType.String, email.Subject);
                    db.ExecuteNonQuery(cmd);
                }

                return "success";
            }
            catch (Exception ex)
            {
                //Handle error
                return ex.Message;
            }
        }
     }
}
