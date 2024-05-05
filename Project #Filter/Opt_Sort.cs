using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NReco.VideoInfo;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {

        // Declare a list to store the order of checked checkboxes
        List<string> checkedOrder = new List<string>();
        string selectedPath;
        int initialFileCount;

        public Opt_Sort()
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

                    // Get all files in the directory and subdirectories
                    string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                    // Count the files
                    initialFileCount = files.Length;

                    // Display just the count in label_Count
                    label_Count.Text = initialFileCount.ToString();

                    // Clear the TreeView
                    treeView1.Nodes.Clear();

                    // Create the root node
                    TreeNode rootNode = new TreeNode(selectedPath);
                    treeView1.Nodes.Add(rootNode);

                    // Populate the TreeView with directories and files
                    PopulateTreeView(selectedPath, rootNode);

                    // Expand the root node
                    rootNode.Expand();
                }
            }
            checkBox_Resolution.Enabled = true;
            checkBox_Duration.Enabled = true;
            checkBox_Include.Enabled = true;
            checkBox_Size.Enabled = true;
            checkBox_Alphabet.Enabled = true;
            button_Filter.Enabled = true;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            // Call SortFiles first
            if (File.Exists("Folders.json"))
            {
                SortFiles("Folders.json", selectedPath);
            }

            // Then check the checkboxes
            foreach (string checkBoxName in checkedOrder)
            {
                switch (checkBoxName)
                {
                    case "checkBox_Include":
                        SortBySimilar(selectedPath);
                        break;
                    case "checkBox_Resolution":
                        SortByResolution(selectedPath);
                        break;
                    case "checkBox_Duration":
                        if (File.Exists("Duration.json"))
                        {
                            SortByDuration("Duration.json", selectedPath);
                        }
                        else
                        {
                            MessageBox.Show("The configuration file 'Duration.json' does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case "checkBox_Size":
                        SortBySize(selectedPath);
                        break;
                    case "checkBox_Alphabet":
                        SortAlphabetically(selectedPath);
                        break;
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checkbox that triggered the event
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                // If the checkbox was checked, add it to the end of the list
                checkedOrder.Add(checkBox.Name);
            }
            else
            {
                // If the checkbox was unchecked, remove it from the list
                checkedOrder.Remove(checkBox.Name);
            }
        }

        // Functions

        private void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            string[] directories = Directory.GetDirectories(directoryValue);
            foreach (string directory in directories)
            {
                TreeNode directoryNode = new TreeNode(Path.GetFileName(directory));
                parentNode.Nodes.Add(directoryNode);
                PopulateTreeView(directory, directoryNode); // Recursively add subdirectories
            }

            string[] files = Directory.GetFiles(directoryValue);
            foreach (string file in files)
            {
                // Add files to the TreeView
                parentNode.Nodes.Add(new TreeNode(Path.GetFileName(file)));
            }
        }

        public void SortFiles(string FolderJson, string rootPath)
        {
            // Load the JSON file
            var folders = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(FolderJson));

            // Walk through the directory
            foreach (var file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                // Get the file extension and convert it to lowercase
                string fileExt = Path.GetExtension(file).ToLower().TrimStart('.');
                string destinationDirectory;

                // Check if the file extension is in the dictionary
                if (folders.Any(kvp => kvp.Value.Contains(fileExt)))
                {
                    string key = folders.First(kvp => kvp.Value.Contains(fileExt)).Key;
                    destinationDirectory = Path.Combine(rootPath, key);
                }
                else
                {
                    destinationDirectory = Path.Combine(rootPath, "Other");
                }

                // Create the destination folder if it doesn't exist
                Directory.CreateDirectory(destinationDirectory);

                // Construct the source and destination paths
                string srcPath = file;
                string destPath = Path.Combine(destinationDirectory, Path.GetFileName(file));

                // Check if the file already exists in the destination directory
                if (!File.Exists(destPath))
                {
                    // Move the file
                    File.Move(srcPath, destPath);
                }
            }

            if (checkBox_Delete.Checked)
            {
                DeleteFolders(rootPath);
            }

            ScanFiles(rootPath);

            // Clear the TreeView
            treeView1.Nodes.Clear();

            // Create the root node
            TreeNode rootNode = new TreeNode(selectedPath);
            treeView1.Nodes.Add(rootNode);

            // Populate the TreeView with directories and files
            PopulateTreeView(selectedPath, rootNode);

            // Expand the root node
            rootNode.Expand();
        }

        public void ScanFiles(string rootPath)
        {
            string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

            int finalFileCount = files.Length;

            if (initialFileCount != finalFileCount)
            {
                MessageBox.Show("Some files were lost during the sorting operation.");
            }
        }

        public void DeleteFolders(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*.*", SearchOption.AllDirectories);

            // List to store all empty directories
            List<string> emptyDirectories = new List<string>();

            foreach (var dir in directories)
            {
                // Check if the directory is empty
                if (!Directory.EnumerateFileSystemEntries(dir).Any())
                {
                    // Add the empty directory to the list
                    emptyDirectories.Add(dir);
                }
            }

            // If there are any empty directories, ask for confirmation to delete them all
            if (emptyDirectories.Any())
            {
                string message = $"There are {emptyDirectories.Count} empty directories. Do you want to delete them all?";
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    foreach (var dir in emptyDirectories)
                    {
                        Directory.Delete(dir);
                    }
                    MessageBox.Show($"Deleted all {emptyDirectories.Count} empty directories.");
                }
                else
                {
                    MessageBox.Show("Skipped deleting empty directories.");
                }
            }
        }

        public void RepopulateTreeView(string rootPath)
        {
            // Clear the TreeView
            treeView1.Nodes.Clear();

            // Create the root node
            TreeNode rootNode = new TreeNode(rootPath);
            treeView1.Nodes.Add(rootNode);

            // Populate the TreeView with directories and files
            PopulateTreeView(rootPath, rootNode);

            // Expand the root node
            rootNode.Expand();
        }

        // Add sorts
        public void SortByDuration(string DurationJson, string rootPath)
        {
            // Load the JSON file
            var durations = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(File.ReadAllText(DurationJson));

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            // Filter directories to only include those with the name "Videos"
            var videoDirectories = directories.Where(dir => new DirectoryInfo(dir).Name == "Videos");

            foreach (var directory in videoDirectories)
            {
                // Walk through the directory
                foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        // Get the file duration in seconds
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        int fileDuration = (int)videoInfo.Duration.TotalSeconds;

                        // Check if the file duration is in the dictionary
                        foreach (var duration in durations)
                        {
                            int minDuration = duration.Value["Item1"];
                            int maxDuration = duration.Value["Item2"];

                            if (fileDuration >= minDuration && fileDuration <= maxDuration)
                            {
                                // Get the parent directory of the file
                                string fileDirectory = Directory.GetParent(file).FullName;

                                // Construct the source and destination paths
                                string srcPath = file;
                                string destPath = Path.Combine(fileDirectory, duration.Key, Path.GetFileName(file));

                                // Skip if the file is already in the correct directory
                                if (Path.GetDirectoryName(srcPath) == Path.GetDirectoryName(destPath))
                                    continue;

                                // Create the destination folder if it doesn't exist
                                Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                                // Move the file
                                File.Move(srcPath, destPath);

                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Show a message box with the error
                        MessageBox.Show($"An error occurred while sorting the file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                ScanFiles(rootPath);
            }

            RepopulateTreeView(rootPath);
        }

        public void SortByResolution(string rootPath)
        {
            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Walk through the directory
                foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        // Get the video info
                        var videoInfo = ffProbe.GetMediaInfo(file);

                        // Get the resolution of the video
                        string resolution = $"{videoInfo.Streams[0].Width}x{videoInfo.Streams[0].Height}";

                        // Get the directory of the file
                        string fileDirectory = Path.GetDirectoryName(file);

                        // Create a new folder for the resolution if it doesn't exist
                        string resolutionFolder = Path.Combine(fileDirectory, resolution);
                        Directory.CreateDirectory(resolutionFolder);

                        // Construct the destination path
                        string destPath = Path.Combine(resolutionFolder, Path.GetFileName(file));

                        // Move the file
                        File.Move(file, destPath);
                    }
                    catch (Exception ex)
                    {
                        // Show a message box with the error
                        MessageBox.Show($"An error occurred while sorting the file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ScanFiles(rootPath);
            }

            RepopulateTreeView(rootPath);
        }

        public void SortBySize(string rootPath)
        {
            // Define the size categories in bytes
            long below50MB = 50L * 1024 * 1024;
            long below100MB = 100L * 1024 * 1024;
            long below500MB = 500L * 1024 * 1024;
            long above1GB = 1024L * 1024 * 1024;

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    // Get the file size
                    long fileSize = new FileInfo(file).Length;

                    // Determine the destination folder based on the file size
                    string destinationFolder;
                    if (fileSize < below50MB)
                    {
                        destinationFolder = "Below 50 MB";
                    }
                    else if (fileSize < below100MB)
                    {
                        destinationFolder = "50 MB to 100 MB";
                    }
                    else if (fileSize < below500MB)
                    {
                        destinationFolder = "100 MB to 500 MB";
                    }
                    else if (fileSize < above1GB)
                    {
                        destinationFolder = "500 MB to 1 GB";
                    }
                    else
                    {
                        destinationFolder = "Above 1 GB";
                    }

                    // Get the directory of the file
                    string fileDirectory = Path.GetDirectoryName(file);

                    // Create the destination folder if it doesn't exist
                    string destinationDirectory = Path.Combine(fileDirectory, destinationFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    // Construct the source and destination paths
                    string srcPath = file;
                    string destPath = Path.Combine(destinationDirectory, Path.GetFileName(file));

                    // Move the file
                    File.Move(srcPath, destPath);
                }
            }

            ScanFiles(rootPath);
            RepopulateTreeView(rootPath);
        }

        public void SortAlphabetically(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    // Get the first letter of the file name
                    char firstLetter = Char.ToUpper(Path.GetFileName(file)[0]);

                    // If the first letter is not a letter, get the next character that is a letter
                    if (!Char.IsLetter(firstLetter))
                    {
                        foreach (char c in Path.GetFileName(file))
                        {
                            if (Char.IsLetter(c))
                            {
                                firstLetter = Char.ToUpper(c);
                                break;
                            }
                        }
                    }

                    // Get the directory of the file
                    string fileDirectory = Path.GetDirectoryName(file);

                    // Determine the destination folder based on the first letter
                    string letterFolder;
                    if (firstLetter < 128)  // ASCII characters
                    {
                        letterFolder = firstLetter.ToString();
                    }
                    else  // Non-ASCII characters
                    {
                        letterFolder = "Special Characters";
                    }

                    // Create the destination folder if it doesn't exist
                    string destinationDirectory = Path.Combine(fileDirectory, letterFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    // Construct the destination path
                    string destPath = Path.Combine(destinationDirectory, Path.GetFileName(file));

                    // Move the file
                    File.Move(file, destPath);
                }
                ScanFiles(rootPath);
            }

            RepopulateTreeView(rootPath);
        }

        public void SortBySimilar(string rootPath)
        {
            // Get all files in the directory and its subdirectories
            var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories);

            // Group the files by the common part of their names
            var groupedFiles = files.GroupBy(f => Regex.Match(Path.GetFileNameWithoutExtension(f), @"^[a-zA-Z]*").Value);

            foreach (var group in groupedFiles)
            {
                string commonName = group.Key;

                // Skip the group if the common name is empty
                if (string.IsNullOrEmpty(commonName))
                    continue;

                // Get the directory of the first file in the group
                string fileDirectory = Path.GetDirectoryName(group.First());

                // Create a new folder for the similar files in the same directory as the file
                string similarFolder = Path.Combine(fileDirectory, commonName);
                Directory.CreateDirectory(similarFolder);

                // Move the similar files to the new folder
                foreach (var file in group)
                {
                    string destPath = Path.Combine(similarFolder, Path.GetFileName(file));
                    File.Move(file, destPath);
                }
                ScanFiles(rootPath);
            }

            RepopulateTreeView(rootPath);
        }
    }
}