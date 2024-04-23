using Newtonsoft.Json;
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
    public partial class Menu_Sizes : UserControl
    {
        private Dictionary<string, int> myDict;

        public Menu_Sizes()
        {
            InitializeComponent();
        }

        private void Config_Sizes_Load(object sender, EventArgs e)
        {
            if (File.Exists("Sizes.json"))
            {
                string json = File.ReadAllText("Sizes.json");

                // Read the JSON file
                myDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

                // Populate the folder list with the keys from the dictionary
                foreach (var key in myDict.Keys)
                {
                    // Add the key to the folder list
                    listBox_Folders.Items.Add(key);
                }
            }

        }

        private void listBox_Folders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the items in listBox_Extension
            listBox_Extension.Items.Clear();

            // Get the selected key from listBox_Folders
            string selectedKey = listBox_Folders.SelectedItem.ToString();

            // Get the value associated with the selected key from the dictionary
            int value = myDict[selectedKey];

            // Add the value to listBox_Extension
            listBox_Extension.Items.Add(value);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

        }

        private void button_Remove_Click(object sender, EventArgs e)
        {

        }
    }
}
