namespace Yomuko.Forms.ShelfSelect
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using Yomuko.Shelf;

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
        public string ShelfPath { get; set; }

        #region イベントプロシージャ

        /// <summary>作成ボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "フォルダを指定してください";

                if (Settings.Default.Shelfs == null)
                {
                    Settings.Default.Shelfs = new List<string>();
                }

                // 読み取り専用フォルダ/コントロールパネルは開かない
                // dialog.EnsureReadOnly = false;
                // dialog.AllowNonFileSystemItems = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.Shelfs.Add(dialog.SelectedPath);

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
                var shelf = new ShelfModel().ReadJson(this.SelectListView.SelectedItems[0].SubItems[1].Text);
                this.ShelfPath = shelf.FilePath;

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
            Settings.Default.Shelfs.Remove(this.SelectListView.SelectedItems[0].SubItems[1].Text);

            if (this.SelectListView.SelectedItems.Count != 0)
            {
                this.ShowBooksList();
            }

            Settings.Default.Save();
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
                var shelf = new ShelfModel().ReadJson(filePath);
                shelf.Title = e.Label;
                shelf.WriteJson();
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

            if (Settings.Default.Shelfs == null)
            {
                return;
            }

            foreach (string filePath in Settings.Default.Shelfs)
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

        private void SelectListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (files.Where(f => Directory.Exists(f)).Count() > 0)
                {
                    e.Effect = DragDropEffects.Link;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void SelectListView_DragDrop(object sender, DragEventArgs e)
        {
            if (Settings.Default.Shelfs == null)
            {
                Settings.Default.Shelfs = new List<string>();
            }

            foreach (var f in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                Settings.Default.Shelfs.Add(f);
            }

            this.ShowBooksList();
        }
    }
}
