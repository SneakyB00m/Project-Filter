namespace Project__Filter
{
    partial class Encrypt
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
            panel_R.Location = new Point(644, 32);
            panel_R.Margin = new Padding(3, 2, 3, 2);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(32, 341);
            panel_R.TabIndex = 33;
            // 
            // panel_L
            // 
            panel_L.BackColor = Color.FromArgb(64, 64, 64);
            panel_L.Dock = DockStyle.Left;
            panel_L.Location = new Point(0, 32);
            panel_L.Margin = new Padding(3, 2, 3, 2);
            panel_L.Name = "panel_L";
            panel_L.Size = new Size(32, 341);
            panel_L.TabIndex = 32;
            // 
            // panel_Down
            // 
            panel_Down.BackColor = Color.FromArgb(0, 64, 64);
            panel_Down.Dock = DockStyle.Bottom;
            panel_Down.Location = new Point(0, 373);
            panel_Down.Margin = new Padding(3, 2, 3, 2);
            panel_Down.Name = "panel_Down";
            panel_Down.Size = new Size(676, 32);
            panel_Down.TabIndex = 31;
            // 
            // panel_Up
            // 
            panel_Up.BackColor = Color.FromArgb(0, 64, 64);
            panel_Up.Controls.Add(button_FilePath);
            panel_Up.Dock = DockStyle.Top;
            panel_Up.Location = new Point(0, 0);
            panel_Up.Margin = new Padding(3, 2, 3, 2);
            panel_Up.Name = "panel_Up";
            panel_Up.Size = new Size(676, 32);
            panel_Up.TabIndex = 30;
            // 
            // button_FilePath
            // 
            button_FilePath.BackColor = Color.Teal;
            button_FilePath.FlatAppearance.BorderSize = 0;
            button_FilePath.FlatStyle = FlatStyle.Flat;
            button_FilePath.Image = Properties.Resources.Add;
            button_FilePath.Location = new Point(630, 5);
            button_FilePath.Margin = new Padding(3, 2, 3, 2);
            button_FilePath.Name = "button_FilePath";
            button_FilePath.Size = new Size(44, 22);
            button_FilePath.TabIndex = 0;
            button_FilePath.UseVisualStyleBackColor = false;
            button_FilePath.Click += button_FilePath_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(38, 39);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 34;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(115, 39);
            textBox_Path.Margin = new Padding(3, 2, 3, 2);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(523, 33);
            textBox_Path.TabIndex = 36;
            // 
            // button_Filter
            // 
            button_Filter.BackColor = Color.Teal;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(398, 313);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(233, 26);
            button_Filter.TabIndex = 39;
            button_Filter.Text = "Encrypt";
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Location = new Point(41, 347);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(590, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(61, 92);
            label3.Name = "label3";
            label3.Size = new Size(95, 30);
            label3.TabIndex = 40;
            label3.Text = "Options";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(245, 92);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 179);
            textBox1.TabIndex = 43;
            textBox1.WordWrap = false;
            // 
            // checkBox_Decrypt
            // 
            checkBox_Decrypt.AutoSize = true;
            checkBox_Decrypt.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Decrypt.ForeColor = Color.White;
            checkBox_Decrypt.Location = new Point(102, 198);
            checkBox_Decrypt.Margin = new Padding(3, 2, 3, 2);
            checkBox_Decrypt.Name = "checkBox_Decrypt";
            checkBox_Decrypt.Size = new Size(103, 27);
            checkBox_Decrypt.TabIndex = 45;
            checkBox_Decrypt.Text = "Decrypt";
            checkBox_Decrypt.UseVisualStyleBackColor = true;
            checkBox_Decrypt.CheckedChanged += checkBox_Decrypt_CheckedChanged;
            // 
            // checkBox_Encrypt
            // 
            checkBox_Encrypt.AutoSize = true;
            checkBox_Encrypt.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Encrypt.ForeColor = Color.White;
            checkBox_Encrypt.Location = new Point(102, 152);
            checkBox_Encrypt.Margin = new Padding(3, 2, 3, 2);
            checkBox_Encrypt.Name = "checkBox_Encrypt";
            checkBox_Encrypt.Size = new Size(102, 27);
            checkBox_Encrypt.TabIndex = 44;
            checkBox_Encrypt.Text = "Encrypt";
            checkBox_Encrypt.UseVisualStyleBackColor = true;
            checkBox_Encrypt.CheckedChanged += checkBox_Encrypt_CheckedChanged;
            // 
            // Privacy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Privacy";
            Size = new Size(676, 405);
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
