using System;
using System.Collections.Generic;
using System.Text;



namespace AuthenticatorPractice
{
    public class AuthenticationHelper
    {
        private String accessID;
        private String secretKey;
        private int expiresInterval = 300;
        private DateTime currentDate = DateTime.Now;


        public AuthenticationHelper(String accessID, String secretKey)
        {
            this.accessID = accessID;
            this.secretKey = secretKey;

        }

        public int GetUNIXTimestamp()
        {
            var unixTime = DateTime.Now.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (int)unixTime.TotalSeconds;
        }

        public String GetAuthenticationStr()
        {
            int allowedAccessTime = this.GetUNIXTimestamp() + 300;
            String stringToSign = accessID + secretKey + allowedAccessTime;
            return stringToSign;             
        }

        public string EncodingwithBase(string autheticationString)
        {
            // convert string into bytes array
            byte[] bytes = Encoding.UTF8.GetBytes(autheticationString);
            // base64 converts this bytes array into a more complicated string 
            var encoder = Convert.ToBase64String(bytes);
            return encoder;
          
        }

 
    }
}
