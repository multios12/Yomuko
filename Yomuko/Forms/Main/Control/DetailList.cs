namespace Yomuko.Forms.Main.Control
{
    using Book;
    using Form;
    using Properties;
    using Series;
    using Shelf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Utils;

    /// <summary>
    /// 詳細リストビューコントロール
    /// </summary>
    public partial class DetailList
    {
        /// <summary>リスト</summary>
        private BookList books;

        /// <summary>列情報リスト</summary>
        private List<ColumnModel> columns = new List<ColumnModel>();

        /// <summary>直前に選択したファイル名変更インデックス</summary>
        private int selectChangeSelectedIndex;

        private FieldType fieldType;

        public bool IsLoaded { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DetailList()
        {
            this.InitializeComponent();
        }

        #region パブリックイベント

        /// <summary>書籍選択イベント</summary>
        public event EventHandler<ItemEventArgs<BookModel>> ItemSelected;

        /// <summary>情報変更イベント</summary>
        public event EventHandler<ItemEventArgs<IEnumerable<BookModel>>> ItemChanged;

        /// <summary>表紙表示イベント</summary>
        public event EventHandler<ItemEventArgs<BookModel>> CoverImagePaint;

        /// <summary>検索選択イベント</summary>
        public event EventHandler<SelectSearchEventArgs> SearchSelected;

        /// <summary>シリーズモード変更イベント</summary>
        public event EventHandler SeriesModeChanged;

        /// <summary>しおりボタン選択イベント</summary>
        public event EventHandler BookmarksShown;
        #endregion

        #region パブリックプロパティ

        /// <summary>シェルフオブジェクト</summary>
        [XmlIgnore, Browsable(false), DefaultValue(null)]
        public ShelfModel Shelf { get; set; }

        /// <summary>数・サブタイトルをタイトルにまとめて表示するか</summary>
        [XmlIgnore, Browsable(false)]
        public bool IsCollectSubtitle { get; set; }

        /// <summary>このモデルで管理対象となるリスト</summary>
        [XmlIgnore, Browsable(false), DefaultValue(null)]
        public BookList Books
        {
            get
            {
                return this.books;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                if (this.books != null)
                {
                    this.books.PropertyChanged -= this.Books_PropertyChanged;
                }

                this.books = value;
                this.books.PropertyChanged += this.Books_PropertyChanged;
                this.books.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));

                Debug.Print("DetailList 対象件数:{0}", this.Books.Count());
                Debug.Print("DetailList 表示件数:{0}", this.Books.SearchedItems.Count());
            }
        }

        /// <summary>値</summary>
        public string Value { get; set; }

        /// <summary>検索</summary>
        public string Search { get; set; }
        #endregion

        #region パブリックメソッド

        /// <summary>リストアイテムの取得</summary>
        /// <returns>リスト</returns>
        public List<ColumnModel> GetColumns()
        {
            return this.columns;
        }

        /// <summary>リストアイテムの更新</summary>
        /// <param name="items">リストアイテム</param>
        public void RefreshColumns(List<ColumnModel> items = null)
        {
            this.DetailListView.VirtualListSize = 0;
            this.columns = items ?? new List<ColumnModel>();
            this.DetailListView.Columns.Clear();

            this.columns.ToList().ForEach(l => this.DetailListView.Columns.Add(l.FieldType.LabelName(), l.Width));
        }

        /// <summary>プロパティダイアログの表示</summary>
        public void ShowPropertyDialog()
        {
            this.PropertyMenuItem_Click(null, null);
        }
        #endregion

        /// <summary>
        /// リスト プロパティ変更イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Books_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var invoker = (MethodInvoker)delegate
            {
                Debug.Print("DetailList:PropertyChanged発生");
                if (e.PropertyName == nameof(BookList.SearchedItems))
                {
                    this.RefreshDetailList();
                }
                else if (e.PropertyName == nameof(BookList.SeriesItems))
                {
                    this.RefreshSeriesList();
                }
            };

            this.Invoke(invoker);
        }

        /// <summary>お気に入りボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FavoriteButton_Click(object sender, EventArgs e)
        {
            this.books.RefreshSearchCriterias(new SearchModel(FieldType.Favorite, "true"));
            this.RefreshDetailList();
        }

        /// <summary>重複ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            this.books.RefreshSearchCriterias(new SearchModel(true));
            this.RefreshDetailList();
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CoverPaintTimer_Tick(object sender, EventArgs e)
        {
            this.CoverPaintTimer.Enabled = false;

            if (!this.IsLoaded)
            {
                return;
            }

            if ((this.SeriesListView.Visible == true && this.SeriesListView.SelectedIndices.Count == 0)
                || (this.SeriesListView.Visible == false && this.DetailListView.SelectedIndices.Count == 0))
            {
                this.CoverImagePaint(this, new ItemEventArgs<BookModel>(null));
                return;
            }

            var eventArgs = new ItemEventArgs<BookModel>(this.GetSelectedBooks().First());
            this.CoverImagePaint(this, eventArgs);
        }

        /// <summary>ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkButton_Click(object sender, EventArgs e)
        {
            this.BookmarksShown(sender, new EventArgs());
        }

        /// <summary>モード変更ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ChangeSeriesButton_Click(object sender, EventArgs e)
        {
            this.Books.IsSeriesMode = true;
            this.SeriesModeChanged(sender, new EventArgs());
            this.DetailListView.Refresh();
        }

        /// <summary>シリーズモード終了ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.books.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));
            this.RefreshDetailList();
            this.SeriesListView.Focus();
        }

        #region イベントプロシージャ：SeriesListView

        /// <summary>シリーズリストビュー 列クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.SeriesListView.Columns.Cast<ColumnHeader>().ToList()
                .ForEach(c => c.Text = c.Text.Replace(Resources.ColumnOrderAsc, string.Empty));
            this.SeriesListView.Columns.Cast<ColumnHeader>().ToList()
                .ForEach(c => c.Text = c.Text.Replace(Resources.ColumnOrderDesc, string.Empty));

            this.books.SeriesItems.SortKey = this.SeriesListView.Columns[e.Column].Text;
            this.SeriesListView.Refresh();
        }

        /// <summary>シリーズリストビュー ダブルクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.SeriesListView.SelectedIndices.Count != 0)
            {
                string value = this.books.SeriesItems[this.SeriesListView.SelectedIndices[0]].Title;
                this.books.RefreshSearchCriterias(new SearchModel(FieldType.Title, value));
            }
        }

        /// <summary>シリーズリストビュー キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.SeriesListView_DoubleClick(sender, e);
            }
        }

        /// <summary>シリーズリストビュー リサイズイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_Resize(object sender, EventArgs e)
        {
            Debug.Print("SeriesListView_Resize");
            this.CoverPaintTimer_Tick(this, null);
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= this.books.SeriesItems.Count())
            {
                return;
            }

            // リストビューアイテムの生成
            var listItem = new ListViewItem();
            var series = this.books.SeriesItems[e.ItemIndex];
            listItem.SubItems.Clear();
            listItem.Text = series.Title;
            listItem.SubItems.Add(series.Writer);
            listItem.SubItems.Add(series.Count.ToString());
            listItem.SubItems.Add(series.FirstReleaseDate);

            if (series.IsComplete == true)
            {
                listItem.SubItems.Add("完結");
            }
            else if (string.IsNullOrEmpty(series.LastNo) == false)
            {
                listItem.SubItems.Add($"{series.LastNo}巻 {series.LastReleaseDate}");
            }
            else
            {
                listItem.SubItems.Add(string.Empty);
            }

            e.Item.BackColor = (e.ItemIndex % 2 == 0) ? Color.FromArgb(240, 255, 240) : Color.FromArgb(255, 255, 255);
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.CoverPaintTimer.Enabled = false;
            this.CoverPaintTimer.Enabled = true;
            Debug.Print("SeriesListView_ItemSelectionChanged:CoverPaintTimer:True");
        }
        #endregion

        #region イベントプロシージャ：DetailListView

        /// <summary>詳細リストビュー 列クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var columns = this.DetailListView.Columns.Cast<ColumnHeader>().ToList();
            columns.ForEach(c => c.Text = c.Text.Replace(Resources.ColumnOrderAsc, string.Empty));
            columns.ForEach(c => c.Text = c.Text.Replace(Resources.ColumnOrderDesc, string.Empty));

            // クリックされた列によりソートキーを指定
            this.Books.SortKey = BookModel.GetFieldType(this.DetailListView.Columns[e.Column].Text);

            columns[e.Column].Text = (this.books.IsSortOrderAsc ? Resources.ColumnOrderAsc : Resources.ColumnOrderDesc)
                + this.DetailListView.Columns[e.Column].Text;

            this.DetailListView.Refresh();
        }

        /// <summary>詳細リストビュー 列幅変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.columns[e.ColumnIndex].Width = this.DetailListView.Columns[e.ColumnIndex].Width;
        }

        /// <summary>詳細リストビュー 選択アイテム変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.CoverPaintTimer.Enabled = false;

            if (!this.IsLoaded)
            {
                return;
            }

            this.books.SearchedItems[e.ItemIndex].IsDuplicate = !this.books.SearchedItems[e.ItemIndex].FileExists();
            this.CoverPaintTimer.Enabled = this.books.SearchedItems[e.ItemIndex].FileExists();
            Debug.Print("DetailListView_ItemSelectionChanged:CoverPaintTimer:");
        }

        /// <summary>詳細リストビュー  ビューアイテム作成イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (this.books.SearchedItems.Count < e.ItemIndex)
            {
                return;
            }

            // リストビューアイテムの生成
            var listItem = new ListViewItem()
            {
                Text = this.books.SearchedItems[e.ItemIndex].GetFormatValue(this.columns[0].FieldType, this.IsCollectSubtitle)
            };
            if (!(this.DetailListView.Columns.Count <= 1))
            {
                for (int index = 1; index < this.DetailListView.Columns.Count; index++)
                {
                    var column = this.DetailListView.Columns[index];
                    string valueName = column.Text.Replace(Resources.ColumnOrderAsc, string.Empty)
                        .Replace(Resources.ColumnOrderDesc, string.Empty);

                    string value = this.books.SearchedItems[e.ItemIndex]
                        .GetFormatValue(this.columns[index].FieldType, this.IsCollectSubtitle);
                    listItem.SubItems.Add(value);
                }
            }

            listItem.ImageIndex = this.books.SearchedItems[e.ItemIndex].Favorite ? 0 : -1;
            listItem.StateImageIndex = this.books.SearchedItems[e.ItemIndex].Favorite ? 0 : -1;
            listItem.BackColor = ((e.ItemIndex % 2) == 0) ? Color.FromArgb(240, 255, 240) : Color.FromArgb(255, 255, 255);
            listItem.ForeColor = this.books.SearchedItems[e.ItemIndex].IsDuplicate ? Color.Red : Color.Black;
            e.Item = listItem;
        }

        /// <summary>詳細リストビュー ダブルクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_DoubleClick(object sender, EventArgs e)
        {
            var model = this.GetSelectedBooks()?.FirstOrDefault();

            if (model == null)
            {
                return;
            }
            else if (model.FileExists())
            {
                this.ItemSelected(sender, new ItemEventArgs<BookModel>(model));
                return;
            }

            DialogResult ret = MessageBox.Show(Resources.ErrorFileNotFoundDelete, Application.ProductName, MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                var books = this.GetSelectedBooks();
                books.ToList().ForEach(b => this.books.SearchedItems.Remove(b));

                this?.ItemChanged(sender, new ItemEventArgs<IEnumerable<BookModel>>(null));
            }
        }

        /// <summary>詳細リストビュー ドラッグドロップイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_DragDrop(object sender, DragEventArgs e)
        {
            // 格納されているデータを文字列型配列に変換
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Array.ForEach(files, f => this.Books.Add(f));
            this.ItemChanged(sender, new ItemEventArgs<IEnumerable<BookModel>>(null));
        }

        /// <summary>詳細リストビュー イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_DragEnter(object sender, DragEventArgs e)
        {
            // コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>詳細リストビュー キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DetailListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Alt)
                    {
                        this.PropertyMenuItem_Click(sender, e);
                    }
                    else
                    {
                        this.DetailListView_DoubleClick(sender, e);
                    }

                    break;
                case Keys.F2: // プロパティを開く
                    this.PropertyMenuItem_Click(null, null);
                    break;
                case Keys.F3: // 一括変更
                    this.AllPropertyChangeMenuItem_Click(null, null);
                    break;
                case Keys.F4: // 一括変更再実行
                    var models = (BookList)new BookList();
                    this.GetSelectedBooks().ToList().ForEach(b => models.Add(b));

                    models.ReplaceValue(this.fieldType, this.Search, this.Value);

                    if (Settings.Default.IsAutoSave)
                    {
                        foreach (var model in models)
                        {
                            this.Shelf.FileNames.ChangeFileName(model);
                        }
                    }

                    break;
                case Keys.F5: // 名前を変更する
                    this.BookChangeFileNameMenuItem_Click(null, null);
                    break;
                case Keys.Delete: // 削除
                    this.BookDeleteMenuItem_Click(sender, e);
                    break;
                case Keys.Escape:
                    if (this.books.SearchedItems.IsSeriesMode)
                    {
                        this.ReturnButton_Click(sender, e);
                    }

                    break;
            }
        }
        #endregion

        #region イベントプロシージャ：右クリックメニュー

        /// <summary>プロパティメニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PropertyMenuItem_Click(object sender, EventArgs e)
        {
            var model = this.GetSelectedBooks().FirstOrDefault();

            if (model == null)
            {
                return;
            }

            // プロパティ画面の表示
            using (var dialog = new PropertyDialog() { Book = model, Shelf = this.Shelf })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    var ev = new ItemEventArgs<BookModel>(dialog.Book);
                    this.CoverImagePaint(sender, ev);
                }
            }
        }

        /// <summary>プロパティの一括変更メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void AllPropertyChangeMenuItem_Click(object sender, EventArgs e)
        {
            // ダイアログ表示
            var models = (BookList)new BookList();
            this.GetSelectedBooks().ToList().ForEach(b => models.Add(b));
            using (var form = new SelectChangeForm() { Models = models, Shelf = this.Shelf })
            {
                form.FieldTypeComboBox.SelectedIndex = this.selectChangeSelectedIndex;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.selectChangeSelectedIndex = form.FieldTypeComboBox.SelectedIndex;
                    this.DetailListView.Refresh();
                }
            }
        }

        /// <summary>削除 メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookDeleteMenuItem_Click(object sender, EventArgs e)
        {
            var ret = MessageBox.Show(Resources.InfoIsDeleteBook, Application.ProductName, MessageBoxButtons.YesNoCancel);

            if (ret == DialogResult.Cancel)
            {
                return;
            }

            IEnumerable<BookModel> models = this.GetSelectedBooks();
            if (ret == DialogResult.Yes)
            {
                models = models.Select(m => m.FileDelete());
            }

            this.books.SearchedItems.RemoveRange(models);

            var eventArgs = new ItemEventArgs<IEnumerable<BookModel>>(models);
            this?.ItemChanged(sender, eventArgs);

            this.books.Refresh();
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FavoriteMenuItem_Click(object sender, EventArgs e)
        {
            var models = this.GetSelectedBooks();

            Parallel.ForEach(models, b => b.Favorite = !b.Favorite);

            var eventArgs = new ItemEventArgs<IEnumerable<BookModel>>(models);
            this.ItemChanged(sender, eventArgs);

            this.DetailListView.Refresh();
            this.DetailListView.Update();
        }

        /// <summary>イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileMoveMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.DetailMenuStrip.Close();

            string distFolderPath = e.ClickedItem.Text;

            if (Directory.Exists(e.ClickedItem.Text) == false)
            {
                string message = Resources.ErrorMoveFileNotFound.FormatWith(distFolderPath);
                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DetailListView.SuspendLayout();
            var models = this.GetSelectedBooks().ToList();
            models.ForEach(m => m.FileMove(distFolderPath));

            foreach (var model in models)
            {
                if (!this.books.GetSearchCriterias()[0].Check(model))
                {
                    this.books.SearchedItems.Remove(model);
                }
            }

            this.DetailListView.VirtualListSize = this.books.SearchedItems.Count;

            var eventArgs = new ItemEventArgs<IEnumerable<BookModel>>(models);
            this.ItemChanged(sender, eventArgs);

            this.DetailListView.ResumeLayout();
            this.DetailListView.Refresh();
        }

        /// <summary>他の本棚に移動 メニュークリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookToShelfMenuItem_Click(object sender, EventArgs e)
        {
            var f = new BookToAnotherForm();
            IEnumerable<BookModel> models = this.GetSelectedBooks();
            f.Books = models.DeepCopy().ToList();
            var ret = f.ShowDialog();

            if (ret == DialogResult.Cancel)
            {
                return;
            }

            this.books.SearchedItems.RemoveRange(this.GetSelectedBooks());

            var eventArgs = new ItemEventArgs<IEnumerable<BookModel>>(models);
            this?.ItemChanged(sender, eventArgs);

            this.books.Refresh();
        }

        /// <summary>ファイルの移動 ドロップダウンリスト展開中イベント </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookMoveMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            item.DropDownItems.Clear();

            string filePath = Path.GetDirectoryName(this.Shelf.FilePath);
            item.DropDownItems.Add(filePath);
            Directory.GetDirectories(filePath).ToList().ForEach(folder => item.DropDownItems.Add(folder));
        }

        /// <summary>置き換えメニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookChangeFileNameMenuItem_Click(object sender, EventArgs e)
        {
            var books = this.GetSelectedBooks();
            books.ToList().ForEach(m => this.Shelf.FileNames.ChangeFileName(m));

            var eventArgs = new ItemEventArgs<IEnumerable<BookModel>>(books);
            this.ItemChanged(sender, eventArgs);
        }

        /// <summary>シリーズ名抽出 メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SeriesTitleMenuItem_Click(object sender, EventArgs e)
        {
            string seriesName = this.books.SeriesItems[this.SeriesListView.SelectedIndices[0]].Title;
            SeriesList selectedList = (SeriesList)this.SeriesListView.SelectedIndices.Cast<int>()
                .Select(i => this.books.SeriesItems[i]).ToList();
            seriesName = selectedList.GetBeginWithMatchTitle(seriesName);

            if (seriesName == string.Empty)
            {
                MessageBox.Show(Resources.ErrorSearchTitleError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = Resources.InfoDetailListIsSetTitle.FormatWith(seriesName);
            DialogResult result = MessageBox.Show(this, name, Application.ProductName, MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }

            this.Books.SearchedItems.ToList().ForEach(m => m.ReplaceTitle(seriesName));
            this.Books.Refresh();
        }

        /// <summary>メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CompleteInsertMenuItem_Click(object sender, EventArgs e)
        {
            this.SeriesListView.SelectedIndices.Cast<int>()
                .Select(i => this.books.SeriesItems[i]).ToList().ForEach(m => m.IsComplete = true);
        }

        /// <summary>メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CompleteDeleteMenuItem_Click(object sender, EventArgs e)
        {
            this.SeriesListView.SelectedIndices.Cast<int>()
                .Select(i => this.books.SeriesItems[i]).ToList().ForEach(m => m.IsComplete = false);
        }

        /// <summary>検索 メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            BookModel model = this.GetSelectedBooks()?.FirstOrDefault();

            if (model != null && sender == this.SearchWriterMenuItem)
            {
                this?.SearchSelected(this, new SelectSearchEventArgs(FieldType.Writer, model.Writer));
            }
            else if (model != null && sender == this.SearchTitleMenuItem)
            {
                this?.SearchSelected(this, new SelectSearchEventArgs(FieldType.Title, model.Title));
            }
        }
        #endregion

        #region プライベートメソッド

        /// <summary>現在選択されているモデルを取得します。</summary>
        /// <returns>モデルリスト</returns>
        private BookModel[] GetSelectedBooks()
        {
            if (this.books.SearchedItems.IsSeriesMode == true)
            {
                return this.SeriesListView.SelectedIndices.Cast<int>()
                    .SelectMany(s => this.books.SeriesItems[s].Books).Distinct().ToArray();
            }
            else if (this.DetailListView.SelectedIndices.Count == 0)
            {
                return Enumerable.Empty<BookModel>().ToArray();
            }

            return this.DetailListView.SelectedIndices.Cast<int>().Select(i => this.books.SearchedItems?[i]).ToArray();
        }

        /// <summary>詳細リストビューを表示する</summary>
        private void RefreshDetailList()
        {
            this.DetailListView.SuspendLayout();
            this.SeriesListView.SuspendLayout();

            this.DetailListView.VirtualListSize = this.books.SearchedItems.Count;

            if (this.DetailListView.Items.Count > 0 && this.DetailListView.SelectedIndices.Count == 0)
            {
                this.DetailListView.SelectedIndices.Add(0);
            }

            // フォームの整形
            this.SeriesListView.Dock = DockStyle.Fill;
            this.DetailListView.Visible = true;
            this.SeriesListView.Visible = false;
            if (this.books.IsSeriesMode || this.books.GetSearchCriterias()[0].Value != SearchModel.ALL)
            {
                this.ReturnButton.Enabled = true;
            }
            else
            {
                this.ReturnButton.Enabled = false;
            }

            this.ExitButton.Enabled = true;

            // 表紙表示
            if (this.DetailListView.SelectedIndices.Count > 0)
            {
                BookModel book = this.GetSelectedBooks().FirstOrDefault();
                var eventArgs = new ItemEventArgs<BookModel>(book);
                this.CoverImagePaint?.Invoke(this, eventArgs);
            }

            this.DetailListView.ResumeLayout();
            this.SeriesListView.ResumeLayout();

            Debug.Print("DetailList 詳細リストビュー更新:{0}", this.books.SearchedItems.Count);
        }

        /// <summary>シリーズリストビューを表示する</summary>
        private void RefreshSeriesList()
        {
            this.DetailListView.SuspendLayout();
            this.SeriesListView.SuspendLayout();

            this.SeriesListView.VirtualListSize = this.books.SeriesItems.Count();

            if (this.SeriesListView.Items.Count > 0 && this.SeriesListView.SelectedIndices.Count == 0)
            {
                this.SeriesListView.SelectedIndices.Add(0);
            }

            this.SeriesListView.Dock = DockStyle.Fill;
            this.DetailListView.Visible = false;
            this.SeriesListView.Visible = true;
            this.ReturnButton.Enabled = false;
            this.ExitButton.Enabled = true;

            this.DetailListView.ResumeLayout();
            this.SeriesListView.ResumeLayout();

            Debug.Print("DetailList シリーズリストビュー更新:{0}", this.books.SeriesItems.Count());
        }
        #endregion
    }
}
