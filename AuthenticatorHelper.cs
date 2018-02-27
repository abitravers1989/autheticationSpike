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
            var unixTime = DateTime.Now.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (int)unixTime.TotalSeconds;
        }

        public String GetAuthenticationStr(string encryptedSignature)
        {
            int allowedAccessTime = this.GetUNIXTimestamp() + 300;
            //taken out secrete key
            
            String stringToSign = "AccessID=member-" + accessID + "&Expires=" + allowedAccessTime + "&Signature=" + encryptedSignature;
            return stringToSign;             
        }

        public HmacSHA1Encription()
        {
            int allowedAccessTime = this.GetUNIXTimestamp() + 300;
            accessID;
            secretKey;

            
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

        }

        public string DoEncription()
        {
            var hmacEncriptedString = this.HmacSHA1Encription();
            var base64EncriptedString = this.Base64Encrption(hmacEncriptedString);
            var urlEncriptedString = this.UrlEncription(base64EncriptedString);

            return urlEncriptedString;
        }

    }
}
