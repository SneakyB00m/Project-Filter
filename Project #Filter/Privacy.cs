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
    public partial class Privacy : UserControl
    {
        private string folderPath;
        Actions actions = new Actions();

        public Privacy()
        {
            InitializeComponent();
        }

        private void button_FilePath_Click(object sender, EventArgs e)
        {
            folderPath = actions.OpenFolderManager();
            textBox_Path.Text = folderPath;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkedCheckBoxes = actions.GetCheckedCheckBoxes(this);

            if (checkedCheckBoxes.Count > 0)
            {
                // Handle the action for each checked checkbox
                foreach (CheckBox checkBox in checkedCheckBoxes)
                {
                    switch (checkBox.Name)
                    {
                        case "checkBox_Encrypt":
                            if (!string.IsNullOrEmpty(folderPath))
                            {
                                actions.HandleEncrypt(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No Folder Selected.");
                            }
                            break;
                        case "checkBox_Decrypt":
                            if (!string.IsNullOrEmpty(folderPath))
                            {
                                actions.HandleDecrypt(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No Folder Selected.");
                            }
                            break;
                        case "checkBox_Delete":
                            break;
                        default:
                            MessageBox.Show("Error !!!");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No checkbox is checked.");
            }
        }

        private void checkBox_Encrypt_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_Encrypt.Checked)
            {
                checkBox_Decrypt.Checked = false;
            }
        }

        private void checkBox_Decrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Decrypt.Checked)
            {
                checkBox_Encrypt.Checked = false;
            }
        }
    }
}
