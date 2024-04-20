using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using SharpCompress;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        Dictionary<string, List<string>> myDict;
        List<string> checkedOrder = new List<string>();

        public Filter()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;
                    textBox_Path.Text = selectedPath;
                }
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            if (!string.IsNullOrWhiteSpace(selectedItem))
            {
                switch (selectedItem)
                {
                    case "SORT":
                        //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (RENAME FILE)":
                     //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (FOLDER NAME)":

                        //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (CUSTOM)":

                        //ProcessCheckedOrder();
                        break;
                    case "MOVE ONLY (CUSTOM FOLDER)":

                        //ProcessCheckedOrder();
                        break;
                    case "MOVE ONLY (FILE NAME)":

                        break;
                    default:
                        MessageBox.Show("ERROR");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid selection");
            }

        }

        private void checkBox_Resolution_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Resolution.Checked)
            {
                checkedOrder.Add("Resolution");
            }
            else
            {
                checkedOrder.Remove("Resolution");
            }
        }

        private void checkBox_Duration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Duration.Checked)
            {
                checkedOrder.Add("Duration");
            }
            else
            {
                checkedOrder.Remove("Duration");
            }
        }

        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Include.Checked)
            {
                checkedOrder.Add("Include");
            }
            else
            {
                checkedOrder.Remove("Include");
            }
        }

        private void checkBox_Size_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Size.Checked)
            {
                checkedOrder.Add("Size");
            }
            else
            {
                checkedOrder.Remove("Size");
            }
        }

        private void checkBox_AtoZ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AtoZ.Checked)
            {
                checkedOrder.Add("AtoZ");
            }
            else
            {
                checkedOrder.Remove("AtoZ");
            }
        }

        // Function
        private void ProcessCheckedOrder()
        {
            foreach (string checkboxName in checkedOrder)
            {
                switch (checkboxName)
                {
                    case "Resolution":
                        Resolution();
                        break;
                    case "Duration":
                        Duration();
                        break;
                    case "Include":
                        Include();
                        break;
                    case "Size":
                        FileSize();
                        break;
                    case "AtoZ":
                        Alphabetical();
                        break;
                }
            }
        }

        // Sorts
       
    }
}