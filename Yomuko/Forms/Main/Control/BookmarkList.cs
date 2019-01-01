namespace Yomuko.Forms.Main.Control
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Book;
    using Image;

    /// <summary>
    /// ブックマークリスト
    /// </summary>
    public partial class BookmarkList
    {
        /// <summary>コントロールクローズイベント</summary>
        public event EventHandler ControlClosed;

        /// <summary>選択 イベント</summary>
        public event EventHandler<ItemEventArgs<BookmarkModel>> ItemSelected;

        /// <summary>ブックマークリスト</summary>
        [Browsable(false), DefaultValue(null)]
        public List<BookmarkModel> Bookmarks { get; private set; }

        /// <summary>リスト</summary>
        [Browsable(false), DefaultValue(null)]
        public BookList Books { get; set; }

        /// <summary>ブックマークリストセット</summary>
        /// <param name="bookmarks">ブックマークリスト</param>
        public void SetBookmarkList(List<BookmarkModel> bookmarks)
        {
            this.Bookmarks = bookmarks;
            this.BookmarkListView.Items.Clear();
            this.picCover.Image = null;

            foreach (BookmarkModel bookmark in this.Bookmarks)
            {
                foreach (BookModel book in this.Books.Where(b => b.Hash == bookmark.Hash))
                {
                    var item = new ListViewItem(book.GetFormatValue(FieldType.Title, true));
                    item.SubItems.Add(bookmark.PageIndex.ToString());
                    item.SubItems.Add(book.Writer);
                    item.SubItems.Add(bookmark.CreateDate);
                    this.BookmarkListView.Items.Add(item);
                    break;
                }
            }
        }

        #region イベントプロシージャ

        /// <summary>リストビュー ダブルクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.BookmarkListView.SelectedItems.Count != 0)
            {
                this.ItemSelected(this, new ItemEventArgs<BookmarkModel>(this.GetSelectedModel()));
            }
        }

        /// <summary>リストビュー キーアップイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.ControlClosed(this, new EventArgs());
                    break;
                case Keys.Return:
                    this.ItemSelected(this, new ItemEventArgs<BookmarkModel>(this.GetSelectedModel()));
                    break;
                case Keys.Delete:
                    this.DeleteMenuItem_Click(null, null);
                    break;
            }
        }

        /// <summary>リストビュー 選択インデックス変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookmarkListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = this.GetSelectedModel();
            var filePath = this.Books.Where(c => c.Hash == model?.Hash).FirstOrDefault()?.FilePath;
            if (filePath == null)
            {
                this.picCover.Image = null;
                return;
            }

            try
            {
                var archiveBook = new ArchiveModel(filePath, this.picCover.Height, this.picCover.Width)
                {
                    PageIndex = model.PageIndex
                };
                this.picCover.Image = archiveBook.PagePicture;
            }
            catch (Exception)
            {
                this.picCover.Image = null;
            }
        }

        /// <summary>戻るボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.ControlClosed(this, new EventArgs());
        }

        /// <summary>削除メニューアイテム クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            this.Bookmarks.Remove(this.GetSelectedModel());
            this.BookmarkListView.Items[this.BookmarkListView.SelectedIndices[0]].Remove();
        }
        #endregion

        /// <summary>選択されたモデルを返します。</summary>
        /// <returns>モデル</returns>
        private BookmarkModel GetSelectedModel()
        {
            return (this.BookmarkListView.SelectedItems.Count == 0) ? null : this.Bookmarks[this.BookmarkListView.SelectedIndices[0]];
        }
    }
}
