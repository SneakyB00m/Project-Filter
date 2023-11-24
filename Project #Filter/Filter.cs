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
                                string inputInclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                                actions.HandleInclude(folderPath, inputInclude);
                                break;
                            case "checkBox_Exclude":
                                string inputExclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                                actions.HandleExclude(folderPath, inputExclude);
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

    public List<string> HandleInclude(string folderPath, string include)
    {
        // Create the "filtered" directory if it doesn't exist
        string filteredPath = Path.Combine(folderPath, "Filtered");
        if (!Directory.Exists(filteredPath))
        {
            Directory.CreateDirectory(filteredPath);
        }

        // Create the "include" directory inside the "filtered" directory
        string includePath = Path.Combine(filteredPath, "Includes");
        if (!Directory.Exists(includePath))
        {
            Directory.CreateDirectory(includePath);
        }

        // Get all files in the folder and its subfolders
        List<string> allFiles = GetAllFiles(folderPath);

        // Filter the files based on the include string
        List<string> includedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(include, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        // List to store the destination paths of the moved files
        List<string> destinationPaths = new List<string>();

        // Move the included files to the "include" directory
        foreach (string file in includedFiles)
        {
            string destinationPath = Path.Combine(includePath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);

            // Add the destination path to the list
            destinationPaths.Add(destinationPath);
        }

        // Return the list of destination paths
        return destinationPaths;
    }


    public void HandleExclude(string folderPath, string exclude)
    {

    }

    public void HandleExtension(string folderPath)
    {

    }

    public void HandleResolution(string folderPath)
    {

    }

    public void HandleDuration(string folderPath)
    {

    }

    public void HandleSize(string folderPath)
    {

    }

    public void HandleDate(string folderPath)
    {

    }

    public void HandleAToZ(string folderPath)
    {

    }

    public void HandleDelete(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public List<string> GetAllFiles(string folderPath)
    {
        List<string> filesList = new List<string>();

        // Check if the directory exists
        if (Directory.Exists(folderPath))
        {
            // Get the files in the directory
            string[] files = Directory.GetFiles(folderPath);
            filesList.AddRange(files);

            // Get the subdirectories in the directory
            string[] subdirectories = Directory.GetDirectories(folderPath);

            // Use a foreach loop to check each subdirectory
            foreach (string subdirectory in subdirectories)
            {
                // Use recursion to get the files in the subdirectory
                List<string> subdirectoryFiles = GetAllFiles(subdirectory);
                filesList.AddRange(subdirectoryFiles);
            }
        }

        return filesList; // Return the list of files
    }

}

