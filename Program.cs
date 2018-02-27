using System;

namespace AuthenticatorPractice
{
    class Program
    {
        static void Main(string[] args)
        {
          
        AuthenticationHelper aOuth = new AuthenticationHelper("mozscape - 4726a11918", "5dd5adca2d11b02fc2ce94977b1db23c");
        String auth = aOuth.GetAuthenticationStr();
            //this has - and empty space in
        Console.WriteLine(auth);

         var encodedString = aOuth.EncodingwithBase(auth);
        // Console.WriteLine(encodedString);

         var hmac = aOuth.CreateToken(auth);
          Console.WriteLine(hmac);
          Console.ReadKey();
        }
    }


}
