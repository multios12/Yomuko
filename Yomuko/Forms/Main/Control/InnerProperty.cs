namespace Yomuko.Forms.Main.Control
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Yomuko.Book;

    public partial class InnerProperty : UserControl
    {

        private List<BookModel> archiveBooks;

        /// <summary>プロパティ表示イベント</summary>
        public event EventHandler<ItemEventArgs<BookModel>> ItemChanged;

        /// <summary>情報</summary>
        public List<BookModel> Books
        {
            get
            {
                return this.archiveBooks;
            }
            set
            {
                this.archiveBooks = value;

                if (this.archiveBooks == null || this.archiveBooks.Count == 0)
                {
                    return;
                }

                this.AutoSaveCheckBox.Checked = Settings.Default.IsAutoSave;

                this.txtFilePath.Enabled = this.archiveBooks.Count == 1;
                this.txtHash.Enabled = this.archiveBooks.Count == 1;
                this.cboTitle.Enabled = this.archiveBooks.Count == 1;
                this.txtHash.Enabled = this.archiveBooks.Count == 1;

                if (this.archiveBooks.Count == 1)
                {
                    var book = this.archiveBooks[0];
                    this.txtFilePath.Text = book.FilePath;
                    this.txtHash.Text = book.Hash;

                    this.cboTitle.Text = book.Title;
                    this.txtNO.Text = book.No;

                    this.cboWriter.Text = book.Writer;
                    this.SubTitleTextBox.Text = book.SubTitle;
                    this.cboPublisher.Text = book.PublishingCompany;
                    this.txtJunle.Text = book.Junle;

                    this.FavoriteCheckBox.Checked = book.Favorite;

                    this.txtMemo.Text = book.Memo;

                    this.AutoSaveCheckBox.Checked = Settings.Default.IsAutoSave;

                    this.BookTypeComboBox.Text = book.Type;
                    this.SaleDateTextBox.Text = book.ReleaseDate;
                }

                this.txtFilePath.Tag = this.txtFilePath.Text;
                this.txtHash.Tag = this.txtHash.Text;

                this.cboTitle.Tag = this.cboTitle.Text;
                this.txtNO.Tag = this.txtNO.Text;

                this.cboWriter.Tag = this.cboWriter.Text;
                this.SubTitleTextBox.Tag = this.SubTitleTextBox.Text;
                this.cboPublisher.Tag = this.cboPublisher.Text;
                this.txtJunle.Tag = this.txtJunle.Text;

                this.txtMemo.Tag = this.txtMemo.Text;

                this.BookTypeComboBox.Tag = this.BookTypeComboBox.Text;


            }
        }

        public InnerProperty()
        {
            InitializeComponent();
        }

        #region パブリックメソッド
            public void InitialFocus()
            {
                this.BookTypeComboBox.Focus();
            }
        #endregion


        private void InnerProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!e.Control)
                {
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                this.NoButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                this.OK_Button_Click(null, null);
            }
        }

        private void InnerProperty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }

        private void InnerProperty_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>OKボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {

            if (this.archiveBooks.Count == 1)
            {

                this.archiveBooks[0].Title = this.cboTitle.Text.Trim();
                this.archiveBooks[0].SubTitle = this.SubTitleTextBox.Text.Trim();
                this.archiveBooks[0].Writer = this.cboWriter.Text.Trim();
                this.archiveBooks[0].PublishingCompany = this.cboPublisher.Text.Trim();
                this.archiveBooks[0].Junle = this.txtJunle.Text.Trim();
                this.archiveBooks[0].Memo = this.txtMemo.Text.Trim();
                this.archiveBooks[0].UpdateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                this.archiveBooks[0].No = this.txtNO.Text.Trim();
                this.archiveBooks[0].Type = this.BookTypeComboBox.Text.Trim();

                this.archiveBooks[0].Favorite = this.FavoriteCheckBox.Checked;
            }

            Settings.Default.IsAutoSave = this.AutoSaveCheckBox.Checked;
            Settings.Default.Save();


            if (DateTime.TryParse(this.SaleDateTextBox.Text, out DateTime d))
            {
                this.archiveBooks[0].ReleaseDate = this.SaleDateTextBox.Text.Trim();
            }
            else
            {
                this.archiveBooks[0].ReleaseDate = string.Empty;
            }

            this.ItemChanged(this, new ItemEventArgs<BookModel>(archiveBooks[0]));
        }

        /// <summary>キャンセルボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            this.ItemChanged(this, new ItemEventArgs<BookModel>(null));
        }
    }
}
