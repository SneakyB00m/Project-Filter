using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NReco.VideoInfo;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Writers;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            // Index
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Git_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/Dev-Alan-Isaac",
                UseShellExecute = true
            });
        }

        private void button_Home_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
        }

        private void button_Filter_Click_1(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Filter.Height;
            Panel_Index.Top = button_Filter.Top;
            filter1.BringToFront();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Convert.Height;
            Panel_Index.Top = button_Convert.Top;
            convert1.BringToFront();
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Extract.Height;
            Panel_Index.Top = button_Extract.Top;
            extract1.BringToFront();
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Merge.Height;
            Panel_Index.Top = button_Merge.Top;
            merge1.BringToFront();
        }

        private void button_Privacy_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Privacy.Height;
            Panel_Index.Top = button_Privacy.Top;
            privacy1.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> data;

            string filePath = "Config.json";

            if (!File.Exists(filePath))
            {
                // Create a dictionary to hold the data
                data = new Dictionary<string, object>();

                // Add a section for video extensions
                List<string> videoExtensions = new List<string> { ".mp4", ".avi", ".mkv" };
                data.Add("VideoExtensions", videoExtensions);

                // Add a section for duration in seconds
                List<int> durations = new List<int> { 300, 600, 1200, 1800, 2400, 3000, 3600 }; // replace with actual durations
                data.Add("Duration", durations);

                // Convert the dictionary to a JSON string
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                // Save the JSON string to a file
                File.WriteAllText(filePath, json);

                // Start a new instance of the application
                Process.Start(Application.ExecutablePath);

                // Close the current process
                Environment.Exit(0);

            }
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            config1.BringToFront();
        }
    }
}

public class Actions
{
    // Filter
    public List<CheckBox> GetCheckedCheckBoxes(UserControl userControl)
    {
        List<CheckBox> checkedCheckBoxes = new List<CheckBox>();

        foreach (Control control in userControl.Controls)
        {
            if (control is CheckBox)
            {
                CheckBox? checkBox = control as CheckBox;
                if (checkBox.Checked)
                {
                    checkedCheckBoxes.Add(checkBox);
                }
            }
        }

        return checkedCheckBoxes; // Return the list of checked checkboxes
    }

    public void BasedOrganizeFiles(string folderPath, Dictionary<string, object> data)
    {
        // Get the video extensions from the dictionary
        var videoExtensions = ((JArray)data["VideoExtensions"]).ToObject<string[]>();

        // Get all the files in the folder and its subfolders
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        // Filter the files based on the video extensions
        var filteredFiles = files.Where(file => videoExtensions.Contains(Path.GetExtension(file))).ToList();

        // If there are any filtered files, create the "Filter/Videos" directory and move the files there
        if (filteredFiles.Any())
        {
            var videoDirectory = Path.Combine(folderPath, "Filter", "Videos");
            if (!Directory.Exists(videoDirectory))
            {
                Directory.CreateDirectory(videoDirectory);
            }

            foreach (var file in filteredFiles)
            {
                var destinationPath = Path.Combine(videoDirectory, Path.GetFileName(file));
                File.Move(file, destinationPath);
            }
        }

        // Get the remaining files
        var otherFiles = files.Except(filteredFiles);

        // If there are any other files, create the "Filter/Files" directory and move the files there
        if (otherFiles.Any())
        {
            var filesDirectory = Path.Combine(folderPath, "Filter", "Files");
            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            foreach (var file in otherFiles)
            {
                var destinationPath = Path.Combine(filesDirectory, Path.GetFileName(file));
                File.Move(file, destinationPath);
            }
        }
    }

    public void DeleteEmptyFolders(string rootPath)
    {
        foreach (var directory in Directory.GetDirectories(rootPath))
        {
            DeleteEmptyFolders(directory);
            if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
            {
                Directory.Delete(directory);
            }
        }
    }

    public void OrganizeFilesBasedOnCriteria(string folderPath, Dictionary<string, object> data, string Include)
    {
        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");
        var filesFolder = Path.Combine(folderPath, "Filter", "Files");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder) || !Directory.Exists(filesFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all files in the 'videos' folder and its subdirectories
        var videoFiles = Directory.EnumerateFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        // Get all files in the 'files' folder and its subdirectories
        var otherFiles = Directory.EnumerateFiles(filesFolder, "*.*", SearchOption.AllDirectories);

        // Combine the two lists of files
        var allFiles = videoFiles.Concat(otherFiles);

        // Create a new folder inside the 'Filter' folder
        var destinationFolder = Path.Combine(folderPath, "Filter", "IncludedFiles");
        Directory.CreateDirectory(destinationFolder);

        foreach (var file in allFiles)
        {
            // Get the file name
            var fileName = Path.GetFileName(file);

            // Check if the file name contains the 'Include' string (case-insensitive)
            if (fileName.IndexOf(Include, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Get the destination file path
                var destinationFilePath = Path.Combine(destinationFolder, fileName);

                // Move the file to the new folder
                File.Move(file, destinationFilePath);
            }
        }
    }

    public void OrganizeFilesBasedOnExtension(string folderPath, Dictionary<string, object> data)
    {
        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");
        var filesFolder = Path.Combine(folderPath, "Filter", "Files");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder) || !Directory.Exists(filesFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all files in the 'videos' folder and its subdirectories
        var videoFiles = Directory.EnumerateFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        // Get all files in the 'files' folder and its subdirectories
        var otherFiles = Directory.EnumerateFiles(filesFolder, "*.*", SearchOption.AllDirectories);

        // Combine the two lists of files
        var allFiles = videoFiles.Concat(otherFiles);

        foreach (var file in allFiles)
        {
            // Get the file extension
            var extension = Path.GetExtension(file).TrimStart('.').ToUpper();

            // Get the directory of the current file
            var currentDirectory = Path.GetDirectoryName(file);

            // Create a new folder for the extension if it doesn't exist
            var extensionFolder = Path.Combine(currentDirectory, extension);
            Directory.CreateDirectory(extensionFolder);

            // Get the destination file path
            var destinationFilePath = Path.Combine(extensionFolder, Path.GetFileName(file));

            // Move the file to the new folder
            File.Move(file, destinationFilePath);
        }
    }

    public void OrganizeFilesBasedOnResolution(string folderPath, Dictionary<string, object> data)
    {
        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all files in the 'videos' folder and its subdirectories
        var videoFiles = Directory.EnumerateFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        foreach (var file in videoFiles)
        {
            // Get the directory of the current file
            var currentDirectory = Path.GetDirectoryName(file);

            // Get the video resolution
            var resolution = GetVideoResolution(file);

            // Create a new folder for the resolution if it doesn't exist
            var resolutionFolder = Path.Combine(currentDirectory, resolution);
            Directory.CreateDirectory(resolutionFolder);

            // Get the destination file path
            var destinationFilePath = Path.Combine(resolutionFolder, Path.GetFileName(file));

            // Move the file to the new folder
            File.Move(file, destinationFilePath);
        }

    }

    public string GetVideoResolution(string filePath)
    {
        var ffProbe = new FFProbe();
        var videoInfo = ffProbe.GetMediaInfo(filePath);

        int width = videoInfo.Streams[0].Width;
        int height = videoInfo.Streams[0].Height;

        return $"{width}x{height}";
    }

    public void OrganizeFilesBasedOnDuration(string folderPath, Dictionary<string, object> data)
    {
        // Get the video durations from the dictionary
        var videoDurations = ((JArray)data["Duration"]).ToObject<int[]>();

        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all the files in the "Videos" folder and its subfolders
        var files = Directory.GetFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            // Get the duration of the video file
            int duration = GetVideoDuration(file);

            // Find the appropriate duration threshold
            int durationThreshold = videoDurations.FirstOrDefault(d => duration <= d);
            if (durationThreshold != 0)
            {
                // Convert the duration threshold to minutes
                int durationThresholdInMinutes = durationThreshold / 60;

                // Create a new folder with the duration threshold name if it doesn't exist
                string CurrentFilePath = Path.GetDirectoryName(file);
                string durationFolderPath = Path.Combine(CurrentFilePath, $"{durationThresholdInMinutes}Min");
                Directory.CreateDirectory(durationFolderPath);

                // Move the file to the new folder
                string destinationPath = Path.Combine(durationFolderPath, Path.GetFileName(file));
                File.Move(file, destinationPath);
            }
        }
    }

    public int GetVideoDuration(string filePath)
    {
        var ffProbe = new FFProbe();
        var videoInfo = ffProbe.GetMediaInfo(filePath);

        // Get the duration in seconds
        int duration = (int)videoInfo.Duration.TotalSeconds;

        return duration;
    }

    public void OrganizeFilesBasedOnSize(string folderPath, Dictionary<string, object> data)
    {
        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");
        var filesFolder = Path.Combine(folderPath, "Filter", "Files");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder) || !Directory.Exists(filesFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all files in the 'videos' folder and its subdirectories
        var videoFiles = Directory.EnumerateFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        // Get all files in the 'files' folder and its subdirectories
        var otherFiles = Directory.EnumerateFiles(filesFolder, "*.*", SearchOption.AllDirectories);

        // Combine the two lists of files
        var allFiles = videoFiles.Concat(otherFiles);

        foreach (var file in allFiles)
        {
            // Get the directory of the current file
            var currentDirectory = Path.GetDirectoryName(file);

            // Get the file size
            var fileInfo = new FileInfo(file);
            var sizeInBytes = fileInfo.Length;

            // Define the size range
            string sizeRange;
            if (sizeInBytes < 1024) // less than 1KB
            {
                sizeRange = "B";
            }
            else if (sizeInBytes < 1024 * 1024) // less than 1MB
            {
                sizeRange = "KB";
            }
            else if (sizeInBytes < 1024 * 1024 * 1024) // less than 1GB
            {
                sizeRange = "MB";
            }
            else // 1GB or more
            {
                sizeRange = "GB";
            }

            // Create a new folder for the size range if it doesn't exist
            var sizeFolder = Path.Combine(currentDirectory, sizeRange);
            Directory.CreateDirectory(sizeFolder);

            // Get the destination file path
            var destinationFilePath = Path.Combine(sizeFolder, Path.GetFileName(file));

            // Move the file to the new folder
            File.Move(file, destinationFilePath);
        }
    }

    public void OrganizeFilesBasedOnAToZ(string folderPath, Dictionary<string, object> data)
    {
        // Get the subfolders 'videos' and 'files'
        var videoFolder = Path.Combine(folderPath, "Filter", "Videos");
        var filesFolder = Path.Combine(folderPath, "Filter", "Files");

        // Check if the subfolders exist
        if (!Directory.Exists(videoFolder) || !Directory.Exists(filesFolder))
        {
            BasedOrganizeFiles(folderPath, data);
        }

        // Get all files in the 'videos' folder and its subdirectories
        var videoFiles = Directory.EnumerateFiles(videoFolder, "*.*", SearchOption.AllDirectories);

        // Get all files in the 'files' folder and its subdirectories
        var otherFiles = Directory.EnumerateFiles(filesFolder, "*.*", SearchOption.AllDirectories);

        // Combine the two lists of files
        var allFiles = videoFiles.Concat(otherFiles);

        foreach (var file in allFiles)
        {
            // Get the directory of the current file
            var currentDirectory = Path.GetDirectoryName(file);

            // Get the first character of the file name and make it uppercase
            var firstChar = Char.ToUpper(Path.GetFileName(file)[0]);

            // Create a new folder path based on the first character
            var newFolderPath = Path.Combine(currentDirectory, firstChar.ToString());

            // Create the new folder if it doesn't exist
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }

            // Move the file to the new folder
            var newFilePath = Path.Combine(newFolderPath, Path.GetFileName(file));
            File.Move(file, newFilePath);
        }
    }

    // Univresal
    public string? OpenFolderManager()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    // Extract
    public List<RadioButton> GetCheckedRadioButtons(UserControl userControl)
    {
        List<RadioButton> checkedRadioButtons = new List<RadioButton>();

        foreach (Control control in userControl.Controls)
        {
            if (control is RadioButton)
            {
                RadioButton? radioButton = control as RadioButton;
                if (radioButton.Checked)
                {
                    checkedRadioButtons.Add(radioButton);
                }
            }
        }

        return checkedRadioButtons; // Return the list of checked radio buttons
    }

    public void HandleFolder(string folderPath)
    {
        // Create the 'Extracted' directory
        string extractedFolderPath = Path.Combine(folderPath, "Extracted");
        Directory.CreateDirectory(extractedFolderPath);

        // Get all files in the specified directory and its subdirectories
        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        // Move each file to the 'Extracted' directory
        foreach (string file in files)
        {
            // Get the file name
            string fileName = Path.GetFileName(file);

            // Create the destination path
            string destPath = Path.Combine(extractedFolderPath, fileName);

            // Ensure that the destination file name is unique
            int count = 1;
            string fileNameOnly = Path.GetFileNameWithoutExtension(destPath);
            string extension = Path.GetExtension(destPath);
            while (File.Exists(destPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                destPath = Path.Combine(extractedFolderPath, tempFileName + extension);
            }

            // Move the file
            File.Move(file, destPath);
        }
    }

    public void HandleZip(string folderPath)
    {
        // Get the name of the folder
        string folderName = new DirectoryInfo(folderPath).Name;

        // Define the path of the zip file
        string zipFilePath = Path.Combine(Directory.GetParent(folderPath).FullName, $"{folderName}.zip");

        // Create the zip file from the directory
        using (var archive = SharpCompress.Archives.Zip.ZipArchive.Create())
        {
            archive.AddAllFromDirectory(folderPath);
            archive.SaveTo(zipFilePath, CompressionType.Deflate);
        }
    }

    public void HandleTar(string folderPath)
    {
        // Get the name of the folder
        string folderName = new DirectoryInfo(folderPath).Name;

        // Define the path of the tar file
        string tarFilePath = Path.Combine(Directory.GetParent(folderPath).FullName, $"{folderName}.tar");

        // Create the tar file from the directory
        using (var stream = File.OpenWrite(tarFilePath))
        {
            using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, CompressionType.None))
            {
                writer.WriteAll(folderPath, "*", SearchOption.AllDirectories);
            }
        }
    }

    public void HandleUnRar(string rarFilePath)
    {
        // Get the directory of the rar file
        string directoryPath = Path.GetDirectoryName(rarFilePath);

        // Get the name of the rar file without the extension
        string folderName = Path.GetFileNameWithoutExtension(rarFilePath);

        // Define the path of the folder to unrar to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Unrar the rar file to the directory
        using (var archive = RarArchive.Open(rarFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    public void HandleUnZip(string zipFilePath)
    {
        // Get the directory of the zip file
        string directoryPath = Path.GetDirectoryName(zipFilePath);

        // Get the name of the zip file without the extension
        string folderName = Path.GetFileNameWithoutExtension(zipFilePath);

        // Define the path of the folder to unzip to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Unzip the zip file to the directory
        using (var archive = SharpCompress.Archives.Zip.ZipArchive.Open(zipFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new SharpCompress.Common.ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    public void HandleUnTar(string tarFilePath)
    {
        // Get the directory of the tar file
        string directoryPath = Path.GetDirectoryName(tarFilePath);

        // Get the name of the tar file without the extension
        string folderName = Path.GetFileNameWithoutExtension(tarFilePath);

        // Define the path of the folder to untar to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Untar the tar file to the directory
        using (var archive = ArchiveFactory.Open(tarFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    // Merge
    //public void MergePDFs(List<string> filePaths)
    //{
    //    // Sort the file names
    //    var sortedFileNames = filePaths.OrderBy(name => name);

    //    // Save the document in the same directory as the selected files...
    //    string filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), "Simple Merged.pdf");

    //    // Check if a file with the same name already exists and change the name accordingly
    //    int count = 2;
    //    while (File.Exists(filename))
    //    {
    //        filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), $"Simple Merged ({count}).pdf");
    //        count++;
    //    }

    //    // Initialize a new PDF document
    //    PdfDocument outputDocument = new PdfDocument();

    //    // Iterate through the selected files
    //    foreach (string pdfFile in sortedFileNames)
    //    {
    //        // Open the document to import pages from it.
    //        PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

    //        // Add each page to the output document
    //        for (int page = 0; page < inputDocument.PageCount; page++)
    //        {
    //            outputDocument.AddPage(inputDocument.Pages[page]);
    //        }

    //        // Update your progress bar here
    //        MessageBox.Show($"Merged {pdfFile}");
    //    }

    //    // Save and close the output document
    //    outputDocument.Save(filename);
    //    outputDocument.Close();

    //    MessageBox.Show($"Done! Successfully merged {sortedFileNames.Count()} PDF files into {filename}.");
    //}

    //public void MergePDFsWithIndex(List<string> filePaths)
    //{
    //    // Sort the file names
    //    var sortedFileNames = filePaths.OrderBy(name => name);

    //    // Save the document in the same directory as the selected files...
    //    string filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), "Title Merged.pdf");

    //    // Check if a file with the same name already exists and change the name accordingly
    //    int count = 2;
    //    while (File.Exists(filename))
    //    {
    //        filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), $"Title Merged ({count}).pdf");
    //        count++;
    //    }

    //    // Initialize a new PDF document
    //    PdfDocument outputDocument = new PdfDocument();

    //    // Iterate through the selected files
    //    foreach (string pdfFile in sortedFileNames)
    //    {
    //        // Add a new page with the file name
    //        PdfPage fileNamePage = outputDocument.AddPage();
    //        XGraphics gfx = XGraphics.FromPdfPage(fileNamePage);
    //        XFont font = new XFont("Verdana Bold", 20);
    //        gfx.DrawString(Path.GetFileNameWithoutExtension(pdfFile), font, XBrushes.Black, new XRect(0, 0, fileNamePage.Width, fileNamePage.Height), XStringFormats.Center);

    //        // Open the document to import pages from it.
    //        PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

    //        // Iterate through the pages
    //        int pageCount = inputDocument.PageCount;
    //        for (int idx = 0; idx < pageCount; idx++)
    //        {
    //            PdfPage page = inputDocument.Pages[idx];
    //            outputDocument.AddPage(page);
    //        }

    //        // Update your progress bar here
    //        Console.WriteLine($"Merged {pdfFile}");
    //    }

    //    // Save and close the PDF document
    //    outputDocument.Save(filename);

    //    Console.WriteLine($"Done! Successfully merged {sortedFileNames.Count()} PDF files into {filename}.");
    //}

    // Convert 
    public void ConvertImagesToPdf(string folderPath, string pdfFile)
    {
        // Get all image files in the directory and its subdirectories
        string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
            .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".bmp")).ToArray();

        // Check if the PDF file already exists
        if (File.Exists(pdfFile))
        {
            // Create a new PDF file with a unique name
            string directory = Path.GetDirectoryName(pdfFile);
            string fileName = Path.GetFileNameWithoutExtension(pdfFile);
            string extension = Path.GetExtension(pdfFile);
            int count = 1;

            while (File.Exists(pdfFile))
            {
                pdfFile = Path.Combine(directory, $"{fileName} ({count}){extension}");
                count++;
            }
        }

        using (FileStream stream = new FileStream(pdfFile, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (Document document = new Document())
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();

                foreach (string imageFile in imageFiles)
                {
                    if (File.Exists(imageFile))
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFile);
                        document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
                        document.NewPage();
                        image.SetAbsolutePosition(0, 0);
                        document.Add(image);
                    }
                }
            }
        }
    }


    // Encrypt
    public void HandleEncrypt(string encryptFilePath)
    {
        string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "Password Entry", "", -1, -1);

        // Get all files in the folder and subfolders
        string[] files = Directory.GetFiles(encryptFilePath, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string fileEncrypted = $"{file}.aes";

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);

            // Delete the original file
            File.Delete(file);
        }
    }

    public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;

        // Create salt bytes
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            using AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                cs.Close();
            }
            encryptedBytes = ms.ToArray();
        }
        return encryptedBytes;
    }

    public void HandleDecrypt(string decryptFilePath)
    {
        string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "Password Entry", "", -1, -1);

        // Get all files in the folder and subfolders
        string[] files = Directory.GetFiles(decryptFilePath, "*.*", SearchOption.AllDirectories);

        bool errorShown = false; // Add this line

        foreach (string file in files)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            try
            {
                byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

                // Delete the original encrypted file
                File.Delete(file);

                // Get the directory of the original file
                string directoryPath = Path.GetDirectoryName(file);

                // Get the original file name without the extension
                string fileName = Path.GetFileNameWithoutExtension(file);

                // Combine the directory path and file name
                string fileDecrypted = Path.Combine(directoryPath, fileName);

                File.WriteAllBytes(fileDecrypted, bytesDecrypted);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                if (!errorShown)
                {
                    MessageBox.Show("The password you entered is incorrect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorShown = true;
                }
            }
        }
    }

    public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
            using var AES = new AesCryptoServiceProvider();
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                try
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    MessageBox.Show("The password you entered is incorrect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            decryptedBytes = ms.ToArray();
        }
        return decryptedBytes;
    }

}
