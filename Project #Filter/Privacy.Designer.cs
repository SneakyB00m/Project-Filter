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
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            textBox_Path = new TextBox();
            label2 = new Label();
            checkBox_Delete = new CheckBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
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
            panel4.TabIndex = 33;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(37, 454);
            panel3.TabIndex = 32;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 497);
            panel2.Name = "panel2";
            panel2.Size = new Size(773, 43);
            panel2.TabIndex = 31;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 43);
            panel1.TabIndex = 30;
            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.Add;
            button1.Location = new Point(720, 7);
            button1.Name = "button1";
            button1.Size = new Size(50, 29);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 423);
            label2.Name = "label2";
            label2.Size = new Size(351, 23);
            label2.TabIndex = 37;
            label2.Text = "Would you like to delete the original files?";
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(398, 426);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 38;
            checkBox_Delete.UseVisualStyleBackColor = true;
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
            // 
            // progressBar_Time
            // 
            progressBar_Time.Location = new Point(47, 463);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(674, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 35;
            // 
            // Privacy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(label1);
            Controls.Add(textBox_Path);
            Controls.Add(label2);
            Controls.Add(checkBox_Delete);
            Controls.Add(button_Filter);
            Controls.Add(progressBar_Time);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Privacy";
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
        private Button button1;
        private Label label1;
        private TextBox textBox_Path;
        private Label label2;
        private CheckBox checkBox_Delete;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
    }
}
