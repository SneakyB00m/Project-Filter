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

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button3.Height;
            Panel_Index.Top = button3.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button4.Height;
            Panel_Index.Top = button4.Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button5.Height;
            Panel_Index.Top = button5.Top;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button6.Height;
            Panel_Index.Top = button6.Top;
        }
    }
}