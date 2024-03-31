using System.IO;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using SharpCompress;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        Dictionary<string, List<string>> myDict;

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("Folders.json"))
            {
                string json = System.IO.File.ReadAllText("Folders.json");
                myDict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            }
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
                    checkBox_Size.Enabled = true;
                    checkBox_Resolution.Enabled = true;
                    checkBox_AtoZ.Enabled = true;
                    checkBox_Duration.Enabled = true;
                    checkBox_Include.Enabled = true;
                    button_Filter.Enabled = true;
                }
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "BASIC (NO RENAME)":
                    FirstSort();
                    break;
                case "BASIC (RENAME)":

                    break;
                case "RENAME & MOVE (FILE NAME)":

                    break;
                case "RENAME & MOVE (FOLDER NAME)":

                    break;
                case "RENAME & MOVE (CUSTOM)":

                    break;
                case "MOVE ONLY (CUSTOM FOLDER)":

                    break;
                case "MOVE ONLY(FILE NAME)":

                    break;
                default:
                    MessageBox.Show("Invalid selection");
                    break;
            }

            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox checkbox = control as System.Windows.Forms.CheckBox;
                    if (checkbox.Checked)
                    {
                        // Perform operation for each checked checkbox
                        switch (checkbox.Name)
                        {
                            case "checkBox1":
                                // Call function1
                                break;
                            case "checkBox2":
                                // Call function2
                                break;
                            case "checkBox3":
                                // Call function3
                                break;
                            case "checkBox4":
                                // Call function4
                                break;
                            case "checkBox5":
                                // Call function5
                                break;
                            default:
                                Console.WriteLine(checkbox.Name + " is checked but no function is associated with it.");
                                break;
                        }
                    }
                }
            }
        }

        // Functions
        private void FirstSort()
        {
            Task.Run(() =>
            {
                string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
                Invoke((Action)(() => progressBar_Time.Value = 0));

                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory;

                    if (myDict.Any(kvp => kvp.Value.Contains(extension)))
                    {
                        string key = myDict.First(kvp => kvp.Value.Contains(extension)).Key;
                        destinationDirectory = Path.Combine(selectedPath, key);
                    }
                    else
                    {
                        destinationDirectory = Path.Combine(selectedPath, "Other");
                    }

                    Directory.CreateDirectory(destinationDirectory);
                    string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(file));

                    // Check if the file already exists in the destination directory
                    if (!System.IO.File.Exists(destinationFile))
                    {
                        // If the file does not exist, move the file
                        System.IO.File.Move(file, destinationFile);
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value++));
                }

                Invoke((Action)(() => MessageBox.Show("Filterd completed")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

        private void Resolution()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                var ffprobe = new NReco.VideoInfo.FFProbe();

                string videosPath = Path.Combine(selectedPath, "Videos");

                if (!Directory.Exists(videosPath))
                {
                    MessageBox.Show("No 'Videos' folder or video files found in the directory: " + selectedPath);
                    return;
                }

                string[] videoFiles = Directory.GetFiles(videosPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length));

                for (int i = 0; i < videoFiles.Length; i++)
                {
                    try
                    {
                        var videoInfo = ffprobe.GetMediaInfo(videoFiles[i]);
                        string resolution = videoInfo.Streams[0].Width.ToString() + "x" + videoInfo.Streams[0].Height.ToString();

                        string destinationDirectory = Path.Combine(videosPath, resolution);
                        Directory.CreateDirectory(destinationDirectory);

                        string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(videoFiles[i]));
                        System.IO.File.Move(videoFiles[i], destinationFile);
                    }
                    catch (NReco.VideoInfo.FFProbeException ex)
                    {
                        // Log the error message if needed
                        Console.WriteLine($"Error processing file {videoFiles[i]}: {ex.Message}");
                        continue; // Skip this file and move on to the next one
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }

                Invoke((Action)(() => MessageBox.Show("Filterd completed")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

        private void Duration()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                var ffprobe = new NReco.VideoInfo.FFProbe();

                string videosPath = Path.Combine(selectedPath, "Videos");

                if (!Directory.Exists(videosPath))
                {
                    MessageBox.Show("No 'Videos' folder or video files found in the directory: " + selectedPath);
                    return;
                }

                // Get all video files in the "Videos" directory and its subdirectories
                string[] videoFiles = Directory.GetFiles(videosPath, "*.*", SearchOption.AllDirectories);

                // Read the duration categories from a JSON file
                string json = System.IO.File.ReadAllText("Duration.json"); // replace with the path to your JSON file
                Dictionary<string, int> durationCategories = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);


                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length));

                for (int i = 0; i < videoFiles.Length; i++)
                {
                    try
                    {
                        var videoInfo = ffprobe.GetMediaInfo(videoFiles[i]);
                        var duration = videoInfo.Duration.TotalSeconds;

                        foreach (var category in durationCategories)
                        {
                            if (duration <= category.Value)
                            {
                                var destinationFolder = Path.Combine(Path.GetDirectoryName(videoFiles[i]), category.Key);
                                Directory.CreateDirectory(destinationFolder);
                                System.IO.File.Move(videoFiles[i], Path.Combine(destinationFolder, Path.GetFileName(videoFiles[i])));
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the error message if needed
                        Console.WriteLine($"Error processing file {videoFiles[i]}: {ex.Message}");
                        continue; // Skip this file and move on to the next one
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }
                Invoke((Action)(() => MessageBox.Show("Filterd completed")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

        private void Include()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                string inputInclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "", -1, -1);

                // If the cancel button is clicked, the input box will return an empty string
                if (string.IsNullOrEmpty(inputInclude))
                {
                    return; // Stop the operation
                }

                string searchPath = selectedPath; // replace with the path to your directory

                // Get all files in the directory and its subdirectories
                string[] files = Directory.GetFiles(searchPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = files.Length));

                string lowerCaseSearchText = inputInclude.ToLower();

                // Filter the files that contain the search text in their name, excluding the extension
                var foundFiles = files.Where(file => Path.GetFileNameWithoutExtension(file).ToLower().Contains(lowerCaseSearchText)).ToList();

                for (int i = 0; i < foundFiles.Count; i++)
                {
                    try
                    {
                        var destinationFolder = Path.Combine(Path.GetDirectoryName(foundFiles[i]), "Match");
                        Directory.CreateDirectory(destinationFolder);
                        System.IO.File.Move(foundFiles[i], Path.Combine(destinationFolder, Path.GetFileName(foundFiles[i])));
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions here, e.g. file in use, insufficient permissions, etc.
                        Console.WriteLine($"Error processing file {foundFiles[i]}: {ex.Message}");
                        continue; // Skip this file and move on to the next one
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }

                Invoke((Action)(() => MessageBox.Show(foundFiles.Count + " files found that contain the text '" + inputInclude + "' in their name.")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

        private void FileSize()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                // Get all files in the selected directory and its subdirectories
                string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = files.Length));

                // Read the size categories from a JSON file
                string json = System.IO.File.ReadAllText("Sizes.json"); // replace with the path to your JSON file
                Dictionary<string, long> sizeCategories = JsonConvert.DeserializeObject<Dictionary<string, long>>(json);

                for (int i = 0; i < files.Length; i++)
                {
                    var fileInfo = new FileInfo(files[i]);
                    var fileSize = fileInfo.Length; // Get the file size in bytes

                    foreach (var category in sizeCategories)
                    {
                        // Convert category value from MB to bytes
                        long maxSizeInBytes = category.Value * 1024 * 1024;

                        if (fileSize <= maxSizeInBytes)
                        {
                            var destinationFolder = Path.Combine(Path.GetDirectoryName(files[i]), category.Key);
                            Directory.CreateDirectory(destinationFolder);
                            System.IO.File.Move(files[i], Path.Combine(destinationFolder, Path.GetFileName(files[i])));
                            break;
                        }
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }

                Invoke((Action)(() => MessageBox.Show("Filterd completed")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }

        private void Alphabetical()
        {
            // Run on a separate thread to avoid freezing the UI
            Task.Run(() =>
            {
                // Get all files in the selected directory and its subdirectories
                string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                // Set the maximum value of the progress bar
                Invoke((Action)(() => progressBar_Time.Maximum = files.Length));

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        string fileName = Path.GetFileNameWithoutExtension(files[i]);
                        char firstChar = fileName[0];

                        string folderName;

                        if (char.IsLetter(firstChar) && Encoding.UTF8.GetByteCount(new char[] { firstChar }) == 1)
                        {
                            // If the first character is a UTF-8 letter, use it as the folder name
                            folderName = firstChar.ToString().ToUpper();
                        }
                        else
                        {
                            // If the first character is not a UTF-8 letter, use "Special characters" as the folder name
                            folderName = "Special characters";
                        }

                        var destinationFolder = Path.Combine(Path.GetDirectoryName(files[i]), folderName);
                        Directory.CreateDirectory(destinationFolder);
                        System.IO.File.Move(files[i], Path.Combine(destinationFolder, Path.GetFileName(files[i])));
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions here, e.g. file in use, insufficient permissions, etc.
                        Console.WriteLine($"Error processing file {files[i]}: {ex.Message}");
                        continue; // Skip this file and move on to the next one
                    }

                    // Update the progress bar
                    Invoke((Action)(() => progressBar_Time.Value = i + 1));
                }
                Invoke((Action)(() => MessageBox.Show("Filterd completed")));

                Invoke((Action)(() => progressBar_Time.Value = 0));
            });
        }
    }
}