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
    public partial class Config_Menu : UserControl
    {
        public Config_Menu()
        {
            InitializeComponent();

        }

        private void button_Folder_Click(object sender, EventArgs e)
        {

            config_Folders1.BringToFront();
        }

        private void button_Size_Click(object sender, EventArgs e)
        {

            config_Sizes1.BringToFront();
        }
    }
}
