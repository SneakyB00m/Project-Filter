﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Filter
{
    public partial class Convert : UserControl
    {
        string folderPath;
        Actions actions = new Actions();

        public Convert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected item
            string selectedOption = comboBox_Selector.SelectedItem.ToString();
            OpenFileDialog openDialog = new OpenFileDialog();

            switch (selectedOption)
            {
                case "IMAGE > ASCII":
                    openDialog.Title = "Select A File";
                    openDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
                    openDialog.InitialDirectory = @"C:\";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = openDialog.FileName;
                        textBox_Path.Text = folderPath;
                    }
                    break;
                case "IMAGES > PFD":
                    folderPath = actions.OpenFolderManager();
                    textBox_Path.Text = folderPath;
                    break;
                case "IMAGE > ICO":
                    openDialog.Title = "Select A File";
                    openDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
                    openDialog.InitialDirectory = @"C:\";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = openDialog.FileName;
                        textBox_Path.Text = folderPath;
                    }
                    break;
                default:
                    MessageBox.Show("Select first an option");
                    break;
            }
        }

        private void Convert_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(folderPath))
            {
                // Check if an item is selected in the ComboBox
                if (comboBox_Selector.SelectedItem != null)
                {
                    // Get the selected item
                    string selectedOption = comboBox_Selector.SelectedItem.ToString();

                    switch (selectedOption)
                    {
                        case "IMAGES > PFD":
                            actions.ConvertImagesToPdf(folderPath);
                            break;
                        case "IMAGE > ICO":
                            actions.ConvertImageToIco(folderPath);
                            break;
                        case "IMAGE > ASCII":
                            actions.ConvertImageToAscii(folderPath);
                            break;
                        case "PDF - TITLE ":
                            break;
                        case "IMAGE COLLAGE":
                            break;
                        default:
                            MessageBox.Show("No file selected");
                            break;
                    }
                }
                else
                {
                    // No item is selected in the ComboBox
                    Debug.WriteLine("No option selected.");
                }
            }
            else
            {
                MessageBox.Show("No Folder Selected.");
            }
        }
    }
}
