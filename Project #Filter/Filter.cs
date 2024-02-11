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



        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedPath = fbd.SelectedPath;
                    // Use 'selectedPath' wherever you need it
                }
            }
        }


        private void button_Filter_Click(object sender, EventArgs e)
        {
            string checkedBoxes = "";

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        checkedBoxes += checkBox.Name + " is checked.\n";
                    }
                }
            }

            if (!string.IsNullOrEmpty(checkedBoxes))
            {
                MessageBox.Show(checkedBoxes);
            }
            else
            {
                MessageBox.Show("No checkboxes are checked.");
            }
        }

        // Funcs
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
