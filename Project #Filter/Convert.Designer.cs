namespace Project__Filter
{
    partial class Convert
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel_R = new Panel();
            panel_B = new Panel();
            panel_T = new Panel();
            button_Path = new Button();
            panel_button = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Convert = new Button();
            panel_Path = new Panel();
            textBox_Path = new TextBox();
            panel_Middle = new Panel();
            panel1 = new Panel();
            label4 = new Label();
            listBox_File = new ListBox();
            panel3 = new Panel();
            label3 = new Label();
            comboBox_Select = new ComboBox();
            panel_Action = new Panel();
            radioButton_Date = new RadioButton();
            radioButton_Size = new RadioButton();
            radioButton_Name = new RadioButton();
            label6 = new Label();
            radioButton_Folder = new RadioButton();
            radioButton_Custom = new RadioButton();
            label_Warning = new Label();
            panel_T.SuspendLayout();
            panel_button.SuspendLayout();
            panel_Path.SuspendLayout();
            panel_Middle.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel_Action.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 17;
            label1.Text = "Path:";
            // 
            // panel_R
            // 
            panel_R.BackColor = Color.FromArgb(0, 64, 64);
            panel_R.Dock = DockStyle.Right;
            panel_R.Location = new Point(667, 32);
            panel_R.Margin = new Padding(3, 2, 3, 2);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(32, 341);
            panel_R.TabIndex = 26;
            // 
            // panel_B
            // 
            panel_B.BackColor = Color.FromArgb(0, 64, 64);
            panel_B.Dock = DockStyle.Bottom;
            panel_B.Location = new Point(0, 373);
            panel_B.Margin = new Padding(3, 2, 3, 2);
            panel_B.Name = "panel_B";
            panel_B.Size = new Size(699, 32);
            panel_B.TabIndex = 24;
            // 
            // panel_T
            // 
            panel_T.BackColor = Color.FromArgb(0, 64, 64);
            panel_T.Controls.Add(button_Path);
            panel_T.Dock = DockStyle.Top;
            panel_T.Location = new Point(0, 0);
            panel_T.Margin = new Padding(3, 2, 3, 2);
            panel_T.Name = "panel_T";
            panel_T.Size = new Size(699, 32);
            panel_T.TabIndex = 23;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.icons8_add_file_50;
            button_Path.BackgroundImageLayout = ImageLayout.Stretch;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(635, 4);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(25, 25);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel_button
            // 
            panel_button.Controls.Add(label2);
            panel_button.Controls.Add(progressBar_Time);
            panel_button.Controls.Add(checkBox_Delete);
            panel_button.Controls.Add(button_Convert);
            panel_button.Dock = DockStyle.Bottom;
            panel_button.Location = new Point(0, 309);
            panel_button.Margin = new Padding(3, 2, 3, 2);
            panel_button.Name = "panel_button";
            panel_button.Size = new Size(667, 64);
            panel_button.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(307, 19);
            label2.TabIndex = 43;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 38);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(659, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 42;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(334, 13);
            checkBox_Delete.Margin = new Padding(3, 2, 3, 2);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(15, 14);
            checkBox_Delete.TabIndex = 44;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Convert
            // 
            button_Convert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Convert.BackColor = Color.Teal;
            button_Convert.Enabled = false;
            button_Convert.FlatAppearance.BorderSize = 0;
            button_Convert.FlatStyle = FlatStyle.Flat;
            button_Convert.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Convert.ForeColor = Color.White;
            button_Convert.Location = new Point(429, 6);
            button_Convert.Margin = new Padding(3, 2, 3, 2);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(233, 26);
            button_Convert.TabIndex = 45;
            button_Convert.Text = "Convert";
            button_Convert.UseVisualStyleBackColor = false;
            button_Convert.Click += button_Convert_Click;
            // 
            // panel_Path
            // 
            panel_Path.Controls.Add(textBox_Path);
            panel_Path.Controls.Add(label1);
            panel_Path.Dock = DockStyle.Top;
            panel_Path.Location = new Point(0, 32);
            panel_Path.Margin = new Padding(3, 2, 3, 2);
            panel_Path.Name = "panel_Path";
            panel_Path.Size = new Size(667, 72);
            panel_Path.TabIndex = 40;
            // 
            // textBox_Path
            // 
            textBox_Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(86, 4);
            textBox_Path.Margin = new Padding(3, 2, 3, 2);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(572, 33);
            textBox_Path.TabIndex = 26;
            // 
            // panel_Middle
            // 
            panel_Middle.BackColor = Color.FromArgb(64, 64, 64);
            panel_Middle.Controls.Add(panel1);
            panel_Middle.Controls.Add(panel3);
            panel_Middle.Controls.Add(panel_Action);
            panel_Middle.Dock = DockStyle.Fill;
            panel_Middle.Location = new Point(0, 104);
            panel_Middle.Margin = new Padding(3, 2, 3, 2);
            panel_Middle.Name = "panel_Middle";
            panel_Middle.Size = new Size(667, 205);
            panel_Middle.TabIndex = 41;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(listBox_File);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(420, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 205);
            panel1.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 5);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 1;
            label4.Text = "File List";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.ItemHeight = 15;
            listBox_File.Location = new Point(9, 37);
            listBox_File.Name = "listBox_File";
            listBox_File.Size = new Size(233, 169);
            listBox_File.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBox_Select);
            panel3.Location = new Point(0, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(414, 64);
            panel3.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 2);
            label3.Name = "label3";
            label3.Size = new Size(104, 32);
            label3.TabIndex = 39;
            label3.Text = "Options";
            // 
            // comboBox_Select
            // 
            comboBox_Select.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox_Select.BackColor = Color.FromArgb(64, 64, 64);
            comboBox_Select.Enabled = false;
            comboBox_Select.FlatStyle = FlatStyle.Flat;
            comboBox_Select.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            comboBox_Select.ForeColor = Color.White;
            comboBox_Select.FormattingEnabled = true;
            comboBox_Select.Items.AddRange(new object[] { "IMAGE To PDF (TITLE)", "IMAGE To PDF (NO TITLE)", "IMAGE To ICO", "IMAGE To WEBP", "IMAGE To BMP", "IMAGE To ASCII", "VIDEO To AUDIO", "VIDEO To WEBM", "VIDEO To AVI", "AUDIO To WAV" });
            comboBox_Select.Location = new Point(107, 10);
            comboBox_Select.Margin = new Padding(3, 2, 3, 2);
            comboBox_Select.Name = "comboBox_Select";
            comboBox_Select.Size = new Size(304, 29);
            comboBox_Select.TabIndex = 40;
            comboBox_Select.SelectedIndexChanged += comboBox_Select_SelectedIndexChanged;
            // 
            // panel_Action
            // 
            panel_Action.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Action.Controls.Add(radioButton_Date);
            panel_Action.Controls.Add(radioButton_Size);
            panel_Action.Controls.Add(radioButton_Name);
            panel_Action.Controls.Add(label6);
            panel_Action.Controls.Add(radioButton_Folder);
            panel_Action.Controls.Add(radioButton_Custom);
            panel_Action.Controls.Add(label_Warning);
            panel_Action.Location = new Point(0, 75);
            panel_Action.Name = "panel_Action";
            panel_Action.Size = new Size(414, 130);
            panel_Action.TabIndex = 41;
            // 
            // radioButton_Date
            // 
            radioButton_Date.Anchor = AnchorStyles.None;
            radioButton_Date.AutoSize = true;
            radioButton_Date.Enabled = false;
            radioButton_Date.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Date.ForeColor = Color.White;
            radioButton_Date.Location = new Point(287, 78);
            radioButton_Date.Name = "radioButton_Date";
            radioButton_Date.Size = new Size(122, 25);
            radioButton_Date.TabIndex = 5;
            radioButton_Date.TabStop = true;
            radioButton_Date.Text = "Sort by Date";
            radioButton_Date.UseVisualStyleBackColor = true;
            // 
            // radioButton_Size
            // 
            radioButton_Size.Anchor = AnchorStyles.None;
            radioButton_Size.AutoSize = true;
            radioButton_Size.Enabled = false;
            radioButton_Size.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Size.ForeColor = Color.White;
            radioButton_Size.Location = new Point(160, 78);
            radioButton_Size.Name = "radioButton_Size";
            radioButton_Size.Size = new Size(117, 25);
            radioButton_Size.TabIndex = 4;
            radioButton_Size.TabStop = true;
            radioButton_Size.Text = "Sort by Size";
            radioButton_Size.UseVisualStyleBackColor = true;
            // 
            // radioButton_Name
            // 
            radioButton_Name.Anchor = AnchorStyles.None;
            radioButton_Name.AutoSize = true;
            radioButton_Name.Enabled = false;
            radioButton_Name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Name.ForeColor = Color.White;
            radioButton_Name.Location = new Point(18, 78);
            radioButton_Name.Name = "radioButton_Name";
            radioButton_Name.Size = new Size(132, 25);
            radioButton_Name.TabIndex = 3;
            radioButton_Name.TabStop = true;
            radioButton_Name.Text = "Sort by Name";
            radioButton_Name.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 2;
            label6.Text = "Actions";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.Anchor = AnchorStyles.None;
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Enabled = false;
            radioButton_Folder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(213, 47);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(114, 25);
            radioButton_Folder.TabIndex = 2;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder Title";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_Custom
            // 
            radioButton_Custom.Anchor = AnchorStyles.None;
            radioButton_Custom.AutoSize = true;
            radioButton_Custom.Enabled = false;
            radioButton_Custom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Custom.ForeColor = Color.White;
            radioButton_Custom.Location = new Point(66, 47);
            radioButton_Custom.Name = "radioButton_Custom";
            radioButton_Custom.Size = new Size(124, 25);
            radioButton_Custom.TabIndex = 1;
            radioButton_Custom.TabStop = true;
            radioButton_Custom.Text = "Custom Title";
            radioButton_Custom.UseVisualStyleBackColor = true;
            // 
            // label_Warning
            // 
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(3, 103);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 25);
            label_Warning.TabIndex = 0;
            // 
            // Convert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Middle);
            Controls.Add(panel_Path);
            Controls.Add(panel_button);
            Controls.Add(panel_R);
            Controls.Add(panel_B);
            Controls.Add(panel_T);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Convert";
            Size = new Size(699, 405);
            panel_T.ResumeLayout(false);
            panel_button.ResumeLayout(false);
            panel_button.PerformLayout();
            panel_Path.ResumeLayout(false);
            panel_Path.PerformLayout();
            panel_Middle.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel_Action.ResumeLayout(false);
            panel_Action.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel_R;
        private Panel panel_B;
        private Panel panel_T;
        private Button button_Path;
        private Panel panel_button;
        private Panel panel_Path;
        private TextBox textBox_Path;
        private Panel panel_Middle;
        private Label label3;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Convert;
        private ComboBox comboBox_Select;
        private Panel panel_Action;
        private RadioButton radioButton_Custom;
        private Label label_Warning;
        private RadioButton radioButton_Folder;
        private ListBox listBox_File;
        private Label label6;
        private Panel panel3;
        private Panel panel1;
        private Label label4;
        private RadioButton radioButton_Size;
        private RadioButton radioButton_Name;
        private RadioButton radioButton_Date;
    }
}
