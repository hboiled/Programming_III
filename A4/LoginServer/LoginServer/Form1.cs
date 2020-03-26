using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginServer
{
    public partial class Form1 : Form
    {
        static string[] args;
        static string[] receivedMsgs = new string[3];
        List<User> registeredUsers = new List<User>();
        static Boolean validRego;
        static PWGen pg = new PWGen();

        public Form1()
        {
            InitializeComponent();
            registeredUsers.Add(GenUser("Admin", "admin", true));
            LoadRegisteredUsers();
            args = Environment.GetCommandLineArgs();
            // upon start load registered users  
            if (args.Length > 1)
            {
                ReceiveMessages();
                ProcessQuery(receivedMsgs[0]);
            }  
        }
        
        // internal testing method
        private void test()
        {
            foreach (string s in args)
            {
                MessageBox.Show(s);
            }
        }


        //*** STAGE 0: INITIALISATION
        // load users from txt file into list of users
        private void LoadRegisteredUsers()
        {            
            using (Stream fstream = new FileStream("users.dat", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                while (fstream.Position != fstream.Length)
                {
                    registeredUsers.Add((User)bf.Deserialize(fstream));
                }
            }
        }

        // processes pipe input
        private void ReceiveMessages()
        {
            try
            {
                // pipe handle is element [1] of args
                using (PipeStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, args[1]))
                {
                    // client current transmission mode for pipeclient
                    using (StreamReader sr = new StreamReader(pipeClient))
                    {
                        receivedMsgs[0] = sr.ReadLine();
                        receivedMsgs[1] = sr.ReadLine();
                        receivedMsgs[2] = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //** END INITIALISATION STAGE

        //*** STAGE 1: LOGIN LOGIC
        // receivedmsgs[2] represents the msg sent by login form, either login or register
        private void ProcessQuery(string query)
        {
            string user = receivedMsgs[1];
            string pw = receivedMsgs[2];
            
            if ("login".Equals(query))
            {                
                LoginUser(user, pw);
            }
            else if ("rego".Equals(query))
            {
                if (CheckForDupe(user))
                {
                    ReturnOutcome(user + " - user already exists.");
                }
                else
                {
                    RegisterUser(user, pw);
                }
                
            }
        }

        // prevent multiple users with same name registering
        private bool CheckForDupe(string user)
        {
            bool dupeExists = false;
            foreach (User u in registeredUsers)
            {
                if (user.Equals(u.Username))
                {
                    dupeExists = true;
                    break;
                }
            }

            return dupeExists;
        }

        // login method which handles the query based on submitted data
        private void LoginUser(string user, string pw)
        {
            User targerUser = LinearSearch(user);                        

            if (targerUser != null)
            {            
                bool result = CheckMatch(targerUser, pw);
                
                if (!result)
                {
                    ReturnOutcome("Incorrect password");
                }
                else if (result && targerUser.IsAdmin)
                {
                    ConfigureAdminWindow();
                }
                else if (result)
                {
                    ReturnOutcome(targerUser.Username + " successfully logged in");
                }
            }
            else
            {
                ReturnOutcome(user + " - User does not exist");
            }
        }

        // basic linear search
        private User LinearSearch(string name)
        {
            foreach (User u in registeredUsers)
            {
                if (u.Username.Equals(name))
                {
                    return u;
                }
            }
            return null;
        }

        // salts and hashes plain text pw, then compares it with what user has
        private Boolean CheckMatch(User u, string pw)
        {
            PWGen pg = new PWGen();
            string HashedQueryPW = pg.GenHashedPW(pw, u.Salt);
            MessageBox.Show(HashedQueryPW + " vs " + u.HashedPW);
            return HashedQueryPW.Equals(u.HashedPW);
        }
        //*** END LOGIN LOGIC

        //*** STAGE 2: REGISTER USER LOGIC
        // adds new user to list (database), creates a copy in .dat file, sends outcome back to login
        private void RegisterUser(string user, string pw)
        {
            User newUser = GenUser(user, pw, false);              

            registeredUsers.Add(newUser);
            RecordRegisteredUsers(newUser);
            //MessageBox.Show(registeredUsers.ElementAt(0).ToString());
            validRego = true;

            string outcome = validRego ? "Registered successfully" : "Unsuccessful";
            ReturnOutcome(outcome + " " + user);

            validRego = false;
        }

        // creates user, its salt and hashes its password
        private User GenUser(string user, string pw, bool admin)
        {
            User newUser = new User(user);
            newUser.Salt = pg.GetSalt();
            newUser.HashedPW = pg.GenHashedPW(pw, newUser.Salt);
            newUser.IsAdmin = admin;
            return newUser;
        }

        // used to store a record of a user
        private void RecordRegisteredUsers(User user)
        {
            try
            {
                using (Stream fstream = new FileStream("users.dat", FileMode.Append))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fstream, user);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //*** END REGISTER STAGE

        //*** STAGE 3: FINAL PROCESSING
        // method which returns to a new login window the outcome of the selected query
        private void ReturnOutcome(string outcome)
        {
            // necessary to prevent many login windows being kept open
            Process client = Process.GetProcessesByName("Login").First();
            client.Kill();

            Process returnClient = new Process();
            returnClient.StartInfo.FileName = "login.exe";
            using (AnonymousPipeServerStream pipeReturn = new AnonymousPipeServerStream(
                PipeDirection.Out, HandleInheritability.Inheritable))
            {
                returnClient.StartInfo.Arguments = pipeReturn.GetClientHandleAsString();
                returnClient.StartInfo.UseShellExecute = false;
                returnClient.Start();

                pipeReturn.DisposeLocalCopyOfClientHandle();

                try
                {
                    using (StreamWriter sw = new StreamWriter(pipeReturn))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(outcome);
                        pipeReturn.WaitForPipeDrain();
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            TerminateSelf();
        }

        // automatically runs to prevent non-admins from viewing the admin control panel
        private void TerminateSelf()
        {
            Process self = Process.GetCurrentProcess();
            self.Kill();
        }
        //*** END OF FINAL PROCESSING

        // STAGE 1.5 ADMIN WINDOW CONFIGURATION
        // display info for admin user
        private void ConfigureAdminWindow()
        {
            PopulateListBox();
        }

        // display a list of users registered
        private void PopulateListBox()
        {
            UserDisplay.Items.Clear();

            foreach (User u in registeredUsers)
            {
                UserDisplay.Items.Add(u.ToString());
            }
        }

        // selection for the following method
        private void UserDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int target = UserDisplay.SelectedIndex;
            if (target < 0 || target > registeredUsers.Count)
            {
                return;
            }
            DisplayUserInfo(target);
        }

        // admins can view user's name, salt and hashed pw
        private void DisplayUserInfo(int target)
        {
            UserNBox.Text = registeredUsers.ElementAt(target).Username;
            SaltBox.Text = registeredUsers.ElementAt(target).Salt;
            HashBox.Text = registeredUsers.ElementAt(target).HashedPW;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnOutcome("Admin account was used.");
        }
        //*** END OF ADMIN WINDOW
        
    }
    
}
