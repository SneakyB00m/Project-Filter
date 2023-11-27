namespace Project__Filter
{
    partial class Privacy
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
            panel_R = new Panel();
            panel_L = new Panel();
            panel_Down = new Panel();
            panel_Up = new Panel();
            button_FilePath = new Button();
            label1 = new Label();
            textBox_Path = new TextBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            label3 = new Label();
            textBox1 = new TextBox();
            checkBox_Decrypt = new CheckBox();
            checkBox_Encrypt = new CheckBox();
            panel_Up.SuspendLayout();
            SuspendLayout();
            // 
            // panel_R
            // 
            panel_R.BackColor = Color.FromArgb(64, 64, 64);
            panel_R.Dock = DockStyle.Right;
            panel_R.Location = new Point(736, 43);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(37, 454);
            panel_R.TabIndex = 33;
            // 
            // panel_L
            // 
            panel_L.BackColor = Color.FromArgb(64, 64, 64);
            panel_L.Dock = DockStyle.Left;
            panel_L.Location = new Point(0, 43);
            panel_L.Name = "panel_L";
            panel_L.Size = new Size(37, 454);
            panel_L.TabIndex = 32;
            // 
            // panel_Down
            // 
            panel_Down.BackColor = Color.FromArgb(0, 64, 64);
            panel_Down.Dock = DockStyle.Bottom;
            panel_Down.Location = new Point(0, 497);
            panel_Down.Name = "panel_Down";
            panel_Down.Size = new Size(773, 43);
            panel_Down.TabIndex = 31;
            // 
            // panel_Up
            // 
            panel_Up.BackColor = Color.FromArgb(0, 64, 64);
            panel_Up.Controls.Add(button_FilePath);
            panel_Up.Dock = DockStyle.Top;
            panel_Up.Location = new Point(0, 0);
            panel_Up.Name = "panel_Up";
            panel_Up.Size = new Size(773, 43);
            panel_Up.TabIndex = 30;
            // 
            // button_FilePath
            // 
            button_FilePath.BackColor = Color.Teal;
            button_FilePath.FlatAppearance.BorderSize = 0;
            button_FilePath.FlatStyle = FlatStyle.Flat;
            button_FilePath.Image = Properties.Resources.Add;
            button_FilePath.Location = new Point(720, 7);
            button_FilePath.Name = "button_FilePath";
            button_FilePath.Size = new Size(50, 29);
            button_FilePath.TabIndex = 0;
            button_FilePath.UseVisualStyleBackColor = false;
            button_FilePath.Click += button_FilePath_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 52);
            label1.Name = "label1";
            label1.Size = new Size(89, 41);
            label1.TabIndex = 34;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.None;
            textBox_Path.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(131, 69);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(598, 24);
            textBox_Path.TabIndex = 36;
            // 
            // button_Filter
            // 
            button_Filter.BackColor = Color.Teal;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(455, 417);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(266, 35);
            button_Filter.TabIndex = 39;
            button_Filter.Text = "Encrypt";
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Location = new Point(47, 463);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(674, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(70, 123);
            label3.Name = "label3";
            label3.Size = new Size(120, 38);
            label3.TabIndex = 40;
            label3.Text = "Options";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(280, 123);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(441, 237);
            textBox1.TabIndex = 43;
            textBox1.WordWrap = false;
            // 
            // checkBox_Decrypt
            // 
            checkBox_Decrypt.AutoSize = true;
            checkBox_Decrypt.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_Decrypt.ForeColor = Color.White;
            checkBox_Decrypt.Location = new Point(116, 264);
            checkBox_Decrypt.Name = "checkBox_Decrypt";
            checkBox_Decrypt.Size = new Size(124, 32);
            checkBox_Decrypt.TabIndex = 45;
            checkBox_Decrypt.Text = "Decrypt";
            checkBox_Decrypt.UseVisualStyleBackColor = true;
            checkBox_Decrypt.CheckedChanged += checkBox_Decrypt_CheckedChanged;
            // 
            // checkBox_Encrypt
            // 
            checkBox_Encrypt.AutoSize = true;
            checkBox_Encrypt.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_Encrypt.ForeColor = Color.White;
            checkBox_Encrypt.Location = new Point(116, 202);
            checkBox_Encrypt.Name = "checkBox_Encrypt";
            checkBox_Encrypt.Size = new Size(122, 32);
            checkBox_Encrypt.TabIndex = 44;
            checkBox_Encrypt.Text = "Encrypt";
            checkBox_Encrypt.UseVisualStyleBackColor = true;
            checkBox_Encrypt.CheckedChanged += checkBox_Encrypt_CheckedChanged;
            // 
            // Privacy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(checkBox_Decrypt);
            Controls.Add(checkBox_Encrypt);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox_Path);
            Controls.Add(button_Filter);
            Controls.Add(progressBar_Time);
            Controls.Add(panel_R);
            Controls.Add(panel_L);
            Controls.Add(panel_Up);
            Controls.Add(panel_Down);
            Name = "Privacy";
            Size = new Size(773, 540);
            panel_Up.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel_R;
        private Panel panel_L;
        private Panel panel_Down;
        private Panel panel_Up;
        private Button button_FilePath;
        private Label label1;
        private TextBox textBox_Path;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Label label3;
        private TextBox textBox1;
        private CheckBox checkBox_Decrypt;
        private CheckBox checkBox_Encrypt;
    }
}
