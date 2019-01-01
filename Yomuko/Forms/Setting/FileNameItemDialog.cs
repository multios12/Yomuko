namespace Yomuko.Forms.Setting
{
    using System;
    using System.ComponentModel;
    using Book;
    using Shelf;

    /// <summary>
    /// ファイル名選択ダイアログ
    /// </summary>
    public partial class FileNameItemDialog
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FileNameItemDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// ファイル名生成モデル
        /// </summary>
        public FileNameModel FileName { get; set; }

        /// <summary>フォーム 読み込みイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileNameItemDialog_Load(object sender, EventArgs e)
        {
            var list = new BindingList<FileNameModel>()
            {
                new FileNameModel { Front = string.Empty, Back = " " },
                new FileNameModel { Front = "(", Back = ") " },
                new FileNameModel { Front = "[", Back = "] " },
                new FileNameModel { Front = "[", Back = "] " },
                new FileNameModel { Front = "第", Back = "巻 " }
            };

            this.SplitterComboBox.DisplayMember = "SampleText";
            this.SplitterComboBox.ValueMember = "FieldType";
            this.SplitterComboBox.DataSource = list;
        }

        /// <summary>OKボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.FileName = (FileNameModel)this.SplitterComboBox.SelectedItem;
            this.FileName.Value = this.txtValueDetail.Text;
            this.FileName.FieldType = (FieldType?)this.FieldTypeComboBox.SelectedItem;
            this.Close();
        }

        /// <summary>OKボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ValueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtValueDetail.Enabled = this.FieldTypeComboBox.Text == string.Empty;
        }
    }
}
