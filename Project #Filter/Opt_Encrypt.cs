using ImageMagick;

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
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected extension is in the list of allowed extensions
            List<string> fileExtensions =
                new List<string> { "jpg", "jpeg", "png", "gif", "tif","tiff", "raw", "arw", "cr2", "nef", "orf",
            "svg", "heif","heic","mp4","avi","mov","wmv","flv","mkv","doc","docx","xls","xlsx",
            "ppt","pptx","pdf","mp3","wav","flac","aac","oog"
                };

            string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                             .Where(file => fileExtensions.Any(ext => file.ToLower().EndsWith(ext)))
                                             .ToArray();

            // Count the files
            int initialFileCount = imageFiles.Length;

            // Display just the count in label_Count
            label_Count.Text = initialFileCount.ToString();

            listBox_File.Items.Clear();

            foreach (string imageFile in imageFiles)
            {
                listBox_File.Items.Add(Path.GetFileName(imageFile));
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

                // Sanitize the file based on its extension and save it to the Sanitize folder
                string extension = Path.GetExtension(originalFilePath).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".tif" || extension == ".tiff")
                {
                    // Use Magick.NET for image files
                    using (MagickImage image = new MagickImage(originalFilePath))
                    {
                        image.Strip(); // This removes all profiles and comments
                        image.Write(sanitizeFilePath);
                    }
                }
                else if (extension == ".pdf")
                {
                    // Use iTextSharp for PDF files
                    // TODO: Add your code to sanitize PDF files here
                }
                else if (extension == ".mp3" || extension == ".wav" || extension == ".flac" || extension == ".aac" || extension == ".oog")
                {
                    // Use NAudio for audio files
                    // TODO: Add your code to sanitize audio files here
                }
                // TODO: Add more else if blocks for other file types as needed
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
