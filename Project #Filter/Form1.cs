using Newtonsoft.Json;
using NReco.VideoInfo;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;
using ImageMagick;
using NAudio.Wave;
using PdfSharp.Pdf.IO;
using System.Diagnostics;

namespace Project__Filter
{
    public partial class Form1 : Form
    {
        public string pathDir = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "Path.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                pathDir = data.Directory;
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedDirectory = folderBrowserDialog.SelectedPath;
                    // Create a new JSON file in the project directory
                    var data = new { Directory = selectedDirectory };
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
            }
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    char firstLetter = char.ToUpper(fileName[0]);
                    string subDirectory = Path.Combine(selectedDirectory, firstLetter.ToString());
                    Directory.CreateDirectory(subDirectory);

                    string destinationPath = Path.Combine(subDirectory, fileName);
                    File.Move(file, destinationPath);
                    fileCount++;
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files.");
            }

        }

        private void filterToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_sort_ascending_256;
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory = Path.Combine(selectedDirectory, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                    fileCount++;
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files.");
            }

        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long sizeInMB = fileInfo.Length / (1024 * 1024);

                    string sizeFolder;
                    if (sizeInMB > 1000)
                        sizeFolder = "More than 1GB";
                    else if (sizeInMB > 500)
                        sizeFolder = "500MB to 1GB";
                    else if (sizeInMB > 250)
                        sizeFolder = "250MB to 500MB";
                    else
                        sizeFolder = "Less than 250MB";

                    string destinationDirectory = Path.Combine(selectedDirectory, sizeFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                    fileCount++;
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files based on their sizes.");
            }
        }

        private void typeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory = Path.Combine(selectedDirectory, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                    fileCount++;
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files based on their extensions.");
            }

        }

        private void lenghtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string durationFolder;
                    try
                    {
                        var ffProbe = new FFProbe();
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        double durationInSeconds = videoInfo.Duration.TotalSeconds;

                        if (durationInSeconds >= 3600)
                            durationFolder = "1 hour or more";
                        else if (durationInSeconds >= 3000)
                            durationFolder = "50 min or more";
                        else if (durationInSeconds >= 2400)
                            durationFolder = "40 min or more";
                        else if (durationInSeconds >= 1800)
                            durationFolder = "30 min or more";
                        else if (durationInSeconds >= 1200)
                            durationFolder = "20 min or more";
                        else if (durationInSeconds >= 600)
                            durationFolder = "10 min or more";
                        else if (durationInSeconds >= 300)
                            durationFolder = "5 min or more";
                        else
                            durationFolder = "Less than 5 min";
                    }
                    catch
                    {
                        // Unable to get the duration, put in the undefined folder
                        durationFolder = "Undefined";
                    }

                    string destinationDirectory = Path.Combine(selectedDirectory, durationFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                    fileCount++;
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files based on their durations.");
            }

        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an InputBox to request the text to search for.
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);

            // Create a FolderBrowserDialog to request the path of the folder to check.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    // Get the file name
                    string fileName = Path.GetFileName(file);

                    // Check if the file name contains the search text
                    if (fileName.Contains(searchText))
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, searchText);
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, fileName);
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                    else
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, "Does not contain");
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, fileName);
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files based on whether they contain the search text.");
            }
        }

        private void notContainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an InputBox to request the text to search for.
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);

            // Create a FolderBrowserDialog to request the path of the folder to check.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    // Get the file name
                    string fileName = Path.GetFileName(file);

                    // Check if the file name contains the search text
                    if (!fileName.Contains(searchText))
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, searchText);
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, fileName);
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                    else
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, "Contains");
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, fileName);
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files based on whether they do not contain the search text.");
            }
        }

        private void nameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Create a FolderBrowserDialog to request the path of the folder to check.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    // Get the file name
                    string fileName = Path.GetFileNameWithoutExtension(file);

                    // Check if the file name is similar to any other file name
                    bool isSimilar = false;
                    foreach (var otherFile in files)
                    {
                        if (otherFile == file) continue;

                        string otherFileName = Path.GetFileNameWithoutExtension(otherFile);
                        int distance = LevenshteinDistance(fileName, otherFileName);

                        if (distance <= 3)  // You can adjust this threshold as needed
                        {
                            isSimilar = true;
                            break;
                        }
                    }

                    // If the file name is similar to any other file name, move the file to a new directory
                    if (isSimilar)
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, "Similar");
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, Path.GetFileName(file));
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files with similar names.");
            }
        }

        private int LevenshteinDistance(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;
            var distances = new int[lenA + 1, lenB + 1];

            for (int i = 0; i <= lenA; i++)
                distances[i, 0] = i;

            for (int j = 0; j <= lenB; j++)
                distances[0, j] = j;

            for (int i = 1; i <= lenA; i++)
            {
                for (int j = 1; j <= lenB; j++)
                {
                    int cost = (b[j - 1] == a[i - 1]) ? 0 : 1;

                    distances[i, j] = Math.Min(
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost);
                }
            }

            return distances[lenA, lenB];
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a FolderBrowserDialog to request the path of the folder to check.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                int fileCount = 0;

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    // Get the creation time of the file
                    DateTime creationTime = File.GetCreationTime(file);

                    // Check if the creation time is similar to any other file's creation time
                    bool isSimilar = false;
                    foreach (var otherFile in files)
                    {
                        if (otherFile == file) continue;

                        DateTime otherCreationTime = File.GetCreationTime(otherFile);
                        TimeSpan difference = creationTime - otherCreationTime;

                        if (Math.Abs(difference.TotalDays) <= 7)  // You can adjust this threshold as needed
                        {
                            isSimilar = true;
                            break;
                        }
                    }

                    // If the creation time is similar to any other file's creation time, move the file to a new directory
                    if (isSimilar)
                    {
                        string destinationDirectory = Path.Combine(selectedDirectory, "Similar Dates");
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationPath = Path.Combine(destinationDirectory, Path.GetFileName(file));
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files with similar dates.");
            }
        }

        private void toPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Register the CodePagesEncodingProvider instance
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Create a FolderBrowserDialog to request the path of the folder containing the images.
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the folder containing the images";
            folderBrowserDialog1.ShowDialog();

            // If the folder path is not an empty string, get all image files in the folder.
            if (folderBrowserDialog1.SelectedPath != "")
            {
                string[] imageFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");

                // Create a PDF document
                PdfDocument doc = new PdfDocument();

                // Add an image to each page of the PDF document
                foreach (string imageFile in imageFiles)
                {
                    PdfPage page = doc.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    using (XImage image = XImage.FromFile(imageFile))
                    {
                        // Get the size of the PDF page
                        double pageWidth = page.Width;
                        double pageHeight = page.Height;

                        // Get the size of the image
                        double imageWidth = image.PixelWidth;
                        double imageHeight = image.PixelHeight;

                        // Calculate the scaling factor to fit the image within the page
                        double scale = Math.Min(pageWidth / imageWidth, pageHeight / imageHeight);

                        // Calculate the new size of the image
                        double scaledImageWidth = imageWidth * scale;
                        double scaledImageHeight = imageHeight * scale;

                        // Draw the image centered on the page
                        gfx.DrawImage(image, (pageWidth - scaledImageWidth) / 2, (pageHeight - scaledImageHeight) / 2, scaledImageWidth, scaledImageHeight);
                    }
                }

                // Save and close the PDF document
                string pdfFileName = Path.Combine(folderBrowserDialog1.SelectedPath, "images.pdf");
                doc.Save(pdfFileName);
                doc.Close();

                // Ask before deleting the images from the selected folder
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all images?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string imageFile in imageFiles)
                    {
                        File.Delete(imageFile);
                    }
                    MessageBox.Show($"Done! Successfully moved {imageFiles.Length} images to {pdfFileName} and deleted them.");
                }
                else
                {
                    MessageBox.Show($"Done! Successfully moved {imageFiles.Length} images to {pdfFileName}. The images were not deleted.");
                }
            }
        }

        private void toICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a FolderBrowserDialog to request the path of the folder containing the images.
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the folder containing the images";
            folderBrowserDialog1.ShowDialog();

            // If the folder path is not an empty string, get all image files in the folder.
            if (folderBrowserDialog1.SelectedPath != "")
            {
                string[] imageFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");
                int fileCount = 0;

                // Convert each image to an ICO file
                foreach (string imageFile in imageFiles)
                {
                    using (MagickImage image = new MagickImage(imageFile))
                    {
                        // Resize the image if its width or height exceeds 256 pixels
                        if (image.Width > 256 || image.Height > 256)
                        {
                            image.Resize(256, 256);
                        }

                        string icoFileName = Path.ChangeExtension(imageFile, ".ico");
                        image.Write(icoFileName);
                        fileCount++;
                    }
                }

                // Ask before deleting the original images
                DialogResult dialogResult = MessageBox.Show("Do you want to delete the original images?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string imageFile in imageFiles)
                    {
                        File.Delete(imageFile);
                    }
                    MessageBox.Show($"Done! Successfully converted {fileCount} images to ICO format and deleted the original images.");
                }
                else
                {
                    MessageBox.Show($"Done! Successfully converted {fileCount} images to ICO format. The original images were not deleted.");
                }
            }

        }

        private void toMP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request the path of the MP4 files.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MP4 Files|*.mp4";
            openFileDialog1.Title = "Select MP4 Files";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            // If the file names are not empty, open them for conversion.
            if (openFileDialog1.FileNames.Length > 0)
            {
                int fileCount = 0;

                // Convert each MP4 file to an MP3 file
                foreach (string mp4FilePath in openFileDialog1.FileNames)
                {
                    // Get the directory of the selected MP4 file
                    string directoryPath = Path.GetDirectoryName(mp4FilePath);

                    // Create a path for the MP3 file in the same directory as the MP4 file
                    string mp3FileName = Path.GetFileNameWithoutExtension(mp4FilePath) + ".mp3";
                    string mp3FilePath = Path.Combine(directoryPath, mp3FileName);

                    // Convert the MP4 file to an MP3 file
                    using (MediaFoundationReader reader = new MediaFoundationReader(mp4FilePath))
                    {
                        MediaFoundationEncoder.EncodeToMp3(reader, mp3FilePath);
                        fileCount++;
                    }
                }

                // Ask before deleting the original MP4 files
                DialogResult dialogResult = MessageBox.Show("Do you want to delete the original MP4 files?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string mp4FilePath in openFileDialog1.FileNames)
                    {
                        File.Delete(mp4FilePath);
                    }
                    MessageBox.Show($"Done! Successfully converted {fileCount} files to MP3 format and deleted the original MP4 files.");
                }
                else
                {
                    MessageBox.Show($"Done! Successfully converted {fileCount} files to MP3 format. The original MP4 files were not deleted.");
                }
            }

        }

        private void othersToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Gartoon_Team_Gartoon_Misc_Gtk_Convert_256;
        }

        private void toFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                string newFolder = Path.Combine(selectedDirectory, "Extracted");
                Directory.CreateDirectory(newFolder);

                var allDirectories = Directory.GetDirectories(selectedDirectory, "*", SearchOption.AllDirectories);
                int fileCount = 0;
                foreach (var directory in allDirectories)
                {
                    var files = Directory.GetFiles(directory);
                    foreach (var file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destinationPath = Path.Combine(newFolder, fileName);
                        File.Move(file, destinationPath);
                        fileCount++;
                    }
                }
                MessageBox.Show($"Done! Successfully moved {fileCount} files to the new folder.");
            }
        }

        private void fromZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pDFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Register the CodePagesEncodingProvider instance
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Create an OpenFileDialog to request the path of the PDF files.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files|*.pdf";
            openFileDialog1.Title = "Select PDF Files";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            // If the file names are not empty, open them for merging.
            if (openFileDialog1.FileNames.Length > 0)
            {
                // Create a new PDF document
                PdfDocument outputDocument = new PdfDocument();
                int fileCount = 0;

                // Iterate through the selected files
                foreach (string pdfFile in openFileDialog1.FileNames)
                {
                    // Open the document to import pages from it.
                    PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

                    // Iterate through the pages
                    int count = inputDocument.PageCount;
                    for (int idx = 0; idx < count; idx++)
                    {
                        PdfPage page = inputDocument.Pages[idx];
                        outputDocument.AddPage(page);
                    }
                    fileCount++;
                }

                // Save the document in the same directory as the selected files...
                string filename = Path.Combine(Path.GetDirectoryName(openFileDialog1.FileNames[0]), "Merged.pdf");
                outputDocument.Save(filename);

                // Ask before deleting the original PDF files
                DialogResult dialogResult = MessageBox.Show("Do you want to delete the original PDF files?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string pdfFile in openFileDialog1.FileNames)
                    {
                        File.Delete(pdfFile);
                    }
                    MessageBox.Show($"Done! Successfully merged {fileCount} PDF and deleted the original files.");
                }
                else
                {
                    MessageBox.Show($"Done! Successfully merged {fileCount} PDF files. The original files were not deleted.");
                }
            }
        }

    }
}