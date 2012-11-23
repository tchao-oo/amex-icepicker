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
using System.Collections.Specialized;

namespace Amex.IcePicker.Configuration
{
    public class AuthCredentialsSection : ConfigurationSection
    {
        public static AuthCredentialsSection AuthCredentialSettings = System.Configuration.ConfigurationManager.GetSection("OgilvyOnePlatform/AuthCredentials") as AuthCredentialsSection;

        [ConfigurationProperty("AuthCredentials")]
        [ConfigurationCollection(typeof(AuthCredentialElementCollection), AddItemName = "AuthCredential")]
        public AuthCredentialElementCollection AuthCredentials
        {
            get { return (AuthCredentialElementCollection)this["AuthCredentials"]; }
        }
    }

    public class AuthCredentialElement : ConfigurationElement
    {
        public class AuthCredentialsSection : ConfigurationSection
        {
            public static AuthCredentialsSection AuthCredentialSettings = System.Configuration.ConfigurationManager.GetSection("OgilvyOnePlatform/AuthCredentials") as AuthCredentialsSection;


            [ConfigurationProperty("AuthCredentials")]
            [ConfigurationCollection(typeof(AuthCredentialElementCollection), AddItemName = "AuthCredential")]
            public AuthCredentialElementCollection AuthCredentials
            {
                get { return (AuthCredentialElementCollection)this["AuthCredentials"]; }
            }
        }


        [ConfigurationProperty("clientid", IsRequired = true, IsKey = true)]
        public string ClientId
        {
            get { return (string)this["clientid"]; }
            set { this["clientid"] = value; }
        }

        [ConfigurationProperty("authkey", IsRequired = true)]
        public string AuthKey
        {
            get { return (string)this["authkey"]; }
            set { this["authkey"] = value; }
        }
    }

    public class AuthCredentialElementCollection : ConfigurationElementCollection
    {
        public AuthCredentialElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as AuthCredentialElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new AuthCredentialElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AuthCredentialElement)element).ClientId;
        }
    }
}