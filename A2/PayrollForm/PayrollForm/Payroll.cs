using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Samuel Siew Fei Lee
// Programming 3 AT2

namespace PayrollForm
{
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
        }

        BinarySearchTree<string> BST = new BinarySearchTree<string>();

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                BST.Insert(NameTextBox.Text);
                UpdateDisplay();
            }
            ClearFields();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (!BST.IsEmpty() && !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                if (BST.Find(NameTextBox.Text) != null)
                {
                    BST.Remove(NameTextBox.Text);
                    UpdateDisplay();
                }
                
            }
            ClearFields();
        }
        private void BtnRemoveMin_Click(object sender, EventArgs e)
        {
            if (!BST.IsEmpty())
            {
                BST.RemoveMin();
                UpdateDisplay();
            }
            ClearFields();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FindBox.Text))
            {
                string target = BST.Find(FindBox.Text);
                FindOPBox.Text = target;
            }
        }

        private void UpdateDisplay()
        {
            Display.Items.Clear();
            if (!BST.IsEmpty())
            {
                Display.Items.Add(BST);
            }
        }        

        private void ClearFields()
        {
            NameTextBox.Clear();
            FindBox.Clear();
            FindOPBox.Clear();
        }

        private void BtnIsEmpty_Click(object sender, EventArgs e)
        {
            string empty = BST.IsEmpty() ? "Tree is empty" : "Tree is not empty";
            MessageBox.Show(empty);
        }

        private void BtnMakeEmpty_Click(object sender, EventArgs e)
        {
            while (!BST.IsEmpty())
            {
                BST.RemoveMin();
                UpdateDisplay();
            }
            ClearFields();
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            if (BST.IsEmpty())
            {
                string[] names = File.ReadAllLines(@"payroll.txt");

                foreach (string n in names)
                {
                    BST.Insert(n);
                    UpdateDisplay();
                }
            }            
        }

        private void BtnFindMin_Click(object sender, EventArgs e)
        {
            if (!BST.IsEmpty())
            {
                FindOPBox.Text = BST.FindMin();
            }
        }

        private void BtnFindMax_Click(object sender, EventArgs e)
        {
            if (!BST.IsEmpty())
            {
                FindOPBox.Text = BST.FindMax();
            }
        }
    }
}
