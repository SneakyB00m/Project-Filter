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
            panel_Top = new Panel();
            button_Path = new Button();
            panel_Bottom = new Panel();
            panel_Right = new Panel();
            checkBox_AtoZ = new CheckBox();
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
            label_Warning = new Label();
            panel_Header = new Panel();
            label3 = new Label();
            panel_Footer = new Panel();
            panel_Options = new Panel();
            panel_Top.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Footer.SuspendLayout();
            panel_Options.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Controls.Add(button_Path);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(799, 43);
            panel_Top.TabIndex = 4;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.icons8_add_file_50;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(726, 6);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(30, 30);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 497);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(799, 43);
            panel_Bottom.TabIndex = 5;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(762, 43);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(37, 454);
            panel_Right.TabIndex = 7;
            // 
            // checkBox_AtoZ
            // 
            checkBox_AtoZ.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            checkBox_AtoZ.AutoSize = true;
            checkBox_AtoZ.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_AtoZ.ForeColor = Color.White;
            checkBox_AtoZ.Location = new Point(448, 167);
            checkBox_AtoZ.Name = "checkBox_AtoZ";
            checkBox_AtoZ.Size = new Size(252, 32);
            checkBox_AtoZ.TabIndex = 12;
            checkBox_AtoZ.Text = "Alphabetical Order";
            checkBox_AtoZ.UseVisualStyleBackColor = true;
            checkBox_AtoZ.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox_Size
            // 
            checkBox_Size.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Size.AutoSize = true;
            checkBox_Size.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Size.ForeColor = Color.White;
            checkBox_Size.Location = new Point(272, 167);
            checkBox_Size.Name = "checkBox_Size";
            checkBox_Size.Size = new Size(130, 32);
            checkBox_Size.TabIndex = 14;
            checkBox_Size.Text = "File Size";
            checkBox_Size.UseVisualStyleBackColor = true;
            checkBox_Size.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox_Include
            // 
            checkBox_Include.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Include.AutoSize = true;
            checkBox_Include.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Include.ForeColor = Color.White;
            checkBox_Include.Location = new Point(92, 167);
            checkBox_Include.Name = "checkBox_Include";
            checkBox_Include.Size = new Size(134, 32);
            checkBox_Include.TabIndex = 15;
            checkBox_Include.Text = "Includes";
            checkBox_Include.UseVisualStyleBackColor = true;
            checkBox_Include.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox_Duration
            // 
            checkBox_Duration.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Duration.AutoSize = true;
            checkBox_Duration.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Duration.ForeColor = Color.White;
            checkBox_Duration.Location = new Point(448, 77);
            checkBox_Duration.Name = "checkBox_Duration";
            checkBox_Duration.Size = new Size(136, 32);
            checkBox_Duration.TabIndex = 20;
            checkBox_Duration.Text = "Duration";
            checkBox_Duration.UseVisualStyleBackColor = true;
            checkBox_Duration.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox_Resolution
            // 
            checkBox_Resolution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Resolution.AutoSize = true;
            checkBox_Resolution.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            checkBox_Resolution.ForeColor = Color.White;
            checkBox_Resolution.Location = new Point(92, 77);
            checkBox_Resolution.Name = "checkBox_Resolution";
            checkBox_Resolution.Size = new Size(250, 32);
            checkBox_Resolution.TabIndex = 19;
            checkBox_Resolution.Text = "Display Resolution";
            checkBox_Resolution.UseVisualStyleBackColor = true;
            checkBox_Resolution.CheckedChanged += CheckBox_CheckedChanged;
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
            textBox_Path.Location = new Point(98, 5);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(654, 39);
            textBox_Path.TabIndex = 25;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(382, 17);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 27;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(490, 8);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(266, 35);
            button_Filter.TabIndex = 28;
            button_Filter.Text = "Filter";
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 51);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(753, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 14);
            label2.Name = "label2";
            label2.Size = new Size(367, 23);
            label2.TabIndex = 26;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(3, 57);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 28);
            label_Warning.TabIndex = 29;
            // 
            // panel_Header
            // 
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 43);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(762, 96);
            panel_Header.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 18);
            label3.Name = "label3";
            label3.Size = new Size(130, 41);
            label3.TabIndex = 26;
            label3.Text = "Options";
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(label2);
            panel_Footer.Controls.Add(checkBox_Delete);
            panel_Footer.Controls.Add(button_Filter);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 412);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(762, 85);
            panel_Footer.TabIndex = 32;
            // 
            // panel_Options
            // 
            panel_Options.Controls.Add(label3);
            panel_Options.Controls.Add(checkBox_Size);
            panel_Options.Controls.Add(checkBox_Include);
            panel_Options.Controls.Add(checkBox_AtoZ);
            panel_Options.Controls.Add(checkBox_Resolution);
            panel_Options.Controls.Add(checkBox_Duration);
            panel_Options.Location = new Point(0, 145);
            panel_Options.Name = "panel_Options";
            panel_Options.Size = new Size(756, 261);
            panel_Options.TabIndex = 33;
            // 
            // Filter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Options);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Header);
            Controls.Add(panel_Right);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "Filter";
            Size = new Size(799, 540);
            Load += Filter_Load;
            panel_Top.ResumeLayout(false);
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Footer.ResumeLayout(false);
            panel_Footer.PerformLayout();
            panel_Options.ResumeLayout(false);
            panel_Options.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_Top;
        private Panel panel_Bottom;
        private Panel panel_Header;
        private Panel panel_Right;
        private Button button_Path;
        private CheckBox checkBox_AtoZ;
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
        private Label label_Warning;
        private Panel panel_Footer;
        private Label label3;
        private Panel panel_Options;
    }
}
