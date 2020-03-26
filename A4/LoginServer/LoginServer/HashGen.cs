using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    class HashGen
    {
        // generate hashed passwords
        public string PwHashNSalt(string saltedpw)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Encoding.UTF8.GetBytes(saltedpw);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            return Encoding.UTF8.GetString(resultBytes);
        }
    }
}
