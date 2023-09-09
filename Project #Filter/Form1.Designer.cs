namespace Project__Filter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            filterToolStripMenuItem = new ToolStripMenuItem();
            nameToolStripMenuItem = new ToolStripMenuItem();
            typeToolStripMenuItem = new ToolStripMenuItem();
            sizeToolStripMenuItem = new ToolStripMenuItem();
            videoToolStripMenuItem = new ToolStripMenuItem();
            typeToolStripMenuItem1 = new ToolStripMenuItem();
            lenghtToolStripMenuItem = new ToolStripMenuItem();
            customToolStripMenuItem = new ToolStripMenuItem();
            containsToolStripMenuItem = new ToolStripMenuItem();
            othersToolStripMenuItem = new ToolStripMenuItem();
            iMGPDFToolStripMenuItem = new ToolStripMenuItem();
            toPDFToolStripMenuItem = new ToolStripMenuItem();
            toICOToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem1 = new ToolStripMenuItem();
            videoToolStripMenuItem2 = new ToolStripMenuItem();
            youTubeToolStripMenuItem = new ToolStripMenuItem();
            filesToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            saveFileDialog1 = new SaveFileDialog();
            mP4ToolStripMenuItem = new ToolStripMenuItem();
            toMP3ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { filterToolStripMenuItem, othersToolStripMenuItem, downloadToolStripMenuItem1 });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nameToolStripMenuItem, typeToolStripMenuItem, sizeToolStripMenuItem, videoToolStripMenuItem, customToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            resources.ApplyResources(filterToolStripMenuItem, "filterToolStripMenuItem");
            filterToolStripMenuItem.MouseHover += filterToolStripMenuItem_MouseHover;
            // 
            // nameToolStripMenuItem
            // 
            nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            resources.ApplyResources(nameToolStripMenuItem, "nameToolStripMenuItem");
            nameToolStripMenuItem.Click += nameToolStripMenuItem_Click;
            // 
            // typeToolStripMenuItem
            // 
            typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            resources.ApplyResources(typeToolStripMenuItem, "typeToolStripMenuItem");
            typeToolStripMenuItem.Click += typeToolStripMenuItem_Click;
            // 
            // sizeToolStripMenuItem
            // 
            sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            resources.ApplyResources(sizeToolStripMenuItem, "sizeToolStripMenuItem");
            sizeToolStripMenuItem.Click += sizeToolStripMenuItem_Click;
            // 
            // videoToolStripMenuItem
            // 
            videoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { typeToolStripMenuItem1, lenghtToolStripMenuItem });
            videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            resources.ApplyResources(videoToolStripMenuItem, "videoToolStripMenuItem");
            // 
            // typeToolStripMenuItem1
            // 
            typeToolStripMenuItem1.Name = "typeToolStripMenuItem1";
            resources.ApplyResources(typeToolStripMenuItem1, "typeToolStripMenuItem1");
            typeToolStripMenuItem1.Click += typeToolStripMenuItem1_Click;
            // 
            // lenghtToolStripMenuItem
            // 
            lenghtToolStripMenuItem.Name = "lenghtToolStripMenuItem";
            resources.ApplyResources(lenghtToolStripMenuItem, "lenghtToolStripMenuItem");
            lenghtToolStripMenuItem.Click += lenghtToolStripMenuItem_Click;
            // 
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { containsToolStripMenuItem });
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            resources.ApplyResources(customToolStripMenuItem, "customToolStripMenuItem");
            // 
            // containsToolStripMenuItem
            // 
            containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            resources.ApplyResources(containsToolStripMenuItem, "containsToolStripMenuItem");
            // 
            // othersToolStripMenuItem
            // 
            othersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iMGPDFToolStripMenuItem, mP4ToolStripMenuItem });
            othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            resources.ApplyResources(othersToolStripMenuItem, "othersToolStripMenuItem");
            // 
            // iMGPDFToolStripMenuItem
            // 
            iMGPDFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toPDFToolStripMenuItem, toICOToolStripMenuItem });
            iMGPDFToolStripMenuItem.Name = "iMGPDFToolStripMenuItem";
            resources.ApplyResources(iMGPDFToolStripMenuItem, "iMGPDFToolStripMenuItem");
            // 
            // toPDFToolStripMenuItem
            // 
            toPDFToolStripMenuItem.Name = "toPDFToolStripMenuItem";
            resources.ApplyResources(toPDFToolStripMenuItem, "toPDFToolStripMenuItem");
            toPDFToolStripMenuItem.Click += toPDFToolStripMenuItem_Click;
            // 
            // toICOToolStripMenuItem
            // 
            toICOToolStripMenuItem.Name = "toICOToolStripMenuItem";
            resources.ApplyResources(toICOToolStripMenuItem, "toICOToolStripMenuItem");
            toICOToolStripMenuItem.Click += toICOToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem1
            // 
            downloadToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { videoToolStripMenuItem2, filesToolStripMenuItem });
            downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            resources.ApplyResources(downloadToolStripMenuItem1, "downloadToolStripMenuItem1");
            // 
            // videoToolStripMenuItem2
            // 
            videoToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { youTubeToolStripMenuItem });
            videoToolStripMenuItem2.Name = "videoToolStripMenuItem2";
            resources.ApplyResources(videoToolStripMenuItem2, "videoToolStripMenuItem2");
            // 
            // youTubeToolStripMenuItem
            // 
            youTubeToolStripMenuItem.Name = "youTubeToolStripMenuItem";
            resources.ApplyResources(youTubeToolStripMenuItem, "youTubeToolStripMenuItem");
            // 
            // filesToolStripMenuItem
            // 
            filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            resources.ApplyResources(filesToolStripMenuItem, "filesToolStripMenuItem");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.Martin_Berube_Animal_Sheep_256;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // mP4ToolStripMenuItem
            // 
            mP4ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toMP3ToolStripMenuItem });
            mP4ToolStripMenuItem.Name = "mP4ToolStripMenuItem";
            resources.ApplyResources(mP4ToolStripMenuItem, "mP4ToolStripMenuItem");
            // 
            // toMP3ToolStripMenuItem
            // 
            toMP3ToolStripMenuItem.Name = "toMP3ToolStripMenuItem";
            resources.ApplyResources(toMP3ToolStripMenuItem, "toMP3ToolStripMenuItem");
            toMP3ToolStripMenuItem.Click += toMP3ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem typeToolStripMenuItem;
        private ToolStripMenuItem videoToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem1;
        private ToolStripMenuItem typeToolStripMenuItem1;
        private ToolStripMenuItem lenghtToolStripMenuItem;
        private ToolStripMenuItem othersToolStripMenuItem;
        private ToolStripMenuItem iMGPDFToolStripMenuItem;
        private ToolStripMenuItem toPDFToolStripMenuItem;
        private ToolStripMenuItem toICOToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem1;
        private ToolStripMenuItem videoToolStripMenuItem2;
        private ToolStripMenuItem youTubeToolStripMenuItem;
        private ToolStripMenuItem filesToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem containsToolStripMenuItem;
        private ToolStripMenuItem mP4ToolStripMenuItem;
        private ToolStripMenuItem toMP3ToolStripMenuItem;
    }
}