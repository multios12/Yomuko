namespace Yomuko.Forms.Viewer
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Yomuko.Image;

    /// <summary>
    /// ファイルリスト付き、圧縮ファイル内画像表示コントロール
    /// </summary>
    public partial class PictureList
    {
        /// <summary>圧縮ファイル操作クラス</summary>
        private ArchiveModel archiveBook;

        /// <summary>設定されたページサイズを保持する</summary>
        private PageSizeConstants pageSize;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PictureList()
        {
            this.InitializeComponent();
        }

        /// <summary>クローズ発生イベント</summary>
        public event EventHandler ArchiveClosed;

        /// <summary>書籍移動イベント</summary>
        public event EventHandler<ArchiveMovedEventArgs> ArchiveMoved;

        /// <summary>ユーザ操作 プレビューキーダウンイベント</summary>
        public event PreviewKeyDownEventHandler UserPreviewKeyDown;

        /// <summary>ブックマーク追加イベント</summary>
        public event EventHandler<PageEventArgs> BookmarkAdded;

        /// <summary>ファイルパネルを表示</summary>
        public bool IsEnabledSideFilePanel { get; set; }

        /// <summary>ファイルリストが表示されている場合、Trueを返します。</summary>
        public bool IsVisibledFileList
        {
            get
            {
                return this.spcMain.Panel1Collapsed;
            }

            set
            {
                this.spcMain.Panel1Collapsed = value;
            }
        }

        /// <summary>表示される画像のサイズを設定・取得する</summary>
        public PageSizeConstants PageSize
        {
            get
            {
                return this.pageSize;
            }

            set
            {
                this.pageSize = value;

                if (this.archiveBook == null)
                {
                    return;
                }

                this.archiveBook.DrawHeight = this.PagePictureBox.Height;
                this.archiveBook.DrawWidth = this.PagePictureBox.Width;
                this.archiveBook.SetPageSize(value, this.PagePictureBox.Height, this.PagePictureBox.Width);
                this.archiveBook.PageIndex = this.archiveBook.PageIndex;
                this.DrawPicture(this.PagePictureBox);
            }
        }

        /// <summary>指定されたファイルを表示します</summary>
        /// <param name="path">`ファイルのパス</param>
        /// <param name="pageIndex">ページインデックス</param>
        /// <returns>正常に終了した場合、True</returns>
        public bool ShowArchive(string path, int pageIndex = 0)
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    return false;
                }

                this.archiveBook = new ArchiveModel(path, this.PagePictureBox.Height, this.PagePictureBox.Width);
                this.archiveBook.SetPageSize(this.pageSize, this.PagePictureBox.Height, this.PagePictureBox.Width);

                this.archiveBook.PageIndex = (pageIndex == -1) ? this.archiveBook.PageCount - 1 : pageIndex;

                this.spcMain.Panel1Collapsed = this.IsEnabledSideFilePanel;
                this.DrawPicture(this.PagePictureBox);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.FileListBox.Items.Clear();
            this.archiveBook.EntryNames.ToList().ForEach(e => this.FileListBox.Items.Add(e));
            this.FileListBox.SelectedIndex = (pageIndex == -1) ? this.archiveBook.PageCount - 1 : pageIndex;

            this.ActiveControl = this.PagePictureBox;
            this.Visible = true;
            return true;
        }

        #region イベントプロシージャ 画像表示

        /// <summary>ページ ダブルクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PagePictureBox_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = false;

            this.ArchiveClosed?.Invoke(this, new EventArgs());
        }

        /// <summary>ページ マウスクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PagePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.PagePictureBox.Focus();
        }

        /// <summary>ページ マウスホイールイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PagePictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < -1)
            {
                this.DrawPicture(this.PagePictureBox, +1);
            }
            else if (e.Delta > 1)
            {
                this.DrawPicture(this.PagePictureBox, -1);
            }

            this.PagePictureBox.Refresh();
            this.FileListBox.SelectedIndex = this.archiveBook.PageIndex;
        }

        /// <summary>ページ プレビューキーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PagePictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.PagePictureBox_DoubleClick(sender, e);
                    break;
                case Keys.PageDown:
                    this.DrawPicture(this.PagePictureBox, +1);
                    this.PagePictureBox.Refresh();
                    this.FileListBox.SelectedIndex = this.archiveBook.PageIndex;
                    break;
                case Keys.PageUp:
                    this.DrawPicture(this.PagePictureBox, -1);
                    this.PagePictureBox.Refresh();
                    this.FileListBox.SelectedIndex = this.archiveBook.PageIndex;
                    break;
                default:
                    this.UserPreviewKeyDown(sender, e);
                    break;
            }
        }

        /// <summary>ページ サイズ変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PagePictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.archiveBook != null)
            {
                this.PageSize = this.pageSize;

                this.DrawPicture(this.PagePictureBox);
            }
        }

        /// <summary>ファイルリストボックス キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.FileListBox.SelectedIndex != -1)
                {
                    this.archiveBook.PageIndex = this.FileListBox.SelectedIndex;
                    this.DrawPicture(this.PagePictureBox);
                    this.PagePictureBox.Refresh();
                }

                this.ActiveControl = this.PagePictureBox;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.PagePictureBox_DoubleClick(sender, e);
            }
        }

        /// <summary>ファイルリストボックス マウスクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileListBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.archiveBook.PageIndex = this.FileListBox.SelectedIndex;
            this.DrawPicture(this.PagePictureBox);
            this.PagePictureBox.Refresh();
        }
        #endregion

        /// <summary>ブックマーク追加メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void AddBookmarkMenuItem_Click(object sender, EventArgs e)
        {
            PageEventArgs eventArgs = new PageEventArgs(this.archiveBook.FilePath, this.archiveBook.PageIndex);
            this.BookmarkAdded(sender, eventArgs);
            this.Visible = false;
            this.ArchiveClosed(this, new EventArgs());
        }

        /// <summary>終了メニュー クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ArchiveClosed(this, new EventArgs());
        }

        /// <summary>
        /// 指定したピクチャボックスに画像を表示します。
        /// </summary>
        /// <param name="picture">画像を表示するピクチャボックス</param>
        /// <param name="direction">
        /// 0を指定した場合、現在の画像をそのまま表示する
        /// 正の値を指定した場合次の画像を表示する
        /// 負の値を指定した場合は前の画像を表示する
        /// </param>
        private void DrawPicture(PictureBox picture, int direction = 0)
        {
            int ret = this.archiveBook.Scroll(direction);
            if (ret == -1)
            {
                string filePath = string.Empty;
                this.ArchiveMoved(this, new ArchiveMovedEventArgs(direction, filePath));

                this.ShowArchive(filePath, direction < 0 ? -1 : 0);
            }

            this.PagePictureBox.Image = this.archiveBook.PagePicture;
        }
    }
}