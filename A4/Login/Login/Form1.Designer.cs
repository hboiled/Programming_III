namespace Login
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
            this.UserNText = new System.Windows.Forms.TextBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PWText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRego = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserNText
            // 
            this.UserNText.Location = new System.Drawing.Point(186, 93);
            this.UserNText.Name = "UserNText";
            this.UserNText.Size = new System.Drawing.Size(227, 26);
            this.UserNText.TabIndex = 0;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(186, 192);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(80, 39);
            this.BtnSubmit.TabIndex = 2;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 63);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username: ";
            // 
            // PWText
            // 
            this.PWText.Location = new System.Drawing.Point(186, 146);
            this.PWText.Name = "PWText";
            this.PWText.PasswordChar = '*';
            this.PWText.Size = new System.Drawing.Size(227, 26);
            this.PWText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // DisplayBox
            // 
            this.DisplayBox.Location = new System.Drawing.Point(186, 267);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.ReadOnly = true;
            this.DisplayBox.Size = new System.Drawing.Size(227, 26);
            this.DisplayBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status:";
            // 
            // BtnRego
            // 
            this.BtnRego.Location = new System.Drawing.Point(318, 192);
            this.BtnRego.Name = "BtnRego";
            this.BtnRego.Size = new System.Drawing.Size(95, 39);
            this.BtnRego.TabIndex = 10;
            this.BtnRego.Text = "Register";
            this.BtnRego.UseVisualStyleBackColor = true;
            this.BtnRego.Click += new System.EventHandler(this.BtnRego_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 320);
            this.Controls.Add(this.BtnRego);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DisplayBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PWText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.UserNText);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNText;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PWText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DisplayBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnRego;
    }
}

