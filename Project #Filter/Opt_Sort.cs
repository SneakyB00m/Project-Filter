using Newtonsoft.Json;
using NReco.VideoInfo;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {

        List<string> checkedOrder = new List<string>();
        string selectedPath;

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
                    int fileCount = files.Length;

                    // Display just the count in label_Count
                    label_Count.Text = fileCount.ToString();

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
                    case "Resolution":
                        SortByResolution(selectedPath);
                        break;
                    case "Duration":
                        if (File.Exists("Duration.json"))
                        {
                            SortByDuration("Duration.json", selectedPath);
                        }
                        break;
                    case "Include":
                        string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "", -1, -1);
                        SortBySimilar(selectedPath, searchText);
                        break;
                    case "Size":
                        SortBySize(selectedPath);
                        break;
                    case "AtoZ":
                        SortAlphabetically(selectedPath);
                        break;
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

        // Sorts
        public void SortFiles(string jsonFile, string rootPath)
        {
            // Load the JSON file
            var folders = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(jsonFile));

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
                        File.Move(srcPath, destPath);

                        break;
                    }
                }
            }

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

        public void SortByResolution(string rootPath)
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
                    File.Move(sortedFiles[i], newPath);
                }
            }

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

        public void SortByDuration(string durationFile, string rootPath)
        {
            // Load the JSON file
            var durations = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(durationFile));

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
                        File.Move(srcPath, destPath);

                        break;
                    }
                }
            }

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

        public void SortBySimilar(string rootPath, string searchText)
        {
            // Get all files in the directory and its subdirectories
            var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories);

            // Filter the files by the search text
            var similarFiles = files.Where(f => Path.GetFileNameWithoutExtension(f).ToLower().Contains(searchText.ToLower())).ToList();

            // Create a new folder for the similar files
            string similarFolder = Path.Combine(rootPath, searchText);
            Directory.CreateDirectory(similarFolder);

            // Move the similar files to the new folder
            foreach (var file in similarFiles)
            {
                string destPath = Path.Combine(similarFolder, Path.GetFileName(file));
                File.Move(file, destPath);
            }

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

                // Rename the files to sort them by size
                for (int i = 0; i < sortedFiles.Count; i++)
                {
                    string newPath = Path.Combine(directory, $"{i}_{Path.GetFileName(sortedFiles[i])}");
                    File.Move(sortedFiles[i], newPath);
                }
            }

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

        public void SortAlphabetically(string rootPath)
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
}