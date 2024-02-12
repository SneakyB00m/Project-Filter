using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Filter
{
    public partial class Extract : UserControl
    {
        string selectedPath;

        public Extract()
        {
            InitializeComponent();
        }

        private void button_Folder_Click(object sender, EventArgs e)
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

        private void button_Extract_Click(object sender, EventArgs e)
        {
            List<string> checkedRadios = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = control as RadioButton;
                    if (radioButton.Checked)
                    {
                        checkedRadios.Add(radioButton.Name);
                    }
                }
            }

            if (checkedRadios.Count > 0)
            {
                // Call the Filter function
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    switch (checkedRadios[0]) // Assuming only one radio button can be selected at a time
                    {
                        case "radioButton_Folder":
                            ExtractFiles(selectedPath);
                            break;
                        case "radioButton_Unrar":
                            // Handle radioButton2
                            break;
                        case "radioButton_Zip":
                            // Handle radioButton2
                            break;
                        case "radioButton_Unzip":
                            // Handle radioButton2
                            break;
                        case "radioButton_Tar":
                            // Handle radioButton2
                            break;
                        case "radioButton_Untar":
                            // Handle radioButton2
                            break;
                        // Add more cases as needed
                        default:
                            MessageBox.Show("Unexpected radio button selection.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Not selected path");
                }
            }
            else
            {
                MessageBox.Show("No radio buttons are checked.");
            }
        }

        private void ExtractFiles(string path)
        {  // Handle radioButton_Folder
            string targetPath = Path.Combine(path, "extracted"); // The path of the target directory

            // Create the target directory if it doesn't exist
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // Get the files in the source directory and move them to the target directory
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string sourceFile in files)
            {
                string fileName = Path.GetFileName(sourceFile);
                string targetFile = Path.Combine(targetPath, fileName);
                File.Move(sourceFile, targetFile);
            }
        }
    }
}
