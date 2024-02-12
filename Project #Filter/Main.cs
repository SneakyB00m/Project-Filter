using Newtonsoft.Json;

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

        private void button_Config_Click(object sender, EventArgs e)
        {
            config_Menu1.BringToFront();
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Folders.json") || !File.Exists("Sizes.json") || !File.Exists("Duration.json"))
            {
                var dictsort = new Dictionary<string, List<string>>
                {
                    { "Videos", new List<string>() { "mp4", "m4v", "avi", "mkv" } },
                    { "Documents", new List<string>() { "txt", "docx", "pdf", "pptx" } },
                    { "Images", new List<string>() { "jpg", "png", "gif", "bmp" } }
                };

                string sort = JsonConvert.SerializeObject(dictsort, Formatting.Indented);
                File.WriteAllText("Folders.json", sort);


                var dictsize = new Dictionary<string, int>
                {
                    { "250MB to 500MB", 500 },
                    { "500MB to 1GB", 1000 },
                    { "More than 1GB", 2000 }
                };

                string sizeJson = JsonConvert.SerializeObject(dictsize, Formatting.Indented);
                File.WriteAllText("Sizes.json", sizeJson);


                var dictduration = new Dictionary<string, int>
                {
                    { "Less than 5 Min", 300 },
                    { "5 Min to 10 Min", 600 },
                    { "10 Min to 1 Hr", 3600 },
                    { "More than 1 Hr", 3601 }
                };

                string durationJson = JsonConvert.SerializeObject(dictduration, Formatting.Indented);
                File.WriteAllText("Duration.json", durationJson);

            }
        }

    }
}