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

        public string HmacSHA1AndBase64Encription(int allowedAccessTime)
        {
            var value = accessID + allowedAccessTime;
            var key = secretKey;

            //Setup secrete key as Bytes array
            Byte[] secretBytes = UTF8Encoding.UTF8.GetBytes(key);
            //Create new HMACSHA1 algorithm with this secretekey
            var hmac = new HMACSHA1(secretBytes);
            //create bytes array with the value information
            Byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(value);
            // 1.Call computeHash on the hmac string which contains the seceret key.
            // This creates the hmac hash with the value information
            // 2. This is converted to a Base64 String then returned.
            return Convert.ToBase64String(hmac.ComputeHash(dataBytes));
        }

        public string UrlEncription(string base64String)
        {
            //httpUtility is microsoft class to help send things over web... 
            //The .UrlEncode is a built in method in HttpUtility class. 
            return System.Web.HttpUtility.UrlEncode(base64String);
        }

        public string CreateEncriptedSignature(int allowedAccessTime)
        {
            var hmacSHA1AndBase64Encription = this.HmacSHA1AndBase64Encription(allowedAccessTime);
            var urlEncriptedString = this.UrlEncription(hmacSHA1AndBase64Encription);
            return urlEncriptedString;
        }


        public String GetAuthenticationStr(string encryptedSignature, int allowedAccessTime)
        {
            // Need to remove whitespace in accessID with .Replace
            String stringToSign = "AccessID=member-" + accessID.Replace(" ", "") + "&Expires=" + allowedAccessTime + "&Signature=" + encryptedSignature;
            return stringToSign;
        }


    }
}
