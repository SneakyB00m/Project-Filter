using System.Data;
using System.Drawing.Imaging;
using ImageMagick;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NAudio.Wave;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        string selectedPath = string.Empty;

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
                    case "IMAGE To PDF [TITLE]":
                        EnableOptions(selectedItem);
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "tiff", "bmp" };
                        break;
                    case "IMAGE To PDF [NO TITLE]":
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
                    listBox_File.Items.Add(Path.GetFileName(imageFile));
                }
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            // Get the selected item
            string selectedItem = comboBox_Select.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "IMAGE To PDF [TITLE]":
                    Title();
                    break;
                case "IMAGE To PDF [NO TITLE]":
                    Untitled();
                    break;
                case "IMAGE To ICO":
                    IconBuilder(selectedPath);
                    break;
                case "IMAGE To WEBP":
                    WebpBuilder(selectedPath);
                    break;
                case "IMAGE To BMP":
                    BMPBuilder(selectedPath);
                    break;
                case "VIDEO To AUDIO":
                    MP3Builder(selectedPath);
                    break;
                case "VIDEO To WEBM":
                    WEBMBuilder(selectedPath);
                    break;
                case "VIDEO To AVI":
                    AVIBuilder(selectedPath);
                    break;
                case "VIDEO To GIF":
                    GIFBuilder(selectedPath);
                    break;
                case "AUDIO To WAV":
                    WAVBuilder(selectedPath);
                    break;
                default:
                    MessageBox.Show("Invalid select", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            if (checkBox_Delete.Checked)
            {

            }

        }

        // Functions - Switch
        private async void Title()
        {
            string Title = string.Empty;
            byte[] pdfBytes = await PDFBuilder(selectedPath);
            if (radioButton_Custom.Checked)
            {
                Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "", -1, -1);
            }
            else if (radioButton_Folder.Checked)
            {
                Title = Path.GetFileName(selectedPath);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                byte[] pdfBytesWithTitle = AddTitle(pdfBytes, Title);

                string baseFileName = Title;
                string extension = ".pdf";
                int counter = 1;

                // Create the initial file path
                string pdfPath = Path.Combine(selectedPath, baseFileName + extension);

                // If a file with the same name already exists, append a number to the filename
                while (File.Exists(pdfPath))
                {
                    pdfPath = Path.Combine(selectedPath, $"{baseFileName} {counter}{extension}");
                    counter++;
                }

                // Write the bytes to a file
                File.WriteAllBytes(pdfPath, pdfBytesWithTitle);

                string pdfFileName = Path.GetFileName(pdfPath);
                MessageBox.Show($"PDF '{pdfFileName}' created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Title not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void Untitled()
        {
            // Call the PDFBuilder method to create the PDF document
            byte[] pdfBytes = await PDFBuilder(selectedPath);

            string baseFileName = "Untitled";
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


            string pdfFileName = Path.GetFileName(pdfPathNoTitle);
            MessageBox.Show($"PDF '{pdfFileName}' created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Functions - General
        private void EnableOptions(string Option)
        {
            switch (Option)
            {
                case "IMAGE To PDF [TITLE]":
                    radioButton_Custom.Enabled = true;
                    radioButton_Folder.Enabled = true;
                    checkBox_Alphabetical.Enabled = true;
                    checkBox_Date.Enabled = true;
                    checkBox_Size.Enabled = true;
                    break;
                case "IMAGE To PDF [NO TITLE]":
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

        private async Task<List<string>> PathSelectedFiles(string rootpath)
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

        private async Task<byte[]> PDFBuilder(string rootpath)
        {
            // Create a new PDF document
            Document document = new Document();
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a new PdfWriter object, pointing it to our MemoryStream
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Open the Document for writing
                document.Open();

                List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

                // Initialize the progress bar
                progressBar_Time.Minimum = 0;
                progressBar_Time.Maximum = selectedFilePaths.Count;
                progressBar_Time.Value = 0;

                // Iterate through the list of selected file paths
                foreach (string filePath in selectedFilePaths)
                {
                    // Add the image to the document
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(filePath);
                    document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
                    document.NewPage();
                    image.SetAbsolutePosition(0, 0);
                    document.Add(image);

                    // Update the progress bar
                    progressBar_Time.Value++;
                }

                // Close the Document - this saves it to the MemoryStream
                document.Close();

                // Reset the progress bar
                progressBar_Time.Value = 0;

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

                // Set the page size for the title page
                document.SetPageSize(PageSize.A4);

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
                    document.SetPageSize(reader.GetPageSizeWithRotation(i));
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

        private async Task IconBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the icons
            string iconDirectory = Path.Combine(rootpath, "Icons");
            Directory.CreateDirectory(iconDirectory);

            int iconCount = 1;

            // Define the maximum width and height
            int maxWidth = 256; // Change this to your desired maximum width
            int maxHeight = 256; // Change this to your desired maximum height

            // List to hold the file paths of the images that are too large
            List<string> largeImages = new List<string>();

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                using (MagickImage image = new MagickImage(filePath))
                {
                    // Check if the image dimensions exceed the maximum
                    if (image.Width > maxWidth || image.Height > maxHeight)
                    {
                        largeImages.Add(filePath);
                        continue;
                    }

                    // Convert the image to .ico format
                    image.Format = MagickFormat.Icon;

                    // Save the .ico file in the new directory
                    string iconPath = Path.Combine(iconDirectory, $"Icon {iconCount}.ico");
                    image.Write(iconPath);

                    iconCount++;

                    // Update the progress bar
                    progressBar_Time.Value++;
                }
            }

            // Reset the progress bar
            progressBar_Time.Value = 0;

            // If there are any large images, show a MessageBox with their file paths
            if (largeImages.Count > 0)
            {
                string message = "The following images are too large. Maximum size is " + maxWidth + "x" + maxHeight + ":\n\n" + string.Join("\n", largeImages);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task WebpBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the webp images
            string webpDirectory = Path.Combine(rootpath, "Images Webp");
            Directory.CreateDirectory(webpDirectory);

            int imageCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                using (MagickImage image = new MagickImage(filePath))
                {
                    // Convert the image to .webp format
                    image.Format = MagickFormat.WebP;

                    // Save the .webp file in the new directory
                    string webpPath = Path.Combine(webpDirectory, $"Image {imageCount}.webp");
                    image.Write(webpPath);

                    imageCount++;

                    // Update the progress bar
                    progressBar_Time.Value++;
                }
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task BMPBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the bmp images
            string bmpDirectory = Path.Combine(rootpath, "Images BMP");
            Directory.CreateDirectory(bmpDirectory);

            int imageCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                using (MagickImage image = new MagickImage(filePath))
                {
                    // Convert the image to .bmp format
                    image.Format = MagickFormat.Bmp;

                    // Save the .bmp file in the new directory
                    string bmpPath = Path.Combine(bmpDirectory, $"Image {imageCount}.bmp");
                    image.Write(bmpPath);

                    imageCount++;

                    // Update the progress bar
                    progressBar_Time.Value++;
                }
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task MP3Builder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the mp3 files
            string mp3Directory = Path.Combine(rootpath, "Files MP3");
            Directory.CreateDirectory(mp3Directory);

            int fileCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                // Define the output file path
                string mp3Path = Path.Combine(mp3Directory, $"File {fileCount}.mp3");

                // Convert the .wav file to .mp3 format
                using (var reader = new NAudio.Wave.AudioFileReader(filePath))
                {
                    MediaFoundationEncoder.EncodeToMp3(reader, mp3Path);
                }

                fileCount++;

                // Update the progress bar
                progressBar_Time.Value++;
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task WEBMBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the webm files
            string webmDirectory = Path.Combine(rootpath, "Files WEBM");
            Directory.CreateDirectory(webmDirectory);

            int fileCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                // Define the output file path
                string webmPath = Path.Combine(webmDirectory, $"File {fileCount}.webm");

                // Convert the video file to .webm format
                converter.ConvertMedia(filePath, webmPath, NReco.VideoConverter.Format.webm);

                fileCount++;

                // Update the progress bar
                progressBar_Time.Value++;
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task AVIBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the avi files
            string aviDirectory = Path.Combine(rootpath, "Files AVI");
            Directory.CreateDirectory(aviDirectory);

            int fileCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                // Define the output file path
                string aviPath = Path.Combine(aviDirectory, $"File {fileCount}.avi");

                // Convert the video file to .avi format
                converter.ConvertMedia(filePath, aviPath, NReco.VideoConverter.Format.avi);

                fileCount++;

                // Update the progress bar
                progressBar_Time.Value++;
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task GIFBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the gif files
            string gifDirectory = Path.Combine(rootpath, "Files GIF");
            Directory.CreateDirectory(gifDirectory);

            int fileCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Create a new instance of FFProbe
            var ffProbe = new NReco.VideoInfo.FFProbe();

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                // Get the duration of the video
                var videoInfo = ffProbe.GetMediaInfo(filePath);
                double videoDuration = videoInfo.Duration.TotalSeconds;

                // Check if the video is 15 seconds or less
                if (videoDuration <= 15)
                {
                    // Define the output file path
                    string gifPath = Path.Combine(gifDirectory, $"File {fileCount}.gif");

                    // Convert the video file to .gif format
                    var converter = new NReco.VideoConverter.FFMpegConverter();
                    converter.ConvertMedia(filePath, gifPath, NReco.VideoConverter.Format.gif);

                    fileCount++;

                    // Update the progress bar
                    progressBar_Time.Value++;
                }
                else
                {
                    Console.WriteLine($"The video at {filePath} is longer than 15 seconds and will not be converted.");
                }
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }

        private async Task WAVBuilder(string rootpath)
        {
            List<string> selectedFilePaths = await PathSelectedFiles(rootpath);

            // Create a new directory for the wav files
            string wavDirectory = Path.Combine(rootpath, "WAVFiles");
            Directory.CreateDirectory(wavDirectory);

            int fileCount = 1;

            // Initialize the progress bar
            progressBar_Time.Minimum = 0;
            progressBar_Time.Maximum = selectedFilePaths.Count;
            progressBar_Time.Value = 0;

            // Iterate through the list of selected file paths
            foreach (string filePath in selectedFilePaths)
            {
                // Define the output file path
                string wavPath = Path.Combine(wavDirectory, $"File {fileCount}.wav");

                // Convert the audio file to .wav format
                using (var reader = new AudioFileReader(filePath))
                {
                    WaveFileWriter.CreateWaveFile(wavPath, reader);
                }

                fileCount++;

                // Update the progress bar
                progressBar_Time.Value++;
            }
            // Reset the progress bar
            progressBar_Time.Value = 0;
        }
    }
}


