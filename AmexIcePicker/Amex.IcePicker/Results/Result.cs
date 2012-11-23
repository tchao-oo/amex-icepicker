using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Amex.IcePicker.Results
{
    public class Result
    {  
       //0 :: Success
       //1 :: Error
       //2 :: DatabaseError
       //3 :: SoapHeaderMissing
       //4 :: SoapHeaderDetails
        
        public int Status { get; set; }
        public string Message { get; set; }

        public Result()
        {
            this.Status = 0;
            this.Message = string.Empty;
        }
    }
}
