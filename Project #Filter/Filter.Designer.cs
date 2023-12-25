namespace Project__Filter
{
    partial class Filter
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
            panel1 = new Panel();
            button_Path = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            checkBox_AtoZ = new CheckBox();
            checkBox_Extension = new CheckBox();
            checkBox_Size = new CheckBox();
            checkBox_Include = new CheckBox();
            checkBox_Duration = new CheckBox();
            checkBox_Resolution = new CheckBox();
            label1 = new Label();
            textBox_Path = new TextBox();
            checkBox_Delete = new CheckBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Controls.Add(button_Path);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(676, 32);
            panel1.TabIndex = 4;
            // 
            // button_Path
            // 
            button_Path.BackColor = Color.Teal;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Image = Properties.Resources.Add;
            button_Path.Location = new Point(630, 5);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(44, 22);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 373);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 32);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 32);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(32, 341);
            panel3.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(64, 64, 64);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(644, 32);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(32, 341);
            panel4.TabIndex = 7;
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
            label3.TabIndex = 11;
            label3.Text = "Options";
            // 
            // checkBox_AtoZ
            // 
            checkBox_AtoZ.AutoSize = true;
            checkBox_AtoZ.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_AtoZ.ForeColor = Color.White;
            checkBox_AtoZ.Location = new Point(195, 146);
            checkBox_AtoZ.Margin = new Padding(3, 2, 3, 2);
            checkBox_AtoZ.Name = "checkBox_AtoZ";
            checkBox_AtoZ.Size = new Size(207, 27);
            checkBox_AtoZ.TabIndex = 12;
            checkBox_AtoZ.Text = "Alphabetical Order";
            checkBox_AtoZ.UseVisualStyleBackColor = true;
            // 
            // checkBox_Extension
            // 
            checkBox_Extension.AutoSize = true;
            checkBox_Extension.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Extension.ForeColor = Color.White;
            checkBox_Extension.Location = new Point(195, 175);
            checkBox_Extension.Margin = new Padding(3, 2, 3, 2);
            checkBox_Extension.Name = "checkBox_Extension";
            checkBox_Extension.Size = new Size(163, 27);
            checkBox_Extension.TabIndex = 13;
            checkBox_Extension.Text = "File Extension";
            checkBox_Extension.UseVisualStyleBackColor = true;
            // 
            // checkBox_Size
            // 
            checkBox_Size.AutoSize = true;
            checkBox_Size.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Size.ForeColor = Color.White;
            checkBox_Size.Location = new Point(195, 204);
            checkBox_Size.Margin = new Padding(3, 2, 3, 2);
            checkBox_Size.Name = "checkBox_Size";
            checkBox_Size.Size = new Size(108, 27);
            checkBox_Size.TabIndex = 14;
            checkBox_Size.Text = "File Size";
            checkBox_Size.UseVisualStyleBackColor = true;
            // 
            // checkBox_Include
            // 
            checkBox_Include.AutoSize = true;
            checkBox_Include.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Include.ForeColor = Color.White;
            checkBox_Include.Location = new Point(61, 146);
            checkBox_Include.Margin = new Padding(3, 2, 3, 2);
            checkBox_Include.Name = "checkBox_Include";
            checkBox_Include.Size = new Size(111, 27);
            checkBox_Include.TabIndex = 15;
            checkBox_Include.Text = "Includes";
            checkBox_Include.UseVisualStyleBackColor = true;
            // 
            // checkBox_Duration
            // 
            checkBox_Duration.AutoSize = true;
            checkBox_Duration.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Duration.ForeColor = Color.White;
            checkBox_Duration.Location = new Point(408, 175);
            checkBox_Duration.Margin = new Padding(3, 2, 3, 2);
            checkBox_Duration.Name = "checkBox_Duration";
            checkBox_Duration.Size = new Size(112, 27);
            checkBox_Duration.TabIndex = 20;
            checkBox_Duration.Text = "Duration";
            checkBox_Duration.UseVisualStyleBackColor = true;
            // 
            // checkBox_Resolution
            // 
            checkBox_Resolution.AutoSize = true;
            checkBox_Resolution.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Resolution.ForeColor = Color.White;
            checkBox_Resolution.Location = new Point(408, 146);
            checkBox_Resolution.Margin = new Padding(3, 2, 3, 2);
            checkBox_Resolution.Name = "checkBox_Resolution";
            checkBox_Resolution.Size = new Size(208, 27);
            checkBox_Resolution.TabIndex = 19;
            checkBox_Resolution.Text = "Display Resolution";
            checkBox_Resolution.UseVisualStyleBackColor = true;
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
            label1.TabIndex = 23;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.None;
            textBox_Path.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(115, 51);
            textBox_Path.Margin = new Padding(3, 2, 3, 2);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(523, 20);
            textBox_Path.TabIndex = 25;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(348, 320);
            checkBox_Delete.Margin = new Padding(3, 2, 3, 2);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(15, 14);
            checkBox_Delete.TabIndex = 27;
            checkBox_Delete.UseVisualStyleBackColor = true;
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
            button_Filter.TabIndex = 28;
            button_Filter.Text = "Filter";
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
            progressBar_Time.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 317);
            label2.Name = "label2";
            label2.Size = new Size(292, 19);
            label2.TabIndex = 26;
            label2.Text = "Would you like to delete the original files?";
            // 
            // Filter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(label1);
            Controls.Add(textBox_Path);
            Controls.Add(label2);
            Controls.Add(checkBox_Delete);
            Controls.Add(button_Filter);
            Controls.Add(progressBar_Time);
            Controls.Add(checkBox_Duration);
            Controls.Add(checkBox_Resolution);
            Controls.Add(checkBox_Include);
            Controls.Add(checkBox_Size);
            Controls.Add(checkBox_Extension);
            Controls.Add(checkBox_AtoZ);
            Controls.Add(label3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Filter";
            Size = new Size(676, 405);
            Load += Filter_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button button_Path;
        private Label label3;
        private CheckBox checkBox_AtoZ;
        private CheckBox checkBox_Extension;
        private CheckBox checkBox_Size;
        private CheckBox checkBox_Include;
        private CheckBox checkBox_Duration;
        private CheckBox checkBox_Resolution;
        private Label label1;
        private TextBox textBox_Path;
        private CheckBox checkBox_Delete;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Label label2;
    }
}
