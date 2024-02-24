namespace Project__Filter
{
    public partial class Extract : UserControl
    {
        string selectedPath;

        public Extract()
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
                ExtractFiles();
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

        }

        private void ExtractFiles()
        {
            // Handle radioButton_Folder
            string targetPath = Path.Combine(selectedPath, "Extracted"); // The path of the target directory

            // Create the target directory if it doesn't exist
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // Get all files from the selected directory and its subdirectories
            string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

            // Move each file to the target directory
            foreach (string file in files)
            {
                // Get the file name
                string fileName = Path.GetFileName(file);

                // Combine the target directory with the file name
                string destFile = Path.Combine(targetPath, fileName);

                // Move the file to the target directory
                File.Move(file, destFile);
            }
        }
    }
}
