namespace Project__Filter
{
    public partial class Opt_Extract : UserControl
    {
        string selectedPath;

        public Opt_Extract()
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

                    radioButton_Folder.Enabled = true;
                    radioButton_Unrar.Enabled = true;
                    radioButton_Untar.Enabled = true;
                    radioButton_Unzip.Enabled = true;
                    button_Extract.Enabled = true;

                    // Create a new List to hold the file paths
                    List<string> filePaths = new List<string>();

                    // Use the Directory class from System.IO to get all files recursively
                    filePaths.AddRange(Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories));

                    // Add the file paths to the ListBox
                    foreach (string filePath in filePaths)
                    {
                        listBox_File.Items.Add(filePath);
                    }

                    label_Count.Text = $"{filePaths.Count}";
                }

            }
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            if (radioButton_Folder.Checked)
            {
                MoveFiles(selectedPath);
            }
            else if (radioButton_Unrar.Checked)
            {

            }
            else if (radioButton_Untar.Checked)
            {

            }
            else if (radioButton_Unzip.Checked)
            {

            }

            if (checkBox_Delete.Checked)
            {
                DeleteFolders();
            }

        }

        public void DeleteFolders()
        {
            // Get all directories from the selected directory
            string[] directories = Directory.GetDirectories(selectedPath, "*", SearchOption.AllDirectories);

            // Check each directory
            foreach (string dir in directories)
            {
                // Get all files and subdirectories in the directory
                if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                {
                    // If the directory is empty, delete it
                    Directory.Delete(dir);
                }
            }
        }

        public void MoveFiles(string rootPath)
        {
            // Construct the destination folder path
            string destinationFolder = Path.Combine(rootPath, "Extracted");

            // Ensure the destination folder exists
            Directory.CreateDirectory(destinationFolder);

            // Get all files in the root path and its subdirectories
            string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                // Skip if the file is in the destination folder
                if (file.StartsWith(destinationFolder))
                    continue;

                // Get the file name
                string fileName = Path.GetFileName(file);

                // Construct the destination path
                string destPath = Path.Combine(destinationFolder, fileName);

                // Move the file
                File.Move(file, destPath);
            }
        }

    }
}
