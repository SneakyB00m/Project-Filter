﻿namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        //Main Main = new Main();
        string selectedPath = "";
        Dictionary<string, List<string>> myDict;
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
                    //myDict = Main.dict;
                }
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            List<string> checkedBoxes = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        checkedBoxes.Add(checkBox.Name);
                    }
                }
            }

            if (checkedBoxes.Count > 0)
            {
                // Call the Filter function
                FilterSort(selectedPath, myDict, checkedBoxes);
            }
            else
            {
                MessageBox.Show("No checkboxes are checked.");
            }
        }

        private void FilterSort(string path, Dictionary<string, List<string>> myDict, List<string> Check)
        {

        }
    }
}