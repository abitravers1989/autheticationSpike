using System;

namespace AuthenticatorPractice
{
    class Program
    {
        static void Main(string[] args)
        {
          
        AuthenticationHelper aOuth = new AuthenticationHelper("mozscape - 45676ffgg11918", "5dd5afgwash556as786fc2ce94977b1db23c");
         var accessTime1 = aOuth.CreateAllowedAccessTime();
            Console.WriteLine(accessTime1);
        //var hmacHashString = aOuth.HmacSHA1HashString();
            //Console.WriteLine(hmacHashString);

            Console.ReadKey();









         
        }
    }


}
