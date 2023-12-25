using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.Design.AxImporter;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string folderPath;
        Dictionary<string, object> JsonData;
        Actions actions = new Actions();

        List<CheckBox> checkedOrder = new List<CheckBox>();

        public Filter()
        {
            InitializeComponent();

            // Add the CheckedChanged event handler for each checkbox
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    checkBox.CheckedChanged += checkBox_CheckedChanged;
                }
            }
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            string filePath = "Config.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error No config File Found");
            }
            else
            {
                // Read the JSON file
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON string to a dictionary
                JsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
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
                List<CheckBox> checkedCheckBoxes = GetCheckedCheckBoxes();

                if (checkedCheckBoxes.Count > 0)
                {
                    // Handle the action for each checked checkbox
                    foreach (CheckBox checkBox in checkedCheckBoxes)
                    {
                        switch (checkBox.Name)
                        {
                            case "checkBox_Include":
                                string inputInclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                                actions.OrganizeFilesBasedOnCriteria(folderPath, JsonData, inputInclude);
                                break;
                            case "checkBox_Extension":
                                actions.OrganizeFilesBasedOnExtension(folderPath, JsonData);
                                break;
                            case "checkBox_Resolution":
                                actions.OrganizeFilesBasedOnResolution(folderPath, JsonData);
                                break;
                            case "checkBox_Duration":
                                actions.OrganizeFilesBasedOnDuration(folderPath, JsonData);
                                break;
                            case "checkBox_Size":
                                actions.OrganizeFilesBasedOnSize(folderPath, JsonData);
                                break;
                            case "checkBox_AtoZ":
                                actions.OrganizeFilesBasedOnAToZ(folderPath, JsonData);
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

        // Funcs
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                checkedOrder.Add(checkBox);
            }
            else
            {
                checkedOrder.Remove(checkBox);
            }
        }

        public List<CheckBox> GetCheckedCheckBoxes()
        {
            return checkedOrder; // Return the list of checked checkboxes in the order they were chec
        }
    }
}
