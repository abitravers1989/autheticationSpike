using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


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
            var unixTime = currentDate.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (int)unixTime.TotalSeconds;
        }

        public int CreateAllowedAccessTime()
        {
            int allowedAccessTime = this.GetUNIXTimestamp() + expiresInterval;
            return allowedAccessTime;
        }

        public string HmacSHA1HashString(int allowedAccessTime)
        {
            var value = accessID + allowedAccessTime;
            var key = secretKey;

            //HMACSHA1 is a microsoft class .. set up with secrete key 
            using (var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(key)))
            {
               // then use that class which has a secrete key and is called hmac .. ask it to compute hash value
                return Encoding.ASCII.GetString(hmac.ComputeHash(Encoding.ASCII.GetBytes(value)));
            }         
        }

        public string Base64Encrption(string hexadecimalString)
        {
            // convert string into bytes array
            byte[] bytes = Encoding.UTF8.GetBytes(hexadecimalString);
            // base64 converts this bytes array into a more complicated string 
            var encoder = Convert.ToBase64String(bytes);
            return encoder;
          
        }

        public string UrlEncription(string base64String)
        {
            //httpUtility is microsoft class to help send things over web... 
            //The .UrlEncode is a built in method in HttpUtility class. 
            //Class which have methods on.
           // System.Web.HttpUtility.

            return System.Web.HttpUtility.UrlEncode(base64String);
        }

        public string CreateEncriptedSignature(int allowedAccessTime)
        {
            var hmacEncriptedString = this.HmacSHA1HashString(allowedAccessTime);
            var base64EncriptedString = this.Base64Encrption(hmacEncriptedString);
            var urlEncriptedString = this.UrlEncription(base64EncriptedString);

            return urlEncriptedString;
        }


        public String GetAuthenticationStr(string encryptedSignature, int allowedAccessTime)
        {
            String stringToSign = "AccessID=member-" + accessID + "&Expires=" + allowedAccessTime + "&Signature=" + encryptedSignature;
            return stringToSign;
        }


    }
}
