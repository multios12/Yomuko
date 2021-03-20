namespace Yomuko.Forms.Main
{
    using Book;
    using Forms.Main.Control;
    using Forms.Setting;
    using Image;
    using Properties;
    using Shelf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Yomuko.Forms.Sync;

    /// <summary>メインフォーム</summary>
    public partial class MainForm : Form
    {
        /// <summary>GroupTypeに選択されているインデックス</summary>
        private int selectedGroupTypeIndex;

        /// <summary>ページサイズを変更するためのメニューアイテム</summary>
        private Dictionary<PageSizeConstants, ToolStripMenuItem> pageSizeMenuItems;

        /// <summary>管理クラス</summary>
        private ShelfModel shelf;

        /// <summary>検索結果リスト</summary>
        private BookList finds = new BookList();

        /// <summary>コンストラクタ</summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.pageSizeMenuItems = new Dictionary<PageSizeConstants, ToolStripMenuItem>()
            {
                { PageSizeConstants.Fit, this.smiFit }, { PageSizeConstants.FitWidth, this.smiFitWidth },
                { PageSizeConstants.Percent050, this.smiPercent050 }, { PageSizeConstants.Percent075, this.smiPercent075 },
                { PageSizeConstants.Percent100, this.smiPercent100 }, { PageSizeConstants.Percent150, this.smiPercent150 },
                { PageSizeConstants.Percent200, this.smiPercent200 }, { PageSizeConstants.Percent300, this.smiPercent300 },
                { PageSizeConstants.Percent400, this.smiPercent400 }
            };

            DetailVerticalContainer.Panel2Collapsed = true;
            this.DetailList.ItemShown += this.DetailList_ItemShown;
            this.DetailList.ItemChanged += this.DetailList_ItemChanged;
            this.DetailList.ItemPropertyShown += this.DetailList_ItemPropertyShown;
            this.DetailList.ItemSelected += DetailList_ItemSelected;
        }

        private void DetailList_ItemPropertyShown(object sender, ItemEventArgs<BookModel> e)
        {
            this.innerProperty1.Books = new List<BookModel>() { e.Item };
            this.DetailVerticalContainer.Panel2Collapsed = false;
            this.innerProperty1.InitialFocus();
        }

        private void DetailList_ItemSelected(object sender, ItemEventArgs<BookModel> e)
        {
            if(!this.DetailVerticalContainer.Panel2Collapsed)
            {
                this.innerProperty1.Books = new List<BookModel>() { e.Item };
            }
        }

        /// <summary>
        /// フォームをモーダルダイアログとして表示します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>結果</returns>
        public DialogResult ShowDialog(string filePath)
        {
            this.shelf = new ShelfModel().ReadJson(filePath);
            this.shelf.FilePath = filePath;

            return this.ShowDialog();
        }

        #region イベントプロシージャ

        /// <summary>フォーム読込イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Debug.Print("FormLoad開始-----------------------------------");

            Application.ThreadException += this.Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;

            // ファインダ種別
            this.cboFinderType.Items.AddRange(Enum.GetValues(typeof(FieldType)).Cast<FieldType>().Select(f => f.LabelName()).ToArray());
            this.cboFinderType.SelectedIndex = 0;

            // グループ種類
            this.GroupTypeComboBox.Items.AddRange(new string[]
            {
                FieldType.Writer.LabelName() + "別",
                FieldType.Junle.LabelName() + "別",
                FieldType.PublishingCompany.LabelName() + "別",
                FieldType.CarryMagazine.LabelName() + "別",
                FieldType.Photographer.LabelName() + "別",
                FieldType.ReleaseDate.LabelName() + "別",
                FieldType.CreateDate.LabelName() + "別",
                FieldType.UpdateDate.LabelName() + "別",
                FieldType.FilePath.LabelName() + "別"
            });
            this.GroupTypeComboBox.SelectedIndex = 0;

            // カバー表示
            this.picCover.Image = null;

            Debug.Print("FormLoad2-----------------------------------");

            // フォームの整形
            if (this.shelf.Columns.Count == 0)
            {
                this.shelf.Columns.Add(new ColumnModel(FieldType.Type, 100));
                this.shelf.Columns.Add(new ColumnModel(FieldType.Title, 200));
                this.shelf.Columns.Add(new ColumnModel(FieldType.Writer, 100));
                this.shelf.Columns.Add(new ColumnModel(FieldType.Junle, 100));
                this.shelf.Columns.Add(new ColumnModel(FieldType.ReleaseDate, 100));
            }

            this.Text = Resources.Title + this.shelf.Title;
            this.SetImageSize(this.shelf.PageSize);

            this.CollectTitleMenuItem.Checked = this.shelf.CollectSubTitle;

            this.DetailList.RefreshColumns(this.shelf.Columns);

            // ファイルリスト
            this.ShowFileListMenuItem_Click(null, null);

            // 検索フィルタ
            this.ShowSearchFilterMenuItem_Click(null, null);

            // ファイルリストｓ
            this.ShowFileListMenuItem_Click(null, null);
            this.shelf.Books.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));
            this.finds = this.shelf.Books.SearchedItems;
            Debug.Print("FormLoad6.2-----------------------------------");

            this.GroupTypeComboBox_DropDownClosed(null, null);
            Debug.Print("FormLoad7-----------------------------------");

            this.DetailList.Focus();

            this.DetailList.Shelf = this.shelf;
            this.DetailList.Books = this.finds.SearchedItems;
            this.DetailList.CoverImagePaint += this.DetailList_CoverImagePaint;
            this.shelf.Books.SearchCriteriasChanged += this.Books_SearchItemsChanged;
            this.finds.PropertyChanged += this.Finds_PropertyChanged;
            this.innerProperty1.ItemChanged += this.InnerProperty_ItemChanged;
            Debug.Print("FormLoad完了-----------------------------------");
            this.DetailList.IsLoaded = true;
        }

        /// <summary>
        /// アプリケーション 補足されなかった例外イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (this.shelf == null && !File.Exists(this.shelf.FilePath))
            {
                return;
            }

            var logPath = Path.Combine(Path.GetDirectoryName(this.shelf.FilePath), "error.log");
            var ex = (Exception)e.ExceptionObject;
            File.AppendAllText(logPath, ex.Message + "\r\n" + ex.StackTrace + "\r\n");
            throw ex;
        }

        /// <summary>
        /// アプリケーション 補足されなかった例外イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (this.shelf == null && !File.Exists(this.shelf.FilePath))
            {
                return;
            }

            var logPath = Path.Combine(Path.GetDirectoryName(this.shelf.FilePath), "error.log");
            var ex = e.Exception;
            File.AppendAllText(logPath, ex.Message + "\r\n" + ex.StackTrace + "\r\n");
            throw ex;
        }

        /// <summary>フォームクローズイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.shelf == null)
            {
                return;
            }

            Application.ThreadException -= this.Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException -= this.CurrentDomain_UnhandledException;

            this.shelf.Columns = this.DetailList.GetColumns();
            this.shelf.WriteJson();

            Settings.Default.MainSplit = this.MainSplitContainer.SplitterDistance;
            Settings.Default.SideFilePanel = this.MainSplitContainer.Panel1Collapsed;
            Settings.Default.Save();
        }

        /// <summary>グループリストボックス キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupListBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.DetailList.Focus();
                    break;
                case Keys.Escape:
                    this.ActiveControl = this.GroupTypeComboBox;
                    break;
            }
        }

        /// <summary>グループリストボックス 選択インデックス変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((string)this.GroupListBox.SelectedItem) != Resources.GroupAll)
            {
                var gourpName = this.GroupTypeComboBox.Text.Replace("別", string.Empty);
                var searchType = BookModel.GetFieldType(gourpName);
                var model = new SearchModel(searchType, this.GroupListBox.Text);
                this.finds.RefreshSearchCriterias(model);
            }
            else
            {
                this.finds.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));
            }

            this.DetailList.Refresh();

            Debug.Print($"GroupListBox 選択値:{this.GroupListBox.Text}");
        }

        /// <summary>種別コンボボックス キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeCombobox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    this.GroupListBox.Focus();
                    break;
            }
        }

        /// <summary>種別コンボボックス ドロップダウンクローズイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.finds.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));

            var gourpName = this.GroupTypeComboBox.Text.Replace("別", string.Empty);
            var searchType = BookModel.GetFieldType(gourpName);

            this.GroupListBox.Items.Clear();
            if (searchType == FieldType.Favorite)
            {
                this.GroupListBox.Items.Add(Resources.Favorite);
            }
            else
            {
                this.GroupListBox.Items.Add(Resources.GroupAll);
                this.GroupListBox.Items.AddRange(this.finds.GetCollectValues(searchType).ToArray());
            }

            this.GroupListBox.SelectedIndex = 0;
            this.selectedGroupTypeIndex = this.GroupTypeComboBox.SelectedIndex;
        }

        /// <summary>種別コンボボックス フォーカス喪失イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeComboBox_Leave(object sender, EventArgs e)
        {
            if (this.selectedGroupTypeIndex != this.GroupTypeComboBox.SelectedIndex)
            {
                this.GroupTypeComboBox_DropDownClosed(null, null);
            }
        }

        /// <summary>全件 検索状態変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Books_SearchItemsChanged(object sender, EventArgs e)
        {
            this.GroupTypeComboBox_DropDownClosed(sender, e);
        }

        /// <summary>検索結果 プロパティイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Finds_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.DetailList.Books == null)
            {
                return;
            }

            if (e.PropertyName == nameof(this.finds.SearchedItems))
            {
                this.DetailList.IsCollectSubtitle = this.shelf.CollectSubTitle;

                var a = (MethodInvoker)delegate
                {
                    this.sslInfomation.Text = Resources.Information.FormatWith(this.DetailList.Books.SearchedItems.Count, this.shelf.Books.Count);
                };

                this.Invoke(a);
            }
        }
        #endregion

        #region イベントプロシージャ 詳細表示

        /// <summary>詳細表示：ブックマーク表示イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_BookmarksShown(object sender, EventArgs e)
        {
            // ブックマークのハッシュチェック
            List<string> hashs = this.shelf.Books.Select(b => b.Hash).ToList();
            hashs.Sort();

            this.shelf.Bookmarks = this.shelf.Bookmarks.Where(b => hashs.BinarySearch(b.Hash) >= 0).ToList();
            this.BookmarkList1.SetBookmarkList(this.shelf.Bookmarks);

            // しおりリストの表示
            this.smiBookmark.Checked = true;
            this.MainSplitContainer.Visible = false;
            this.BookmarkList1.Visible = true;
        }

        /// <summary>詳細表示：選択イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_ItemShown(object sender, ItemEventArgs<BookModel> e)
        {
            if (!this.DetailVerticalContainer.Panel2Collapsed)
            {
                this.innerProperty1.Books = new List<BookModel>() { e.Item };
            }

            this.ShowArchive(e.Item.FilePath);
        }

        /// <summary>詳細表示：変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_ItemChanged(object sender, ItemEventArgs<IEnumerable<BookModel>> e)
        {
            foreach (var model in e.Item)
            {
                if (!this.finds.GetSearchCriterias()[0].Check(model))
                {
                    this.finds.Remove(model, true);
                }
            }

            this.shelf.WriteJson();
        }

        /// <summary>詳細表示：モード変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_SeriesModeChanged(object sender, EventArgs e)
        {
            this.CollectTitleMenuItem.Checked = !this.CollectTitleMenuItem.Checked;
            this.DetailList.IsCollectSubtitle = this.shelf.CollectSubTitle;
        }

        /// <summary>詳細表示：イメージ変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_CoverImagePaint(object sender, ItemEventArgs<BookModel> e)
        {
            Debug.Print($"DetailList_CoverImagePaint:Start:{e.Item.CoverFileIndex}");
            if (e.Item == null || File.Exists(e.Item.FilePath) == false)
            {
                this.picCover.Image = null;
                return;
            }

            try
            {
                using (var archiveBook = new ArchiveModel(e.Item.FilePath))
                {
                    archiveBook.ResizeHeight = this.picCover.Height;
                    archiveBook.ResizeWidth = this.picCover.Width;
                    archiveBook.DrawHeight = this.picCover.Height;
                    archiveBook.DrawWidth = this.picCover.Width;
                    archiveBook.PageIndex = e.Item.CoverFileIndex;
                    this.picCover.Image = archiveBook.PagePicture;
                    this.picCover.Tag = e.Item;
                }
            }
            catch (Exception ex)
            {
                this.picCover.Image = null;
            }
            Debug.Print("DetailList_CoverImagePaint:End");
        }

        /// <summary>詳細表示：キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.ActiveControl = this.GroupListBox;
                    break;
            }
        }

        /// <summary>詳細表示：検索イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_SearchSelected(object sender, SelectSearchEventArgs e)
        {
            this.cboFinderType.SelectedItem = e.FieldType.LabelName();
            this.SearchFinderComboBox.Text = e.Value;
            this.SearchFinderComboBox_LostFocus(sender, null);
            this.GroupListBox.Focus();

            // 検索フィルタ表示
            this.spcDetail.Panel1Collapsed = false;
            this.ShowSearchFilterMenuItem.Checked = true;
        }
        #endregion

        #region イベントプロシージャ 表示

        /// <summary>ブックマーク表示：選択イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookmarkList1_BookmarkSelected(object sender, ItemEventArgs<BookmarkModel> e)
        {
            BookModel book = this.shelf.Books.FirstOrDefault(b => b.Hash == e.Item.Hash);

            if (book == null)
            {
                return;
            }

            this.ShowArchive(book.FilePath, e.Item.PageIndex);

            this.shelf.Bookmarks = this.BookmarkList1.Bookmarks;
            this.shelf.WriteJson();
        }

        /// <summary>ブックマーク表示：非表示選択イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookmarkList1_ControlClosed(object sender, EventArgs e)
        {
            this.shelf.Bookmarks = this.BookmarkList1.Bookmarks;
            this.shelf.WriteJson();
            this.smiBookmark.Checked = false;
            this.MainSplitContainer.Visible = true;
            this.BookmarkList1.Visible = false;
        }
        #endregion

        #region イベントプロシージャ メニュー

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void OptionMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm(this.shelf);
            DialogResult result = setting.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.DetailList.RefreshColumns(this.shelf.Columns);
                this.finds.Refresh();
            }
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SyncBaseFolderMenuItem_Click(object sender, EventArgs e)
        {
            // ベースフォルダのチェック
            var workFolders = new List<string> { Path.GetDirectoryName(this.shelf.FilePath) };

            // ベースフォルダの確認
            var failedBaseFolders = workFolders.Where(b => Directory.Exists(b) == false);
            if (failedBaseFolders.Count() > 0)
            {
                string message = string.Join(Environment.NewLine, failedBaseFolders);
                string.Format(Resources.ErrorBookListBaseFolderNotFound, message);

                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            // 同期直前のデータ保存
            this.shelf.Columns = this.DetailList.GetColumns();
            this.shelf.WriteJson();

            this.shelf = null;
            this.DialogResult = DialogResult.Retry;
            this.Close();

            using (var form = new SyncForm())
            {
                form.Owner = this;
                this.Enabled = false;
                form.Show(workFolders[0]);
                this.Enabled = true;
            }
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookListChangeMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void EndMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ShowFileListMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.SideFilePanel = !this.ShowFileListMenuItem.Checked;
            Settings.Default.Save();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DisplayAllMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == this.ToolStripMenuItem1)
            {
                this.smiDisplayAll.Checked = this.ToolStripMenuItem1.Checked;
            }
            else
            {
                this.ToolStripMenuItem1.Checked = this.smiDisplayAll.Checked;
            }

            if (this.smiDisplayAll.Checked)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ShowSearchFilterMenuItem_Click(object sender, EventArgs e)
        {
            this.spcDetail.Panel1Collapsed = !this.ShowSearchFilterMenuItem.Checked;
            this.cboFinderType.Focus();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookMarkListMenuItem_Click(object sender, EventArgs e)
        {
            // ブックマークのハッシュチェック
            this.BookmarkList1.SetBookmarkList(this.shelf.Bookmarks);

            // しおりリストの表示
            this.MainSplitContainer.Visible = false;
            this.BookmarkList1.Visible = true;
        }

        /// <summary>メニュー：しおり一覧表示</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkListMenuItem_Click(object sender, EventArgs e)
        {
            if (this.smiBookmark.Checked == false)
            {
                this.DetailList_BookmarksShown(null, null);
            }
        }
        #endregion

        #region イベントプロシージャ 検索ボックス

        /// <summary>検索種別コンボボックス フォーカスキーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SearchFinderCombobox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    this.SearchFinderComboBox_LostFocus(sender, e);
                    this.GroupListBox.Focus();
                    break;
            }
        }

        /// <summary>検索種別コンボボックス フォーカス喪失イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SearchFinderComboBox_LostFocus(object sender, EventArgs e)
        {
            var searchItem = new SearchModel(BookModel.GetFieldType(this.cboFinderType.Text), this.SearchFinderComboBox.Text);
            this.shelf.Books.RefreshSearchCriterias(searchItem);
        }

        /// <summary>検索ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SearchFinderClearButton_Click(object sender, EventArgs e)
        {
            this.cboFinderType.SelectedIndex = 0;
            this.SearchFinderComboBox.Text = string.Empty;
            this.SearchFinderComboBox_LostFocus(sender, e);
            this.GroupListBox.Focus();
        }
        #endregion

        /// <summary>指定されたファイルを表示します。</summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="pageIndex">インデックス</param>
        private void ShowArchive(string filePath, int pageIndex = 0)
        {
            Process p = new Process();
            p.StartInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            p.StartInfo.FileName = Path.GetDirectoryName(p.StartInfo.FileName);
            p.StartInfo.FileName = Path.Combine(p.StartInfo.FileName, "yomuko.exe");
            p.StartInfo.Arguments = string.Format(@"""{0}"" {1}", filePath, pageIndex);

            p.Start();
            p.WaitForExit();
        }

        /// <summary>画像サイズをフォームに設定します。</summary>
        /// <param name="value">サイズ</param>
        private void SetImageSize(PageSizeConstants value)
        {
            this.pageSizeMenuItems.Values.ToList().ForEach(m => m.Checked = false);
            this.shelf.PageSize = value;
            this.pageSizeMenuItems[value].Checked = true;
        }

        private void picCover_MouseDown(object sender, MouseEventArgs e)
        {
            //マウスの左ボタンだけが押されている時のみドラッグできるようにする
            if (e.Button == MouseButtons.Left)
            {

                var model = (BookModel)this.picCover.Tag;
                using (var s = ArchiveImagerHelper.GetStream(model.FilePath, model.CoverFileIndex))
                {
                    var b = new System.Drawing.Bitmap(s);
                    var dataObj = new DataObject();
                    dataObj.SetData(DataFormats.Bitmap, s);
                    picCover.DoDragDrop(picCover.Image, DragDropEffects.Copy);
                }

            }
            else
            {
            }
        }

        private void smiCoverCopy_Click(object sender, EventArgs e)
        {
            var model = (BookModel)this.picCover.Tag;
            using (var s = ArchiveImagerHelper.GetStream(model.FilePath, model.CoverFileIndex))
            {
                var b = new System.Drawing.Bitmap(s);
                // 画像データをクリップボードにコピーする
                Clipboard.SetImage(b);
            }



        }

        private void smiCoverPaste_Click(object sender, EventArgs e)
        {
            //クリップボードにあるデータの取得
            System.Drawing.Image img = Clipboard.GetImage();
            var model = (BookModel)this.picCover.Tag;
            if (img != null)
            {
                var a = new ArchiveModel(model.FilePath);
                a.SetCover(img);

                try
                {
                    model.CoverFileIndex = 0;
                    using (var archiveBook = new ArchiveModel(model.FilePath))
                    {
                        archiveBook.ResizeHeight = this.picCover.Height;
                        archiveBook.ResizeWidth = this.picCover.Width;
                        archiveBook.DrawHeight = this.picCover.Height;
                        archiveBook.DrawWidth = this.picCover.Width;
                        archiveBook.PageIndex = model.CoverFileIndex;
                        this.picCover.Image = archiveBook.PagePicture;
                    }
                }
                catch (Exception ex)
                {
                    this.picCover.Image = null;
                }
            }
        }

        private void cmsCover_Opening(object sender, CancelEventArgs e)
        {
            System.Drawing.Image img = Clipboard.GetImage();
            this.smiCoverPaste.Enabled = (img != null);

        }

        private void InnerProperty_ItemChanged(object sender, ItemEventArgs<BookModel> e)
        {
            if (e.Item == null)
            {
                this.DetailVerticalContainer.Panel2Collapsed = true;
                this.DetailList.Focus();
                return;
            }

            this.shelf.FileNames.ChangeFileName(e.Item);
            this.DetailList.Refresh();
            this.DetailList.Focus();
        }
    }
}
