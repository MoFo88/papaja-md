using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BLL
{
    public class Core
    {
        public static String GetSh1(String s)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] passwordHash = sha.ComputeHash(ascii.GetBytes(s));


            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            string myString = enc.GetString(passwordHash);

            return myString;
        }
    }
}
