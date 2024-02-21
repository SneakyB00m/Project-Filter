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
            button1 = new Button();
            panel5 = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Filter = new Button();
            panel6 = new Panel();
            textBox_Path = new TextBox();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 41);
            label1.TabIndex = 17;
            label1.Text = "Path:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 64, 64);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(762, 43);
            panel4.Name = "panel4";
            panel4.Size = new Size(37, 454);
            panel4.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 497);
            panel2.Name = "panel2";
            panel2.Size = new Size(799, 43);
            panel2.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 43);
            panel1.TabIndex = 23;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(0, 64, 64);
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(726, 6);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(progressBar_Time);
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(button_Filter);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 412);
            panel5.Name = "panel5";
            panel5.Size = new Size(762, 85);
            panel5.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 14);
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
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(382, 17);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 44;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(490, 8);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(266, 35);
            button_Filter.TabIndex = 45;
            button_Filter.Text = "Filter";
            button_Filter.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(textBox_Path);
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 43);
            panel6.Name = "panel6";
            panel6.Size = new Size(762, 96);
            panel6.TabIndex = 40;
            // 
            // textBox_Path
            // 
            textBox_Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(98, 5);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(654, 39);
            textBox_Path.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 139);
            panel3.Name = "panel3";
            panel3.Size = new Size(762, 273);
            panel3.TabIndex = 41;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.BackColor = Color.FromArgb(64, 64, 64);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.ForeColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "IMAGE To PDF (TITLE)", "IMAGE To PDF (NO TITLE)", "IMAGE To ICO", "IMAGE To WEBP", "IMAGE To BMP", "VIDEO To GIF", "VIDEO To AUDIO", "VIDEO To WEBM", "VIDEO To AVI", "AUDIO To WAV" });
            comboBox1.Location = new Point(139, 20);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(613, 36);
            comboBox1.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 18);
            label3.Name = "label3";
            label3.Size = new Size(130, 41);
            label3.TabIndex = 39;
            label3.Text = "Options";
            // 
            // Convert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel3);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Convert";
            Size = new Size(799, 540);
            Load += Convert_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel4;
        private Panel panel2;
        private Panel panel1;
        private Button button1;
        private Panel panel5;
        private Panel panel6;
        private TextBox textBox_Path;
        private Panel panel3;
        private Label label3;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Filter;
        private ComboBox comboBox1;
    }
}
