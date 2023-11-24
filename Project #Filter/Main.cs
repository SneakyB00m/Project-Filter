using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Writers;

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

    public List<string> HandleInclude(string folderPath, string include)
    {
        string filteredPath = Path.Combine(folderPath, "Filtered");
        if (!Directory.Exists(filteredPath))
        {
            Directory.CreateDirectory(filteredPath);
        }

        string includePath = Path.Combine(filteredPath, "Includes");
        if (!Directory.Exists(includePath))
        {
            Directory.CreateDirectory(includePath);
        }

        // Get all files in the folder and its subfolders
        List<string> allFiles = GetAllFiles(folderPath);

        // Filter the files based on the include string
        List<string> includedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(include, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        // List to store the destination paths of the moved files
        List<string> destinationPaths = new List<string>();

        // Move the included files to the "include" directory
        foreach (string file in includedFiles)
        {
            string destinationPath = Path.Combine(includePath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);

            // Add the destination path to the list
            destinationPaths.Add(destinationPath);
        }

        // Return the list of destination paths
        return destinationPaths;
    }

    public List<string> HandleExclude(string folderPath, string exclude)
    {
        // Create the "filtered" directory if it doesn't exist
        string filteredPath = Path.Combine(folderPath, "Filtered");
        if (!Directory.Exists(filteredPath))
        {
            Directory.CreateDirectory(filteredPath);
        }

        // Create the "exclude" directory inside the "filtered" directory
        string excludePath = Path.Combine(filteredPath, "Excludes");
        if (!Directory.Exists(excludePath))
        {
            Directory.CreateDirectory(excludePath);
        }

        // Get all files in the folder and its subfolders
        List<string> allFiles = GetAllFiles(folderPath);

        // Filter the files based on the exclude string
        List<string> excludedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(exclude, StringComparison.OrdinalIgnoreCase) < 0).ToList();

        // List to store the destination paths of the moved files
        List<string> destinationPaths = new List<string>();

        // Move the excluded files to the "exclude" directory
        foreach (string file in excludedFiles)
        {
            string destinationPath = Path.Combine(excludePath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);

            // Add the destination path to the list
            destinationPaths.Add(destinationPath);
        }

        // Return the list of destination paths
        return destinationPaths;
    }

    // Hacer que no mueva los folders
    public void HandleExtension(string folderPath)
    {
        // Get all files in the directory and its subdirectories
        List<string> allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).ToList();

        // Move the files to directories based on their extensions
        foreach (string file in allFiles)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            string extensionPath = Path.Combine(folderPath, extension);

            if (!Directory.Exists(extensionPath))
            {
                Directory.CreateDirectory(extensionPath);
            }

            string destinationPath = Path.Combine(extensionPath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);
        }
    }

    public void HandleResolution(string folderPath)
    {

    }

    public void HandleDuration(string folderPath)
    {

    }

    public void HandleSize(string folderPath)
    {

    }

    public void HandleDate(string folderPath)
    {

    }

    public void HandleAToZ(string folderPath)
    {

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

    public List<string> GetAllFiles(string folderPath)
    {
        List<string> filesList = new List<string>();

        // Check if the directory exists
        if (Directory.Exists(folderPath))
        {
            // Get the files in the directory
            string[] files = Directory.GetFiles(folderPath);
            filesList.AddRange(files);

            // Get the subdirectories in the directory
            string[] subdirectories = Directory.GetDirectories(folderPath);

            // Use a foreach loop to check each subdirectory
            foreach (string subdirectory in subdirectories)
            {
                // Use recursion to get the files in the subdirectory
                List<string> subdirectoryFiles = GetAllFiles(subdirectory);
                filesList.AddRange(subdirectoryFiles);
            }
        }

        return filesList; // Return the list of files
    }

    public void HandleDelete(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
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
            archive.SaveTo(zipFilePath, SharpCompress.Common.CompressionType.Deflate);
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

    // 
}
