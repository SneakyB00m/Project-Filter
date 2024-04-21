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

        List<string> checkedOrder = new List<string>();
        string selectedPath;

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

                        break;
                    case "Duration":

                        break;
                    case "Include":

                        break;
                    case "Size":

                        break;
                    case "AtoZ":

                        break;
                }
            }
        }

        // Sorts
        public static void SortFiles(string jsonFile, string rootPath)
        {
            // Load the JSON file
            var folders = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(System.IO.File.ReadAllText(jsonFile));

            // Walk through the directory
            foreach (var file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                // Get the file extension
                string fileExt = Path.GetExtension(file).ToLower();

                // Check if the file extension is in the dictionary
                foreach (var folder in folders)
                {
                    if (folder.Value.Contains(fileExt))
                    {
                        // Construct the source and destination paths
                        string srcPath = file;
                        string destPath = Path.Combine(rootPath, folder.Key, Path.GetFileName(file));

                        // Create the destination folder if it doesn't exist
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // Move the file
                        System.IO.File.Move(srcPath, destPath);

                        break;
                    }
                }
            }
        }

        public static void SortAlphabetically(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Sort the files alphabetically
                var sortedFiles = files.OrderBy(f => f).ToList();

                // Rename the files to sort them alphabetically
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    System.IO.File.Move(sortedFiles[i], newPath);
                }
            }
        }
    }
}