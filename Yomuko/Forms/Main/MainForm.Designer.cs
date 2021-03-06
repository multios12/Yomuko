﻿using Yomuko.Book;

namespace Yomuko.Forms.Main
{

    public partial class MainForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmsColumnHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sslInfomation = new System.Windows.Forms.ToolStripStatusLabel();
            this.sspMain = new System.Windows.Forms.StatusStrip();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.spcList = new System.Windows.Forms.SplitContainer();
            this.GroupTypeComboBox = new System.Windows.Forms.ComboBox();
            this.spcCover = new System.Windows.Forms.SplitContainer();
            this.GroupListBox = new System.Windows.Forms.ListBox();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.cmsCover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiCoverCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCoverPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailVerticalContainer = new System.Windows.Forms.SplitContainer();
            this.spcDetail = new System.Windows.Forms.SplitContainer();
            this.SearchFinderClearButton = new System.Windows.Forms.Button();
            this.SearchFinderComboBox = new System.Windows.Forms.ComboBox();
            this.cboFinderType = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DetailList = new Yomuko.Forms.Main.Control.DetailList();
            this.innerProperty1 = new Yomuko.Forms.Main.Control.InnerProperty();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookListChangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.EndMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SyncBaseFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookmarkListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ShowDisplayAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiFit = new System.Windows.Forms.ToolStripMenuItem();
            this.smiFitWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiPercent050 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent075 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent100 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent150 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent200 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent300 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPercent400 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowFileListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDisplayAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.smiSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowSearchFilterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollectTitleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiShowCover = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BookmarkList1 = new Yomuko.Forms.Main.Control.BookmarkList();
            this.sspMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcList)).BeginInit();
            this.spcList.Panel1.SuspendLayout();
            this.spcList.Panel2.SuspendLayout();
            this.spcList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcCover)).BeginInit();
            this.spcCover.Panel1.SuspendLayout();
            this.spcCover.Panel2.SuspendLayout();
            this.spcCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.cmsCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailVerticalContainer)).BeginInit();
            this.DetailVerticalContainer.Panel1.SuspendLayout();
            this.DetailVerticalContainer.Panel2.SuspendLayout();
            this.DetailVerticalContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcDetail)).BeginInit();
            this.spcDetail.Panel1.SuspendLayout();
            this.spcDetail.Panel2.SuspendLayout();
            this.spcDetail.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsColumnHeader
            // 
            this.cmsColumnHeader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsColumnHeader.Name = "cmsColumnHeader";
            this.cmsColumnHeader.Size = new System.Drawing.Size(61, 4);
            // 
            // sslInfomation
            // 
            this.sslInfomation.Name = "sslInfomation";
            this.sslInfomation.Size = new System.Drawing.Size(0, 16);
            // 
            // sspMain
            // 
            this.sspMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslInfomation});
            this.sspMain.Location = new System.Drawing.Point(0, 713);
            this.sspMain.Name = "sspMain";
            this.sspMain.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.sspMain.Size = new System.Drawing.Size(1302, 22);
            this.sspMain.TabIndex = 3;
            this.sspMain.Text = "StatusStrip1";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 30);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(5);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.spcList);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.DetailVerticalContainer);
            this.MainSplitContainer.Size = new System.Drawing.Size(1302, 683);
            this.MainSplitContainer.SplitterDistance = 258;
            this.MainSplitContainer.SplitterWidth = 6;
            this.MainSplitContainer.TabIndex = 2;
            this.MainSplitContainer.TabStop = false;
            // 
            // spcList
            // 
            this.spcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcList.IsSplitterFixed = true;
            this.spcList.Location = new System.Drawing.Point(0, 0);
            this.spcList.Margin = new System.Windows.Forms.Padding(5);
            this.spcList.Name = "spcList";
            this.spcList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcList.Panel1
            // 
            this.spcList.Panel1.Controls.Add(this.GroupTypeComboBox);
            // 
            // spcList.Panel2
            // 
            this.spcList.Panel2.Controls.Add(this.spcCover);
            this.spcList.Size = new System.Drawing.Size(258, 683);
            this.spcList.SplitterDistance = 25;
            this.spcList.SplitterWidth = 1;
            this.spcList.TabIndex = 2;
            this.spcList.TabStop = false;
            // 
            // GroupTypeComboBox
            // 
            this.GroupTypeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupTypeComboBox.FormattingEnabled = true;
            this.GroupTypeComboBox.Location = new System.Drawing.Point(0, 0);
            this.GroupTypeComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.GroupTypeComboBox.MaxDropDownItems = 20;
            this.GroupTypeComboBox.Name = "GroupTypeComboBox";
            this.GroupTypeComboBox.Size = new System.Drawing.Size(258, 28);
            this.GroupTypeComboBox.TabIndex = 0;
            this.GroupTypeComboBox.DropDownClosed += new System.EventHandler(this.GroupTypeComboBox_DropDownClosed);
            this.GroupTypeComboBox.Leave += new System.EventHandler(this.GroupTypeComboBox_Leave);
            // 
            // spcCover
            // 
            this.spcCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcCover.Location = new System.Drawing.Point(0, 0);
            this.spcCover.Margin = new System.Windows.Forms.Padding(5);
            this.spcCover.Name = "spcCover";
            this.spcCover.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcCover.Panel1
            // 
            this.spcCover.Panel1.Controls.Add(this.GroupListBox);
            // 
            // spcCover.Panel2
            // 
            this.spcCover.Panel2.Controls.Add(this.picCover);
            this.spcCover.Size = new System.Drawing.Size(258, 657);
            this.spcCover.SplitterDistance = 316;
            this.spcCover.SplitterWidth = 7;
            this.spcCover.TabIndex = 3;
            this.spcCover.TabStop = false;
            // 
            // GroupListBox
            // 
            this.GroupListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.GroupListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupListBox.FormattingEnabled = true;
            this.GroupListBox.ItemHeight = 20;
            this.GroupListBox.Location = new System.Drawing.Point(0, 0);
            this.GroupListBox.Margin = new System.Windows.Forms.Padding(5);
            this.GroupListBox.Name = "GroupListBox";
            this.GroupListBox.Size = new System.Drawing.Size(258, 316);
            this.GroupListBox.TabIndex = 0;
            this.GroupListBox.SelectedIndexChanged += new System.EventHandler(this.GroupListBox_SelectedIndexChanged);
            // 
            // picCover
            // 
            this.picCover.BackColor = System.Drawing.Color.Black;
            this.picCover.ContextMenuStrip = this.cmsCover;
            this.picCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCover.Location = new System.Drawing.Point(0, 0);
            this.picCover.Margin = new System.Windows.Forms.Padding(5);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(258, 334);
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            this.picCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCover_MouseDown);
            // 
            // cmsCover
            // 
            this.cmsCover.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiCoverCopy,
            this.smiCoverPaste});
            this.cmsCover.Name = "cmsCover";
            this.cmsCover.Size = new System.Drawing.Size(206, 52);
            this.cmsCover.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCover_Opening);
            // 
            // smiCoverCopy
            // 
            this.smiCoverCopy.Name = "smiCoverCopy";
            this.smiCoverCopy.Size = new System.Drawing.Size(205, 24);
            this.smiCoverCopy.Text = "カバー画像をコピー";
            this.smiCoverCopy.Click += new System.EventHandler(this.smiCoverCopy_Click);
            // 
            // smiCoverPaste
            // 
            this.smiCoverPaste.Name = "smiCoverPaste";
            this.smiCoverPaste.Size = new System.Drawing.Size(205, 24);
            this.smiCoverPaste.Text = "カバー画像に貼り付け";
            this.smiCoverPaste.Click += new System.EventHandler(this.smiCoverPaste_Click);
            // 
            // DetailVerticalContainer
            // 
            this.DetailVerticalContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailVerticalContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.DetailVerticalContainer.Location = new System.Drawing.Point(0, 0);
            this.DetailVerticalContainer.Name = "DetailVerticalContainer";
            this.DetailVerticalContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // DetailVerticalContainer.Panel1
            // 
            this.DetailVerticalContainer.Panel1.Controls.Add(this.spcDetail);
            // 
            // DetailVerticalContainer.Panel2
            // 
            this.DetailVerticalContainer.Panel2.Controls.Add(this.innerProperty1);
            this.DetailVerticalContainer.Panel2MinSize = 300;
            this.DetailVerticalContainer.Size = new System.Drawing.Size(1038, 683);
            this.DetailVerticalContainer.SplitterDistance = 229;
            this.DetailVerticalContainer.SplitterWidth = 10;
            this.DetailVerticalContainer.TabIndex = 16;
            this.DetailVerticalContainer.Text = "splitContainer1";
            // 
            // spcDetail
            // 
            this.spcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcDetail.Location = new System.Drawing.Point(0, 0);
            this.spcDetail.Margin = new System.Windows.Forms.Padding(5);
            this.spcDetail.Name = "spcDetail";
            this.spcDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcDetail.Panel1
            // 
            this.spcDetail.Panel1.Controls.Add(this.SearchFinderClearButton);
            this.spcDetail.Panel1.Controls.Add(this.SearchFinderComboBox);
            this.spcDetail.Panel1.Controls.Add(this.cboFinderType);
            this.spcDetail.Panel1.Controls.Add(this.Label1);
            this.spcDetail.Panel1MinSize = 30;
            // 
            // spcDetail.Panel2
            // 
            this.spcDetail.Panel2.Controls.Add(this.DetailList);
            this.spcDetail.Size = new System.Drawing.Size(1038, 229);
            this.spcDetail.SplitterDistance = 40;
            this.spcDetail.SplitterWidth = 7;
            this.spcDetail.TabIndex = 1;
            this.spcDetail.TabStop = false;
            // 
            // SearchFinderClearButton
            // 
            this.SearchFinderClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchFinderClearButton.Location = new System.Drawing.Point(952, 3);
            this.SearchFinderClearButton.Margin = new System.Windows.Forms.Padding(5);
            this.SearchFinderClearButton.Name = "SearchFinderClearButton";
            this.SearchFinderClearButton.Size = new System.Drawing.Size(86, 32);
            this.SearchFinderClearButton.TabIndex = 3;
            this.SearchFinderClearButton.Text = "クリア";
            this.SearchFinderClearButton.UseVisualStyleBackColor = true;
            this.SearchFinderClearButton.Click += new System.EventHandler(this.SearchFinderClearButton_Click);
            // 
            // SearchFinderComboBox
            // 
            this.SearchFinderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchFinderComboBox.FormattingEnabled = true;
            this.SearchFinderComboBox.Location = new System.Drawing.Point(304, 3);
            this.SearchFinderComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.SearchFinderComboBox.Name = "SearchFinderComboBox";
            this.SearchFinderComboBox.Size = new System.Drawing.Size(638, 28);
            this.SearchFinderComboBox.TabIndex = 2;
            // 
            // cboFinderType
            // 
            this.cboFinderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinderType.FormattingEnabled = true;
            this.cboFinderType.Location = new System.Drawing.Point(74, 5);
            this.cboFinderType.Margin = new System.Windows.Forms.Padding(5);
            this.cboFinderType.Name = "cboFinderType";
            this.cboFinderType.Size = new System.Drawing.Size(220, 28);
            this.cboFinderType.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 11);
            this.Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "フィルタ";
            // 
            // DetailList
            // 
            this.DetailList.AllowDrop = true;
            this.DetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailList.IsCollectSubtitle = false;
            this.DetailList.IsLoaded = false;
            this.DetailList.Location = new System.Drawing.Point(0, 0);
            this.DetailList.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DetailList.Name = "DetailList";
            this.DetailList.Search = null;
            this.DetailList.Size = new System.Drawing.Size(1038, 182);
            this.DetailList.TabIndex = 0;
            this.DetailList.Value = null;
            this.DetailList.SearchSelected += new System.EventHandler<Yomuko.Forms.Main.Control.SelectSearchEventArgs>(this.DetailList_SearchSelected);
            this.DetailList.SeriesModeChanged += new System.EventHandler(this.DetailList_SeriesModeChanged);
            this.DetailList.BookmarksShown += new System.EventHandler(this.DetailList_BookmarksShown);
            // 
            // innerProperty1
            // 
            this.innerProperty1.Books = null;
            this.innerProperty1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerProperty1.Location = new System.Drawing.Point(0, 0);
            this.innerProperty1.Name = "innerProperty1";
            this.innerProperty1.Size = new System.Drawing.Size(1038, 444);
            this.innerProperty1.TabIndex = 15;
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BookListChangeMenuItem,
            this.ToolStripMenuItem2,
            this.EndMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.ファイルFToolStripMenuItem.Text = "本棚(&F)";
            // 
            // BookListChangeMenuItem
            // 
            this.BookListChangeMenuItem.Name = "BookListChangeMenuItem";
            this.BookListChangeMenuItem.Size = new System.Drawing.Size(164, 26);
            this.BookListChangeMenuItem.Text = "本棚の変更";
            this.BookListChangeMenuItem.Click += new System.EventHandler(this.BookListChangeMenuItem_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // EndMenuItem
            // 
            this.EndMenuItem.Name = "EndMenuItem";
            this.EndMenuItem.Size = new System.Drawing.Size(164, 26);
            this.EndMenuItem.Text = "終了(&X)";
            this.EndMenuItem.Click += new System.EventHandler(this.EndMenuItem_Click);
            // 
            // ツールTToolStripMenuItem
            // 
            this.ツールTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncBaseFolderMenuItem,
            this.OptionMenuItem,
            this.BookmarkListMenuItem});
            this.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem";
            this.ツールTToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.ツールTToolStripMenuItem.Text = "ツール(&T)";
            // 
            // SyncBaseFolderMenuItem
            // 
            this.SyncBaseFolderMenuItem.Name = "SyncBaseFolderMenuItem";
            this.SyncBaseFolderMenuItem.Size = new System.Drawing.Size(210, 26);
            this.SyncBaseFolderMenuItem.Text = "ベースフォルダと同期";
            this.SyncBaseFolderMenuItem.Click += new System.EventHandler(this.SyncBaseFolderMenuItem_Click);
            // 
            // OptionMenuItem
            // 
            this.OptionMenuItem.Name = "OptionMenuItem";
            this.OptionMenuItem.Size = new System.Drawing.Size(210, 26);
            this.OptionMenuItem.Text = "オプション";
            this.OptionMenuItem.Click += new System.EventHandler(this.OptionMenuItem_Click);
            // 
            // BookmarkListMenuItem
            // 
            this.BookmarkListMenuItem.Name = "BookmarkListMenuItem";
            this.BookmarkListMenuItem.Size = new System.Drawing.Size(210, 26);
            this.BookmarkListMenuItem.Text = "しおり一覧";
            this.BookmarkListMenuItem.Click += new System.EventHandler(this.BookMarkListMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.ShowDisplayAllMenuItem,
            this.ShowMenuItem,
            this.ツールTToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.MenuStrip1.Size = new System.Drawing.Size(1302, 30);
            this.MenuStrip1.TabIndex = 13;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // ShowDisplayAllMenuItem
            // 
            this.ShowDisplayAllMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiFit,
            this.smiFitWidth,
            this.ToolStripSeparator1,
            this.smiPercent050,
            this.smiPercent075,
            this.smiPercent100,
            this.smiPercent150,
            this.smiPercent200,
            this.smiPercent300,
            this.smiPercent400,
            this.ToolStripSeparator2,
            this.ShowFileListMenuItem,
            this.smiDisplayAll});
            this.ShowDisplayAllMenuItem.Name = "ShowDisplayAllMenuItem";
            this.ShowDisplayAllMenuItem.Size = new System.Drawing.Size(72, 24);
            this.ShowDisplayAllMenuItem.Text = "表示(&V)";
            this.ShowDisplayAllMenuItem.Visible = false;
            // 
            // smiFit
            // 
            this.smiFit.CheckOnClick = true;
            this.smiFit.Name = "smiFit";
            this.smiFit.Size = new System.Drawing.Size(201, 26);
            this.smiFit.Text = "全体を表示";
            // 
            // smiFitWidth
            // 
            this.smiFitWidth.CheckOnClick = true;
            this.smiFitWidth.Enabled = false;
            this.smiFitWidth.Name = "smiFitWidth";
            this.smiFitWidth.Size = new System.Drawing.Size(201, 26);
            this.smiFitWidth.Text = "幅に合わせて表示";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // smiPercent050
            // 
            this.smiPercent050.CheckOnClick = true;
            this.smiPercent050.Name = "smiPercent050";
            this.smiPercent050.Size = new System.Drawing.Size(201, 26);
            this.smiPercent050.Text = "50%表示";
            // 
            // smiPercent075
            // 
            this.smiPercent075.CheckOnClick = true;
            this.smiPercent075.Name = "smiPercent075";
            this.smiPercent075.Size = new System.Drawing.Size(201, 26);
            this.smiPercent075.Text = "75%表示";
            // 
            // smiPercent100
            // 
            this.smiPercent100.CheckOnClick = true;
            this.smiPercent100.Name = "smiPercent100";
            this.smiPercent100.Size = new System.Drawing.Size(201, 26);
            this.smiPercent100.Text = "100%表示";
            // 
            // smiPercent150
            // 
            this.smiPercent150.Name = "smiPercent150";
            this.smiPercent150.Size = new System.Drawing.Size(201, 26);
            this.smiPercent150.Text = "150%表示";
            // 
            // smiPercent200
            // 
            this.smiPercent200.CheckOnClick = true;
            this.smiPercent200.Name = "smiPercent200";
            this.smiPercent200.Size = new System.Drawing.Size(201, 26);
            this.smiPercent200.Text = "200%表示";
            // 
            // smiPercent300
            // 
            this.smiPercent300.CheckOnClick = true;
            this.smiPercent300.Name = "smiPercent300";
            this.smiPercent300.Size = new System.Drawing.Size(201, 26);
            this.smiPercent300.Text = "300%表示";
            // 
            // smiPercent400
            // 
            this.smiPercent400.CheckOnClick = true;
            this.smiPercent400.Name = "smiPercent400";
            this.smiPercent400.Size = new System.Drawing.Size(201, 26);
            this.smiPercent400.Text = "400%表示";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // ShowFileListMenuItem
            // 
            this.ShowFileListMenuItem.Checked = true;
            this.ShowFileListMenuItem.CheckOnClick = true;
            this.ShowFileListMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFileListMenuItem.Name = "ShowFileListMenuItem";
            this.ShowFileListMenuItem.Size = new System.Drawing.Size(201, 26);
            this.ShowFileListMenuItem.Text = "ファイルリスト";
            // 
            // smiDisplayAll
            // 
            this.smiDisplayAll.CheckOnClick = true;
            this.smiDisplayAll.Name = "smiDisplayAll";
            this.smiDisplayAll.Size = new System.Drawing.Size(201, 26);
            this.smiDisplayAll.Text = "全画面表示";
            // 
            // ShowMenuItem
            // 
            this.ShowMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiFavorite,
            this.smiBookmark,
            this.ToolStripSeparator4,
            this.smiSeries,
            this.ToolStripSeparator3,
            this.ShowSearchFilterMenuItem,
            this.CollectTitleMenuItem,
            this.smiShowCover,
            this.ToolStripMenuItem1});
            this.ShowMenuItem.Name = "ShowMenuItem";
            this.ShowMenuItem.Size = new System.Drawing.Size(72, 24);
            this.ShowMenuItem.Text = "表示(&V)";
            // 
            // smiFavorite
            // 
            this.smiFavorite.CheckOnClick = true;
            this.smiFavorite.Name = "smiFavorite";
            this.smiFavorite.Size = new System.Drawing.Size(222, 26);
            this.smiFavorite.Text = "お気に入り表示";
            // 
            // smiBookmark
            // 
            this.smiBookmark.CheckOnClick = true;
            this.smiBookmark.Name = "smiBookmark";
            this.smiBookmark.Size = new System.Drawing.Size(222, 26);
            this.smiBookmark.Text = "しおり一覧表示";
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(219, 6);
            // 
            // smiSeries
            // 
            this.smiSeries.Name = "smiSeries";
            this.smiSeries.Size = new System.Drawing.Size(222, 26);
            this.smiSeries.Text = "シリーズモード切替";
            this.smiSeries.Visible = false;
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            this.ToolStripSeparator3.Visible = false;
            // 
            // ShowSearchFilterMenuItem
            // 
            this.ShowSearchFilterMenuItem.CheckOnClick = true;
            this.ShowSearchFilterMenuItem.Name = "ShowSearchFilterMenuItem";
            this.ShowSearchFilterMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ShowSearchFilterMenuItem.Size = new System.Drawing.Size(222, 26);
            this.ShowSearchFilterMenuItem.Text = "検索フィルタ";
            this.ShowSearchFilterMenuItem.Click += new System.EventHandler(this.ShowSearchFilterMenuItem_Click);
            // 
            // CollectTitleMenuItem
            // 
            this.CollectTitleMenuItem.CheckOnClick = true;
            this.CollectTitleMenuItem.Name = "CollectTitleMenuItem";
            this.CollectTitleMenuItem.Size = new System.Drawing.Size(222, 26);
            this.CollectTitleMenuItem.Text = "タイトルをまとめて表示";
            this.CollectTitleMenuItem.Visible = false;
            // 
            // smiShowCover
            // 
            this.smiShowCover.Checked = true;
            this.smiShowCover.CheckOnClick = true;
            this.smiShowCover.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smiShowCover.Name = "smiShowCover";
            this.smiShowCover.Size = new System.Drawing.Size(222, 26);
            this.smiShowCover.Text = "表紙を表示";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.CheckOnClick = true;
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(222, 26);
            this.ToolStripMenuItem1.Text = "全画面表示";
            // 
            // BookmarkList1
            // 
            this.BookmarkList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookmarkList1.Location = new System.Drawing.Point(0, 30);
            this.BookmarkList1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BookmarkList1.Name = "BookmarkList1";
            this.BookmarkList1.Size = new System.Drawing.Size(1302, 705);
            this.BookmarkList1.TabIndex = 14;
            this.BookmarkList1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 735);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.sspMain);
            this.Controls.Add(this.BookmarkList1);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sspMain.ResumeLayout(false);
            this.sspMain.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.spcList.Panel1.ResumeLayout(false);
            this.spcList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcList)).EndInit();
            this.spcList.ResumeLayout(false);
            this.spcCover.Panel1.ResumeLayout(false);
            this.spcCover.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCover)).EndInit();
            this.spcCover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.cmsCover.ResumeLayout(false);
            this.DetailVerticalContainer.Panel1.ResumeLayout(false);
            this.DetailVerticalContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailVerticalContainer)).EndInit();
            this.DetailVerticalContainer.ResumeLayout(false);
            this.spcDetail.Panel1.ResumeLayout(false);
            this.spcDetail.Panel1.PerformLayout();
            this.spcDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDetail)).EndInit();
            this.spcDetail.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        System.Windows.Forms.ContextMenuStrip cmsColumnHeader;
        System.Windows.Forms.ToolStripStatusLabel sslInfomation;
        System.Windows.Forms.StatusStrip sspMain;
        System.Windows.Forms.SplitContainer MainSplitContainer;
        System.Windows.Forms.ListBox GroupListBox;
        System.Windows.Forms.SplitContainer spcList;
        System.Windows.Forms.ComboBox GroupTypeComboBox;
        System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem BookListChangeMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        System.Windows.Forms.ToolStripMenuItem EndMenuItem;
        System.Windows.Forms.ToolStripMenuItem ツールTToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem SyncBaseFolderMenuItem;
        System.Windows.Forms.ToolStripMenuItem OptionMenuItem;
        System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        System.Windows.Forms.MenuStrip MenuStrip1;
        System.Windows.Forms.SplitContainer spcDetail;
        System.Windows.Forms.ComboBox SearchFinderComboBox;
        System.Windows.Forms.ComboBox cboFinderType;
        System.Windows.Forms.Label Label1;
        System.Windows.Forms.Button SearchFinderClearButton;
        Yomuko.Forms.Main.Control.DetailList DetailList;
        System.Windows.Forms.ToolStripMenuItem ShowMenuItem;
        System.Windows.Forms.ToolStripMenuItem ShowSearchFilterMenuItem;
        System.Windows.Forms.ToolStripMenuItem CollectTitleMenuItem;
        System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        System.Windows.Forms.ToolStripMenuItem BookmarkListMenuItem;
        System.Windows.Forms.SplitContainer spcCover;
        System.Windows.Forms.PictureBox picCover;
        System.Windows.Forms.ToolStripMenuItem smiShowCover;
        Yomuko.Forms.Main.Control.BookmarkList BookmarkList1;
        System.Windows.Forms.ToolStripMenuItem smiFavorite;
        System.Windows.Forms.ToolStripMenuItem smiBookmark;
        System.Windows.Forms.ToolStripMenuItem smiSeries;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        System.Windows.Forms.ContextMenuStrip cmsCover;
        private System.Windows.Forms.ToolStripMenuItem ShowDisplayAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiFit;
        private System.Windows.Forms.ToolStripMenuItem smiFitWidth;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem smiPercent050;
        private System.Windows.Forms.ToolStripMenuItem smiPercent075;
        private System.Windows.Forms.ToolStripMenuItem smiPercent100;
        private System.Windows.Forms.ToolStripMenuItem smiPercent150;
        private System.Windows.Forms.ToolStripMenuItem smiPercent200;
        private System.Windows.Forms.ToolStripMenuItem smiPercent300;
        private System.Windows.Forms.ToolStripMenuItem smiPercent400;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ShowFileListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiDisplayAll;
        private System.Windows.Forms.ToolStripMenuItem smiCoverCopy;
        private System.Windows.Forms.ToolStripMenuItem smiCoverPaste;
        private System.Windows.Forms.SplitContainer DetailVerticalContainer;
        private Control.InnerProperty innerProperty1;
    }
}
