using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        private string folderPath;
        Actions actions = new Actions();

        public Filter()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            folderPath = actions.OpenFolderManager();
            textBox_Path.Text = folderPath;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(folderPath))
            {
                List<CheckBox> checkedCheckBoxes = actions.GetCheckedCheckBoxes(this);

                if (checkedCheckBoxes.Count > 0)
                {
                    // Handle the action for each checked checkbox
                    foreach (CheckBox checkBox in checkedCheckBoxes)
                    {
                        switch (checkBox.Name)
                        {
                            case "checkBox_Include":
                                break;
                            case "checkBox_Exclude":
                                break;
                            case "checkBox_AtoZ":
                                actions.HandleAToZ(folderPath);
                                break;
                            case "checkBox_Extension":
                                break;
                            case "checkBox_Size":
                                break;
                            case "checkBox_Date":
                                break;
                            case "checkBox_Resolution":
                                break;
                            case "checkBox_Duration":
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
            else
            {
                MessageBox.Show("No Folder Selected.");
            }
        }

        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Include.Checked)
            {
                checkBox_Exclude.Checked = false;
            }
        }

        private void checkBox_Exclude_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Exclude.Checked)
            {
                checkBox_Include.Checked = false;
            }
        }
    }
}

public class Actions
{
    public string? OpenFolderManager()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    public List<CheckBox> GetCheckedCheckBoxes(UserControl userControl)
    {
        List<CheckBox> checkedCheckBoxes = new List<CheckBox>();

        foreach (Control control in userControl.Controls)
        {
            if (control is CheckBox)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox.Checked)
                {
                    checkedCheckBoxes.Add(checkBox);
                }
            }
        }

        return checkedCheckBoxes; // Return the list of checked checkboxes
    }


    public void HandleInclude(string folderPath, string include)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleExclude(string folderPath, string exclude)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleExtension(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }


    public void HandleAToZ(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleSize(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleDate(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleResolution(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleDuration(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public void HandleDelete(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }
}

