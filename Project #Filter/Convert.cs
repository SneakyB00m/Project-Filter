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
using iTextSharp.text.pdf;
using iTextSharp.text;
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
                    PDFNoTitle();
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

                string pdfPath = Path.Combine(selectedPath, $"{Title}.pdf");

                // Create a Document object
                Document document = new Document();

                // Create a PdfWriter object
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                // Open the Document
                document.Open();

                string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                    .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png"))
                                    .ToArray();

                foreach (string imageFile in imageFiles)
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFile);

                    // Set the page size to the image size
                    document.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image.Width, image.Height));

                    // Add a new page
                    document.NewPage();

                    // Add the image to the document
                    document.Add(image);
                }

                // Close the Document
                document.Close();

                MessageBox.Show($"PDF created successfully at: {pdfPath}");
            }
            else if (radioButton_Folder.Checked)
            {

            }

            else
            {
                MessageBox.Show("No radio button is checked.");
            }
        }

        private void PDFNoTitle()
        {
            string pdfPath = Path.Combine(selectedPath, $"Notitle.pdf");

            // Create a PdfDocument object
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

            string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                             .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png"))
                                             .ToArray();

            foreach (string imageFile in imageFiles)
            {
                XImage image = XImage.FromFile(imageFile);

                // Create a new page with the dimensions of the image
                PdfSharp.Pdf.PdfPage page = document.AddPage();
                page.Width = image.PointWidth;
                page.Height = image.PointHeight;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw the image to fit the page
                gfx.DrawImage(image, 0, 0, page.Width, page.Height);
            }

            // Save the document
            document.Save(pdfPath);

            MessageBox.Show($"PDF created successfully at: {pdfPath}");
        }

        private void ImageIcon() {

        }

        private void DeleteFiles()
        {
            if (checkBox_Delete.Checked)
            {

            }
        }
    }
}


