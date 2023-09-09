using Newtonsoft.Json;
using NReco.VideoInfo;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;
using ImageMagick;
using NAudio.Wave;

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
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    char firstLetter = char.ToUpper(fileName[0]);
                    string subDirectory = Path.Combine(filterDirectory, firstLetter.ToString());
                    Directory.CreateDirectory(subDirectory);

                    string destinationPath = Path.Combine(subDirectory, fileName);
                    File.Move(file, destinationPath);
                }
                MessageBox.Show("\nDone");
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
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory = Path.Combine(filterDirectory, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
                MessageBox.Show("\nDone");
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

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

                    string destinationDirectory = Path.Combine(filterDirectory, sizeFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
            }
        }

        private void typeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory = Path.Combine(selectedDirectory, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
            }
        }

        private void lenghtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;

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
                }
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

                // Delete the images from the selected folder
                foreach (string imageFile in imageFiles)
                {
                    File.Delete(imageFile);
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
                    }
                }
            }
        }


        private void toMP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request the path of the MP4 file.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MP4 Files|*.mp4";
            openFileDialog1.Title = "Select an MP4 File";
            openFileDialog1.ShowDialog();

            // If the file name is not an empty string, open it for conversion.
            if (openFileDialog1.FileName != "")
            {
                // Get the directory of the selected MP4 file
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);

                // Create a path for the MP3 file in the same directory as the MP4 file
                string mp3FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".mp3";
                string mp3FilePath = Path.Combine(directoryPath, mp3FileName);

                // Convert the MP4 file to an MP3 file
                using (MediaFoundationReader reader = new MediaFoundationReader(openFileDialog1.FileName))
                {
                    MediaFoundationEncoder.EncodeToMp3(reader, mp3FilePath);
                }

                // Delete the original MP4 file
                File.Delete(openFileDialog1.FileName);
            }
        }


    }
}