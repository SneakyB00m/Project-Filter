using ImageMagick;
using System.Security.Cryptography;
using System.Text;

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

            switch (selectedItem)
            {
                case "SANATIZE":
                    Metadata(selectedPath);
                    break;
                case "ENCRYPT":
                    Encrypt(selectedPath);
                    break;
                case "DECRYPT":
                    Decrypt(selectedPath);
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

            ComboBox comboBox = sender as ComboBox;

            // Get the selected item
            string selectedItem = comboBox.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "SANATIZE":
                case "ENCRYPT":
                    {
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
                    break;
                case "DECRYPT":
                    {
                        string encryptedPath = Path.Combine(selectedPath, "Encrypted");

                        if (!Directory.Exists(encryptedPath))
                        {
                            MessageBox.Show("Error: The folder Encrypted does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string[] imageFiles = Directory.EnumerateFiles(encryptedPath)
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
                    }
                    break;
                default:
                    break;
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
        private void Metadata(string rootpath)
        {
            Dictionary<string, List<string>> fileExtensions = new Dictionary<string, List<string>>
            {
                { "Images", new List<string> { "jpg", "jpeg", "png", "gif", "tif", "tiff", "raw", "arw", "cr2", "nef", "orf", "svg", "heif", "heic" } },
                { "Videos", new List<string> { "mp4", "avi", "mov", "wmv", "flv", "mkv" } },
                { "Documents", new List<string> { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "pdf" } },
                { "Audio", new List<string> { "mp3", "wav", "flac", "aac", "oog" } }
            };

            List<string> selectedFilePaths = PathSelectedFiles(rootpath);

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

                // Determine the type of the file
                string extension = Path.GetExtension(filePath).TrimStart('.').ToLower();
                string fileType = fileExtensions.FirstOrDefault(pair => pair.Value.Contains(extension)).Key;

                // Sanitize the file based on its type and save it to the Sanitize folder
                if (fileType == "Images")
                {
                    // Use Magick.NET for image files
                    using (MagickImage image = new MagickImage(originalFilePath))
                    {
                        image.Strip(); // This removes all profiles and comments
                        image.Write(sanitizeFilePath);
                    }
                }
                else if (fileType == "Videos")
                {
                    // TODO: Add your code to sanitize video files here
                }
                else if (fileType == "Documents")
                {
                    // Use iTextSharp for PDF files
                    // TODO: Add your code to sanitize document files here
                }
                else if (fileType == "Audio")
                {
                    // Use NAudio for audio files
                    // TODO: Add your code to sanitize audio files here
                }
            }
        }

        public async Task Encrypt(string rootPath)
        {
            await Task.Run(() =>
            {
                List<string> selectedFilePaths = PathSelectedFiles(rootPath);

                string originalPath = Path.Combine(rootPath, "Original");
                string encryptedPath = Path.Combine(rootPath, "Encrypted");

                // Create the directories if they don't exist
                Directory.CreateDirectory(originalPath);
                Directory.CreateDirectory(encryptedPath);

                // Ask the user for a password
                string password = Microsoft.VisualBasic.Interaction.InputBox("Enter the password for encryption:", "Encryption Password", "", -1, -1);

                foreach (string filePath in selectedFilePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    string originalFilePath = Path.Combine(originalPath, fileName);
                    string encryptedFilePath = Path.Combine(encryptedPath, fileName);

                    // Move the original file to the Original folder
                    File.Move(filePath, originalFilePath);

                    // Generate a key and IV from the password
                    using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1000)) // Use a constant salt for simplicity
                    {
                        byte[] key = pbkdf2.GetBytes(32); // 256 bits
                        byte[] iv = pbkdf2.GetBytes(16); // 128 bits

                        // Encrypt the file
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = key;
                            aes.IV = iv;

                            // Create an encryptor to encrypt the file
                            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                            using (FileStream inputFileStream = new FileStream(originalFilePath, FileMode.Open))
                            using (FileStream outputFileStream = new FileStream(encryptedFilePath, FileMode.Create))
                            using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                            {
                                inputFileStream.CopyTo(cryptoStream);
                            }
                        }
                    }
                }
            });
        }

        private void Decrypt(string rootpath)
        {
            string encryptedPath = Path.Combine(rootpath, "Encrypted");
            string decryptedPath = Path.Combine(rootpath, "Decrypted");

            // Create the Decrypted directory if it doesn't exist
            Directory.CreateDirectory(decryptedPath);

            // Ask the user for the decryption password
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter the password for decryption:", "Decryption Password", "", -1, -1);

            // Get all files in the Encrypted directory
            string[] encryptedFiles = Directory.GetFiles(encryptedPath);



            foreach (string encryptedFilePath in encryptedFiles)
            {
                string fileName = Path.GetFileName(encryptedFilePath);
                string decryptedFilePath = Path.Combine(decryptedPath, fileName);

                // Generate a key and IV from the password
                using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1000)) // Use a constant salt for simplicity
                {
                    byte[] key = pbkdf2.GetBytes(32); // 256 bits
                    byte[] iv = pbkdf2.GetBytes(16); // 128 bits

                    // Decrypt the file
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        // Create a decryptor to decrypt the file
                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (FileStream inputFileStream = new FileStream(encryptedFilePath, FileMode.Open))
                        using (FileStream outputFileStream = new FileStream(decryptedFilePath, FileMode.Create))
                        using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outputFileStream);
                        }
                    }
                }
            }
        }

    }
}
