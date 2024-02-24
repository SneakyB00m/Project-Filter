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
            panel4 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            button_Path = new Button();
            panel5 = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Convert = new Button();
            panel6 = new Panel();
            textBox_Path = new TextBox();
            panel3 = new Panel();
            panel7 = new Panel();
            label6 = new Label();
            panel8 = new Panel();
            label5 = new Label();
            listBox_File = new ListBox();
            radioButton_Folder = new RadioButton();
            radioButton_Custom = new RadioButton();
            label_Warning = new Label();
            comboBox_Select = new ComboBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
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
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 64, 64);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(667, 32);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(32, 341);
            panel4.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 373);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(699, 32);
            panel2.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Controls.Add(button_Path);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(699, 32);
            panel1.TabIndex = 23;
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
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(progressBar_Time);
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(button_Convert);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 309);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(667, 64);
            panel5.TabIndex = 39;
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
            // panel6
            // 
            panel6.Controls.Add(textBox_Path);
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 32);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(667, 72);
            panel6.TabIndex = 40;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(comboBox_Select);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 104);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(667, 205);
            panel3.TabIndex = 41;
            // 
            // panel7
            // 
            panel7.Controls.Add(label6);
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(radioButton_Folder);
            panel7.Controls.Add(radioButton_Custom);
            panel7.Controls.Add(label_Warning);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 75);
            panel7.Name = "panel7";
            panel7.Size = new Size(667, 130);
            panel7.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 35);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 2;
            label6.Text = "Actions";
            // 
            // panel8
            // 
            panel8.Controls.Add(label5);
            panel8.Controls.Add(listBox_File);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(391, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(276, 130);
            panel8.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 1;
            label5.Text = "Files";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.ItemHeight = 15;
            listBox_File.Location = new Point(3, 20);
            listBox_File.Name = "listBox_File";
            listBox_File.Size = new Size(270, 109);
            listBox_File.TabIndex = 0;
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(14, 94);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(93, 21);
            radioButton_Folder.TabIndex = 2;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder Title";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_Custom
            // 
            radioButton_Custom.AutoSize = true;
            radioButton_Custom.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton_Custom.ForeColor = Color.White;
            radioButton_Custom.Location = new Point(14, 67);
            radioButton_Custom.Name = "radioButton_Custom";
            radioButton_Custom.Size = new Size(102, 21);
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
            label_Warning.Location = new Point(3, 10);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 25);
            label_Warning.TabIndex = 0;
            // 
            // comboBox_Select
            // 
            comboBox_Select.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox_Select.BackColor = Color.FromArgb(64, 64, 64);
            comboBox_Select.FlatStyle = FlatStyle.Flat;
            comboBox_Select.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            comboBox_Select.ForeColor = Color.White;
            comboBox_Select.FormattingEnabled = true;
            comboBox_Select.Items.AddRange(new object[] { "IMAGE To PDF (TITLE)", "IMAGE To PDF (NO TITLE)", "IMAGE To ICO", "IMAGE To WEBP", "IMAGE To BMP", "IMAGE To ASCII", "VIDEO To GIF", "VIDEO To AUDIO", "VIDEO To WEBM", "VIDEO To AVI", "AUDIO To WAV" });
            comboBox_Select.Location = new Point(122, 15);
            comboBox_Select.Margin = new Padding(3, 2, 3, 2);
            comboBox_Select.Name = "comboBox_Select";
            comboBox_Select.Size = new Size(537, 29);
            comboBox_Select.TabIndex = 40;
            comboBox_Select.SelectedIndexChanged += comboBox_Select_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 14);
            label3.Name = "label3";
            label3.Size = new Size(104, 32);
            label3.TabIndex = 39;
            label3.Text = "Options";
            // 
            // Convert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel3);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Convert";
            Size = new Size(699, 405);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel4;
        private Panel panel2;
        private Panel panel1;
        private Button button_Path;
        private Panel panel5;
        private Panel panel6;
        private TextBox textBox_Path;
        private Panel panel3;
        private Label label3;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Convert;
        private ComboBox comboBox_Select;
        private Panel panel7;
        private RadioButton radioButton_Custom;
        private Label label_Warning;
        private RadioButton radioButton_Folder;
        private Panel panel8;
        private ListBox listBox_File;
        private Label label5;
        private Label label6;
    }
}
