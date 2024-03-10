namespace Project__Filter
{
    partial class Downloader
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Top = new Panel();
            panel_Bottom = new Panel();
            panel_Right = new Panel();
            panel_Path = new Panel();
            button1 = new Button();
            textBox_url = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            panel_Path.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(699, 32);
            panel_Top.TabIndex = 0;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 373);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 2;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 341);
            panel_Right.TabIndex = 3;
            // 
            // panel_Path
            // 
            panel_Path.Controls.Add(button1);
            panel_Path.Controls.Add(textBox_url);
            panel_Path.Controls.Add(label1);
            panel_Path.Dock = DockStyle.Top;
            panel_Path.Location = new Point(0, 32);
            panel_Path.Margin = new Padding(3, 2, 3, 2);
            panel_Path.Name = "panel_Path";
            panel_Path.Size = new Size(667, 72);
            panel_Path.TabIndex = 41;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(594, 6);
            button1.Name = "button1";
            button1.Size = new Size(67, 33);
            button1.TabIndex = 27;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_url
            // 
            textBox_url.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_url.BackColor = Color.FromArgb(64, 64, 64);
            textBox_url.BorderStyle = BorderStyle.FixedSingle;
            textBox_url.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_url.ForeColor = Color.White;
            textBox_url.Location = new Point(75, 6);
            textBox_url.Margin = new Padding(3, 2, 3, 2);
            textBox_url.Name = "textBox_url";
            textBox_url.Size = new Size(513, 33);
            textBox_url.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(66, 32);
            label1.TabIndex = 17;
            label1.Text = "URL:";
            // 
            // panel1
            // 
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 329);
            panel1.Name = "panel1";
            panel1.Size = new Size(667, 44);
            panel1.TabIndex = 42;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 15);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(639, 23);
            progressBar1.TabIndex = 0;
            // 
            // Downloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel1);
            Controls.Add(panel_Path);
            Controls.Add(panel_Right);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "Downloader";
            Size = new Size(699, 405);
            panel_Path.ResumeLayout(false);
            panel_Path.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Top;
        private Panel panel_Bottom;
        private Panel panel_Right;
        private Panel panel_Path;
        private TextBox textBox_url;
        private Label label1;
        private Button button1;
        private Panel panel1;
        private ProgressBar progressBar1;
    }
}
