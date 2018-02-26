using System;

namespace AuthenticatorPractice
{
    class Program
    {
        static void Main(string[] args)
        {
          
        AuthenticationHelper aOuth = new AuthenticationHelper("454664646", "sasasdasd");
        String auth = aOuth.GetAuthenticationStr();
        Console.WriteLine(auth);

         var encodedString = aOuth.EncodingwithBase(auth);
         Console.WriteLine(encodedString);

         var hmac = aOuth.CreateToken(auth, "secreteKey");
          Console.WriteLine(hmac);
       Console.ReadKey();
        }
    }


}
