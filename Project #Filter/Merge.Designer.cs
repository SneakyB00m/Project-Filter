﻿namespace Project__Filter
{
    partial class Merge
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
            panel_Footer = new Panel();
            label2 = new Label();
            checkBox_Delete = new CheckBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            panel_Header = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            label_Warning = new Label();
            panel_Right = new Panel();
            panel_Bottom = new Panel();
            panel_Top = new Panel();
            button_Path = new Button();
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            label_Count = new Label();
            label4 = new Label();
            listBox_File = new ListBox();
            panel_Footer.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Top.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(label2);
            panel_Footer.Controls.Add(checkBox_Delete);
            panel_Footer.Controls.Add(button_Filter);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 309);
            panel_Footer.Margin = new Padding(3, 2, 3, 2);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(667, 64);
            panel_Footer.TabIndex = 42;
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
            label2.TabIndex = 26;
            label2.Text = "Would you like to delete unused directories?";
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
            checkBox_Delete.TabIndex = 27;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.Enabled = false;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(429, 6);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(233, 26);
            button_Filter.TabIndex = 28;
            button_Filter.Text = "Filter";
            button_Filter.UseVisualStyleBackColor = false;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 38);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(659, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 24;
            // 
            // panel_Header
            // 
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 32);
            panel_Header.Margin = new Padding(3, 2, 3, 2);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(667, 72);
            panel_Header.TabIndex = 41;
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
            label1.TabIndex = 23;
            label1.Text = "Path:";
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
            textBox_Path.TabIndex = 25;
            // 
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(236, 43);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 21);
            label_Warning.TabIndex = 29;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 341);
            panel_Right.TabIndex = 40;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 373);
            panel_Bottom.Margin = new Padding(3, 2, 3, 2);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 39;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Controls.Add(button_Path);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(3, 2, 3, 2);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(699, 32);
            panel_Top.TabIndex = 38;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.icons8_add_file_50;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(635, 4);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(25, 25);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(667, 205);
            panel1.TabIndex = 50;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 2);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 40;
            label5.Text = "Options";
            // 
            // panel2
            // 
            panel2.Controls.Add(label_Count);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(listBox_File);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(420, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(247, 205);
            panel2.TabIndex = 0;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Count.ForeColor = Color.White;
            label_Count.Location = new Point(129, 5);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(67, 21);
            label_Count.TabIndex = 3;
            label_Count.Text = "File List";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 5);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 2;
            label4.Text = "File List           #";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.ItemHeight = 15;
            listBox_File.Location = new Point(9, 37);
            listBox_File.Name = "listBox_File";
            listBox_File.Size = new Size(233, 169);
            listBox_File.TabIndex = 1;
            // 
            // Merge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel1);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Header);
            Controls.Add(panel_Right);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "Merge";
            Size = new Size(699, 405);
            Load += Merge_Load;
            panel_Footer.ResumeLayout(false);
            panel_Footer.PerformLayout();
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Top.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_Footer;
        private Label label2;
        private CheckBox checkBox_Delete;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Panel panel_Header;
        private Label label1;
        private TextBox textBox_Path;
        private Label label_Warning;
        private Panel panel_Right;
        private Panel panel_Bottom;
        private Panel panel_Top;
        private Button button_Path;
        private Panel panel2;
        private Label label_Count;
        private Label label4;
        private ListBox listBox_File;
        private Panel panel1;
        private Label label5;
    }
}
