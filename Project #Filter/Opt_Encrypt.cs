namespace Project__Filter
{
    public partial class Opt_Encrypt : UserControl
    {

        string selectedPath = string.Empty;

        public Opt_Encrypt()
        {
            InitializeComponent();
            listBox_File.SelectionMode = SelectionMode.MultiExtended;
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

                    comboBox_Select.Enabled = true;
                    button_Start.Enabled = true;
                }
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            List<string> fileExtensions =
                          new List<string> { "jpg", "jpeg", "png", "gif", "tif","tiff", "raw", "arw", "cr2", "nef", "orf",
                            "svg", "heif","heic","mp4","avi","mov","wmv","flv","mkv","doc","docx","xls","xlsx",
                            "ppt","pptx","pdf","mp3","wav","flac","aac","oog"
                          };
            switch (selectedItem)
            {
                case "SANATIZE":
                    Metadata(selectedPath, fileExtensions);
                    break;
                case "ENCRYPT":

                    break;
                case "DECRYPT":

                    break;
                default:
                    MessageBox.Show("Invalid select", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            // Get all image files in the selected directory that can be converted to the selected format
            string[] Files = Directory.EnumerateFiles(selectedPath)
                                           .Where(file => fileExtensions.Any(ext => file.ToLower().EndsWith(ext)))
                                           .ToArray();

            // Count the files
            int initialFileCount = Files.Length;

            // Display just the count in label_Count
            label_Count.Text = initialFileCount.ToString();

            listBox_File.Items.Clear();

            foreach (string File in Files)
            {
                listBox_File.Items.Add(Path.GetFileName(File));
            }
        }


        // Functions - General
        private List<string> PathSelectedFiles(string rootpath)
        {
            // Get the selected items in the ListBox
            var selectedItems = listBox_File.SelectedItems;

            // Convert the selected items to a list of strings
            List<string> selectedFiles = selectedItems.Cast<string>().ToList();

            // Create a list to hold the full paths of the selected files
            List<string> fullPaths = new List<string>();

            // Get the full path of each selected file
            foreach (string file in selectedFiles)
            {
                string fullPath = Path.Combine(rootpath, file);
                fullPaths.Add(fullPath);
            }

            return fullPaths;
        }

        // Function - Actions
        private void Metadata(string rootpath, List<string> extensions)
        {
            List<string> allFilePaths = PathSelectedFiles(rootpath);
            List<string> selectedFilePaths = allFilePaths.Where(path => extensions.Contains(Path.GetExtension(path).TrimStart('.').ToLower())).ToList();

            string originalPath = Path.Combine(rootpath, "Original");
            string sanitizePath = Path.Combine(rootpath, "Sanitize");

            // Create the directories if they don't exist
            Directory.CreateDirectory(originalPath);
            Directory.CreateDirectory(sanitizePath);

            foreach (string filePath in selectedFilePaths)
            {
                string fileName = Path.GetFileName(filePath);
                string originalFilePath = Path.Combine(originalPath, fileName);
                string sanitizeFilePath = Path.Combine(sanitizePath, fileName);

                // Move the original file to the Original folder
                File.Move(filePath, originalFilePath);

                // TODO: Sanitize the file and save it to the Sanitize folder
                // For now, we'll just copy the original file as a placeholder
                File.Copy(originalFilePath, sanitizeFilePath);
            }
        }


        private void Encrypt(string rootpath)
        {

        }

        private void Decrypt(string rootpath)
        {

        }
    }
}
