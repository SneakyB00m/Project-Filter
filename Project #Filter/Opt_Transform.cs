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

        //public void ConvertImagesToPdf(string folderPath)
        //{
        //    // Define the PDF file path
        //    string pdfFile = Path.Combine(folderPath, "Album.pdf");

        //    // Get all image files in the directory and its subdirectories
        //    string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
        //        .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".bmp")).ToArray();

        //    // Check if the PDF file already exists
        //    if (File.Exists(pdfFile))
        //    {
        //        // Create a new PDF file with a unique name
        //        int count = 1;
        //        while (File.Exists(pdfFile))
        //        {
        //            pdfFile = Path.Combine(folderPath, $"Album ({count}).pdf");
        //            count++;
        //        }
        //    }

        //    using (FileStream stream = new FileStream(pdfFile, FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        using (Document document = new Document())
        //        {
        //            PdfWriter.GetInstance(document, stream);
        //            document.Open();

        //            foreach (string imageFile in imageFiles)
        //            {
        //                if (File.Exists(imageFile))
        //                {
        //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFile);
        //                    document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
        //                    document.NewPage();
        //                    image.SetAbsolutePosition(0, 0);
        //                    document.Add(image);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}


