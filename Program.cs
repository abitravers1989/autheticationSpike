using System;

namespace AuthenticatorPractice
{
    class Program
    {
        static void Main(string[] args)
        {
          
        AuthenticationHelper aOuth = new AuthenticationHelper("mozscape - 45676fedfgg11918", "5dd5afgwash556asasa786fc2ce94977b1db23c");
         var accessTime1 = aOuth.CreateAllowedAccessTime();
       
            var encryptedSignature = aOuth.CreateEncriptedSignature(accessTime1);
            var authenticationStr = aOuth.GetAuthenticationStr(encryptedSignature, accessTime1);
            Console.WriteLine(authenticationStr);

           // var hmacHashString = aOuth.HmacSHA1HashString(accessTime1);
            //Console.WriteLine(hmacHashString);

            //var base64String = aOuth.Base64Encrption("dasbdsdnng%798700887777");
            //Console.WriteLine(base64String);
            
            //var urlEncryptStr = aOuth.UrlEncription(hmacHashString);
            //Console.WriteLine(urlEncryptStr);

            
            Console.ReadKey();

  
        }
    }


}
