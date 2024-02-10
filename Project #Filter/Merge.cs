using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project__Filter
{
    public partial class Merge : UserControl
    {
     
        public Merge()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
           
        }

        private void Merge_Load(object sender, EventArgs e)
        {
            // Add the new item to the ComboBox at the first position
            comboBox_Selector.Items.Insert(0, "Select an option");

            // Set the new item as the selected item
            comboBox_Selector.SelectedIndex = 0;

            // Handle the DrawItem event to change the color of the first item
            comboBox_Selector.DrawItem += new DrawItemEventHandler(comboBox_Selector_DrawItem);

            // Handle the SelectedIndexChanged event to prevent selection of the first item
            comboBox_Selector.SelectedIndexChanged += new EventHandler(comboBox_Selector_SelectedIndexChanged);
        }

        private void comboBox_Selector_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == 0) // If it is the first item
            {
                e.Graphics.DrawString(comboBox_Selector.Items[e.Index].ToString(),
                    e.Font, Brushes.Gray, e.Bounds);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(comboBox_Selector.Items[e.Index].ToString(),
                    e.Font, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void comboBox_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Selector.SelectedIndex == 0) // If the first item is selected
            {
                // Change the selected index to the second item
                comboBox_Selector.SelectedIndex = 1;
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
           
        }


    }
}
