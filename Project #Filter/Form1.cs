namespace Project__Filter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Panel_Index.Height = button1.Height;
            Panel_Index.Top = button1.Top;
            home1.BringToFront();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Panel_Index.Height = button1.Height;
            Panel_Index.Top = button1.Top;
            home1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button2.Height;
            Panel_Index.Top = button2.Top;
            filter1.BringToFront();
        }
    }
}