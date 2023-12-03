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
        private string folderPath;
        Actions actions = new Actions();

        public Extract()
        {
            InitializeComponent();
        }

        private void button_Folder_Click(object sender, EventArgs e)
        {
            folderPath = actions.OpenFolderManager();
            textBox_Path.Text = folderPath;
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            List<RadioButton> checkedRadioButtons = actions.GetCheckedRadioButtons(this);

            if (checkedRadioButtons.Count > 0)
            {
                // Handle the action for each checked radio button
                foreach (RadioButton radioButton in checkedRadioButtons)
                {
                    switch (radioButton.Name)
                    {
                        case "radioButton_Folder":
                            if (!string.IsNullOrEmpty(folderPath))
                            {
                                actions.HandleFolder(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No Folder Selected.");
                            }
                            break;
                        case "radioButton_Zip":
                            if (!string.IsNullOrEmpty(folderPath))
                            {
                                actions.HandleZip(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No Folder Selected.");
                            }
                            break;
                        case "radioButton_Unzip":
                            // Create a new instance of OpenFileDialog
                            OpenFileDialog zipfile = new OpenFileDialog();

                            // Set the filter to only show zip files
                            zipfile.Filter = "Zip files (*.zip)|*.zip";

                            // Show the dialog and get result
                            if (zipfile.ShowDialog() == DialogResult.OK)
                            {
                                string zipFilePath = zipfile.FileName;

                                // Now you can use the zip file path
                                actions.HandleUnZip(zipFilePath);
                            }
                            break;
                        case "radioButton_Tar":
                            if (!string.IsNullOrEmpty(folderPath))
                            {
                                actions.HandleTar(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No Folder Selected.");
                            }
                            break;
                        case "radioButton_Untar":
                            // Create a new instance of OpenFileDialog
                            OpenFileDialog tarfile = new OpenFileDialog();

                            // Set the filter to only show tar files
                            tarfile.Filter = "Tar files (*.tar)|*.tar";

                            // Show the dialog and get result
                            if (tarfile.ShowDialog() == DialogResult.OK)
                            {
                                string tarFilePath = tarfile.FileName;

                                // Now you can use the tar file path
                                actions.HandleUnTar(tarFilePath);
                            }
                            break;

                        case "radioButton_Unrar":
                            // Create a new instance of OpenFileDialog
                            OpenFileDialog rarfile = new OpenFileDialog();

                            // Set the filter to only show rar files
                            rarfile.Filter = "RAR files (*.rar)|*.rar";

                            // Show the dialog and get result
                            if (rarfile.ShowDialog() == DialogResult.OK)
                            {
                                string rarFilePath = rarfile.FileName;

                                // Now you can use the rar file path
                                actions.HandleUnRar(rarFilePath);
                            }

                            break;
                        default:
                            MessageBox.Show("Error !!!");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No selection is checked.");
            }
        }
    }
}
