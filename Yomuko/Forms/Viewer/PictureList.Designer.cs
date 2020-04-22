namespace Yomuko.Forms.Viewer
{
    public partial class PictureList : System.Windows.Forms.UserControl
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
            if (disposing && components != null)
            {
                archiveBook.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.fileNamePanel1 = new Yomuko.Forms.Property.FileNamePanel();
            this.FileNameLabel = new System.Windows.Forms.LinkLabel();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.PagePictureBox = new System.Windows.Forms.PictureBox();
            this.cmsSubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBookmarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiSetCover = new System.Windows.Forms.ToolStripMenuItem();
            this.smiShowClickGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smiPageNext = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPageBack = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PagePictureBox)).BeginInit();
            this.cmsSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.fileNamePanel1);
            this.spcMain.Panel1.Controls.Add(this.FileNameLabel);
            this.spcMain.Panel1.Controls.Add(this.FileListBox);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.PagePictureBox);
            this.spcMain.Size = new System.Drawing.Size(1069, 718);
            this.spcMain.SplitterDistance = 354;
            this.spcMain.TabIndex = 0;
            this.spcMain.TabStop = false;
            // 
            // fileNamePanel1
            // 
            this.fileNamePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileNamePanel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fileNamePanel1.Location = new System.Drawing.Point(0, 24);
            this.fileNamePanel1.Name = "fileNamePanel1";
            this.fileNamePanel1.Size = new System.Drawing.Size(354, 694);
            this.fileNamePanel1.TabIndex = 2;
            this.fileNamePanel1.Visible = false;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileNameLabel.Location = new System.Drawing.Point(0, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(354, 24);
            this.FileNameLabel.TabIndex = 10;
            this.FileNameLabel.TabStop = true;
            this.FileNameLabel.Text = "ファイル名";
            this.FileNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FileNameLabel_LinkClicked);
            // 
            // FileListBox
            // 
            this.FileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 12;
            this.FileListBox.Location = new System.Drawing.Point(0, 0);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(354, 718);
            this.FileListBox.TabIndex = 9;
            this.FileListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileListBox_MouseClick);
            // 
            // PagePictureBox
            // 
            this.PagePictureBox.BackColor = System.Drawing.Color.Black;
            this.PagePictureBox.ContextMenuStrip = this.cmsSubMenu;
            this.PagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.PagePictureBox.Name = "PagePictureBox";
            this.PagePictureBox.Size = new System.Drawing.Size(711, 718);
            this.PagePictureBox.TabIndex = 1;
            this.PagePictureBox.TabStop = false;
            this.PagePictureBox.SizeChanged += new System.EventHandler(this.PagePictureBox_SizeChanged);
            this.PagePictureBox.DoubleClick += new System.EventHandler(this.PagePictureBox_DoubleClick);
            this.PagePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PagePictureBox_MouseClick);
            this.PagePictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PagePictureBox_MouseWheel);
            this.PagePictureBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PagePictureBox_PreviewKeyDown_1);
            // 
            // cmsSubMenu
            // 
            this.cmsSubMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem,
            this.AddBookmarkMenuItem,
            this.ToolStripSeparator1,
            this.smiSetCover,
            this.smiShowClickGuide,
            this.ToolStripSeparator2,
            this.smiPageNext,
            this.smiPageBack});
            this.cmsSubMenu.Name = "cmsSubMenu";
            this.cmsSubMenu.Size = new System.Drawing.Size(174, 148);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeyDisplayString = "ESC";
            this.ExitMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ExitMenuItem.Text = "読書モード終了";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // AddBookmarkMenuItem
            // 
            this.AddBookmarkMenuItem.Name = "AddBookmarkMenuItem";
            this.AddBookmarkMenuItem.Size = new System.Drawing.Size(173, 22);
            this.AddBookmarkMenuItem.Text = "しおりをはさんで終了";
            this.AddBookmarkMenuItem.Click += new System.EventHandler(this.AddBookmarkMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // smiSetCover
            // 
            this.smiSetCover.Name = "smiSetCover";
            this.smiSetCover.Size = new System.Drawing.Size(173, 22);
            this.smiSetCover.Text = "表紙に設定";
            // 
            // smiShowClickGuide
            // 
            this.smiShowClickGuide.Name = "smiShowClickGuide";
            this.smiShowClickGuide.Size = new System.Drawing.Size(173, 22);
            this.smiShowClickGuide.Text = "クリックガイド表示";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // smiPageNext
            // 
            this.smiPageNext.Name = "smiPageNext";
            this.smiPageNext.Size = new System.Drawing.Size(173, 22);
            this.smiPageNext.Text = "次へ";
            // 
            // smiPageBack
            // 
            this.smiPageBack.Name = "smiPageBack";
            this.smiPageBack.Size = new System.Drawing.Size(173, 22);
            this.smiPageBack.Text = "前へ";
            // 
            // PictureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "PictureList";
            this.Size = new System.Drawing.Size(1069, 718);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PagePictureBox)).EndInit();
            this.cmsSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        System.Windows.Forms.SplitContainer spcMain;
        System.Windows.Forms.ListBox FileListBox;
        System.Windows.Forms.PictureBox PagePictureBox;
        System.Windows.Forms.ContextMenuStrip cmsSubMenu;
        System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        System.Windows.Forms.ToolStripMenuItem smiShowClickGuide;
        System.Windows.Forms.ToolStripMenuItem smiPageNext;
        System.Windows.Forms.ToolStripMenuItem smiPageBack;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        System.Windows.Forms.ToolStripMenuItem AddBookmarkMenuItem;
        System.Windows.Forms.ToolStripMenuItem smiSetCover;
        private System.Windows.Forms.LinkLabel FileNameLabel;
        private Property.FileNamePanel fileNamePanel1;
    }
}