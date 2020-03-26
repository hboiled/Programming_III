using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    /// <summary>
    /// Functions as a password manager that is responsible for generating the salt
    /// and creating hashed passwords
    /// </summary>
    class PWGen
    {
        private SaltGen sg;
        private HashGen hg;

        public PWGen()
        {
            sg = new SaltGen();
            hg = new HashGen();
        }

        public string GetSalt()
        {
            return sg.GetSalt();
        }

        public string GenHashedPW(string pw, string salt)
        {
            string saltedPW = pw + salt;
            return hg.PwHashNSalt(saltedPW);
        }
    }
}
