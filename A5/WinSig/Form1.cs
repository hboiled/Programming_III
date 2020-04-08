using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Samuel Lee
// 30018308

namespace WinSig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // starts the background worker thread
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (BtnStart.Text.Equals("Start") && !backgroundWorker.IsBusy)
            {
                BtnStart.Text = "Reset";
                backgroundWorker.RunWorkerAsync();                
            }
            else
            {
                BtnStart.Text = "Start";
                progressBar.Value = 0;
                Display.Clear();
            }
        }

        // cancel event listener which checks for a busy backgroundworker
        //
        private void CancelEvent(object sender, KeyEventArgs e)
        {
            // return on inactive worker
            if (!backgroundWorker.IsBusy)
            {
                return;
            }
            // listens for ctrl + c to be pressed
            // sends msg to backgroundworker to cancel
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                backgroundWorker.CancelAsync();
                Display.Text = "Event cancelling...";
            }
        }

        // loops 100 times to fill out progressbar
        
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 100; i++)
            {
                // listens for cancellation requests from above method
                // then terminates the process
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }

        // increments progress bar
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        // determine the display text at resolution of backgroundworker's work
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Display.Text = "Was cancelled by key signal.";
            }
            else if (e.Error != null)
            {
                Display.Text = "Error: " + e.Error.Message;
            }
            else
            {
                Display.Text = "Finished without issue.";
            }
        }
    }
}
