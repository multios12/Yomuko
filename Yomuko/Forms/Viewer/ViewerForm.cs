namespace Yomuko.Forms.Viewer
{
    using SharpCompress.Archives;
    using System;
    using System.Windows.Forms;

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

        private void ViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                // 画像データをクリップボードにコピーする
                Clipboard.SetImage(this.pictureList1.Picture);
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                //クリップボードにあるデータの取得
                System.Drawing.Image img = Clipboard.GetImage();
                if (img != null)
                {
                    //データが取得できたときは表示する
                    this.pictureList1.SetCover(img);
                }
            } else if (e.KeyCode == Keys.Enter)
            {
                if (!e.Control)
                {
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
            }
        }

        private void ViewerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
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
