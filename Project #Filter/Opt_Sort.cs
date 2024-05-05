using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NReco.VideoInfo;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {

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
            if (File.Exists("Folders.json"))
            {
                SortFiles("Folders.json", selectedPath);
            }
            foreach (string checkboxName in checkedOrder)
            {
                switch (checkboxName)
                {
                    case "checkBox_Resolution":
                        SortByResolution(selectedPath);
                        break;
                    case "checkBox_Duration":
                        if (File.Exists("Duration.json"))
                        {
                            SortByDuration("Duration.json", selectedPath);
                        }
                        break;
                    case "checkBox_Include":
                        SortBySimilar(selectedPath);
                        break;
                    case "checkBox_Size":
                        SortBySize(selectedPath);
                        break;
                    case "checkBox_Alphabet":
                        SortAlphabetically(selectedPath);
                        break;
                }
            }

            // Clear the checkedOrder list and uncheck all checkboxes
            checkedOrder.Clear();
            checkBox_Resolution.Checked = false;
            checkBox_Duration.Checked = false;
            checkBox_Include.Checked = false;
            checkBox_Size.Checked = false;
            checkBox_Alphabet.Checked = false;
        }


        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedOrder(sender as CheckBox);
        }

        private void checkBox_Resolution_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedOrder(sender as CheckBox);
        }

        private void checkBox_Duration_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedOrder(sender as CheckBox);
        }

        private void checkBox_Size_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedOrder(sender as CheckBox);
        }

        private void checkBox_Alphabet_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckedOrder(sender as CheckBox);
        }


        // Functions
        private void UpdateCheckedOrder(CheckBox checkBox)
        {
            if (checkBox != null)
            {
                if (checkBox.Checked)
                {
                    // Add the checkbox's name to the list when it's checked
                    checkedOrder.Add(checkBox.Name);
                }
                else
                {
                    // Remove the checkbox's name from the list when it's unchecked
                    checkedOrder.Remove(checkBox.Name);
                }
            }
        }

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

        // Add sorts
        public void SortByDuration(string DurationJson, string rootPath)  // Duration
        {
            // Load the JSON file
            var durations = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(File.ReadAllText(DurationJson));

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "Videos", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Walk through the directory
                foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories))
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

                ScanFiles(rootPath);
            }

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

        public void SortByResolution(string rootPath)  // Resolution
        {
            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Get all directories named "Videos"
            var directories = Directory.GetDirectories(rootPath, "Videos", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Filter and sort the files by the resolution
                var sortedFiles = files.Where(f =>
                {
                    var videoInfo = ffProbe.GetMediaInfo(f);
                    int resolution = videoInfo.Streams[0].Width * videoInfo.Streams[0].Height;
                    return resolution > 0;
                })
                .OrderBy(f =>
                {
                    var videoInfo = ffProbe.GetMediaInfo(f);
                    return videoInfo.Streams[0].Width * videoInfo.Streams[0].Height;
                })
                .ToList();

                // Move the files to new folders based on their resolution
                foreach (var file in sortedFiles)
                {
                    var videoInfo = ffProbe.GetMediaInfo(file);
                    string resolution = $"{videoInfo.Streams[0].Width}x{videoInfo.Streams[0].Height}";

                    // Create a new folder for the resolution if it doesn't exist
                    string resolutionFolder = Path.Combine(directory, resolution);
                    Directory.CreateDirectory(resolutionFolder);

                    // Construct the destination path
                    string destPath = Path.Combine(resolutionFolder, Path.GetFileName(file));

                    // Move the file
                    File.Move(file, destPath);
                }

                ScanFiles(rootPath);
            }

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

        public void SortBySize(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Sort the files by size
                var sortedFiles = files.OrderBy(f => new FileInfo(f).Length).ToList();

                // Create a new folder for the sorted files
                string sortedFolder = Path.Combine(directory, "SortedBySize");
                Directory.CreateDirectory(sortedFolder);

                // Rename the files to sort them by size and move them to the new folder
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(sortedFolder, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    File.Move(sortedFiles[i], newPath);
                }
            }

            // Clear the TreeView
            treeView1.Nodes.Clear();

            // Create the root node
            TreeNode rootNode = new TreeNode(rootPath);
            treeView1.Nodes.Add(rootNode);

            // Populate the TreeView with directories and files
            PopulateTreeView(rootPath, rootNode);

            // Expand the root node
            rootNode.Expand();

            ScanFiles(rootPath);
        }

        public void SortAlphabetically(string rootPath)
        {
            // Get all directories
            var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (var directory in directories)
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directory);

                // Sort the files alphabetically by name
                var sortedFiles = files.OrderBy(f => Path.GetFileName(f)).ToList();

                // Rename the files to sort them alphabetically
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string oldPath = sortedFiles[i];
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(oldPath)}");

                    // Rename the file
                    File.Move(oldPath, newPath);
                }
            }

            // Clear the TreeView
            treeView1.Nodes.Clear();

            // Create the root node
            TreeNode rootNode = new TreeNode(rootPath);
            treeView1.Nodes.Add(rootNode);

            // Populate the TreeView with directories and files
            PopulateTreeView(rootPath, rootNode);

            // Expand the root node
            rootNode.Expand();

            ScanFiles(rootPath);
        }

        public void SortBySimilar(string rootPath)
        {
            // Get all files in the directory and its subdirectories
            var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories);

            // Group the files by the common part of their names
            var groupedFiles = files.GroupBy(f => Regex.Match(Path.GetFileNameWithoutExtension(f), @"^\D*").Value);

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
            }

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
    }
}