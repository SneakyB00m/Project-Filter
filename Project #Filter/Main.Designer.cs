namespace Project__Filter
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Menu = new Panel();
            Panel_Index = new Panel();
            button_Privacy = new Button();
            button_Help = new Button();
            button_Merge = new Button();
            button_Extract = new Button();
            button_Convert = new Button();
            button_Filter = new Button();
            button_Home = new Button();
            panel_Accent = new Panel();
            label1 = new Label();
            button_Exit = new Button();
            button_Git = new Button();
            Panel_Banner = new Panel();
            pictureBox1 = new PictureBox();
            home1 = new Home();
            filter1 = new Filter();
            convert1 = new Convert();
            extract1 = new Extract();
            merge1 = new Merge();
            privacy1 = new Privacy();
            panel_Menu.SuspendLayout();
            panel_Accent.SuspendLayout();
            Panel_Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.FromArgb(64, 64, 64);
            panel_Menu.Controls.Add(Panel_Index);
            panel_Menu.Controls.Add(button_Privacy);
            panel_Menu.Controls.Add(button_Help);
            panel_Menu.Controls.Add(button_Merge);
            panel_Menu.Controls.Add(button_Extract);
            panel_Menu.Controls.Add(button_Convert);
            panel_Menu.Controls.Add(button_Filter);
            panel_Menu.Controls.Add(button_Home);
            panel_Menu.Dock = DockStyle.Left;
            panel_Menu.Location = new Point(0, 0);
            panel_Menu.Margin = new Padding(3, 2, 3, 2);
            panel_Menu.Name = "panel_Menu";
            panel_Menu.Size = new Size(219, 512);
            panel_Menu.TabIndex = 0;
            // 
            // Panel_Index
            // 
            Panel_Index.BackColor = Color.Teal;
            Panel_Index.Location = new Point(3, 26);
            Panel_Index.Margin = new Padding(3, 2, 3, 2);
            Panel_Index.Name = "Panel_Index";
            Panel_Index.Size = new Size(22, 40);
            Panel_Index.TabIndex = 1;
            // 
            // button_Privacy
            // 
            button_Privacy.FlatAppearance.BorderSize = 0;
            button_Privacy.FlatStyle = FlatStyle.Flat;
            button_Privacy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Privacy.ForeColor = Color.White;
            button_Privacy.Image = Properties.Resources.icons8_fingerprint_30;
            button_Privacy.Location = new Point(30, 246);
            button_Privacy.Margin = new Padding(3, 2, 3, 2);
            button_Privacy.Name = "button_Privacy";
            button_Privacy.Size = new Size(186, 40);
            button_Privacy.TabIndex = 8;
            button_Privacy.Text = "    Encipher";
            button_Privacy.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Privacy.UseVisualStyleBackColor = true;
            button_Privacy.Click += button_Privacy_Click;
            // 
            // button_Help
            // 
            button_Help.FlatAppearance.BorderSize = 0;
            button_Help.FlatStyle = FlatStyle.Flat;
            button_Help.Image = Properties.Resources.icons8_help_30;
            button_Help.Location = new Point(3, 478);
            button_Help.Margin = new Padding(3, 2, 3, 2);
            button_Help.Name = "button_Help";
            button_Help.Size = new Size(32, 32);
            button_Help.TabIndex = 6;
            button_Help.UseVisualStyleBackColor = true;
            // 
            // button_Merge
            // 
            button_Merge.FlatAppearance.BorderSize = 0;
            button_Merge.FlatStyle = FlatStyle.Flat;
            button_Merge.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Merge.ForeColor = Color.White;
            button_Merge.Image = Properties.Resources.icons8_merge_30;
            button_Merge.Location = new Point(30, 202);
            button_Merge.Margin = new Padding(3, 2, 3, 2);
            button_Merge.Name = "button_Merge";
            button_Merge.Size = new Size(186, 40);
            button_Merge.TabIndex = 5;
            button_Merge.Text = "    Merge";
            button_Merge.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Merge.UseVisualStyleBackColor = true;
            button_Merge.Click += button_Merge_Click;
            // 
            // button_Extract
            // 
            button_Extract.FlatAppearance.BorderSize = 0;
            button_Extract.FlatStyle = FlatStyle.Flat;
            button_Extract.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Extract.ForeColor = Color.White;
            button_Extract.Image = Properties.Resources.icons8_undo_30;
            button_Extract.Location = new Point(30, 158);
            button_Extract.Margin = new Padding(3, 2, 3, 2);
            button_Extract.Name = "button_Extract";
            button_Extract.Size = new Size(186, 40);
            button_Extract.TabIndex = 4;
            button_Extract.Text = "    Extract";
            button_Extract.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Extract.UseVisualStyleBackColor = true;
            button_Extract.Click += button_Extract_Click;
            // 
            // button_Convert
            // 
            button_Convert.FlatAppearance.BorderSize = 0;
            button_Convert.FlatStyle = FlatStyle.Flat;
            button_Convert.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Convert.ForeColor = Color.White;
            button_Convert.Image = Properties.Resources.icons8_convert_30;
            button_Convert.Location = new Point(30, 114);
            button_Convert.Margin = new Padding(3, 2, 3, 2);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(186, 40);
            button_Convert.TabIndex = 3;
            button_Convert.Text = "    Transform";
            button_Convert.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Convert.UseVisualStyleBackColor = true;
            button_Convert.Click += button_Convert_Click;
            // 
            // button_Filter
            // 
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Filter.ForeColor = Color.White;
            button_Filter.Image = Properties.Resources.icons8_filter_30;
            button_Filter.Location = new Point(30, 70);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(186, 40);
            button_Filter.TabIndex = 2;
            button_Filter.Text = "    Filter";
            button_Filter.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Filter.UseVisualStyleBackColor = true;
            button_Filter.Click += button_Filter_Click_1;
            // 
            // button_Home
            // 
            button_Home.FlatAppearance.BorderSize = 0;
            button_Home.FlatStyle = FlatStyle.Flat;
            button_Home.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_Home.ForeColor = Color.White;
            button_Home.Image = Properties.Resources.icons8_windows_30;
            button_Home.Location = new Point(30, 26);
            button_Home.Margin = new Padding(3, 2, 3, 2);
            button_Home.Name = "button_Home";
            button_Home.Size = new Size(186, 40);
            button_Home.TabIndex = 0;
            button_Home.Text = "    Home";
            button_Home.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Home.UseVisualStyleBackColor = true;
            button_Home.Click += button_Home_Click;
            // 
            // panel_Accent
            // 
            panel_Accent.BackColor = Color.FromArgb(0, 64, 64);
            panel_Accent.Controls.Add(label1);
            panel_Accent.Controls.Add(button_Exit);
            panel_Accent.Controls.Add(button_Git);
            panel_Accent.Dock = DockStyle.Top;
            panel_Accent.Location = new Point(219, 0);
            panel_Accent.Margin = new Padding(3, 2, 3, 2);
            panel_Accent.Name = "panel_Accent";
            panel_Accent.Size = new Size(692, 32);
            panel_Accent.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(84, 6);
            label1.Name = "label1";
            label1.Size = new Size(274, 19);
            label1.TabIndex = 6;
            label1.Text = "TOOL KIT 2.0  BY @SneakyB00m";
            // 
            // button_Exit
            // 
            button_Exit.Anchor = AnchorStyles.Right;
            button_Exit.FlatAppearance.BorderSize = 0;
            button_Exit.FlatStyle = FlatStyle.Flat;
            button_Exit.Image = Properties.Resources.icons8_power_25;
            button_Exit.Location = new Point(660, 2);
            button_Exit.Margin = new Padding(3, 2, 3, 2);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(25, 25);
            button_Exit.TabIndex = 3;
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // button_Git
            // 
            button_Git.FlatAppearance.BorderSize = 0;
            button_Git.FlatStyle = FlatStyle.Flat;
            button_Git.Image = Properties.Resources.icons8_github_25;
            button_Git.Location = new Point(630, 2);
            button_Git.Margin = new Padding(3, 2, 3, 2);
            button_Git.Name = "button_Git";
            button_Git.Size = new Size(25, 25);
            button_Git.TabIndex = 7;
            button_Git.UseVisualStyleBackColor = true;
            // 
            // Panel_Banner
            // 
            Panel_Banner.BackColor = Color.FromArgb(0, 64, 64);
            Panel_Banner.Controls.Add(pictureBox1);
            Panel_Banner.Location = new Point(237, 0);
            Panel_Banner.Margin = new Padding(3, 2, 3, 2);
            Panel_Banner.Name = "Panel_Banner";
            Panel_Banner.Size = new Size(60, 77);
            Panel_Banner.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Martin_Berube_Animal_Sheep_256;
            pictureBox1.Location = new Point(3, 20);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // home1
            // 
            home1.Location = new Point(219, 82);
            home1.Margin = new Padding(3, 2, 3, 2);
            home1.Name = "home1";
            home1.Size = new Size(692, 430);
            home1.TabIndex = 4;
            // 
            // filter1
            // 
            filter1.BackColor = Color.FromArgb(64, 64, 64);
            filter1.Location = new Point(219, 82);
            filter1.Margin = new Padding(3, 2, 3, 2);
            filter1.Name = "filter1";
            filter1.Size = new Size(692, 430);
            filter1.TabIndex = 5;
            // 
            // convert1
            // 
            convert1.BackColor = Color.FromArgb(64, 64, 64);
            convert1.Location = new Point(219, 82);
            convert1.Margin = new Padding(3, 2, 3, 2);
            convert1.Name = "convert1";
            convert1.Size = new Size(692, 430);
            convert1.TabIndex = 8;
            // 
            // extract1
            // 
            extract1.BackColor = Color.FromArgb(64, 64, 64);
            extract1.Location = new Point(219, 82);
            extract1.Margin = new Padding(3, 2, 3, 2);
            extract1.Name = "extract1";
            extract1.Size = new Size(692, 430);
            extract1.TabIndex = 9;
            // 
            // merge1
            // 
            merge1.BackColor = Color.FromArgb(64, 64, 64);
            merge1.Location = new Point(219, 82);
            merge1.Name = "merge1";
            merge1.Size = new Size(692, 430);
            merge1.TabIndex = 10;
            // 
            // privacy1
            // 
            privacy1.BackColor = Color.FromArgb(64, 64, 64);
            privacy1.Location = new Point(219, 82);
            privacy1.Margin = new Padding(3, 2, 3, 2);
            privacy1.Name = "privacy1";
            privacy1.Size = new Size(692, 430);
            privacy1.TabIndex = 11;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(911, 512);
            Controls.Add(home1);
            Controls.Add(filter1);
            Controls.Add(convert1);
            Controls.Add(extract1);
            Controls.Add(merge1);
            Controls.Add(privacy1);
            Controls.Add(Panel_Banner);
            Controls.Add(panel_Accent);
            Controls.Add(panel_Menu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "Form1";
            panel_Menu.ResumeLayout(false);
            panel_Accent.ResumeLayout(false);
            panel_Accent.PerformLayout();
            Panel_Banner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private Panel panel_Accent;
        private Panel Panel_Banner;
        private PictureBox pictureBox1;
        private Button button_Merge;
        private Button button_Extract;
        private Button button_Convert;
        private Button button_Filter;
        private Panel Panel_Index;
        private Button button_Home;
        private Button button_Exit;
        private Button button_Help;
        private Home home1;
        private Filter filter1;
        private Button button_Privacy;
        private Label label1;
        private Button button_Git;
        private Convert convert1;
        private Extract extract1;
        private Merge merge1;
        private Privacy privacy1;
    }
}