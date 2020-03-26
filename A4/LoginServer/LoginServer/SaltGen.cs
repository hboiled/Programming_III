using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    class SaltGen
    {
        private RNGCryptoServiceProvider CSP;
        private const int SALT_SIZE = 24;

        public SaltGen()
        {
            CSP = new RNGCryptoServiceProvider();
        }

        // generate salts which are used in conjunction with a standard text password to make a salted and hashed password
        public string GetSalt()
        {
            byte[] saltArr = new byte[SALT_SIZE];
            CSP.GetNonZeroBytes(saltArr);
            return Encoding.UTF8.GetString(saltArr);
            // can possibly return strings with newlines
        }
    }
}
