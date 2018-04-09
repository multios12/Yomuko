namespace ComicLaunch.Forms.Main.Control
{
    public partial class DetailList : System.Windows.Forms.UserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailList));
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.BookmarkButton = new System.Windows.Forms.Button();
            this.FavoriteButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SeriesListView = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SeriesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiAllPropertyChangeSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSeriesTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.お気に入りToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.お気に入り解除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SetCompleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearCompleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smiBookChangeFileNameSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBookMoveSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBookDeleteSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.片付け箱に入れるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderSearchTitleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderSearchWriterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailListView = new System.Windows.Forms.ListView();
            this.DetailMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.AllPropertyChangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.InsertCompleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDeleteFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiBookChangeFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBookMove = new System.Windows.Forms.ToolStripMenuItem();
            this.DummyItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTitleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchWriterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CoverPaintTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.SeriesContextMenu.SuspendLayout();
            this.DetailMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.BookmarkButton);
            this.spcMain.Panel1.Controls.Add(this.FavoriteButton);
            this.spcMain.Panel1.Controls.Add(this.ReturnButton);
            this.spcMain.Panel1.Controls.Add(this.ExitButton);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.SeriesListView);
            this.spcMain.Panel2.Controls.Add(this.DetailListView);
            this.spcMain.Size = new System.Drawing.Size(716, 355);
            this.spcMain.SplitterDistance = 25;
            this.spcMain.TabIndex = 0;
            this.spcMain.TabStop = false;
            // 
            // BookmarkButton
            // 
            this.BookmarkButton.Location = new System.Drawing.Point(279, 1);
            this.BookmarkButton.Name = "BookmarkButton";
            this.BookmarkButton.Size = new System.Drawing.Size(75, 23);
            this.BookmarkButton.TabIndex = 3;
            this.BookmarkButton.TabStop = false;
            this.BookmarkButton.Text = "しおり一覧";
            this.BookmarkButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteButton
            // 
            this.FavoriteButton.Location = new System.Drawing.Point(198, 0);
            this.FavoriteButton.Name = "FavoriteButton";
            this.FavoriteButton.Size = new System.Drawing.Size(75, 24);
            this.FavoriteButton.TabIndex = 2;
            this.FavoriteButton.TabStop = false;
            this.FavoriteButton.Text = "お気に入り";
            this.FavoriteButton.UseVisualStyleBackColor = true;
            this.FavoriteButton.Click += new System.EventHandler(this.FavoriteButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(3, 0);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(75, 24);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.TabStop = false;
            this.ReturnButton.Text = "戻る";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(84, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(108, 24);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "シリーズモード終了";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SeriesListView
            // 
            this.SeriesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.SeriesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader3,
            this.ColumnHeader2,
            this.ColumnHeader4,
            this.ColumnHeader5});
            this.SeriesListView.ContextMenuStrip = this.SeriesContextMenu;
            this.SeriesListView.FullRowSelect = true;
            this.SeriesListView.HideSelection = false;
            this.SeriesListView.Location = new System.Drawing.Point(99, 102);
            this.SeriesListView.Name = "SeriesListView";
            this.SeriesListView.Size = new System.Drawing.Size(557, 219);
            this.SeriesListView.TabIndex = 1;
            this.SeriesListView.UseCompatibleStateImageBehavior = false;
            this.SeriesListView.View = System.Windows.Forms.View.Details;
            this.SeriesListView.VirtualMode = true;
            this.SeriesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SeriesListView_ColumnClick);
            this.SeriesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SeriesListView_ItemSelectionChanged);
            this.SeriesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeriesListView_KeyDown);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "タイトル";
            this.ColumnHeader1.Width = 221;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "著者";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "冊数";
            this.ColumnHeader2.Width = 42;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "初巻発売日";
            this.ColumnHeader4.Width = 77;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "最新刊";
            this.ColumnHeader5.Width = 107;
            // 
            // SeriesContextMenu
            // 
            this.SeriesContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SeriesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiAllPropertyChangeSeries,
            this.smiSeriesTitle,
            this.ToolStripSeparator1,
            this.お気に入りToolStripMenuItem,
            this.お気に入り解除ToolStripMenuItem,
            this.ToolStripSeparator4,
            this.SetCompleteMenuItem,
            this.ClearCompleteMenuItem,
            this.ToolStripSeparator2,
            this.smiBookChangeFileNameSeries,
            this.smiBookMoveSeries,
            this.smiBookDeleteSeries,
            this.片付け箱に入れるToolStripMenuItem,
            this.ToolStripSeparator5,
            this.ToolStripMenuItem2});
            this.SeriesContextMenu.Name = "SeriesContextMenu";
            this.SeriesContextMenu.Size = new System.Drawing.Size(176, 270);
            // 
            // smiAllPropertyChangeSeries
            // 
            this.smiAllPropertyChangeSeries.Name = "smiAllPropertyChangeSeries";
            this.smiAllPropertyChangeSeries.Size = new System.Drawing.Size(175, 22);
            this.smiAllPropertyChangeSeries.Text = "プロパティを一括変更";
            // 
            // smiSeriesTitle
            // 
            this.smiSeriesTitle.Name = "smiSeriesTitle";
            this.smiSeriesTitle.Size = new System.Drawing.Size(175, 22);
            this.smiSeriesTitle.Text = "シリーズ名抽出";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // お気に入りToolStripMenuItem
            // 
            this.お気に入りToolStripMenuItem.Name = "お気に入りToolStripMenuItem";
            this.お気に入りToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.お気に入りToolStripMenuItem.Text = "お気に入り";
            this.お気に入りToolStripMenuItem.Visible = false;
            // 
            // お気に入り解除ToolStripMenuItem
            // 
            this.お気に入り解除ToolStripMenuItem.Name = "お気に入り解除ToolStripMenuItem";
            this.お気に入り解除ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.お気に入り解除ToolStripMenuItem.Text = "お気に入り解除";
            this.お気に入り解除ToolStripMenuItem.Visible = false;
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            this.ToolStripSeparator4.Visible = false;
            // 
            // SetCompleteMenuItem
            // 
            this.SetCompleteMenuItem.Name = "SetCompleteMenuItem";
            this.SetCompleteMenuItem.Size = new System.Drawing.Size(175, 22);
            this.SetCompleteMenuItem.Text = "完結シリーズ";
            // 
            // ClearCompleteMenuItem
            // 
            this.ClearCompleteMenuItem.Name = "ClearCompleteMenuItem";
            this.ClearCompleteMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ClearCompleteMenuItem.Text = "完結シリーズを解除";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // smiBookChangeFileNameSeries
            // 
            this.smiBookChangeFileNameSeries.Name = "smiBookChangeFileNameSeries";
            this.smiBookChangeFileNameSeries.Size = new System.Drawing.Size(175, 22);
            this.smiBookChangeFileNameSeries.Text = "ファイル名置き換え";
            // 
            // smiBookMoveSeries
            // 
            this.smiBookMoveSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem3});
            this.smiBookMoveSeries.Name = "smiBookMoveSeries";
            this.smiBookMoveSeries.Size = new System.Drawing.Size(175, 22);
            this.smiBookMoveSeries.Text = "ファイルの移動";
            this.smiBookMoveSeries.Visible = false;
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(145, 22);
            this.ToolStripMenuItem3.Text = "(dummyItem)";
            // 
            // smiBookDeleteSeries
            // 
            this.smiBookDeleteSeries.Name = "smiBookDeleteSeries";
            this.smiBookDeleteSeries.Size = new System.Drawing.Size(175, 22);
            this.smiBookDeleteSeries.Text = "削除";
            // 
            // 片付け箱に入れるToolStripMenuItem
            // 
            this.片付け箱に入れるToolStripMenuItem.Name = "片付け箱に入れるToolStripMenuItem";
            this.片付け箱に入れるToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.片付け箱に入れるToolStripMenuItem.Text = "片付け箱に入れる";
            this.片付け箱に入れるToolStripMenuItem.Visible = false;
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(172, 6);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderSearchTitleMenuItem,
            this.FolderSearchWriterMenuItem});
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(175, 22);
            this.ToolStripMenuItem2.Text = "検索";
            // 
            // FolderSearchTitleMenuItem
            // 
            this.FolderSearchTitleMenuItem.Name = "FolderSearchTitleMenuItem";
            this.FolderSearchTitleMenuItem.Size = new System.Drawing.Size(144, 22);
            this.FolderSearchTitleMenuItem.Text = "タイトルで検索";
            // 
            // FolderSearchWriterMenuItem
            // 
            this.FolderSearchWriterMenuItem.Name = "FolderSearchWriterMenuItem";
            this.FolderSearchWriterMenuItem.Size = new System.Drawing.Size(144, 22);
            this.FolderSearchWriterMenuItem.Text = "著者で検索";
            // 
            // DetailListView
            // 
            this.DetailListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.DetailListView.AllowDrop = true;
            this.DetailListView.ContextMenuStrip = this.DetailMenuStrip;
            this.DetailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailListView.FullRowSelect = true;
            this.DetailListView.HideSelection = false;
            this.DetailListView.Location = new System.Drawing.Point(0, 0);
            this.DetailListView.Name = "DetailListView";
            this.DetailListView.Size = new System.Drawing.Size(716, 326);
            this.DetailListView.SmallImageList = this.ImageList1;
            this.DetailListView.TabIndex = 0;
            this.DetailListView.UseCompatibleStateImageBehavior = false;
            this.DetailListView.View = System.Windows.Forms.View.Details;
            this.DetailListView.VirtualMode = true;
            this.DetailListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DetailListView_ColumnClick);
            this.DetailListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.DetailListView_ColumnWidthChanged);
            this.DetailListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DetailListView_ItemSelectionChanged);
            this.DetailListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.DetailListView_RetrieveVirtualItem);
            this.DetailListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DetailListView_DragDrop);
            this.DetailListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.DetailListView_DragEnter);
            this.DetailListView.DoubleClick += new System.EventHandler(this.DetailListView_DoubleClick);
            this.DetailListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetailListView_KeyDown);
            // 
            // DetailMenuStrip
            // 
            this.DetailMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DetailMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiProperty,
            this.AllPropertyChangeMenuItem,
            this.ToolStripMenuItem1,
            this.InsertCompleteMenuItem,
            this.smiDeleteFavorite,
            this.Separator1,
            this.smiBookChangeFileName,
            this.smiBookMove,
            this.BookDeleteMenuItem,
            this.ToolStripSeparator3,
            this.SearchToolStripMenuItem});
            this.DetailMenuStrip.Name = "cmsDetail";
            this.DetailMenuStrip.Size = new System.Drawing.Size(177, 198);
            // 
            // smiProperty
            // 
            this.smiProperty.Name = "smiProperty";
            this.smiProperty.Size = new System.Drawing.Size(176, 22);
            this.smiProperty.Text = "プロパティ";
            this.smiProperty.Click += new System.EventHandler(this.PropertyMenuItem_Click);
            // 
            // AllPropertyChangeMenuItem
            // 
            this.AllPropertyChangeMenuItem.Name = "AllPropertyChangeMenuItem";
            this.AllPropertyChangeMenuItem.Size = new System.Drawing.Size(176, 22);
            this.AllPropertyChangeMenuItem.Text = "プロパティの一括変更";
            this.AllPropertyChangeMenuItem.Click += new System.EventHandler(this.AllPropertyChangeMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // InsertCompleteMenuItem
            // 
            this.InsertCompleteMenuItem.Name = "InsertCompleteMenuItem";
            this.InsertCompleteMenuItem.Size = new System.Drawing.Size(176, 22);
            this.InsertCompleteMenuItem.Text = "お気に入り";
            this.InsertCompleteMenuItem.Click += new System.EventHandler(this.FavoriteMenuItem_Click);
            // 
            // smiDeleteFavorite
            // 
            this.smiDeleteFavorite.Name = "smiDeleteFavorite";
            this.smiDeleteFavorite.Size = new System.Drawing.Size(176, 22);
            this.smiDeleteFavorite.Text = "お気に入り解除";
            this.smiDeleteFavorite.Click += new System.EventHandler(this.FavoriteMenuItem_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(173, 6);
            // 
            // smiBookChangeFileName
            // 
            this.smiBookChangeFileName.Name = "smiBookChangeFileName";
            this.smiBookChangeFileName.Size = new System.Drawing.Size(176, 22);
            this.smiBookChangeFileName.Text = "ファイル名置き換え";
            this.smiBookChangeFileName.Click += new System.EventHandler(this.BookChangeFileNameMenuItem_Click);
            // 
            // smiBookMove
            // 
            this.smiBookMove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DummyItemToolStripMenuItem});
            this.smiBookMove.Name = "smiBookMove";
            this.smiBookMove.Size = new System.Drawing.Size(176, 22);
            this.smiBookMove.Text = "ファイルの移動";
            this.smiBookMove.DropDownOpening += new System.EventHandler(this.BookMoveMenuItem_DropDownOpening);
            this.smiBookMove.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FileMoveMenuItem_DropDownItemClicked);
            // 
            // DummyItemToolStripMenuItem
            // 
            this.DummyItemToolStripMenuItem.Name = "DummyItemToolStripMenuItem";
            this.DummyItemToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.DummyItemToolStripMenuItem.Text = "(dummyItem)";
            // 
            // BookDeleteMenuItem
            // 
            this.BookDeleteMenuItem.Name = "BookDeleteMenuItem";
            this.BookDeleteMenuItem.Size = new System.Drawing.Size(176, 22);
            this.BookDeleteMenuItem.Text = "削除";
            this.BookDeleteMenuItem.Click += new System.EventHandler(this.BookDeleteMenuItem_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchTitleMenuItem,
            this.SearchWriterMenuItem});
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SearchToolStripMenuItem.Text = "検索";
            // 
            // SearchTitleMenuItem
            // 
            this.SearchTitleMenuItem.Name = "SearchTitleMenuItem";
            this.SearchTitleMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SearchTitleMenuItem.Text = "タイトルで検索";
            this.SearchTitleMenuItem.Click += new System.EventHandler(this.SearchMenuItem_Click);
            // 
            // SearchWriterMenuItem
            // 
            this.SearchWriterMenuItem.Name = "SearchWriterMenuItem";
            this.SearchWriterMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SearchWriterMenuItem.Text = "著者で検索";
            this.SearchWriterMenuItem.Click += new System.EventHandler(this.SearchMenuItem_Click);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "173.png");
            // 
            // CoverPaintTimer
            // 
            this.CoverPaintTimer.Interval = 200;
            this.CoverPaintTimer.Tick += new System.EventHandler(this.CoverPaintTimer_Tick);
            // 
            // DetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "DetailList";
            this.Size = new System.Drawing.Size(716, 355);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.SeriesContextMenu.ResumeLayout(false);
            this.DetailMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        System.Windows.Forms.SplitContainer spcMain;
        System.Windows.Forms.ListView DetailListView;
        System.Windows.Forms.Button ReturnButton;
        System.Windows.Forms.Button ExitButton;
        System.Windows.Forms.ListView SeriesListView;
        System.Windows.Forms.ContextMenuStrip DetailMenuStrip;
        System.Windows.Forms.ToolStripMenuItem smiProperty;
        System.Windows.Forms.ToolStripMenuItem AllPropertyChangeMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        System.Windows.Forms.ToolStripMenuItem InsertCompleteMenuItem;
        System.Windows.Forms.ToolStripMenuItem smiDeleteFavorite;
        System.Windows.Forms.ToolStripSeparator Separator1;
        System.Windows.Forms.ToolStripMenuItem smiBookChangeFileName;
        System.Windows.Forms.ToolStripMenuItem smiBookMove;
        System.Windows.Forms.ToolStripMenuItem DummyItemToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem BookDeleteMenuItem;
        System.Windows.Forms.ColumnHeader ColumnHeader1;
        System.Windows.Forms.ColumnHeader ColumnHeader2;
        System.Windows.Forms.ContextMenuStrip SeriesContextMenu;
        System.Windows.Forms.ToolStripMenuItem smiSeriesTitle;
        System.Windows.Forms.ColumnHeader ColumnHeader3;
        System.Windows.Forms.ImageList ImageList1;
        System.Windows.Forms.Button FavoriteButton;
        System.Windows.Forms.Timer CoverPaintTimer;
        System.Windows.Forms.Button BookmarkButton;
        System.Windows.Forms.ColumnHeader ColumnHeader4;
        System.Windows.Forms.ColumnHeader ColumnHeader5;
        System.Windows.Forms.ToolStripMenuItem smiAllPropertyChangeSeries;
        System.Windows.Forms.ToolStripMenuItem SetCompleteMenuItem;
        System.Windows.Forms.ToolStripMenuItem ClearCompleteMenuItem;
        System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem SearchTitleMenuItem;
        System.Windows.Forms.ToolStripMenuItem SearchWriterMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        System.Windows.Forms.ToolStripMenuItem FolderSearchTitleMenuItem;
        System.Windows.Forms.ToolStripMenuItem FolderSearchWriterMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        System.Windows.Forms.ToolStripMenuItem お気に入りToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem お気に入り解除ToolStripMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        System.Windows.Forms.ToolStripMenuItem smiBookChangeFileNameSeries;
        System.Windows.Forms.ToolStripMenuItem smiBookMoveSeries;
        System.Windows.Forms.ToolStripMenuItem smiBookDeleteSeries;
        System.Windows.Forms.ToolStripMenuItem 片付け箱に入れるToolStripMenuItem;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
    }
}
