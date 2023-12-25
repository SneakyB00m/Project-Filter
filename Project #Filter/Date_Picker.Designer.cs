namespace Project__Filter
{
    partial class DatePicker
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bunifuDragControl_Frame = new Bunifu.Framework.UI.BunifuDragControl(components);
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            panel_Top = new Panel();
            button_Close = new Button();
            button_Check = new Button();
            panel2 = new Panel();
            bunifuDragControl_Banner = new Bunifu.Framework.UI.BunifuDragControl(components);
            panel_Top.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // bunifuDragControl_Frame
            // 
            bunifuDragControl_Frame.Fixed = true;
            bunifuDragControl_Frame.Horizontal = true;
            bunifuDragControl_Frame.TargetControl = this;
            bunifuDragControl_Frame.Vertical = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 53);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(437, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 119);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(437, 23);
            dateTimePicker2.TabIndex = 1;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Controls.Add(button_Close);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(461, 35);
            panel_Top.TabIndex = 2;
            // 
            // button_Close
            // 
            button_Close.Anchor = AnchorStyles.Right;
            button_Close.FlatAppearance.BorderSize = 0;
            button_Close.FlatStyle = FlatStyle.Flat;
            button_Close.Image = Properties.Resources.Close;
            button_Close.Location = new Point(424, 5);
            button_Close.Margin = new Padding(3, 2, 3, 2);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(25, 25);
            button_Close.TabIndex = 5;
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // button_Check
            // 
            button_Check.Anchor = AnchorStyles.Right;
            button_Check.FlatAppearance.BorderSize = 0;
            button_Check.FlatStyle = FlatStyle.Flat;
            button_Check.Image = Properties.Resources.Check;
            button_Check.Location = new Point(424, 4);
            button_Check.Margin = new Padding(3, 2, 3, 2);
            button_Check.Name = "button_Check";
            button_Check.Size = new Size(25, 25);
            button_Check.TabIndex = 4;
            button_Check.UseVisualStyleBackColor = true;
            button_Check.Click += button_Check_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Controls.Add(button_Check);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 190);
            panel2.Name = "panel2";
            panel2.Size = new Size(461, 35);
            panel2.TabIndex = 3;
            // 
            // bunifuDragControl_Banner
            // 
            bunifuDragControl_Banner.Fixed = true;
            bunifuDragControl_Banner.Horizontal = true;
            bunifuDragControl_Banner.TargetControl = panel_Top;
            bunifuDragControl_Banner.Vertical = true;
            // 
            // DatePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(461, 225);
            Controls.Add(panel2);
            Controls.Add(panel_Top);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DatePicker";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel_Top.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl_Frame;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Panel panel2;
        private Panel panel_Top;
        private Button button_Check;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl_Banner;
        private Button button_Close;
    }
}