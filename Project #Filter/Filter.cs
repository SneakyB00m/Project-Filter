using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using SharpCompress;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        Dictionary<string, List<string>> myDict;
        List<CheckBox> checkedBoxesInOrder = new List<CheckBox>();

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            if (File.Exists("Folders.json"))
            {
                string json = File.ReadAllText("Folders.json");
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

                    checkBox_Size.Enabled = true;
                    checkBox_Resolution.Enabled = true;
                    checkBox_AtoZ.Enabled = true;
                    checkBox_Duration.Enabled = true;
                    checkBox_Include.Enabled = true;
                    button_Filter.Enabled = true;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                checkedBoxesInOrder.Add(checkBox);
            }
            else
            {
                checkedBoxesInOrder.Remove(checkBox);
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            List<string> checkedBoxesNames = new List<string>();

            // Now checkedBoxesInOrder contains the CheckBoxes in the order they were checked
            foreach (CheckBox checkBox in checkedBoxesInOrder)
            {
                checkedBoxesNames.Add(checkBox.Name);
            }

            FirstSort();

            foreach (string checkBoxName in checkedBoxesNames)
            {
                switch (checkBoxName)
                {
                    case "checkBox_Resolution":
                        Resolution();
                        break;
                    case "checkBox_Duration":
                        Duration();
                        break;
                    case "checkBox_Include":
                        Include();
                        break;
                    case "checkBox_Size":
                        FileSize();
                        break;
                    case "checkBox_AtoZ":
                        Alphabetical();
                        break;
                    default:
                        // Optional: Perform a default action
                        break;
                }
            }

            if (checkBox_Delete.Checked)
            {
                // Perform delete operation
            }

            // Populate the TreeView control
            PopulateTreeView(selectedPath, treeView1.Nodes);
        }

        private void PopulateTreeView(string directoryValue, TreeNodeCollection parentNode)
        {
            string[] directoryArray = Directory.GetDirectories(directoryValue);
            try
            {
                if (directoryArray.Length != 0)
                {
                    foreach (string directory in directoryArray)
                    {
                        string dir = Path.GetFileName(directory);
                        TreeNode myNode = new TreeNode(dir);
                        parentNode.Add(myNode);
                        PopulateTreeView(directory, myNode.Nodes);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Catch exception if the code doesn't have access to the folder
                parentNode.Add("Access denied");
            }
        }


        // Functions
        private void FirstSort()
        {
            string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

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
                File.Move(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
            }
        }

        private void Resolution()
        {
            var ffprobe = new NReco.VideoInfo.FFProbe();

            // get the path of the "videos" directory
            string videospath = Path.Combine(selectedPath, "videos");

            // check if the "videos" directory exists
            if (!Directory.Exists(videospath))
            {
                MessageBox.Show("no 'videos' folder or video files found in the directory: " + selectedPath);
                return;
            }

            // get all video files in the "videos" directory and its subdirectories
            string[] videofiles = Directory.GetFiles(videospath, "*.*", SearchOption.AllDirectories);

            foreach (string videofile in videofiles)
            {
                var videoInfo = ffprobe.GetMediaInfo(videofile);
                string resolution = videoInfo.Streams[0].Width.ToString() + "x" + videoInfo.Streams[0].Height.ToString();

                string destinationDirectory = Path.Combine(videospath, resolution);
                Directory.CreateDirectory(destinationDirectory);

                string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(videofile));
                File.Move(videofile, destinationFile);
            }
        }

        private void Duration()
        {
            var ffProbe = new NReco.VideoInfo.FFProbe();

            // Get the path of the "Videos" directory
            string videosPath = Path.Combine(selectedPath, "Videos");

            // Check if the "Videos" directory exists
            if (!Directory.Exists(videosPath))
            {
                MessageBox.Show("No 'Videos' folder or video files found in the directory: " + selectedPath);
                return;
            }

            // Get all video files in the "Videos" directory and its subdirectories
            string[] videoFiles = Directory.GetFiles(videosPath, "*.*", SearchOption.AllDirectories);

            // Read the duration categories from a JSON file
            string json = File.ReadAllText("Duration.json"); // replace with the path to your JSON file
            Dictionary<string, int> durationCategories = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

            foreach (var videoFile in videoFiles)
            {
                try
                {
                    var videoInfo = ffProbe.GetMediaInfo(videoFile);
                    var duration = videoInfo.Duration.TotalSeconds;

                    foreach (var category in durationCategories)
                    {
                        if (duration <= category.Value)
                        {
                            var destinationFolder = Path.Combine(Path.GetDirectoryName(videoFile), category.Key);
                            Directory.CreateDirectory(destinationFolder);
                            File.Move(videoFile, Path.Combine(destinationFolder, Path.GetFileName(videoFile)));
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the error message if needed
                    Console.WriteLine($"Error processing file {videoFile}: {ex.Message}");
                    continue; // Skip this file and move on to the next one
                }
            }

        }

        private void Include()
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

            string lowerCaseSearchText = inputInclude.ToLower();

            // Filter the files that contain the search text in their name, excluding the extension
            var foundFiles = files.Where(file => Path.GetFileNameWithoutExtension(file).ToLower().Contains(lowerCaseSearchText)).ToList();

            foreach (var file in foundFiles)
            {
                try
                {
                    var destinationFolder = Path.Combine(Path.GetDirectoryName(file), "Match");
                    Directory.CreateDirectory(destinationFolder);
                    File.Move(file, Path.Combine(destinationFolder, Path.GetFileName(file)));
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, e.g. file in use, insufficient permissions, etc.
                }
            }

            MessageBox.Show(foundFiles.Count + " files found that contain the text '" + inputInclude + "' in their name.");
        }


        private void FileSize()
        {
            // Get all files in the selected directory and its subdirectories
            string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

            // Read the size categories from a JSON file
            string json = File.ReadAllText("Sizes.json"); // replace with the path to your JSON file
            Dictionary<string, long> sizeCategories = JsonConvert.DeserializeObject<Dictionary<string, long>>(json);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileSize = fileInfo.Length; // Get the file size in bytes

                foreach (var category in sizeCategories)
                {
                    // Convert category value from MB to bytes
                    long maxSizeInBytes = category.Value * 1024 * 1024;

                    if (fileSize <= maxSizeInBytes)
                    {
                        var destinationFolder = Path.Combine(Path.GetDirectoryName(file), category.Key);
                        Directory.CreateDirectory(destinationFolder);
                        File.Move(file, Path.Combine(destinationFolder, Path.GetFileName(file)));
                        break;
                    }
                }
            }
        }


        private void Alphabetical()
        {
            // Get all files in the selected directory and its subdirectories
            string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
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

                    var destinationFolder = Path.Combine(Path.GetDirectoryName(file), folderName);
                    Directory.CreateDirectory(destinationFolder);
                    File.Move(file, Path.Combine(destinationFolder, Path.GetFileName(file)));
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, e.g. file in use, insufficient permissions, etc.
                }
            }
        }

    }
}