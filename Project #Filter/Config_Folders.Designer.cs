namespace Project__Filter
{
    partial class Config_Folders
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
            button_Remove = new Button();
            label3 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            button_Path = new Button();
            listBox_Folders = new ListBox();
            listBox_Extension = new ListBox();
            button_Wip = new Button();
            button_Add = new Button();
            label1 = new Label();
            textBox_Item = new TextBox();
            label2 = new Label();
            label4 = new Label();
            radioButton_Folder = new RadioButton();
            radioButton_Extension = new RadioButton();
            groupBox = new GroupBox();
            panel1.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // button_Remove
            // 
            button_Remove.BackColor = Color.Teal;
            button_Remove.BackgroundImage = Properties.Resources.icons8_remove_50;
            button_Remove.BackgroundImageLayout = ImageLayout.Zoom;
            button_Remove.FlatAppearance.BorderSize = 0;
            button_Remove.FlatStyle = FlatStyle.Flat;
            button_Remove.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Remove.ForeColor = Color.White;
            button_Remove.Location = new Point(510, 330);
            button_Remove.Margin = new Padding(3, 2, 3, 2);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(128, 39);
            button_Remove.TabIndex = 39;
            button_Remove.UseVisualStyleBackColor = false;
            button_Remove.Click += button_Remove_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(41, 34);
            label3.Name = "label3";
            label3.Size = new Size(156, 30);
            label3.TabIndex = 33;
            label3.Text = "Configuration";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 64, 64);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(644, 32);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(32, 341);
            panel4.TabIndex = 32;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 32);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(32, 341);
            panel3.TabIndex = 31;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 373);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 32);
            panel2.TabIndex = 30;
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
            panel1.TabIndex = 29;
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
            // 
            // listBox_Folders
            // 
            listBox_Folders.BackColor = Color.Gray;
            listBox_Folders.Cursor = Cursors.Hand;
            listBox_Folders.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Folders.ForeColor = Color.White;
            listBox_Folders.FormattingEnabled = true;
            listBox_Folders.ItemHeight = 18;
            listBox_Folders.Location = new Point(37, 112);
            listBox_Folders.Name = "listBox_Folders";
            listBox_Folders.Size = new Size(95, 256);
            listBox_Folders.TabIndex = 40;
            listBox_Folders.SelectedIndexChanged += listBox_Folders_SelectedIndexChanged;
            // 
            // listBox_Extension
            // 
            listBox_Extension.BackColor = Color.Gray;
            listBox_Extension.Cursor = Cursors.Hand;
            listBox_Extension.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Extension.ForeColor = Color.White;
            listBox_Extension.FormattingEnabled = true;
            listBox_Extension.ItemHeight = 18;
            listBox_Extension.Location = new Point(138, 112);
            listBox_Extension.Name = "listBox_Extension";
            listBox_Extension.Size = new Size(90, 256);
            listBox_Extension.TabIndex = 41;
            // 
            // button_Wip
            // 
            button_Wip.BackColor = Color.Teal;
            button_Wip.FlatAppearance.BorderSize = 0;
            button_Wip.FlatStyle = FlatStyle.Flat;
            button_Wip.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Wip.ForeColor = Color.White;
            button_Wip.Location = new Point(379, 330);
            button_Wip.Margin = new Padding(3, 2, 3, 2);
            button_Wip.Name = "button_Wip";
            button_Wip.Size = new Size(128, 39);
            button_Wip.TabIndex = 42;
            button_Wip.Text = "Video";
            button_Wip.UseVisualStyleBackColor = false;
            // 
            // button_Add
            // 
            button_Add.BackColor = Color.Teal;
            button_Add.BackgroundImage = Properties.Resources.icons8_add_50;
            button_Add.BackgroundImageLayout = ImageLayout.Zoom;
            button_Add.FlatAppearance.BorderSize = 0;
            button_Add.FlatStyle = FlatStyle.Flat;
            button_Add.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Add.ForeColor = Color.White;
            button_Add.Location = new Point(248, 330);
            button_Add.Margin = new Padding(3, 2, 3, 2);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(128, 39);
            button_Add.TabIndex = 43;
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(109, 30);
            label1.TabIndex = 44;
            label1.Text = "Extension";
            // 
            // textBox_Item
            // 
            textBox_Item.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Item.BorderStyle = BorderStyle.FixedSingle;
            textBox_Item.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_Item.ForeColor = Color.White;
            textBox_Item.Location = new Point(131, 35);
            textBox_Item.Name = "textBox_Item";
            textBox_Item.Size = new Size(253, 33);
            textBox_Item.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 89);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 46;
            label2.Text = "Folder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(138, 89);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 47;
            label4.Text = "Extension";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(72, 99);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(71, 24);
            radioButton_Folder.TabIndex = 48;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_Extension
            // 
            radioButton_Extension.AutoSize = true;
            radioButton_Extension.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Extension.ForeColor = Color.White;
            radioButton_Extension.Location = new Point(221, 99);
            radioButton_Extension.Name = "radioButton_Extension";
            radioButton_Extension.Size = new Size(95, 24);
            radioButton_Extension.TabIndex = 49;
            radioButton_Extension.TabStop = true;
            radioButton_Extension.Text = "Extension";
            radioButton_Extension.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(radioButton_Folder);
            groupBox.Controls.Add(radioButton_Extension);
            groupBox.Controls.Add(textBox_Item);
            groupBox.Controls.Add(label1);
            groupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox.ForeColor = Color.White;
            groupBox.Location = new Point(248, 112);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(390, 181);
            groupBox.TabIndex = 50;
            groupBox.TabStop = false;
            groupBox.Text = "Type";
            // 
            // Config
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(groupBox);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(button_Add);
            Controls.Add(button_Wip);
            Controls.Add(listBox_Extension);
            Controls.Add(listBox_Folders);
            Controls.Add(button_Remove);
            Controls.Add(label3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Config";
            Size = new Size(676, 405);
            Load += Config_Load;
            panel1.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_Remove;
        private Label label3;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Button button_Path;
        private ListBox listBox_Folders;
        private ListBox listBox_Extension;
        private Button button_Wip;
        private Button button_Add;
        private Label label1;
        private TextBox textBox_Item;
        private Label label2;
        private Label label4;
        private RadioButton radioButton_Folder;
        private RadioButton radioButton_Extension;
        private GroupBox groupBox;
    }
}
