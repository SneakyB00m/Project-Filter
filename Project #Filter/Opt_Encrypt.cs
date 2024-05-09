namespace Project__Filter
{
    public partial class Opt_Encrypt : UserControl
    {

        string selectedPath = string.Empty;

        public Opt_Encrypt()
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

                    comboBox_Select.Enabled = true;
                    button_Start.Enabled = true;
                }
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {

        }
    }
}
