using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        static string[] args;
        static string outcome;

        public Form1()
        {
            InitializeComponent();
            if (CheckArgs())
            {
                ReceiveOutcome();
            }
        }

        // makes sure ReceiveOutcome runs only when started by LoginServer
        private Boolean CheckArgs()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                args = Environment.GetCommandLineArgs();
                return true;
            }
            return false;
        }

        // login button
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserNText.Text) && !string.IsNullOrWhiteSpace(PWText.Text))
            {
                DisplayBox.Text = "Validating...";
                SendToServer(UserNText.Text, PWText.Text, "login");
                
            } else
            {
                DisplayBox.Text = "Error! Missing details.";
            }
            ClearFields();
        }

        // register button
        private void BtnRego_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserNText.Text) && !string.IsNullOrWhiteSpace(PWText.Text))
            {
                DisplayBox.Text = "Registering...";
                SendToServer(UserNText.Text, PWText.Text, "rego");

            }
            else
            {
                DisplayBox.Text = "Error! Missing details.";
            }
            ClearFields();
        }

        private void ClearFields()
        {
            UserNText.Clear();
            PWText.Clear();
        }

        // method for sending msgs to LoginServer, action is determined by "query"
        private void SendToServer(string user, string pw, string query)
        {
            Process pipeClient = new Process();
            pipeClient.StartInfo.FileName = "loginServer.exe";

            using (AnonymousPipeServerStream pipeServ = new AnonymousPipeServerStream(
                PipeDirection.Out, HandleInheritability.Inheritable))
            {
                // pipeServ.TransmissionMode
                // passing login handle to loginServer as arg
                pipeClient.StartInfo.Arguments = pipeServ.GetClientHandleAsString();
                
                pipeClient.StartInfo.UseShellExecute = false;
                pipeClient.Start();

                // check?
                pipeServ.DisposeLocalCopyOfClientHandle();

                try
                {
                    using (StreamWriter sw = new StreamWriter(pipeServ))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(query);
                        sw.WriteLine(user);
                        sw.WriteLine(pw);
                        pipeServ.WaitForPipeDrain();
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            
            pipeClient.WaitForExit();
        }

       
        // Method to capture messages from LoginServer
        private void ReceiveOutcome()
        {
            try
            {
                // pipe handle is element [1] of args
                using (PipeStream receiverPipe = new AnonymousPipeClientStream(PipeDirection.In, args[1]))
                {

                    // client current transmission mode for pipeclient
                    using (StreamReader sr = new StreamReader(receiverPipe))
                    {
                        //MessageBox.Show("Am I working?");
                        outcome = sr.ReadLine();
                        DisplayBox.Text = outcome;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
