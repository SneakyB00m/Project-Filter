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
using com.itextpdf.text.pdf;
using ImageMagick;

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
            if (!string.IsNullOrEmpty(selectedPath))
            {
                ComboBox comboBox = sender as ComboBox;

                // Get the selected item
                string selectedItem = comboBox.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "IMAGE To WEBP":
                    case "IMAGE To BMP":
                    case "IMAGE To ASCII":
                    case "IMAGE To ICO":
                        // Get all the image files in the directory
                        string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                                       .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png"))
                                                       .ToArray();

                        // Clear the ListBox
                        listBox_File.Items.Clear();

                        // Add each file name to the ListBox
                        foreach (string imageFile in imageFiles)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    default:
                        listBox_File.Items.Clear();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Path not selected");
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Get the selected item
                string selectedItem = comboBox_Select.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "IMAGE To PDF (TITLE)":
                        PDFTitle();
                        break;
                    case "IMAGE To PDF (NO TITLE)":
                        PDFNoTitle();
                        break;
                    case "IMAGE To ICO":
                        // Get all the image files in the directory
                        ImageIcon();
                        break;
                    case "IMAGE To WEBP":
                        ImageWebp();
                        break;
                    case "IMAGE To BMP":
                        ImageBMP();
                        break;
                    case "IMAGE To ASCII":
                        ImageAscii();
                        break;
                    case "VIDEO To GIF":
                        // Call your method to convert video to GIF here
                        break;
                    case "VIDEO To AUDIO":
                        // Call your method to convert video to AUDIO here
                        break;
                    case "VIDEO To WEBM":
                        // Call your method to convert video to WEBM here
                        break;
                    case "VIDEO To AVI":
                        // Call your method to convert video to AVI here
                        break;
                    case "AUDIO To WAV":
                        // Call your method to convert audio to WAV here
                        break;
                    default:
                        MessageBox.Show("Invalid selection");
                        break;
                }
                if (checkBox_Delete.Checked)
                {

                }
            }
            else
            {
                MessageBox.Show("Path not selected");
            }
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

        private void ImageIcon()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Load the image file
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                // Get an Hicon for the Bitmap
                IntPtr hIcon = bitmap.GetHicon();

                // Create a new icon from the handle
                Icon icon = Icon.FromHandle(hIcon);

                // Create the full path to the ICO file
                string icoPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".ico");

                // Write the Icon to a File Stream
                using (FileStream fs = new FileStream(icoPath, FileMode.OpenOrCreate))
                {
                    icon.Save(fs);
                }

                MessageBox.Show($"ICO created successfully at: {icoPath}");
            }
        }

        private void ImageWebp()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Create the full path to the WEBP file
            string webpPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".webp");

            // Load the image file
            using (MagickImage image = new MagickImage(imagePath))
            {
                // Convert the image to WEBP and save it
                image.Format = MagickFormat.WebP;
                image.Write(webpPath);
            }

            MessageBox.Show($"WEBP created successfully at: {webpPath}");
        }

        private void ImageBMP()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Create the full path to the BMP file
            string bmpPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".bmp");

            // Load the image file
            using (MagickImage image = new MagickImage(imagePath))
            {
                // Convert the image to BMP and save it
                image.Format = MagickFormat.Bmp;
                image.Write(bmpPath);
            }

            MessageBox.Show($"BMP created successfully at: {bmpPath}");
        }

        private void ImageAscii()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Load the image file
            using (MagickImage image = new MagickImage(imagePath))
            {
                // Resize the image
                image.Resize(100, 0);

                // Convert the image to grayscale
                image.ColorType = ColorType.Grayscale;

                // Define the ASCII characters
                string chars = "@%#*+=-:. ";

                // Create the ASCII art
                StringBuilder asciiArt = new StringBuilder();
                using (var pixels = image.GetPixelsUnsafe())
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            var pixel = pixels.GetPixel(x, y);
                            int gray = (pixel[0] + pixel[1] + pixel[2]) / 3;
                            int index = gray * (chars.Length - 1) / 255;
                            asciiArt.Append(chars[index]);
                        }
                        asciiArt.AppendLine();
                    }
                }

                // Write the ASCII art to a text file
                string asciiPath = Path.Combine(selectedPath, "asciiArt.txt");
                System.IO.File.WriteAllText(asciiPath, asciiArt.ToString());

                MessageBox.Show($"ASCII art created successfully at: {asciiPath}");
            }
        }


        private void VideoGif()
        {

        }
        private void VideoAudio() { }
        private void VideoWemb() { }
        private void VideoAvi() { }
        private void AudioWav() { }


    }
}


