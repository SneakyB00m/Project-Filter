namespace Project__Filter
{
    partial class Extract
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
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            button_Folder = new Button();
            label1 = new Label();
            textBox_Path = new TextBox();
            button_Extract = new Button();
            progressBar_Time = new ProgressBar();
            label3 = new Label();
            radioButton_Folder = new RadioButton();
            radioButton_Zip = new RadioButton();
            radioButton_Tar = new RadioButton();
            radioButton_Unzip = new RadioButton();
            radioButton_Untar = new RadioButton();
            radioButton_Unrar = new RadioButton();
            label2 = new Label();
            checkBox_Delete = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(64, 64, 64);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(736, 43);
            panel4.Name = "panel4";
            panel4.Size = new Size(37, 454);
            panel4.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(37, 454);
            panel3.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 497);
            panel2.Name = "panel2";
            panel2.Size = new Size(773, 43);
            panel2.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Controls.Add(button_Folder);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 43);
            panel1.TabIndex = 8;
            // 
            // button_Folder
            // 
            button_Folder.BackColor = Color.Teal;
            button_Folder.FlatAppearance.BorderSize = 0;
            button_Folder.FlatStyle = FlatStyle.Flat;
            button_Folder.Image = Properties.Resources.Add;
            button_Folder.Location = new Point(720, 7);
            button_Folder.Name = "button_Folder";
            button_Folder.Size = new Size(50, 29);
            button_Folder.TabIndex = 0;
            button_Folder.UseVisualStyleBackColor = false;
            button_Folder.Click += button_Folder_Click;
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
            label1.TabIndex = 30;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.None;
            textBox_Path.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(131, 68);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(598, 24);
            textBox_Path.TabIndex = 32;
            // 
            // button_Extract
            // 
            button_Extract.BackColor = Color.Teal;
            button_Extract.FlatAppearance.BorderSize = 0;
            button_Extract.FlatStyle = FlatStyle.Flat;
            button_Extract.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_Extract.ForeColor = Color.White;
            button_Extract.Location = new Point(455, 417);
            button_Extract.Name = "button_Extract";
            button_Extract.Size = new Size(266, 35);
            button_Extract.TabIndex = 33;
            button_Extract.Text = "Extract";
            button_Extract.UseVisualStyleBackColor = false;
            button_Extract.Click += button_Extract_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Location = new Point(47, 463);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(674, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 31;
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
            label3.TabIndex = 29;
            label3.Text = "Options";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(251, 184);
            radioButton_Folder.Margin = new Padding(3, 4, 3, 4);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(109, 33);
            radioButton_Folder.TabIndex = 34;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_Zip
            // 
            radioButton_Zip.AutoSize = true;
            radioButton_Zip.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Zip.ForeColor = Color.White;
            radioButton_Zip.Location = new Point(251, 245);
            radioButton_Zip.Margin = new Padding(3, 4, 3, 4);
            radioButton_Zip.Name = "radioButton_Zip";
            radioButton_Zip.Size = new Size(71, 33);
            radioButton_Zip.TabIndex = 35;
            radioButton_Zip.TabStop = true;
            radioButton_Zip.Text = "Zip";
            radioButton_Zip.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tar
            // 
            radioButton_Tar.AutoSize = true;
            radioButton_Tar.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Tar.ForeColor = Color.White;
            radioButton_Tar.Location = new Point(251, 306);
            radioButton_Tar.Margin = new Padding(3, 4, 3, 4);
            radioButton_Tar.Name = "radioButton_Tar";
            radioButton_Tar.Size = new Size(73, 33);
            radioButton_Tar.TabIndex = 36;
            radioButton_Tar.TabStop = true;
            radioButton_Tar.Text = "Tar";
            radioButton_Tar.UseVisualStyleBackColor = true;
            // 
            // radioButton_Unzip
            // 
            radioButton_Unzip.AutoSize = true;
            radioButton_Unzip.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Unzip.ForeColor = Color.White;
            radioButton_Unzip.Location = new Point(398, 245);
            radioButton_Unzip.Margin = new Padding(3, 4, 3, 4);
            radioButton_Unzip.Name = "radioButton_Unzip";
            radioButton_Unzip.Size = new Size(102, 33);
            radioButton_Unzip.TabIndex = 37;
            radioButton_Unzip.TabStop = true;
            radioButton_Unzip.Text = "Unzip";
            radioButton_Unzip.UseVisualStyleBackColor = true;
            // 
            // radioButton_Untar
            // 
            radioButton_Untar.AutoSize = true;
            radioButton_Untar.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Untar.ForeColor = Color.White;
            radioButton_Untar.Location = new Point(398, 306);
            radioButton_Untar.Margin = new Padding(3, 4, 3, 4);
            radioButton_Untar.Name = "radioButton_Untar";
            radioButton_Untar.Size = new Size(101, 33);
            radioButton_Untar.TabIndex = 38;
            radioButton_Untar.TabStop = true;
            radioButton_Untar.Text = "Untar";
            radioButton_Untar.UseVisualStyleBackColor = true;
            // 
            // radioButton_Unrar
            // 
            radioButton_Unrar.AutoSize = true;
            radioButton_Unrar.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton_Unrar.ForeColor = Color.White;
            radioButton_Unrar.Location = new Point(398, 184);
            radioButton_Unrar.Margin = new Padding(3, 4, 3, 4);
            radioButton_Unrar.Name = "radioButton_Unrar";
            radioButton_Unrar.Size = new Size(101, 33);
            radioButton_Unrar.TabIndex = 40;
            radioButton_Unrar.TabStop = true;
            radioButton_Unrar.Text = "Unrar";
            radioButton_Unrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 423);
            label2.Name = "label2";
            label2.Size = new Size(351, 23);
            label2.TabIndex = 41;
            label2.Text = "Would you like to delete the original files?";
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(398, 425);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 42;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // Extract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(label2);
            Controls.Add(checkBox_Delete);
            Controls.Add(radioButton_Unrar);
            Controls.Add(radioButton_Untar);
            Controls.Add(radioButton_Unzip);
            Controls.Add(radioButton_Tar);
            Controls.Add(radioButton_Zip);
            Controls.Add(radioButton_Folder);
            Controls.Add(label1);
            Controls.Add(textBox_Path);
            Controls.Add(button_Extract);
            Controls.Add(progressBar_Time);
            Controls.Add(label3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Extract";
            Size = new Size(773, 540);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Button button_Folder;
        private Label label1;
        private TextBox textBox_Path;
        private Button button_Extract;
        private ProgressBar progressBar_Time;
        private Label label3;
        private RadioButton radioButton_Folder;
        private RadioButton radioButton_Zip;
        private RadioButton radioButton_Tar;
        private RadioButton radioButton_Unzip;
        private RadioButton radioButton_Untar;
        private RadioButton radioButton_Unrar;
        private Label label2;
        private CheckBox checkBox_Delete;
    }
}
