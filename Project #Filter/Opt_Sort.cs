using Newtonsoft.Json;

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
                    case "MOVE ONLY (FILE NAME)":

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
        public static void SortFiles(string jsonFile, string rootPath)
        {
            // Load the JSON file
            var folders = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(System.IO.File.ReadAllText(jsonFile));

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
    }
}