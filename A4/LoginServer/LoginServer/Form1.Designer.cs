namespace LoginServer
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
            this.UserNBox = new System.Windows.Forms.TextBox();
            this.SaltBox = new System.Windows.Forms.TextBox();
            this.BtnReturn = new System.Windows.Forms.Button();
            this.HashBox = new System.Windows.Forms.TextBox();
            this.UserDisplay = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNBox
            // 
            this.UserNBox.Location = new System.Drawing.Point(345, 72);
            this.UserNBox.Name = "UserNBox";
            this.UserNBox.ReadOnly = true;
            this.UserNBox.Size = new System.Drawing.Size(249, 26);
            this.UserNBox.TabIndex = 0;
            // 
            // SaltBox
            // 
            this.SaltBox.Location = new System.Drawing.Point(345, 146);
            this.SaltBox.Name = "SaltBox";
            this.SaltBox.ReadOnly = true;
            this.SaltBox.Size = new System.Drawing.Size(249, 26);
            this.SaltBox.TabIndex = 1;
            // 
            // BtnReturn
            // 
            this.BtnReturn.Location = new System.Drawing.Point(499, 429);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(95, 41);
            this.BtnReturn.TabIndex = 2;
            this.BtnReturn.Text = "Return";
            this.BtnReturn.UseVisualStyleBackColor = true;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // HashBox
            // 
            this.HashBox.Location = new System.Drawing.Point(345, 228);
            this.HashBox.Name = "HashBox";
            this.HashBox.ReadOnly = true;
            this.HashBox.Size = new System.Drawing.Size(249, 26);
            this.HashBox.TabIndex = 3;
            // 
            // UserDisplay
            // 
            this.UserDisplay.FormattingEnabled = true;
            this.UserDisplay.ItemHeight = 20;
            this.UserDisplay.Location = new System.Drawing.Point(40, 46);
            this.UserDisplay.Name = "UserDisplay";
            this.UserDisplay.Size = new System.Drawing.Size(214, 424);
            this.UserDisplay.TabIndex = 4;
            this.UserDisplay.SelectedIndexChanged += new System.EventHandler(this.UserDisplay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Salt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "HashedPW";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserDisplay);
            this.Controls.Add(this.HashBox);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.SaltBox);
            this.Controls.Add(this.UserNBox);
            this.Name = "Form1";
            this.Text = "LoginServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNBox;
        private System.Windows.Forms.TextBox SaltBox;
        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.TextBox HashBox;
        private System.Windows.Forms.ListBox UserDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

