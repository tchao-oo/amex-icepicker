using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace Amex.IcePicker.Configuration
{
    public class ConfigurationManager
    {
        protected const string defaultSectionName = "OgilvyOnePlatform/EmailSettings";
        protected const string siteSectionName = "OgilvyOnePlatform/SiteSettings";
        protected const string genericSectionName = "OgilvyOnePlatform/Generic";

        public static string EmailToIgnore
        {
            get { return _getValueInSection(genericSectionName, "OgilvyWidgetEmailToIgnore"); }
        }
        public static string EmailToReplace
        {
            get { return _getValueInSection(genericSectionName, "OgilvyWidgetEmailToReplace"); }
        }
        public static string NewEmail
        {
            get { return _getValueInSection(genericSectionName, "OgilvyWidgetNewEmail"); }
        }

        public static string GoogleWeatherUrl
        {
            get { return _getValueInSection(genericSectionName, "GoogleAPIWeatherUrl"); }
        }

        public static bool EnableSsl
        {
            get { return _getBoolInSection("EnableSsl"); }
        }

        public static string SiteUrl
        {
            get { return _getValueInSection(siteSectionName, "SiteUrl"); }
        }

        public static string NetworkCredentialPassword
        {
            get { return _getValueInSection("NetworkCredentialPassword"); }
        }

        public static string NetworkCredentialUsername
        {
            get { return _getValueInSection("NetworkCredentialUsername"); }
        }

        #region private functions
        private static string _getValueInSection(string key)
        {
            return _getValueInSection(defaultSectionName, key);
        }

        private static bool _getBoolInSection(string key)
        {
            return _getBoolInSection(defaultSectionName, key);
        }

        private static bool _getBoolInSection(string sectionName, string key)
        {
            return Convert.ToBoolean(_getValueInSection(sectionName, key));
        }

        private static string _getValueInSection(string sectionName, string key)
        {
            NameValueCollection section = (NameValueCollection)ConfigurationSettings.GetConfig(sectionName);
            return (section != null && section[key] != null ? section[key] : string.Empty);
        }
        #endregion
    }
}
