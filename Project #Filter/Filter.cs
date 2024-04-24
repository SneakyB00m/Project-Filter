using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using NReco.VideoInfo;
using SharpCompress;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        List<string> checkedOrder = new List<string>();


        public Filter()
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
            comboBox_Select.Enabled = true;
            button_Filter.Enabled = true;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            if (!string.IsNullOrWhiteSpace(selectedItem))
            {
                switch (selectedItem)
                {
                    case "SORT":
                        //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (RENAME FILE)":
                        //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (FOLDER NAME)":

                        //ProcessCheckedOrder();
                        break;
                    case "SORT & MOVE (CUSTOM)":

                        //ProcessCheckedOrder();
                        break;
                    case "MOVE ONLY (CUSTOM FOLDER)":

                        //ProcessCheckedOrder();
                        break;
                    case "BINARIES":
                        ConvertToBinary(selectedPath);
                        break;
                    case "RECONVERT":
                        ConvertFromBinary(selectedPath);
                        break;
                    default:
                        MessageBox.Show("ERROR");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid selection");
            }

        }

        private void checkBox_Resolution_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Resolution.Checked)
            {
                checkedOrder.Add("Resolution");
            }
            else
            {
                checkedOrder.Remove("Resolution");
            }
        }

        private void checkBox_Duration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Duration.Checked)
            {
                checkedOrder.Add("Duration");
            }
            else
            {
                checkedOrder.Remove("Duration");
            }
        }

        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Include.Checked)
            {
                checkedOrder.Add("Include");
            }
            else
            {
                checkedOrder.Remove("Include");
            }
        }

        private void checkBox_Size_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Size.Checked)
            {
                checkedOrder.Add("Size");
            }
            else
            {
                checkedOrder.Remove("Size");
            }
        }

        private void checkBox_AtoZ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AtoZ.Checked)
            {
                checkedOrder.Add("AtoZ");
            }
            else
            {
                checkedOrder.Remove("AtoZ");
            }
        }

        // Function
        private void ProcessCheckedOrder()
        {
            foreach (string checkboxName in checkedOrder)
            {
                switch (checkboxName)
                {
                    case "Resolution":

                        break;
                    case "Duration":

                        break;
                    case "Include":

                        break;
                    case "Size":

                        break;
                    case "AtoZ":

                        break;
                }
            }
        }

        // Sorts
        public static void SortFiles(string folderJson, string rootPath)
        {
            // Load the JSON file
            var folders = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(System.IO.File.ReadAllText(folderJson));

            // Walk through the directory
            foreach (var file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                // Get the file extension
                string fileExt = Path.GetExtension(file).ToLower();

                // Check if the file extension is in the dictionary
                foreach (var folder in folders)
                {
                    if (folder.Value.Contains(fileExt))
                    {
                        // Construct the source and destination paths
                        string srcPath = file;
                        string destPath = Path.Combine(rootPath, folder.Key, Path.GetFileName(file));

                        // Create the destination folder if it doesn't exist
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // Move the file
                        System.IO.File.Move(srcPath, destPath);

                        break;
                    }
                }
            }
        }

        public static void SortByDuration(string durationJson, string rootPath)
        {
            // Load the JSON file
            var durations = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(System.IO.File.ReadAllText(durationJson));

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Walk through the directory
            foreach (var file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                // Get the file duration
                var videoInfo = ffProbe.GetMediaInfo(file);
                string fileDuration = videoInfo.Duration.ToString();

                // Check if the file duration is in the dictionary
                foreach (var duration in durations)
                {
                    if (duration.Value.Contains(fileDuration))
                    {
                        // Construct the source and destination paths
                        string srcPath = file;
                        string destPath = Path.Combine(rootPath, duration.Key, Path.GetFileName(file));

                        // Create the destination folder if it doesn't exist
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // Move the file
                        System.IO.File.Move(srcPath, destPath);

                        break;
                    }
                }
            }
        }

        public static void SortByResolution(string rootPath)
        {
            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Filter the files by the resolution
                var filteredFiles = files.Where(f =>
                {
                    var videoInfo = ffProbe.GetMediaInfo(f);
                    int resolution = videoInfo.Streams[0].Width * videoInfo.Streams[0].Height;
                    return resolution > 0;
                }).ToList();

                // Sort the files by resolution
                var sortedFiles = filteredFiles.OrderBy(f =>
                {
                    var videoInfo = ffProbe.GetMediaInfo(f);
                    return videoInfo.Streams[0].Width * videoInfo.Streams[0].Height;
                }).ToList();

                // Rename the files to sort them by resolution
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    System.IO.File.Move(sortedFiles[i], newPath);
                }
            }
        }

        public static void SortAlphabetically(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Sort the files alphabetically
                var sortedFiles = files.OrderBy(f => f).ToList();

                // Rename the files to sort them alphabetically
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    System.IO.File.Move(sortedFiles[i], newPath);
                }
            }
        }

        public static void SortBySize(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Sort the files by size
                var sortedFiles = files.OrderBy(f => new FileInfo(f).Length).ToList();

                // Rename the files to sort them by size
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    System.IO.File.Move(sortedFiles[i], newPath);
                }
            }
        }

        public static void SortByText(string rootPath)
        {
            // Prompt the user for the search text
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "", -1, -1).ToLower();

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Filter the files by the search text
                var filteredFiles = files.Where(f => Path.GetFileNameWithoutExtension(f).ToLower().Contains(searchText)).ToList();

                // Rename the files to sort them by the search text
                for (int i = 0; i < filteredFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(filteredFiles[i])}");
                    System.IO.File.Move(filteredFiles[i], newPath);
                }
            }
        }


        public static void ConvertToBinary(string rootPath)
        {
            // Create a new folder for the binary files
            string binFolder = Path.Combine(rootPath, "BinaryFiles");
            Directory.CreateDirectory(binFolder);

            // Get all files in the directory
            var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                // Get the file name and extension
                string fileName = Path.GetFileNameWithoutExtension(file);
                string fileExt = Path.GetExtension(file);

                // Create the path for the binary file
                string binPath = Path.Combine(binFolder, $"{fileName}{fileExt}.bin");

                // Convert the file to a binary file
                byte[] fileBytes = System.IO.File.ReadAllBytes(file);
                System.IO.File.WriteAllBytes(binPath, fileBytes);
            }
        }

        public static void ConvertFromBinary(string binFolder)
        {
            // Create a new folder for the reconverted files
            string destFolder = Path.Combine(binFolder, "Reconvers");
            Directory.CreateDirectory(destFolder);

            // Get all binary files in the directory
            var files = Directory.GetFiles(binFolder, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                // Get the file name and extension
                string fileName = Path.GetFileNameWithoutExtension(file);
                string fileExt = Path.GetExtension(file);

                // Remove the .bin from the extension
                string origExt = fileExt.Replace(".bin", "");

                // Create the path for the original file
                string origPath = Path.Combine(destFolder, $"{fileName}{origExt}");

                // Convert the binary file back to its original form
                byte[] fileBytes = System.IO.File.ReadAllBytes(file);
                System.IO.File.WriteAllBytes(origPath, fileBytes);
            }
        }
    }
}