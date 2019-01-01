namespace Yomuko.Forms.Main.Control
{
    public partial class BookmarkList : System.Windows.Forms.UserControl
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
            this.picCover = new System.Windows.Forms.PictureBox();
            this.spcList = new System.Windows.Forms.SplitContainer();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.BookmarkListView = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcList)).BeginInit();
            this.spcList.Panel1.SuspendLayout();
            this.spcList.Panel2.SuspendLayout();
            this.spcList.SuspendLayout();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.picCover);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcList);
            this.spcMain.Size = new System.Drawing.Size(1120, 400);
            this.spcMain.SplitterDistance = 366;
            this.spcMain.SplitterWidth = 5;
            this.spcMain.TabIndex = 2;
            this.spcMain.TabStop = false;
            // 
            // picCover
            // 
            this.picCover.BackColor = System.Drawing.Color.Black;
            this.picCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCover.Location = new System.Drawing.Point(0, 0);
            this.picCover.Margin = new System.Windows.Forms.Padding(0);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(366, 400);
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            // 
            // spcList
            // 
            this.spcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcList.Location = new System.Drawing.Point(0, 0);
            this.spcList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spcList.Name = "spcList";
            this.spcList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcList.Panel1
            // 
            this.spcList.Panel1.Controls.Add(this.ReturnButton);
            // 
            // spcList.Panel2
            // 
            this.spcList.Panel2.Controls.Add(this.BookmarkListView);
            this.spcList.Size = new System.Drawing.Size(749, 400);
            this.spcList.SplitterDistance = 31;
            this.spcList.SplitterWidth = 5;
            this.spcList.TabIndex = 1;
            this.spcList.TabStop = false;
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(4, 0);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(100, 30);
            this.ReturnButton.TabIndex = 1;
            this.ReturnButton.TabStop = false;
            this.ReturnButton.Text = "戻る";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // BookmarkListView
            // 
            this.BookmarkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.BookmarkListView.ContextMenuStrip = this.ContextMenuStrip1;
            this.BookmarkListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookmarkListView.FullRowSelect = true;
            this.BookmarkListView.Location = new System.Drawing.Point(0, 0);
            this.BookmarkListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BookmarkListView.MultiSelect = false;
            this.BookmarkListView.Name = "BookmarkListView";
            this.BookmarkListView.Size = new System.Drawing.Size(749, 364);
            this.BookmarkListView.TabIndex = 1;
            this.BookmarkListView.UseCompatibleStateImageBehavior = false;
            this.BookmarkListView.View = System.Windows.Forms.View.Details;
            this.BookmarkListView.SelectedIndexChanged += new System.EventHandler(this.BookmarkListView_SelectedIndexChanged);
            this.BookmarkListView.DoubleClick += new System.EventHandler(this.BookmarkListView_DoubleClick);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "タイトル";
            this.ColumnHeader1.Width = 200;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "ページ";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "著者";
            this.ColumnHeader3.Width = 120;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "登録日";
            this.ColumnHeader4.Width = 93;
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(182, 58);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(181, 26);
            this.DeleteMenuItem.Text = "削除(&D)";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // BookmarkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BookmarkList";
            this.Size = new System.Drawing.Size(1120, 400);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.spcList.Panel1.ResumeLayout(false);
            this.spcList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcList)).EndInit();
            this.spcList.ResumeLayout(false);
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.SplitContainer spcList;
        private System.Windows.Forms.ListView BookmarkListView;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
    }
}