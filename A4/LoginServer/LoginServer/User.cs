using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer 
{
    /// <summary>
    /// Serialisable user class representing a user which can log in to a server
    /// contains only values that make up a user
    /// can be made into an admin class to access admin control panel
    /// </summary>
    [Serializable]    
    class User
    {
        private string username;
        private string salt;
        private string hashedPW;
        public bool IsAdmin;

        public User(string username)
        {
            this.username = username;

            IsAdmin = false;
        }

        private void genSaltNPW(PWGen pg, string pw)
        {            
            hashedPW = pg.GenHashedPW(pw, this.salt);

        }

        public string Username { get => username; set => username = value; }
        public string Salt { get => salt; set => salt = value; }
        public string HashedPW { get => hashedPW; set => hashedPW = value; }        

        public override string ToString()
        {
            return Username; // + " \nSalt: " + Salt + " \nHashedPW: " + HashedPW;
        }
    }
}
