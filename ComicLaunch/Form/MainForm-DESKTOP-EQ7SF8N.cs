namespace CLibrary.Form
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Control;
    using Image;
    using Model;
    using Model.Shelf;
    using Properties;
    using Utils;

    /// <summary>メインフォーム</summary>
    public partial class MainForm : Form
    {
        /// <summary>GroupTypeに選択されているインデックス</summary>
        private int selectedGroupTypeIndex;

        private Dictionary<PageSizeConstants, ToolStripMenuItem> pageSizeMenuItems;

        /// <summary>管理クラス</summary>
        private ShelfModel shelf;

        /// <summary>検索結果リスト</summary>
        private BookList finds = new BookList();

        /// <summary>処理中ダイアログ</summary>
        private WaitDialog waitDialog;

        /// <summary>コンストラクタ</summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.pageSizeMenuItems = new Dictionary<PageSizeConstants, ToolStripMenuItem>() {
                {PageSizeConstants.Fit, smiFit }, {PageSizeConstants.FitWidth, smiFitWidth },
                {PageSizeConstants.Percent050, smiPercent050 }, {PageSizeConstants.Percent075, smiPercent075 },
                {PageSizeConstants.Percent100, smiPercent100 }, {PageSizeConstants.Percent150, smiPercent150 },
                {PageSizeConstants.Percent200, smiPercent200 }, {PageSizeConstants.Percent300, smiPercent300 },
                {PageSizeConstants.Percent400, smiPercent400 }
            };

            this.DetailList.ItemSelected += this.DetailList_ItemSelected;
            this.DetailList.CoverImagePaint += this.DetailList_CoverImagePaint;
            this.DetailList.ItemChanged += this.DetailList_ItemChanged;
        }

        /// <summary>
        /// フォームをモーダルダイアログとして表示します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>結果</returns>
        public DialogResult ShowDialog(string filePath)
        {
            this.shelf = (new ShelfModel()).ReadXML(filePath);
            this.shelf.FilePath = filePath;

            return this.ShowDialog();
        }

        #region イベントプロシージャ

        /// <summary>フォーム読込イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ファインダ種別
            cboFinderType.Items.AddRange(Enum.GetValues(typeof(FieldType)).Cast<FieldType>().Select(f => f.LabelName()).ToArray());
            cboFinderType.SelectedIndex = 0;

            // グループ種類
            GroupTypeComboBox.Items.AddRange(new string[]
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
            GroupTypeComboBox.SelectedIndex = 0;

            this.shelf.Books.Refresh();
            this.shelf.Books.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));
            this.finds = this.shelf.Books.SearchedItems;
            this.finds.PropertyChanged += this.Finds_PropertyChanged;

            DetailList.Shelf = this.shelf;
            this.DetailList.CoverImagePaint += this.DetailList_CoverImagePaint;
            DetailList.Books = this.finds.SearchedItems;
            this.shelf.Books.SearchCriteriasChanged += this.Books_SearchItemsChanged;
            this.shelf.Books.SyncStatusChanged += this.Books_SyncStatusChanged;

            // カバー表示
            picCover.Image = null;

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

            CollectTitleMenuItem.Checked = this.shelf.CollectSubTitle;

            DetailList.RefreshColumns(this.shelf.Columns);

            // ファイルリスト
            this.ShowFileListMenuItem_Click(null, null);

            // 検索フィルタ
            this.ShowSearchFilterMenuItem_Click(null, null);

            // ファイルリスト
            this.ShowFileListMenuItem_Click(null, null);

            this.GroupTypeComboBox_DropDownClosed(null, null);

            DetailList.Focus();
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

            this.shelf.Columns = DetailList.GetColumns();
            this.shelf.WriteXML(this.shelf.FilePath);

            Settings.Default.MainSplit = MainSplitContainer.SplitterDistance;
            Settings.Default.SideFilePanel = MainSplitContainer.Panel1Collapsed;
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
                    DetailList.Focus();
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
            if (((string)GroupListBox.SelectedItem) != Resources.GroupAll)
            {
                var gourpName = GroupTypeComboBox.Text.Replace("別", string.Empty);
                var searchType = BookModel.GetFieldType(gourpName);
                var model = new SearchModel(searchType, GroupListBox.Text);
                this.finds.RefreshSearchCriterias(model);
            }
            else
            {
                this.finds.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));
            }
            this.DetailList.Refresh();

            Debug.Print("GroupListBox 選択値:{0}", GroupListBox.Text);
        }

        /// <summary>種別コンボボックス キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeCombobox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    GroupListBox.Focus();
                    break;
            }
        }

        /// <summary>種別コンボボックス ドロップダウンクローズイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.finds.RefreshSearchCriterias(new SearchModel(FieldType.Title, SearchModel.ALL));

            var gourpName = GroupTypeComboBox.Text.Replace("別", string.Empty);
            var searchType = BookModel.GetFieldType(gourpName);

            GroupListBox.Items.Clear();
            if (searchType == FieldType.Favorite)
            {
                GroupListBox.Items.Add(Resources.Favorite);
            }
            else
            {
                GroupListBox.Items.Add(Resources.GroupAll);
                GroupListBox.Items.AddRange(this.finds.GetCollectValues(searchType).ToArray());
            }

            GroupListBox.SelectedIndex = 0;
            this.selectedGroupTypeIndex = GroupTypeComboBox.SelectedIndex;
        }

        /// <summary>種別コンボボックス フォーカス喪失イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void GroupTypeComboBox_Leave(object sender, EventArgs e)
        {
            if (this.selectedGroupTypeIndex != GroupTypeComboBox.SelectedIndex)
            {
                this.GroupTypeComboBox_DropDownClosed(null, null);
            }
        }

        /// <summary>全件 同期状態変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Books_SyncStatusChanged(object sender, SyncStatusEventArgs e)
        {
            if (this.waitDialog.IsAborting)
            {
                e.Cancel = true;
                return;
            }

            // 進行状況ダイアログの表示
            this.waitDialog.Invoke((MethodInvoker)delegate
                {

                    this.waitDialog.SubMessage = string.Empty;
                    this.waitDialog.ProgressMessage = string.Format("{0} / {1}", e.ProgressIndex, e.ProgressCount);
                    this.waitDialog.ProgressMax = e.ProgressCount;
                    this.waitDialog.ProgressValue = e.ProgressIndex;
                });
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
            if (e.PropertyName == nameof(this.finds.SearchedItems))
            {
                DetailList.IsCollectSubtitle = this.shelf.CollectSubTitle;
                this.Invoke(
                    (MethodInvoker)delegate ()
                    {
                        sslInfomation.Text = Resources.Information.FormatWith(DetailList.Books.SearchedItems.Count, this.shelf.Books.Count);
                    });
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
            BookmarkList1.SetBookmarkList(this.shelf.Bookmarks);

            // しおりリストの表示
            smiBookmark.Checked = true;
            MainSplitContainer.Visible = false;
            BookmarkList1.Visible = true;
        }

        /// <summary>詳細表示：選択イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_ItemSelected(object sender, ItemEventArgs<BookModel> e)
        {
            this.ShowArchive(e.Item.FilePath);
        }

        /// <summary>詳細表示：変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_ItemChanged(object sender, ItemEventArgs<IEnumerable<BookModel>> e)
        {
            foreach(var model in e.Item)
            {
                if(!this.finds.GetSearchCriterias()[0].Check(model))
                {
                    finds.Remove(model);
                }
            }
            finds.Refresh();
            this.shelf.WriteXML(this.shelf.FilePath);
        }

        /// <summary>詳細表示：モード変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_SeriesModeChanged(object sender, EventArgs e)
        {
            CollectTitleMenuItem.Checked = !CollectTitleMenuItem.Checked;
            DetailList.IsCollectSubtitle = this.shelf.CollectSubTitle;
        }

        /// <summary>詳細表示：イメージ変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DetailList_CoverImagePaint(object sender, ItemEventArgs<BookModel> e)
        {
            if (File.Exists(e.Item.FilePath) == false)
            {
                picCover.Image = null;
                return;
            }

            try
            {
                using (var archiveBook = new ArchiveModel(e.Item.FilePath))
                {
                    archiveBook.ResizeHeight = picCover.Height;
                    archiveBook.ResizeWidth = picCover.Width;
                    archiveBook.DrawHeight = picCover.Height;
                    archiveBook.DrawWidth = picCover.Width;
                    archiveBook.PageIndex = e.Item.CoverFileIndex;
                    picCover.Image = archiveBook.PagePicture;
                }
            }
            catch
            {
                picCover.Image = null;
            }
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
            cboFinderType.SelectedItem = e.FieldType.LabelName();
            SearchFinderComboBox.Text = e.Value;
            this.SearchFinderComboBox_LostFocus(sender, null);
            GroupListBox.Focus();

            // 検索フィルタ表示
            spcDetail.Panel1Collapsed = false;
            ShowSearchFilterMenuItem.Checked = true;
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

            this.shelf.Bookmarks = BookmarkList1.Bookmarks;
            this.shelf.WriteXML(this.shelf.FilePath);
        }

        /// <summary>ブックマーク表示：非表示選択イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookmarkList1_ControlClosed(object sender, EventArgs e)
        {
            this.shelf.Bookmarks = BookmarkList1.Bookmarks;
            this.shelf.WriteXML(this.shelf.FilePath);
            smiBookmark.Checked = false;
            MainSplitContainer.Visible = true;
            BookmarkList1.Visible = false;
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
                DetailList.RefreshColumns(this.shelf.Columns);
                this.finds.Refresh();
            }
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private async void SyncBaseFolderMenuItem_Click(object sender, EventArgs e)
        {
            // ベースフォルダのチェック
            this.shelf.BaseFolderPaths.Sort();
            var workFolders = new List<string>();
            workFolders.AddRange(this.shelf.BaseFolderPaths.Where(f => !workFolders.Any(w => f.IndexOf(w) >= 0)));

            // ベースフォルダの確認
            var failedBaseFolders = workFolders.Where(b => Directory.Exists(b) == false);
            if (failedBaseFolders.Count() > 0)
            {
                string message = string.Join(Environment.NewLine, failedBaseFolders);
                string.Format(Resources.ErrorBookListBaseFolderNotFound, message);
                MessageBox.Show(message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            this.waitDialog = new WaitDialog();
            this.waitDialog.Owner = this;
            this.waitDialog.MainMessage = Resources.BookListSyncingBaseFolder;

            this.Enabled = false;
            this.waitDialog.Show();

            await Task.Run(() => this.shelf.Books.SyncBaseFolder(workFolders, this.shelf.DuplicateFolderPath));
            this.shelf.WriteXML(this.shelf.FilePath);

            this.Enabled = true;
            this.waitDialog.Close();
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
            Settings.Default.SideFilePanel = !ShowFileListMenuItem.Checked;
            Settings.Default.Save();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DisplayAllMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == this.ToolStripMenuItem1)
            {
                smiDisplayAll.Checked = ToolStripMenuItem1.Checked;
            }
            else
            {
                ToolStripMenuItem1.Checked = smiDisplayAll.Checked;
            }

            if (smiDisplayAll.Checked)
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
            spcDetail.Panel1Collapsed = !ShowSearchFilterMenuItem.Checked;
            cboFinderType.Focus();
        }

        /// <summary>メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BookMarkListMenuItem_Click(object sender, EventArgs e)
        {
            // ブックマークのハッシュチェック
            BookmarkList1.SetBookmarkList(this.shelf.Bookmarks);

            // しおりリストの表示
            MainSplitContainer.Visible = false;
            BookmarkList1.Visible = true;
        }

        /// <summary>メニュー：しおり一覧表示</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkListMenuItem_Click(object sender, EventArgs e)
        {
            if (smiBookmark.Checked == false)
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
                    GroupListBox.Focus();
                    break;
            }
        }

        /// <summary>検索種別コンボボックス フォーカス喪失イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SearchFinderComboBox_LostFocus(object sender, EventArgs e)
        {
            var searchItem = new SearchModel(BookModel.GetFieldType(cboFinderType.Text), SearchFinderComboBox.Text);
            this.shelf.Books.RefreshSearchCriterias(searchItem);
        }

        /// <summary>検索ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SearchFinderClearButton_Click(object sender, EventArgs e)
        {
            cboFinderType.SelectedIndex = 0;
            SearchFinderComboBox.Text = string.Empty;
            this.SearchFinderComboBox_LostFocus(sender, e);
            GroupListBox.Focus();
        }
        #endregion

        /// <summary>指定されたファイルを表示します。</summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="pageIndex">インデックス</param>
        private void ShowArchive(string filePath, int pageIndex = 0)
        {
            Process p = new Process();
            p.StartInfo.FileName = "CLibrary.exe";
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

        private void picCover_Resize(object sender, EventArgs e)
        {
        }
    }
}
