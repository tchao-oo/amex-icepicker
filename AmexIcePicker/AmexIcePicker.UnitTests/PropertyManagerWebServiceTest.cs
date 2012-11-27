using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amex.IcePicker.Results;
using Amex.IcePicker.Properties;

namespace AmexIcePicker.UnitTests
{
    [TestClass]
    public class PropertyManagerWebServiceTest
    {
        protected string clientId = "Amex-IcePicker";
        protected string authKey = "0c8aef2a8f840f5b8e1237f736f46ec7";
        string name = "62dfd70b-2388-48e7-9217-14701acbbf33";
        string value = "test,test";

        /// <summary>
        ///A test for SetProperty
        ///</summary>
        [TestMethod()]
        public void SetPropertyTest()
        {
            PropertyManagerWebservice.WebServiceSoapHeader soapHeader = new PropertyManagerWebservice.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            PropertyManagerWebservice.PropertyWebserviceSoapClient target = new PropertyManagerWebservice.PropertyWebserviceSoapClient();
           
            string actual = target.SetProperty(soapHeader, name, value);
            Result actualResult = ResultManager.Deserialize(actual);
            Assert.AreEqual(actualResult.Status, 0);

            Property actualProperty = PropertyManager.Deserialize(actualResult.Message);
            Assert.AreEqual(actualProperty.Value, value);
        }

        /*
        /// <summary>
        ///A test for UpdateProperty
        ///</summary>       
        [TestMethod()]
        public void UpdatePropertyTest()
        {
            PropertyManagerWebservice.WebServiceSoapHeader soapHeader = new PropertyManagerWebservice.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            PropertyManagerWebservice.PropertyManagerWebServiceSoapClient target = new PropertyManagerWebservice.PropertyManagerWebServiceSoapClient();
           
            string actual = target.UpdateProperty(soapHeader, name, value);
            Result actualResult = ResultManager.Deserialize(actual);

            Assert.AreEqual(actualResult.Status, 0);

            Property actualProperty = PropertyManager.Deserialize(actualResult.Message);
            Assert.AreEqual(actualProperty.Name, name);
        }
        */

        /// <summary>
        ///A test for GetProperty
        ///</summary>
        [TestMethod()]
        public void GetPropertyTest()
        {
            PropertyManagerWebservice.WebServiceSoapHeader soapHeader = new PropertyManagerWebservice.WebServiceSoapHeader();
            soapHeader.ClientId = clientId;
            soapHeader.AuthKey = authKey;

            PropertyManagerWebservice.PropertyWebserviceSoapClient target = new PropertyManagerWebservice.PropertyWebserviceSoapClient();
            
            string actual = target.GetProperty(soapHeader, name);
            Result actualResult = ResultManager.Deserialize(actual);

            Assert.AreEqual(actualResult.Status, 0);

            Property actualProperty = PropertyManager.Deserialize(actualResult.Message);
            Assert.AreEqual(actualProperty.Value, value);
            Assert.AreEqual(actualProperty.Name, name);
        }
    }
}
