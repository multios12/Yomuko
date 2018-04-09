namespace ComicLaunch.Forms.Setting
{
    using System;
    using Models.Book;

    /// <summary>列選択ダイアログ</summary>
    public partial class ColumnDialog
    {
        /// <summary>コンストラクタ</summary>
        public ColumnDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>フォーム読込イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ColumnDialog_Load(object sender, EventArgs e)
        {
            this.TypeComboBox.Items.Clear();

            foreach (FieldType item in Enum.GetValues(typeof(FieldType)))
            {
                this.TypeComboBox.Items.Add(item.LabelName());
            }
        }

        /// <summary>OKボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>キャンセルボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
