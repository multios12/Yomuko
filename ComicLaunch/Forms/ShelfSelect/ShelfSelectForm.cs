namespace ComicLaunch.Forms.ShelfSelect
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using ComicLaunch.Shelf;
    using ComicLaunch.Utils;
    using Microsoft.WindowsAPICodePack.Dialogs;

    /// <summary>
    /// ファイル選択フォーム
    /// </summary>
    public partial class ShelfSelectForm
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShelfSelectForm()
        {
            this.InitializeComponent();
        }

        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        #region イベントプロシージャ

        /// <summary>作成ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.Title = "フォルダを指定してください";

                // フォルダーを開く設定に
                dialog.IsFolderPicker = true;

                // 読み取り専用フォルダ/コントロールパネルは開かない
                dialog.EnsureReadOnly = false;
                dialog.AllowNonFileSystemItems = false;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string filePath = Path.Combine(dialog.FileName, ".yomukodb");
                    Properties.Settings.Default.Shelfs.Add(filePath);

                    this.ShowBooksList();
                }
            }
        }

        /// <summary>フォーム 読み込みイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowBooksList();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print(ex.StackTrace);
            }

            if (this.SelectListView.Items.Count > 0)
            {
                this.SelectListView.Items[0].Selected = true;
            }
        }

        /// <summary>「本棚ファイルリストビュー」ダブルクリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SelectListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectListView.SelectedItems.Count != 0)
            {
                this.FilePath = this.SelectListView.SelectedItems[0].SubItems[1].Text;

                if (!File.Exists(this.FilePath))
                {
                    var shelf = new ShelfModel().ReadXML(this.FilePath);
                    shelf.FilePath = this.FilePath;
                    shelf.Title = "新しい本棚";
                    shelf.Initialize();
                    shelf.BaseFolderPaths.Add(Path.GetDirectoryName(this.FilePath));
                    shelf.WriteXML(this.FilePath);
                }

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        /// <summary>「本棚ファイルリストビュー」キーダウンイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SelectListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectListView_DoubleClick(sender, e);
            }
        }

        /// <summary>「本棚ファイル削除 メニュー」クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Shelfs.Remove(this.SelectListView.SelectedItems[0].SubItems[1].Text);

            if (this.SelectListView.SelectedItems.Count != 0)
            {
                this.ShowBooksList();
            }
        }

        /// <summary>ラベル編集完了イベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void SelectListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            try
            {
                var target = (ListView)sender;

                var filePath = target.Items[e.Item].SubItems[1].Text;
                var shelf = new ShelfModel().ReadXML(filePath);
                shelf.Title = e.Label;
                shelf.WriteXML(filePath);
                this.ShowBooksList();
            }
            catch
            {
                MessageBox.Show(this, "変更できませんでした。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }
        #endregion

        /// <summary>選択されたファイルによって、フォームを表示する</summary>
        private void ShowBooksList()
        {
            this.SelectListView.Items.Clear();

            foreach (string filePath in Properties.Settings.Default.Shelfs)
            {
                string title = string.Empty;
                try
                {
                    var tr = new XmlTextReader(filePath);
                    while (tr.Read())
                    {
                        if (tr.LocalName == "Title")
                        {
                            title = tr.ReadString();

                            if (title.Length == 0)
                            {
                                title = "本棚";
                            }
                        }
                    }

                    tr.Close();
                }
                catch (Exception)
                {
                }

                this.SelectListView.Items.Add(title).SubItems.Add(filePath);
            }
        }
    }
}
