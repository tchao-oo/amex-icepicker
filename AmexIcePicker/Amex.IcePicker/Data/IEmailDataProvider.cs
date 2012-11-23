using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amex.IcePicker.Emails;

namespace Amex.IcePicker.Data
{    
    public class EmailDataProvider
    {
        static IEmailDataProvider _instance = new EmailDbDataProvider();

        public static IEmailDataProvider Instance { get { return _instance; } }
    }

    public interface IEmailDataProvider
    {
        string SaveEmail(Email email);
    }
}