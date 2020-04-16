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
using LumenWorks.Framework.IO.Csv;

namespace JMCClimateSensor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // create a blank table which accepts user input
        // table is 7 days by 6 weeks to allow a potential max range
        // for a 31 day month starting on sunday
        private void InitBlankForm()
        {
            ClearAll();

            int daysPerWeek = 7;
            int weeksPerMonth = 6;
            weatherTable.TopLeftHeaderCell.Value = "Values in °C";

            for (int i = 0; i < weeksPerMonth; i++)
            {
                string[] emptyArr = new string[daysPerWeek];                
                for (int j = 0; j < daysPerWeek; j++)
                {
                    emptyArr[j] = "";
                }
                weatherTable.Rows.Add(emptyArr);
                FillHeadRows(i);
            }
        }

        // reader method which populates table based on values from a csv file
        private void InsertValuesToTable(string path)
        {
            ClearAll();
            //string path = "../../weatherData/march.csv";
            using (CsvReader csv = new CsvReader(
                                   new StreamReader(path), false))
            {
                int fieldCount = csv.FieldCount;
                //***DEBUG if this is missing, throws missing field exception
                //***this action ensures all records for that row aren't corrupt
                csv.MissingFieldAction = MissingFieldAction.ReplaceByNull;
                int headIndex = 0;
                while (csv.ReadNextRecord()) 
                {
                    string[] row = new string[fieldCount];
                    
                    for (int i = 0 ; i < fieldCount; i++)
                    {
                        row[i] = csv[i] == "" ? "NA" : csv[i];
                    }
                    weatherTable.Rows.Add(row);
                    FillHeadRows(headIndex);
                    headIndex++;
                }
            }
        }

        // name and identify row headers according to week
        private void FillHeadRows(int index)
        {
            weatherTable.Rows[index].HeaderCell.Value = "Week " + (index + 1);
            weatherTable.AutoResizeRowHeadersWidth(index, 
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            
        }


        // deletes all rows
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        // delete all rows, to prevent excess row generation
        private void ClearAll()
        {
            CurrentMonth.Text = "None";
            weatherTable.Rows.Clear();
            weatherTable.Refresh();
        }

        // disable user from entering inappropriate chars
        private void weatherTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // cast to textbox allows greater control and to set restrictions
            TextBox tb = e.Control as TextBox;
            tb.MaxLength = 5;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Col_KeyPress);
            }
        }

        private void Col_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow number, backspace and dot
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }
            // allow only one dot
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;

            }
        }

        // create open file dialog and to get a filepath then load it to table
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try
                {
                    openFileDialog.InitialDirectory = Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath), @"../../weatherData");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                openFileDialog.AutoUpgradeEnabled = true;                
                openFileDialog.Filter = "All files(*.*)| *.*|csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // get file path for other operations
                    filePath = openFileDialog.FileName;
                    InsertValuesToTable(filePath);
                    SetMonthYearDisplay(filePath);
                }                
            }

            
        }

        // open save file dialog to save files as .csv
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath), @"weatherData");
                saveFileDialog.Filter = "All files(*.*)| *.*|csv files (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveFile(filePath);
                    SetMonthYearDisplay(filePath);
                                        
                }
            }
        }

        // save method which takes all values within dgv and saves as a csv
        private void SaveFile(string file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (DataGridViewRow row in weatherTable.Rows)
                    {
                        int colCount = weatherTable.Columns.Count;
                        for (int i = 0; i < colCount; i++)
                        {
                            if (i != (colCount - 1))
                            {
                                sw.Write(row.Cells[i].Value + ",");
                            }
                            else
                            {
                                sw.Write(row.Cells[i].Value + "\n");
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Could not save file - " + e.Message);
            }
            
        }

        // create new blank form
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
            InitBlankForm();
        }

        // exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // basic instructions
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set title
            MessageBox.Show(
                "File -> Open -> .csv file of your choice >> to read and edit" +
                "\n\n" +
                "To add or edit, click any cell and input the temperature. " +
                "Only digits and one decimal point may be entered. " +
                "For any days which lie outside the month, leave them blank " +
                "and they will be automatically be marked NA when loaded.",
                "Instructions"
                );
        }

        // Set date display (in month/year) of selected csv file
        private void SetMonthYearDisplay(string filePath)
        {
            string displayName = Path.GetFileNameWithoutExtension(filePath).
                Replace('_', ' ').ToUpper();
            CurrentMonth.Text = displayName;
        }
    }
}

