namespace Viewer
{
    using System;
    using System.Windows.Forms;
    using Control;

    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class ViewerForm : Form
    {
        /// <summary>コンストラクタ</summary>
        public ViewerForm()
        {
            this.InitializeComponent();
        }

        /// <summary>選択アイテム変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureList1_SelectedItemChanged(object sender, ArchiveMovedEventArgs e)
        {
            // int nextIndex = DetailList.DetailListIndex + e.Direction;

            // if (nextIndex >= 0 && nextIndex < DetailList.Books.SearchedItems.Count)
            // {
            //    DetailList.DetailListIndex = nextIndex;
            //    e.NextFileName = DetailList.Books.SearchedItems[nextIndex].FilePath;
            // }
        }

        /// <summary>キーダウン発生前イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureList1_UserPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // switch (e.KeyCode)
            // {
            //    case Keys.F2:
            //        this.DetailList.ShowPropertyDialog();
            //        break;
            // }
        }

        /// <summary>ブックマーク追加イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureList1_BookmarkAdded(object sender, PageEventArgs e)
        {
            // var model = this.shelf.Books.FirstOrDefault(b => b.FilePath == e.FilePath);

            // if (model != null)
            // {
            //    BookmarkModel bookmark = new BookmarkModel(model.Hash, e.PageIndex);
            //    this.shelf.Bookmarks.Add(bookmark);
            // }
        }

        /// <summary>クローズイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureList1_ArchiveClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// リスト移動イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PictureList1_ArchiveMoved(object sender, ArchiveMovedEventArgs e)
        {
            Application.Exit();
        }
    }
}
