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

        public Filter()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            Actions actions = new Actions();
            folderPath = actions.OpenFolderManager();
            textBox_Path.Text = folderPath;
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
}

