namespace ComicLaunch.Form
{
    using System;
    using System.IO;
    using Image;
    using Model;

    /// <summary>
    /// プロパティダイアログ
    /// </summary>
    public partial class PropertyDialog
    {
        /// <summary>圧縮</summary>
        private ArchiveModel archiveBook;

        /// <summary>コンストラクタ</summary>
        public PropertyDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>情報</summary>
        public BookModel Book { get; set; }

        /// <summary>OKボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.Book.Title = this.cboTitle.Text;
            this.Book.SubTitle = this.SubTitleTextBox.Text;
            this.Book.Writer = this.cboWriter.Text;
            this.Book.PublishingCompany = this.cboPublisher.Text;
            this.Book.Junle = this.txtJunle.Text;
            this.Book.Memo = this.txtMemo.Text;
            this.Book.UpdateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.Book.No = this.txtNO.Text;
            this.Book.Type = this.cboBookType.Text;
            this.Book.IsComplete = this.CompleteCheckBox.Checked;

            this.Book.CoverFileIndex = (int)this.CoverIndexUpDown.Value;

            if (this.FavoriteCheckBox.Checked)
            {
                this.Book.Favorite = true;
            }
            else
            {
                this.Book.Favorite = false;
            }

            if (this.Book.Type.IndexOf("写真集") > -1)
            {
                this.Book.Photographer = this.cboPhotographer.Text;
            }
            else
            {
                if (this.Book.Type.IndexOf("コミック") > -1)
                {
                    this.Book.CarryMagazine = this.cboPhotographer.Text;
                }

                if (DateTime.TryParse(this.SaleDateTextBox.Text, out DateTime d))
                {
                    this.Book.ReleaseDate = this.SaleDateTextBox.Text;
                }

                this.Close();
            }
        }

        /// <summary>キャンセルボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>フォーム読込イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void PropertyDialog_Load(object sender, EventArgs e)
        {
            this.cboTitle.Text = this.Book.Title;
            this.cboWriter.Text = this.Book.Writer;
            this.SubTitleTextBox.Text = this.Book.SubTitle;
            this.cboPublisher.Text = this.Book.PublishingCompany;
            this.txtFilePath.Text = this.Book.FilePath;
            this.txtJunle.Text = this.Book.Junle;

            if (this.Book.Favorite)
            {
                this.FavoriteCheckBox.Checked = true;
            }
            else
            {
                this.FavoriteCheckBox.Checked = false;
            }

            this.BookTypeComboBox_TextChanged(sender, e);
            this.txtMemo.Text = this.Book.Memo;
            this.txtHash.Text = this.Book.Hash;
            this.txtNO.Text = this.Book.No;
            this.cboPhotographer.Text = this.Book.Photographer;

            this.cboBookType.Text = this.Book.Type;
            if (this.Book.Type?.IndexOf("写真集") > -1)
            {
                this.cboPhotographer.Text = this.Book.Photographer;
            }
            else
            {
                if (this.Book.Type?.IndexOf("コミック") > -1)
                {
                    this.cboPhotographer.Text = this.Book.CarryMagazine;
                }

                if (DateTime.TryParse(this.Book.ReleaseDate, out DateTime d))
                {
                    this.SaleDateTextBox.Text = this.Book.ReleaseDate;
                }

                this.CompleteCheckBox.Checked = this.Book.IsComplete;

                // 画像表示の準備
                try
                {
                    if (this.Book.FilePath.Length == 0 || !File.Exists(this.Book.FilePath))
                    {
                        this.archiveBook = null;
                        return;
                    }
                    else
                    {
                        this.archiveBook = new ArchiveModel(this.Book.FilePath)
                        {
                            DrawHeight = this.picCover.Height,
                            DrawWidth = this.picCover.Width,
                            ResizeHeight = this.picCover.Height,
                            ResizeWidth = this.picCover.Width
                        };

                        // 画像表示処理
                        this.CoverIndexUpDown.Maximum = this.archiveBook.PageCount - 1;
                        if (int.TryParse(this.Book.CoverFileIndex.ToString(), out int fileIndex))
                        {
                            this.archiveBook.PageIndex = fileIndex;
                            this.CoverIndexUpDown.Value = fileIndex;
                        }
                        else
                        {
                            this.archiveBook.PageIndex = 0;
                        }
                    }
                }
                catch
                {
                }

                this.CoverIndexUpDown_ValueChanged(sender, e);
            }
        }

        /// <summary>フォーカス喪失イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SaleDateTextBox_LostFocus(object sender, EventArgs e)
        {
        }

        /// <summary>解析ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void AnalyzeFileNameButton_Click(object sender, EventArgs e)
        {
            var tmpBook = new BookModel(this.Book.FilePath);

            foreach (FieldType fieldType in Enum.GetValues(typeof(FieldType)))
            {
                this.Book.SetValue(fieldType, tmpBook.GetValue(fieldType));
                this.PropertyDialog_Load(sender, e);
            }
        }

        /// <summary>解析ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (this.cboBookType.Text.IndexOf("写真集") > -1)
            {
                this.lblWriter.Text = "モデル";
                this.lblPhotographer.Text = "撮影者";
                this.lblPhotographer.Visible = true;
                this.cboPhotographer.Visible = true;
            }
            else
            {
                if (this.cboBookType.Text.IndexOf("コミック") > -1)
                {
                    this.lblWriter.Text = "著者";
                    this.lblPhotographer.Text = "掲載誌";
                    this.lblPhotographer.Visible = true;
                    this.cboPhotographer.Visible = true;
                }
                else
                {
                    this.lblWriter.Text = "著者";
                    this.lblPhotographer.Visible = false;
                    this.cboPhotographer.Visible = false;
                }
            }
        }

        /// <summary>解析ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CoverIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.archiveBook == null)
            {
                return;
            }

            this.archiveBook.PageIndex = (int)this.CoverIndexUpDown.Value;
            this.picCover.Image = this.archiveBook.PagePicture;
            this.picCover.Refresh();
        }
    }
}
