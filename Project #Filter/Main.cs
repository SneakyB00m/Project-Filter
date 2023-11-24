namespace Project__Filter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            // Index
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Git_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/Dev-Alan-Isaac",
                UseShellExecute = true
            });
        }

        private void button_Home_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
        }

        private void button_Filter_Click_1(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Filter.Height;
            Panel_Index.Top = button_Filter.Top;
            filter1.BringToFront();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Convert.Height;
            Panel_Index.Top = button_Convert.Top;
            convert1.BringToFront();
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Extract.Height;
            Panel_Index.Top = button_Extract.Top;
            extract1.BringToFront();
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Merge.Height;
            Panel_Index.Top = button_Merge.Top;
            merge1.BringToFront();
        }

        private void button_Privacy_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Privacy.Height;
            Panel_Index.Top = button_Privacy.Top;
            privacy1.BringToFront();
        }
    }
}

public class Actions_Filter
{
    public string? OpenFolderManager()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    public List<CheckBox> GetCheckedCheckBoxes(UserControl userControl)
    {
        List<CheckBox> checkedCheckBoxes = new List<CheckBox>();

        foreach (Control control in userControl.Controls)
        {
            if (control is CheckBox)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox.Checked)
                {
                    checkedCheckBoxes.Add(checkBox);
                }
            }
        }

        return checkedCheckBoxes; // Return the list of checked checkboxes
    }

    public List<string> HandleInclude(string folderPath, string include)
    {
        string filteredPath = Path.Combine(folderPath, "Filtered");
        if (!Directory.Exists(filteredPath))
        {
            Directory.CreateDirectory(filteredPath);
        }

        string includePath = Path.Combine(filteredPath, "Includes");
        if (!Directory.Exists(includePath))
        {
            Directory.CreateDirectory(includePath);
        }

        // Get all files in the folder and its subfolders
        List<string> allFiles = GetAllFiles(folderPath);

        // Filter the files based on the include string
        List<string> includedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(include, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        // List to store the destination paths of the moved files
        List<string> destinationPaths = new List<string>();

        // Move the included files to the "include" directory
        foreach (string file in includedFiles)
        {
            string destinationPath = Path.Combine(includePath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);

            // Add the destination path to the list
            destinationPaths.Add(destinationPath);
        }

        // Return the list of destination paths
        return destinationPaths;
    }

    public List<string> HandleExclude(string folderPath, string exclude)
    {
        // Create the "filtered" directory if it doesn't exist
        string filteredPath = Path.Combine(folderPath, "Filtered");
        if (!Directory.Exists(filteredPath))
        {
            Directory.CreateDirectory(filteredPath);
        }

        // Create the "exclude" directory inside the "filtered" directory
        string excludePath = Path.Combine(filteredPath, "Excludes");
        if (!Directory.Exists(excludePath))
        {
            Directory.CreateDirectory(excludePath);
        }

        // Get all files in the folder and its subfolders
        List<string> allFiles = GetAllFiles(folderPath);

        // Filter the files based on the exclude string
        List<string> excludedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(exclude, StringComparison.OrdinalIgnoreCase) < 0).ToList();

        // List to store the destination paths of the moved files
        List<string> destinationPaths = new List<string>();

        // Move the excluded files to the "exclude" directory
        foreach (string file in excludedFiles)
        {
            string destinationPath = Path.Combine(excludePath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);

            // Add the destination path to the list
            destinationPaths.Add(destinationPath);
        }

        // Return the list of destination paths
        return destinationPaths;
    }

    public void HandleExtension(string folderPath)
    {
        // Get all files in the directory and its subdirectories
        List<string> allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).ToList();

        // Move the files to directories based on their extensions
        foreach (string file in allFiles)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            string extensionPath = Path.Combine(folderPath, extension);

            if (!Directory.Exists(extensionPath))
            {
                Directory.CreateDirectory(extensionPath);
            }

            string destinationPath = Path.Combine(extensionPath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);
        }
    }

    public void HandleResolution(string folderPath)
    {

    }

    public void HandleDuration(string folderPath)
    {

    }

    public void HandleSize(string folderPath)
    {

    }

    public void HandleDate(string folderPath)
    {

    }

    public void HandleAToZ(string folderPath)
    {

    }

    public void HandleDelete(string folderPath)
    {
        // Access folderPath here
        Console.WriteLine(folderPath);
    }

    public List<string> GetAllFiles(string folderPath)
    {
        List<string> filesList = new List<string>();

        // Check if the directory exists
        if (Directory.Exists(folderPath))
        {
            // Get the files in the directory
            string[] files = Directory.GetFiles(folderPath);
            filesList.AddRange(files);

            // Get the subdirectories in the directory
            string[] subdirectories = Directory.GetDirectories(folderPath);

            // Use a foreach loop to check each subdirectory
            foreach (string subdirectory in subdirectories)
            {
                // Use recursion to get the files in the subdirectory
                List<string> subdirectoryFiles = GetAllFiles(subdirectory);
                filesList.AddRange(subdirectoryFiles);
            }
        }

        return filesList; // Return the list of files
    }

}


public class Action_Extract
{
    public string? OpenFolderManager()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    public List<string> GetAllFiles(string folderPath)
    {
        List<string> filesList = new List<string>();

        // Check if the directory exists
        if (Directory.Exists(folderPath))
        {
            // Get the files in the directory
            string[] files = Directory.GetFiles(folderPath);
            filesList.AddRange(files);

            // Get the subdirectories in the directory
            string[] subdirectories = Directory.GetDirectories(folderPath);

            // Use a foreach loop to check each subdirectory
            foreach (string subdirectory in subdirectories)
            {
                // Use recursion to get the files in the subdirectory
                List<string> subdirectoryFiles = GetAllFiles(subdirectory);
                filesList.AddRange(subdirectoryFiles);
            }
        }

        return filesList; // Return the list of files
    }
}