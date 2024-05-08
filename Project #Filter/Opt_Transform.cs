using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        string selectedPath;

        public Opt_Transform()
        {
            InitializeComponent();
            listBox_File.SelectionMode = SelectionMode.MultiExtended;
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

                    comboBox_Select.Enabled = true;
                    button_Convert.Enabled = true;
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

                // Define the file extensions for each case
                List<string> fileExtensions = new List<string>();
                switch (selectedItem)
                {
                    case "IMAGE To PDF (TITLE)":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "tiff", "bmp" };
                        break;
                    case "IMAGE To PDF (NO TITLE)":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "tiff", "bmp" };
                        break;
                    case "IMAGE To ICO":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg" };
                        break;
                    case "IMAGE To WEBP":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg", "tiff" };
                        break;
                    case "IMAGE To BMP":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg", "tiff", "webp" };
                        break;
                    case "IMAGE To ASCII":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png" };
                        break;
                    case "VIDEO To AUDIO":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "mp4", "avi", "mkv", "flv", "mov", "wmv" };
                        break;
                    case "VIDEO To WEBM":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "mp4", "avi", "mkv", "flv", "mov", "wmv", "m4v", "mpeg", "mpg" };
                        break;
                    case "VIDEO To AVI":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "mp4", "mkv", "flv", "mov", "wmv", "m4v", "mpeg", "mpg" };
                        break;
                    case "AUDIO To WAV":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "mp3", "aac", "flac", "m4a", "ogg", "wma", "mpeg", "mpg" };
                        break;
                    default:
                        listBox_File.Items.Clear();
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Alphabetical.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        break;

                }

                // Get all image files in the selected directory that can be converted to the selected format
                string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                               .Where(file => fileExtensions.Any(ext => file.ToLower().EndsWith(ext)))
                                               .ToArray();

                // Count the files
                int initialFileCount = imageFiles.Length;

                // Display just the count in label_Count
                label_Count.Text = initialFileCount.ToString();

                listBox_File.Items.Clear();

                foreach (string imageFile in imageFiles)
                {
                    listBox_File.Items.Add(System.IO.Path.GetFileName(imageFile));
                }
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
                        {
                            byte[] pdfBytes = PDFBuilder(selectedPath);
                            AddTitle(pdfBytes);

                            break;
                        }
                    case "IMAGE To PDF (NO TITLE)":
                        {
                            // Call the PDFBuilder method to create the PDF document
                            byte[] pdfBytes = PDFBuilder(selectedPath);

                            string baseFileName = "Untitle";
                            string extension = ".pdf";
                            int counter = 1;

                            // Create the initial file path
                            string pdfPathNoTitle = Path.Combine(selectedPath, baseFileName + extension);

                            // If a file with the same name already exists, append a number to the filename
                            while (File.Exists(pdfPathNoTitle))
                            {
                                pdfPathNoTitle = Path.Combine(selectedPath, $"{baseFileName} {counter}{extension}");
                                counter++;
                            }

                            // Write the bytes to a file
                            File.WriteAllBytes(pdfPathNoTitle, pdfBytes);

                            MessageBox.Show($"PDF created successfully at: {pdfPathNoTitle}");
                            break;
                        }
                    case "IMAGE To ICO":
                        break;
                    case "IMAGE To WEBP":
                        break;
                    case "IMAGE To BMP":
                        break;
                    case "IMAGE To ASCII":
                        break;
                    case "VIDEO To AUDIO":
                        break;
                    case "VIDEO To WEBM":
                        break;
                    case "VIDEO To AVI":
                        break;
                    case "VIDEO To GIF":
                        break;
                    case "AUDIO To WAV":
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

        // Functions
        private void EnableOptions(string Option)
        {
            switch (Option)
            {
                case "IMAGE To PDF (TITLE)":
                    radioButton_Custom.Enabled = true;
                    radioButton_Folder.Enabled = true;
                    checkBox_Alphabetical.Enabled = true;
                    checkBox_Date.Enabled = true;
                    checkBox_Size.Enabled = true;
                    break;
                case "IMAGE To PDF (NO TITLE)":
                    radioButton_Custom.Enabled = false;
                    radioButton_Folder.Enabled = false;
                    checkBox_Alphabetical.Enabled = true;
                    checkBox_Date.Enabled = true;
                    checkBox_Size.Enabled = true;
                    break;
                default:
                    radioButton_Custom.Enabled = false;
                    radioButton_Folder.Enabled = false;
                    checkBox_Alphabetical.Enabled = false;
                    checkBox_Date.Enabled = false;
                    checkBox_Size.Enabled = false;
                    break;
            }
        }

        private List<string> PathSelectedFiles(string rootpath)
        {
            // Get the selected items in the ListBox
            var selectedItems = listBox_File.SelectedItems;

            // Convert the selected items to a list of strings
            List<string> selectedFiles = selectedItems.Cast<string>().ToList();

            // Create a list to hold the full paths of the selected files
            List<string> fullPaths = new List<string>();

            // Get the full path of each selected file
            foreach (string file in selectedFiles)
            {
                string fullPath = Path.Combine(rootpath, file);
                fullPaths.Add(fullPath);
            }

            if (checkBox_Alphabetical.Checked)
            {
                fullPaths.Sort();
            }
            else if (checkBox_Size.Checked)
            {
                fullPaths.Sort((path1, path2) => new FileInfo(path1).Length.CompareTo(new FileInfo(path2).Length));
            }
            else if (checkBox_Date.Checked)
            {
                fullPaths.Sort((path1, path2) => new FileInfo(path1).CreationTime.CompareTo(new FileInfo(path2).CreationTime));
            }

            return fullPaths;
        }

        private byte[] PDFBuilder(string rootpath)
        {
            // Create a new PDF document
            Document document = new Document();
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a new PdfWriter object, pointing it to our MemoryStream
                PdfWriter.GetInstance(document, stream);

                // Open the Document for writing
                document.Open();

                List<string> selectedFilePaths = PathSelectedFiles(rootpath);

                // Iterate through the list of selected file paths
                foreach (string filePath in selectedFilePaths)
                {
                    // Add the image to the document
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(filePath);
                    document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
                    document.NewPage();
                    image.SetAbsolutePosition(0, 0);
                    document.Add(image);
                }

                // Close the Document - this saves it to the MemoryStream
                document.Close();

                // Convert the MemoryStream to an array and return it
                return stream.ToArray();
            }
        }

        private byte[] AddTitle(byte[] pdfBytes, string Title)
        {
            // Create a new PDF document
            Document document = new Document();
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a new PdfWriter object, pointing it to our MemoryStream
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Open the Document for writing
                document.Open();

                // Add some space before the title
                for (int i = 0; i < 20; i++) // Adjust this value to move the title up or down
                {
                    document.Add(new Paragraph("\n"));
                }

                // Create a new Paragraph with the title
                Paragraph title = new Paragraph(Title, FontFactory.GetFont(FontFactory.HELVETICA, 50f, iTextSharp.text.Font.BOLD));
                title.Alignment = Element.ALIGN_CENTER;

                // Add the title to the document
                document.Add(title);

                // Add some space after the title
                for (int i = 0; i < 10; i++) // Adjust this value to move the title up or down
                {
                    document.Add(new Paragraph("\n"));
                }

                // Create a reader for the existing PDF document
                PdfReader reader = new PdfReader(pdfBytes);

                // Add the pages from the existing PDF document to the new document
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    document.NewPage();
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.DirectContent.AddTemplate(page, 0, 0);
                }

                // Close the Document - this saves it to the MemoryStream
                document.Close();

                // Convert the MemoryStream to an array and return it
                return stream.ToArray();
            }
        }
    }
}


