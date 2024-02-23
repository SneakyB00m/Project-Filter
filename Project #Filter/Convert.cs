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
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Project__Filter
{
    public partial class Convert : UserControl
    {
        string selectedPath;
        string SelectedBox;

        public Convert()
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
                }
            }
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the ComboBox from the sender
            ComboBox comboBox = sender as ComboBox;

            // Get the selected item
            string selectedItem = comboBox.SelectedItem.ToString();

            SelectedBox = selectedItem;
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            switch (SelectedBox)
            {
                case "IMAGE To PDF (TITLE)":
                    PDFTitle();
                    break;
                case "IMAGE To PDF (NO TITLE)":
                    break;
                case "IMAGE To ICO":
                    break;
                case "IMAGE To WEBP":
                    break;
                case "IMAGE To BMP":
                    break;
                case "IMAGE To ASCII":
                    break;
                case "VIDEO To GIF":
                    break;
                case "VIDEO To AUDIO":
                    break;
                case "VIDEO To WEBM":
                    break;
                case "VIDEO To AVI":
                    break;
                case "AUDIO To WAV":
                    break;
                default:
                    break;
            }
            DeleteFiles();
        }

        private void PDFTitle()
        {

            if (radioButton_Custom.Checked)
            {
                string Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the title for:", "Title Text", "Default", -1, -1);

                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont font = new XFont("Arial Bold", 20);

                    // Set the title on the first page
                    gfx.DrawString(Title, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                    string[] imageFiles = Directory.GetFiles(selectedPath, "*.{jpg,jpeg,png}"); // Look for jpg, jpeg, and png files

                    foreach (string imageFile in imageFiles)
                    {
                        using (XImage image = XImage.FromFile(imageFile))
                        {
                            page = document.AddPage();
                            gfx = XGraphics.FromPdfPage(page);

                            // Adjust image size as per the page size
                            gfx.DrawImage(image, 0, 0, page.Width, page.Height);
                        }
                    }

                    string pdfPath = Path.Combine(selectedPath, $"{Title}.pdf");
                    document.Save(pdfPath);
                    MessageBox.Show($"PDF created successfully at: {pdfPath}");
                }
            }
            else if (radioButton_Folder.Checked)
            {
                MessageBox.Show("Radio Button 2 is checked.");
            }
            else
            {
                MessageBox.Show("No radio button is checked.");
            }


          
        }
        private void DeleteFiles()
        {
            if(checkBox_Delete.Checked)
            {

            }
        }
    }
}


