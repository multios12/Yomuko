namespace Yomuko.Forms.Setting
{
    using Book;
    using Properties;
    using Shelf;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>設定フォーム</summary>
    public partial class SettingForm
    {
        /// <summary>ダイアログ</summary>
        private FileNameItemDialog fileNameItemDialog = new FileNameItemDialog();

        /// <summary>コンストラクタ</summary>
        /// <param name="bl">マネージャ</param>
        public SettingForm(ShelfModel bl)
        {
            this.InitializeComponent();

            this.Shelf = bl;
        }

        /// <summary>マネージャ</summary>
        public ShelfModel Shelf { get; set; }

        /// <summary>フォーム 読み込みイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.txtBookListName.Text = this.Shelf.Title;
            this.DuplicateFolderTextBox.Text = this.Shelf.DuplicateFolderPath;

            this.CollectSubTitleCheckBox.Checked = this.Shelf.CollectSubTitle;

            this.BaseFolderTextBox.Text = Path.GetDirectoryName(this.Shelf.FilePath);
            this.AutoSaveCheckBox.Checked = Settings.Default.IsAutoSave;

            this.SetFileNameItems();

            foreach (ColumnModel listItem in this.Shelf.Columns)
            {
                this.ColumnListView.Items.Add(listItem.FieldType.LabelName())
                    .SubItems.Add(listItem.Width.ToString());
            }
        }

        /// <summary>OKボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Shelf.Title = this.txtBookListName.Text;
            this.Shelf.DuplicateFolderPath = this.DuplicateFolderTextBox.Text;

            if (this.Shelf.FileNames.Any(i => i.FieldType == FieldType.Title) == false)
            {
                MessageBox.Show(Resources.InfoAutoAddedTitle, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Shelf.FileNames.Clear();
                this.Shelf.FileNames.Add(new FileNameModel("(", ") ", FieldType.Type, string.Empty));
                this.Shelf.FileNames.Add(new FileNameModel("[", "] ", FieldType.Writer, string.Empty));
                this.Shelf.FileNames.Add(new FileNameModel(string.Empty, " ", FieldType.Title, string.Empty));
                this.Shelf.FileNames.Add(new FileNameModel("第", "巻 ", FieldType.No, string.Empty));
                this.Shelf.FileNames.Add(new FileNameModel(string.Empty, " ", FieldType.SubTitle, string.Empty));
                this.Shelf.FileNames.Add(new FileNameModel("[", "] ", FieldType.ReleaseDate, string.Empty));
            }

            // 詳細リスト
            this.Shelf.Columns.Clear();
            foreach (ListViewItem item in this.ColumnListView.Items)
            {
                var listItem = new ColumnModel(BookModel.GetFieldType(item.Text), Convert.ToInt32(item.SubItems[1].Text));
                this.Shelf.Columns.Add(listItem);
            }

            this.Shelf.CollectSubTitle = this.CollectSubTitleCheckBox.Checked;
            this.Shelf.WriteJson();

            Settings.Default.IsAutoSave = this.AutoSaveCheckBox.Checked;
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        /// <summary>キャンセルボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BaseFolderAddButton_Click(object sender, EventArgs e)
        {
            if (this.dlgFolder.ShowDialog() == DialogResult.OK)
            {
                this.BaseFolderTextBox.Text = this.dlgFolder.SelectedPath;
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileNameAddButton_Click(object sender, EventArgs e)
        {
            this.fileNameItemDialog.FieldTypeComboBox.Items.Clear();
            this.fileNameItemDialog.FieldTypeComboBox.Items.Add(string.Empty);

            foreach (FieldType value in Enum.GetValues(typeof(FieldType)))
            {
                this.fileNameItemDialog.FieldTypeComboBox.Items.Add(value.ToString());
            }

            this.fileNameItemDialog.ShowDialog();
            if (this.fileNameItemDialog.DialogResult == DialogResult.OK)
            {
                var item = (FileNameModel)this.fileNameItemDialog.SplitterComboBox.SelectedItem;
                item.FieldType = (FieldType)Enum.Parse(typeof(FieldType), this.fileNameItemDialog.FieldTypeComboBox.Text);

                item.Value = (item.TypeName == string.Empty) ? this.fileNameItemDialog.txtValueDetail.Text : string.Empty;

                this.Shelf.FileNames.Add(item);
                this.SetFileNameItems();
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileNameDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.FileNameListBox.SelectedIndex != -1)
            {
                this.Shelf.FileNames.Remove(this.Shelf.FileNames[this.FileNameListBox.SelectedIndex]);
                this.SetFileNameItems();
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileNameUpButton_Click(object sender, EventArgs e)
        {
            if (this.FileNameListBox.SelectedIndex > 0)
            {
                FileNameModel item = this.Shelf.FileNames[this.FileNameListBox.SelectedIndex];
                var index = this.FileNameListBox.SelectedIndex;
                this.Shelf.FileNames.Remove(this.Shelf.FileNames[this.FileNameListBox.SelectedIndex]);
                this.Shelf.FileNames.Insert(this.FileNameListBox.SelectedIndex - 1, item);
                this.SetFileNameItems();
                this.FileNameListBox.SelectedIndex = index - 1;
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void FileNameDownButton_Click(object sender, EventArgs e)
        {
            if (this.FileNameListBox.SelectedIndex < this.FileNameListBox.Items.Count - 1)
            {
                FileNameModel item = this.Shelf.FileNames[this.FileNameListBox.SelectedIndex];
                var index = this.FileNameListBox.SelectedIndex;
                this.Shelf.FileNames.Remove(this.Shelf.FileNames[this.FileNameListBox.SelectedIndex]);
                this.Shelf.FileNames.Insert(this.FileNameListBox.SelectedIndex + 1, item);
                this.SetFileNameItems();
                this.FileNameListBox.SelectedIndex = index + 1;
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ColumnAddButton_Click(object sender, EventArgs e)
        {
            using (var dlgColumnSelect1 = new ColumnDialog())
            {
                var i = ((FieldType[])Enum.GetValues(typeof(FieldType))).Select(f => f.LabelName()).ToArray();
                dlgColumnSelect1.TypeComboBox.Items.AddRange(i);

                if (dlgColumnSelect1.ShowDialog() == DialogResult.OK)
                {
                    this.ColumnListView.Items.Add(BookModel.GetFieldType(dlgColumnSelect1.TypeComboBox.Text).LabelName())
                    .SubItems.Add("100");
                }
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ColumnDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.ColumnListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.ColumnListView.SelectedItems)
                {
                    item.Remove();
                }
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ColumnUpButton_Click(object sender, EventArgs e)
        {
            if (this.ColumnListView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.ColumnListView.SelectedItems[0];
                var index = this.ColumnListView.SelectedIndices[0];

                if (index == 0)
                {
                    return;
                }

                this.ColumnListView.SelectedItems[0].Remove();
                this.ColumnListView.Items.Insert(index - 1, item);
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void ColumnDownButton_Click(object sender, EventArgs e)
        {
            if (this.ColumnListView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.ColumnListView.SelectedItems[0];
                var index = this.ColumnListView.SelectedIndices[0];

                if (this.ColumnListView.Items.Count - 1 <= index)
                {
                    return;
                }

                this.ColumnListView.SelectedItems[0].Remove();
                this.ColumnListView.Items.Insert(index + 1, item);
            }
        }

        /// <summary>ボタンクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DuplicateFolderChangeButton_Click(object sender, EventArgs e)
        {
            if (this.dlgFolder.ShowDialog() == DialogResult.OK)
            {
                this.DuplicateFolderTextBox.Text = this.dlgFolder.SelectedPath;
            }
        }

        /// <summary>チェックボックス チェック状態変更イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DuplicateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.DuplicateFolderTextBox.Enabled = this.DuplicateCheckBox.Checked;
            this.DuplicateFolderChangeButton.Enabled = this.DuplicateCheckBox.Checked;
        }

        /// <summary>
        /// ファイル名項目リストの値表示を更新します。
        /// </summary>
        private void SetFileNameItems()
        {
            this.FileNameListBox.Items.Clear();
            this.FileNameTextBox.Text = @"フォルダ\";

            foreach (FileNameModel item in this.Shelf.FileNames)
            {
                string value;

                if (string.IsNullOrEmpty(item.TypeName))
                {
                    value = item.Front + item.Value + item.Back;
                }
                else
                {
                    value = item.Front + item.TypeName.ToString() + item.Back;
                }

                this.FileNameListBox.Items.Add(value);
                this.FileNameTextBox.Text = this.FileNameTextBox.Text + value;
            }

            this.FileNameTextBox.Text = this.FileNameTextBox.Text + ".拡張子";
        }
    }
}
