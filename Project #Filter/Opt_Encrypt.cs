﻿using ImageMagick;
using SharpCompress.Common;
using System.Diagnostics;
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

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button_Start_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "SANATIZE":
                    await Metadata(selectedPath);
                    break;
                case "ENCRYPT":
                    await Encrypt(selectedPath);
                    break;
                case "DECRYPT":
                    await Decrypt(selectedPath);
                    break;
                default:
                    MessageBox.Show("Invalid select", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        // Function
        public async Task Encrypt(string rootPath)
        {
            await Task.Run(() =>
            {
                var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories).ToList();

                string encryptedPath = Path.Combine(rootPath, "Encrypted");

                Directory.CreateDirectory(encryptedPath);

                // Ask the user for a password
                string password = Microsoft.VisualBasic.Interaction.InputBox("Enter the password for encryption:", "Encryption Password", "", -1, -1);

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string encryptedFilePath = Path.Combine(encryptedPath, fileName);

                    // Use a constant salt for simplicity (in a real application, use a unique salt for each password)
                    using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1000))
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

                            using (FileStream inputFileStream = new FileStream(file, FileMode.Open))
                            using (FileStream outputFileStream = new FileStream(encryptedFilePath, FileMode.Create))
                            using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                            {
                                inputFileStream.CopyTo(cryptoStream);
                            }
                        }
                    }

                    // Delete the original file
                    File.Delete(file);
                }
            });
        }

        public async Task Decrypt(string rootPath)
        {
            await Task.Run(() =>
            {
                var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories).ToList();

                string decryptedPath = Path.Combine(rootPath, "Decrypted");

                // Create the Decrypted directory if it doesn't exist
                Directory.CreateDirectory(decryptedPath);

                // Ask the user for the decryption password
                string password = Microsoft.VisualBasic.Interaction.InputBox("Enter the password for decryption:", "Decryption Password", "", -1, -1);

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string decryptedFilePath = Path.Combine(decryptedPath, fileName);

                    // Use a constant salt for simplicity (in a real application, use the correct salt associated with the password)
                    using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 1000))
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

                            using (FileStream inputFileStream = new FileStream(file, FileMode.Open))
                            using (FileStream outputFileStream = new FileStream(decryptedFilePath, FileMode.Create))
                            using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                            {
                                cryptoStream.CopyTo(outputFileStream);
                            }
                        }
                    }

                    // Delete the encrypted file
                    File.Delete(file);
                }
            });
        }

        private async Task Metadata(string rootPath)
        {
            await Task.Run(() =>
            {
                var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories).ToList();

                string sanitizePath = Path.Combine(rootPath, "Sanitize");

                Directory.CreateDirectory(sanitizePath);

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string sanitizedFilePath = Path.Combine(sanitizePath, fileName);
                    string extension = Path.GetExtension(file).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".orf":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                        case ".raw":
                        case ".arw":
                        case ".cr2":
                        case ".nef":
                        case ".svg":
                        case ".heif":
                        case ".heic":
                            // Call method to remove image metadata
                            RemoveImageMetadata(file, sanitizedFilePath);
                            break;
                        case ".doc":
                        case ".docx":
                            // Call method to remove Word document metadata
                            RemoveWordMetadata(file, sanitizedFilePath);
                            break;
                        case ".xls":
                        case ".xlsx":
                            // Call method to remove Excel document metadata
                            RemoveExcelMetadata(file, sanitizedFilePath);
                            break;
                        case ".ppt":
                        case ".pptx":
                            // Call method to remove PowerPoint document metadata
                            RemovePowerPointMetadata(file, sanitizedFilePath);
                            break;
                        case ".pdf":
                            // Call method to remove PDF document metadata
                            RemovePdfMetadata(file, sanitizedFilePath);
                            break;
                        case ".mp3":
                        case ".wav":
                        case ".flac":
                        case ".aac":
                        case ".oog":
                            // Call method to remove audio metadata
                            RemoveAudioMetadata(file, sanitizedFilePath);
                            break;
                        case ".mp4":
                        case ".avi":
                        case ".mov":
                        case ".wmv":
                        case ".flv":
                        case ".mkv":
                            // Call method to remove video metadata
                            RemoveVideoMetadata(file, sanitizedFilePath);
                            break;
                        default:
                            // If the file type is not recognized, you might want to copy it as is
                            File.Copy(file, sanitizedFilePath);
                            break;
                    }

                    // Optionally delete the original file
                    File.Delete(file);
                }
            });
        }

        // Implement these methods for each file type
        private void RemoveImageMetadata(string inputFile, string outputFile)
        {
            using (var image = new MagickImage(inputFile))
            {
                // Remove all profiles (metadata)
                image.RemoveProfile("exif");
                image.RemoveProfile("icc");
                image.RemoveProfile("iptc");
                image.RemoveProfile("xmp");

                // Save the image without metadata
                image.Write(outputFile);
            }
        }

        private void RemoveAudioMetadata(string inputFile, string outputFile)
        {
            // Remove tags (metadata) using TagLib#
            using (var file = TagLib.File.Create(inputFile))
            {
                // Remove all tags
                file.RemoveTags(TagLib.TagTypes.AllTags);

                // Save the changes
                file.Save();
            }

            // Copy the audio data to a new file
            File.Copy(inputFile, outputFile, overwrite: true);
        }

        private void RemoveVideoMetadata(string inputFilePath, string outputFilePath)
        {
            var inputMediaFile = new MediaToolkit.Model.MediaFile { Filename = inputFilePath };
            var outputMediaFile = new MediaToolkit.Model.MediaFile { Filename = outputFilePath };

            using (var engine = new MediaToolkit.Engine())
            {
                // This command removes all metadata from the video file
                string command = $"-i {inputMediaFile.Filename} -map_metadata -1 -c:v copy -c:a copy {outputMediaFile.Filename}";
                engine.CustomCommand(command);
            }
        }

        private void RemovePdfMetadata(string inputFilePath, string outputFilePath)
        {
            using (PdfSharp.Pdf.PdfDocument document = PdfSharp.Pdf.IO.PdfReader.Open(inputFilePath, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify))
            {
                // Clear the document information (metadata)
                document.Info.Author = "";
                document.Info.Creator = "";
                document.Info.Keywords = "";
                document.Info.Subject = "";
                document.Info.Title = "";

                // Save the document with cleared metadata
                document.Save(outputFilePath);
            }
        }

        private void RemoveWordMetadata(string inputFilePath, string outputFilePath)
        {
            // Load the document
            var doc = new Aspose.Words.Document(inputFilePath);

            // Remove built-in properties
            doc.BuiltInDocumentProperties.Clear();

            // Remove custom properties
            doc.CustomDocumentProperties.Clear();

            // Save the document with cleared metadata
            doc.Save(outputFilePath);
        }

        private void RemoveExcelMetadata(string inputFilePath, string outputFilePath)
        {
            var workbook = new Aspose.Cells.Workbook(inputFilePath);

            // Clear built-in properties
            workbook.BuiltInDocumentProperties.Clear();

            // Clear custom properties
            workbook.CustomDocumentProperties.Clear();

            workbook.Save(outputFilePath);
        }

        private void RemovePowerPointMetadata(string inputFilePath, string outputFilePath)
        {
            var presentation = new Aspose.Slides.Presentation(inputFilePath);

            // Clear built-in properties
            presentation.DocumentProperties.ClearCustomProperties();

            presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
