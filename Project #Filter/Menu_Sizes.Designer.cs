namespace Project__Filter
{
    partial class Menu_Sizes
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
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            groupBox = new GroupBox();
            groupBox2 = new GroupBox();
            radioButton_Extension = new RadioButton();
            radioButton_Folder = new RadioButton();
            button_Remove = new Button();
            button_Add = new Button();
            textBox_Item = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            listBox_Folders = new ListBox();
            listBox_Extension = new ListBox();
            groupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 338);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 56;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 338);
            panel2.TabIndex = 55;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 32);
            panel1.TabIndex = 54;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(groupBox2);
            groupBox.Controls.Add(button_Remove);
            groupBox.Controls.Add(button_Add);
            groupBox.Controls.Add(textBox_Item);
            groupBox.Controls.Add(label1);
            groupBox.Dock = DockStyle.Fill;
            groupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox.ForeColor = Color.White;
            groupBox.Location = new Point(267, 32);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(312, 306);
            groupBox.TabIndex = 57;
            groupBox.TabStop = false;
            groupBox.Text = "Configuration";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(radioButton_Extension);
            groupBox2.Controls.Add(radioButton_Folder);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(7, 116);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(299, 94);
            groupBox2.TabIndex = 50;
            groupBox2.TabStop = false;
            groupBox2.Text = "Merge";
            // 
            // radioButton_Extension
            // 
            radioButton_Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton_Extension.AutoSize = true;
            radioButton_Extension.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Extension.ForeColor = Color.White;
            radioButton_Extension.Location = new Point(240, 42);
            radioButton_Extension.Name = "radioButton_Extension";
            radioButton_Extension.Size = new Size(54, 24);
            radioButton_Extension.TabIndex = 49;
            radioButton_Extension.TabStop = true;
            radioButton_Extension.Text = "Size";
            radioButton_Extension.UseVisualStyleBackColor = true;
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(19, 42);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(71, 24);
            radioButton_Folder.TabIndex = 48;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Remove.BackColor = Color.Teal;
            button_Remove.BackgroundImage = Properties.Resources.icons8_remove_50;
            button_Remove.BackgroundImageLayout = ImageLayout.Zoom;
            button_Remove.FlatAppearance.BorderSize = 0;
            button_Remove.FlatStyle = FlatStyle.Flat;
            button_Remove.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Remove.ForeColor = Color.White;
            button_Remove.Location = new Point(178, 262);
            button_Remove.Margin = new Padding(3, 2, 3, 2);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(128, 39);
            button_Remove.TabIndex = 39;
            button_Remove.UseVisualStyleBackColor = false;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_Add
            // 
            button_Add.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Add.BackColor = Color.Teal;
            button_Add.BackgroundImage = Properties.Resources.icons8_add_50;
            button_Add.BackgroundImageLayout = ImageLayout.Zoom;
            button_Add.FlatAppearance.BorderSize = 0;
            button_Add.FlatStyle = FlatStyle.Flat;
            button_Add.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Add.ForeColor = Color.White;
            button_Add.Location = new Point(5, 262);
            button_Add.Margin = new Padding(3, 2, 3, 2);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(128, 39);
            button_Add.TabIndex = 43;
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click;
            // 
            // textBox_Item
            // 
            textBox_Item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Item.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Item.BorderStyle = BorderStyle.FixedSingle;
            textBox_Item.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_Item.ForeColor = Color.White;
            textBox_Item.Location = new Point(7, 67);
            textBox_Item.Name = "textBox_Item";
            textBox_Item.Size = new Size(300, 33);
            textBox_Item.TabIndex = 45;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox_Folders);
            groupBox1.Controls.Add(listBox_Extension);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 32);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(267, 306);
            groupBox1.TabIndex = 58;
            groupBox1.TabStop = false;
            groupBox1.Text = "Folder / Size";
            // 
            // listBox_Folders
            // 
            listBox_Folders.BackColor = Color.Gray;
            listBox_Folders.BorderStyle = BorderStyle.None;
            listBox_Folders.Cursor = Cursors.Hand;
            listBox_Folders.Dock = DockStyle.Left;
            listBox_Folders.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Folders.ForeColor = Color.White;
            listBox_Folders.FormattingEnabled = true;
            listBox_Folders.ItemHeight = 18;
            listBox_Folders.Location = new Point(3, 24);
            listBox_Folders.Name = "listBox_Folders";
            listBox_Folders.Size = new Size(143, 280);
            listBox_Folders.TabIndex = 40;
            listBox_Folders.SelectedIndexChanged += listBox_Folders_SelectedIndexChanged;
            // 
            // listBox_Extension
            // 
            listBox_Extension.BackColor = Color.Gray;
            listBox_Extension.BorderStyle = BorderStyle.None;
            listBox_Extension.Cursor = Cursors.Hand;
            listBox_Extension.Dock = DockStyle.Right;
            listBox_Extension.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Extension.ForeColor = Color.White;
            listBox_Extension.FormattingEnabled = true;
            listBox_Extension.ItemHeight = 18;
            listBox_Extension.Location = new Point(154, 24);
            listBox_Extension.Name = "listBox_Extension";
            listBox_Extension.Size = new Size(110, 280);
            listBox_Extension.TabIndex = 41;
            // 
            // Config_Sizes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(groupBox);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Config_Sizes";
            Size = new Size(611, 370);
            Load += Config_Sizes_Load;
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private GroupBox groupBox;
        private GroupBox groupBox2;
        private RadioButton radioButton_Extension;
        private RadioButton radioButton_Folder;
        private Button button_Remove;
        private Button button_Add;
        private TextBox textBox_Item;
        private Label label1;
        private GroupBox groupBox1;
        private ListBox listBox_Folders;
        private ListBox listBox_Extension;
    }
}
