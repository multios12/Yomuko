namespace ComicLaunch.Forms.Main
{
    using System;
    using System.Windows.Forms;
    using Book;
    using Properties;

    /// <summary>
    /// 値変更フォーム
    /// </summary>
    public partial class SelectChangeForm : Form
    {
        /// <summary>コンストラクタ</summary>
        public SelectChangeForm()
        {
            this.InitializeComponent();
        }

        /// <summary>モデル</summary>
        public BookList Models { get; set; }

        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (this.FieldTypeComboBox.Text == Resources.Title && this.SearchCombobox.Text == string.Empty)
            {
                MessageBox.Show(Resources.ErrorSelectChangeReplaceStringNotFound, Application.ProductName, MessageBoxButtons.OK);
                return;
            }

            this.Models.ReplaceValue(BookModel.GetFieldType(this.FieldTypeComboBox.Text), this.SearchCombobox.Text, this.cboValue.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 値コンボボックス テキスト変更イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.FieldTypeComboBox.Text)
            {
                case "タイトル":
                    this.SearchCombobox.Enabled = true;
                    break;
                case "著者":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
                case "出版社":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
                case "ジャンル":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
                case "メモ":
                    this.SearchCombobox.Enabled = true;
                    break;
                case "種類":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
                case "撮影者":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
                case "掲載誌":
                    this.SearchCombobox.Text = string.Empty;
                    this.SearchCombobox.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 検索コンボボックス テキスト変更イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SearchComboBox_TextChanged(object sender, EventArgs e)
        {
            this.OK_Button.Enabled = !(this.SearchCombobox.Text.Length == 0 && this.cboValue.Text.Length == 0);
        }
    }
}