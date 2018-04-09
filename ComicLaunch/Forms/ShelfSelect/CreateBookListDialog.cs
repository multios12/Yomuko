namespace ComicLaunch.Forms.ShelfSelect
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Properties;

    /// <summary>
    /// ファイル作成ダイアログ
    /// </summary>
    public partial class CreateBookListDialog : Form
    {
        /// <summary>コンストラクタ</summary>
        public CreateBookListDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        /// <summary>タイトル</summary>
        public string Title { get; set; }

        /// <summary>
        /// OKボタン クリックイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.FilePathTextBox.Text))
            {
                DialogResult ret = MessageBox.Show(Resources.InfoMoveExistsWhatsOverride, string.Empty, MessageBoxButtons.YesNo);

                if (ret != DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }

            this.FilePath = this.FilePathTextBox.Text;
            this.Title = this.TitleTextBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// キャンセルボタン クリックイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ファイルオープンボタン クリックイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.dlgFile.Title = "作成する場所を指定してください";
            this.dlgFile.ShowDialog();
            if (this.dlgFile.FileName.Length != 0)
            {
                this.FilePathTextBox.Text = this.dlgFile.FileName;
            }
        }
    }
}
