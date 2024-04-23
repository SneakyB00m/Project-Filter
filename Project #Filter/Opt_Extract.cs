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
                   DeleteFolders();
            }

        }

        public void DeleteFolders() {
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

        private void ExtractFiles()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                string targetPath = Path.Combine(selectedPath, "Extracted"); // The path of the target directory

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = files.Length));

                for (int i = 0; i < files.Length; i++)
                {
                    string fileName = Path.GetFileName(files[i]);
                    string destFile = Path.Combine(targetPath, fileName);

                    if (!File.Exists(destFile))
                    {
                        File.Move(files[i], destFile);
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }

                // Show a message box when done
                Invoke((Action)(() => MessageBox.Show("File extraction completed!")));

                // Reset the progress bar
                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

    }
}
