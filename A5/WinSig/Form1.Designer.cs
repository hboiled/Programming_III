namespace WinSig
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BtnStart = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(42, 88);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(420, 63);
            this.progressBar.TabIndex = 0;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(182, 175);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(130, 45);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(103, 33);
            this.Display.Name = "Display";
            this.Display.ReadOnly = true;
            this.Display.Size = new System.Drawing.Size(295, 26);
            this.Display.TabIndex = 2;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 237);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.progressBar);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Windows Signal Demo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancelEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox Display;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

