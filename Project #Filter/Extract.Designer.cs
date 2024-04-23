namespace Project__Filter
{
    partial class Extract
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Path = new Panel();
            textBox_Path = new TextBox();
            label1 = new Label();
            panel_R = new Panel();
            panel_B = new Panel();
            panel_T = new Panel();
            button_Path = new Button();
            panel_button = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Extract = new Button();
            panel1 = new Panel();
            radioButton_Untar = new RadioButton();
            radioButton_Unzip = new RadioButton();
            radioButton_Unrar = new RadioButton();
            label5 = new Label();
            radioButton_Folder = new RadioButton();
            panel2 = new Panel();
            label_Count = new Label();
            label4 = new Label();
            listBox_File = new ListBox();
            panel_Path.SuspendLayout();
            panel_T.SuspendLayout();
            panel_button.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Path
            // 
            panel_Path.Controls.Add(textBox_Path);
            panel_Path.Controls.Add(label1);
            panel_Path.Dock = DockStyle.Top;
            panel_Path.Location = new Point(0, 43);
            panel_Path.Name = "panel_Path";
            panel_Path.Size = new Size(762, 96);
            panel_Path.TabIndex = 47;
            // 
            // textBox_Path
            // 
            textBox_Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(98, 5);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(653, 39);
            textBox_Path.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 41);
            label1.TabIndex = 17;
            label1.Text = "Path:";
            // 
            // panel_R
            // 
            panel_R.BackColor = Color.FromArgb(0, 64, 64);
            panel_R.Dock = DockStyle.Right;
            panel_R.Location = new Point(762, 43);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(37, 454);
            panel_R.TabIndex = 46;
            // 
            // panel_B
            // 
            panel_B.BackColor = Color.FromArgb(0, 64, 64);
            panel_B.Dock = DockStyle.Bottom;
            panel_B.Location = new Point(0, 497);
            panel_B.Name = "panel_B";
            panel_B.Size = new Size(799, 43);
            panel_B.TabIndex = 45;
            // 
            // panel_T
            // 
            panel_T.BackColor = Color.FromArgb(0, 64, 64);
            panel_T.Controls.Add(button_Path);
            panel_T.Dock = DockStyle.Top;
            panel_T.Location = new Point(0, 0);
            panel_T.Name = "panel_T";
            panel_T.Size = new Size(799, 43);
            panel_T.TabIndex = 44;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.icons8_add_file_50;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(726, 5);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(29, 33);
            button_Path.TabIndex = 1;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel_button
            // 
            panel_button.Controls.Add(label2);
            panel_button.Controls.Add(progressBar_Time);
            panel_button.Controls.Add(checkBox_Delete);
            panel_button.Controls.Add(button_Extract);
            panel_button.Dock = DockStyle.Bottom;
            panel_button.Location = new Point(0, 412);
            panel_button.Name = "panel_button";
            panel_button.Size = new Size(762, 85);
            panel_button.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 13);
            label2.Name = "label2";
            label2.Size = new Size(367, 23);
            label2.TabIndex = 43;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 51);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(753, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 42;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(382, 17);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 44;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Extract
            // 
            button_Extract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Extract.BackColor = Color.Teal;
            button_Extract.Enabled = false;
            button_Extract.FlatAppearance.BorderSize = 0;
            button_Extract.FlatStyle = FlatStyle.Flat;
            button_Extract.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Extract.ForeColor = Color.White;
            button_Extract.Location = new Point(490, 8);
            button_Extract.Name = "button_Extract";
            button_Extract.Size = new Size(266, 35);
            button_Extract.TabIndex = 45;
            button_Extract.Text = "Extract";
            button_Extract.UseVisualStyleBackColor = false;
            button_Extract.Click += button_Extract_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton_Untar);
            panel1.Controls.Add(radioButton_Unzip);
            panel1.Controls.Add(radioButton_Unrar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(radioButton_Folder);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 139);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 273);
            panel1.TabIndex = 49;
            // 
            // radioButton_Untar
            // 
            radioButton_Untar.Anchor = AnchorStyles.Top;
            radioButton_Untar.AutoSize = true;
            radioButton_Untar.Enabled = false;
            radioButton_Untar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Untar.ForeColor = Color.White;
            radioButton_Untar.Location = new Point(291, 188);
            radioButton_Untar.Margin = new Padding(3, 4, 3, 4);
            radioButton_Untar.Name = "radioButton_Untar";
            radioButton_Untar.Size = new Size(84, 29);
            radioButton_Untar.TabIndex = 44;
            radioButton_Untar.TabStop = true;
            radioButton_Untar.Text = "Untar";
            radioButton_Untar.UseVisualStyleBackColor = true;
            // 
            // radioButton_Unzip
            // 
            radioButton_Unzip.Anchor = AnchorStyles.Top;
            radioButton_Unzip.AutoSize = true;
            radioButton_Unzip.Enabled = false;
            radioButton_Unzip.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Unzip.ForeColor = Color.White;
            radioButton_Unzip.Location = new Point(291, 83);
            radioButton_Unzip.Margin = new Padding(3, 4, 3, 4);
            radioButton_Unzip.Name = "radioButton_Unzip";
            radioButton_Unzip.Size = new Size(85, 29);
            radioButton_Unzip.TabIndex = 43;
            radioButton_Unzip.TabStop = true;
            radioButton_Unzip.Text = "Unzip";
            radioButton_Unzip.UseVisualStyleBackColor = true;
            // 
            // radioButton_Unrar
            // 
            radioButton_Unrar.Anchor = AnchorStyles.Top;
            radioButton_Unrar.AutoSize = true;
            radioButton_Unrar.Enabled = false;
            radioButton_Unrar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Unrar.ForeColor = Color.White;
            radioButton_Unrar.Location = new Point(73, 188);
            radioButton_Unrar.Margin = new Padding(3, 4, 3, 4);
            radioButton_Unrar.Name = "radioButton_Unrar";
            radioButton_Unrar.Size = new Size(85, 29);
            radioButton_Unrar.TabIndex = 42;
            radioButton_Unrar.TabStop = true;
            radioButton_Unrar.Text = "Unrar";
            radioButton_Unrar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 3);
            label5.Name = "label5";
            label5.Size = new Size(130, 41);
            label5.TabIndex = 40;
            label5.Text = "Options";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.Anchor = AnchorStyles.Top;
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Enabled = false;
            radioButton_Folder.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(73, 83);
            radioButton_Folder.Margin = new Padding(3, 4, 3, 4);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(90, 29);
            radioButton_Folder.TabIndex = 1;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(label_Count);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(listBox_File);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(480, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(282, 273);
            panel2.TabIndex = 0;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Count.ForeColor = Color.White;
            label_Count.Location = new Point(165, 7);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(84, 28);
            label_Count.TabIndex = 3;
            label_Count.Text = "File List";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(162, 28);
            label4.TabIndex = 2;
            label4.Text = "File List           #";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.Location = new Point(10, 49);
            listBox_File.Margin = new Padding(3, 4, 3, 4);
            listBox_File.Name = "listBox_File";
            listBox_File.Size = new Size(266, 224);
            listBox_File.TabIndex = 1;
            // 
            // Extract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel1);
            Controls.Add(panel_button);
            Controls.Add(panel_Path);
            Controls.Add(panel_R);
            Controls.Add(panel_B);
            Controls.Add(panel_T);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Extract";
            Size = new Size(799, 540);
            panel_Path.ResumeLayout(false);
            panel_Path.PerformLayout();
            panel_T.ResumeLayout(false);
            panel_button.ResumeLayout(false);
            panel_button.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Path;
        private TextBox textBox_Path;
        private Label label1;
        private Panel panel_R;
        private Panel panel_B;
        private Panel panel_T;
        private Panel panel_button;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Extract;
        private Panel panel1;
        private Panel panel2;
        private ListBox listBox_File;
        private Label label5;
        private Label label4;
        private Button button_Path;
        private Label label_Count;
        private RadioButton radioButton_Untar;
        private RadioButton radioButton_Unzip;
        private RadioButton radioButton_Unrar;
        private RadioButton radioButton_Folder;
    }
}
