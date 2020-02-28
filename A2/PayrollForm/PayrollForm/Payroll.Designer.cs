namespace PayrollForm
{
    partial class Payroll
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
            this.Display = new System.Windows.Forms.ListBox();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnRemoveMin = new System.Windows.Forms.Button();
            this.BtnFind = new System.Windows.Forms.Button();
            this.BtnFindMin = new System.Windows.Forms.Button();
            this.BtnFindMax = new System.Windows.Forms.Button();
            this.BtnMakeEmpty = new System.Windows.Forms.Button();
            this.BtnIsEmpty = new System.Windows.Forms.Button();
            this.BtnFill = new System.Windows.Forms.Button();
            this.FindBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.FindOPBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.FormattingEnabled = true;
            this.Display.HorizontalExtent = 1000;
            this.Display.HorizontalScrollbar = true;
            this.Display.Location = new System.Drawing.Point(16, 126);
            this.Display.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(613, 69);
            this.Display.TabIndex = 0;
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(16, 14);
            this.BtnInsert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(63, 26);
            this.BtnInsert.TabIndex = 2;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(16, 83);
            this.BtnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(63, 26);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnRemoveMin
            // 
            this.BtnRemoveMin.Location = new System.Drawing.Point(95, 14);
            this.BtnRemoveMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnRemoveMin.Name = "BtnRemoveMin";
            this.BtnRemoveMin.Size = new System.Drawing.Size(70, 35);
            this.BtnRemoveMin.TabIndex = 4;
            this.BtnRemoveMin.Text = "Remove Min";
            this.BtnRemoveMin.UseVisualStyleBackColor = true;
            this.BtnRemoveMin.Click += new System.EventHandler(this.BtnRemoveMin_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.Location = new System.Drawing.Point(226, 14);
            this.BtnFind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(70, 26);
            this.BtnFind.TabIndex = 5;
            this.BtnFind.Text = "Find";
            this.BtnFind.UseVisualStyleBackColor = true;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BtnFindMin
            // 
            this.BtnFindMin.Location = new System.Drawing.Point(397, 14);
            this.BtnFindMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnFindMin.Name = "BtnFindMin";
            this.BtnFindMin.Size = new System.Drawing.Size(63, 26);
            this.BtnFindMin.TabIndex = 6;
            this.BtnFindMin.Text = "Find Min";
            this.BtnFindMin.UseVisualStyleBackColor = true;
            this.BtnFindMin.Click += new System.EventHandler(this.BtnFindMin_Click);
            // 
            // BtnFindMax
            // 
            this.BtnFindMax.Location = new System.Drawing.Point(397, 49);
            this.BtnFindMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnFindMax.Name = "BtnFindMax";
            this.BtnFindMax.Size = new System.Drawing.Size(63, 26);
            this.BtnFindMax.TabIndex = 7;
            this.BtnFindMax.Text = "Find Max";
            this.BtnFindMax.UseVisualStyleBackColor = true;
            this.BtnFindMax.Click += new System.EventHandler(this.BtnFindMax_Click);
            // 
            // BtnMakeEmpty
            // 
            this.BtnMakeEmpty.Location = new System.Drawing.Point(473, 12);
            this.BtnMakeEmpty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnMakeEmpty.Name = "BtnMakeEmpty";
            this.BtnMakeEmpty.Size = new System.Drawing.Size(70, 37);
            this.BtnMakeEmpty.TabIndex = 8;
            this.BtnMakeEmpty.Text = "Make Empty";
            this.BtnMakeEmpty.UseVisualStyleBackColor = true;
            this.BtnMakeEmpty.Click += new System.EventHandler(this.BtnMakeEmpty_Click);
            // 
            // BtnIsEmpty
            // 
            this.BtnIsEmpty.Location = new System.Drawing.Point(397, 83);
            this.BtnIsEmpty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnIsEmpty.Name = "BtnIsEmpty";
            this.BtnIsEmpty.Size = new System.Drawing.Size(63, 26);
            this.BtnIsEmpty.TabIndex = 9;
            this.BtnIsEmpty.Text = "Is Empty?";
            this.BtnIsEmpty.UseVisualStyleBackColor = true;
            this.BtnIsEmpty.Click += new System.EventHandler(this.BtnIsEmpty_Click);
            // 
            // BtnFill
            // 
            this.BtnFill.Location = new System.Drawing.Point(566, 12);
            this.BtnFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnFill.Name = "BtnFill";
            this.BtnFill.Size = new System.Drawing.Size(63, 26);
            this.BtnFill.TabIndex = 11;
            this.BtnFill.Text = "Auto-Fill";
            this.BtnFill.UseVisualStyleBackColor = true;
            this.BtnFill.Click += new System.EventHandler(this.BtnFill_Click);
            // 
            // FindBox
            // 
            this.FindBox.Location = new System.Drawing.Point(315, 18);
            this.FindBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindBox.Name = "FindBox";
            this.FindBox.Size = new System.Drawing.Size(68, 20);
            this.FindBox.TabIndex = 13;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(16, 52);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(68, 20);
            this.NameTextBox.TabIndex = 14;
            // 
            // FindOPBox
            // 
            this.FindOPBox.Location = new System.Drawing.Point(315, 53);
            this.FindOPBox.Margin = new System.Windows.Forms.Padding(2);
            this.FindOPBox.Name = "FindOPBox";
            this.FindOPBox.ReadOnly = true;
            this.FindOPBox.Size = new System.Drawing.Size(68, 20);
            this.FindOPBox.TabIndex = 15;
            // 
            // Payroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 211);
            this.Controls.Add(this.FindOPBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.FindBox);
            this.Controls.Add(this.BtnFill);
            this.Controls.Add(this.BtnIsEmpty);
            this.Controls.Add(this.BtnMakeEmpty);
            this.Controls.Add(this.BtnFindMax);
            this.Controls.Add(this.BtnFindMin);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.BtnRemoveMin);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.Display);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Payroll";
            this.Text = "Payroll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Display;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnRemoveMin;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.Button BtnFindMin;
        private System.Windows.Forms.Button BtnFindMax;
        private System.Windows.Forms.Button BtnMakeEmpty;
        private System.Windows.Forms.Button BtnIsEmpty;
        private System.Windows.Forms.Button BtnFill;
        private System.Windows.Forms.TextBox FindBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox FindOPBox;
    }
}

