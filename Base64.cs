using System;
using System.Collections.Generic;
using System.Text;

namespace AuthenticatorPractice
{
    public class Base64
    {

        public static string ToBase64(Encoding encoding, String authenticatedString)
        {
            if (authenticatedString == null)
            {
                return null;
            }

            byte[] textAsBytes = encoding.GetBytes(authenticatedString);
            return Convert.ToBase64String(textAsBytes);
        }
    }
}
