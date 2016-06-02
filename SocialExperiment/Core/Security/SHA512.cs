using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Core.Security
{
    public class SHA512
    {

        private static RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();

        public SHA512(string plaintext)
        {

        }

        private string genSalt(string password)
        {
            return "";
        }
    }
}
