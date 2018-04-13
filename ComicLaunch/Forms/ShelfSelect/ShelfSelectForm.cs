namespace ComicLaunch.Forms.ShelfSelect
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using ComicLaunch.Shelf;
    using ComicLaunch.Utils;

    /// <summary>
    /// ファイル選択フォーム
    /// </summary>
    public partial class ShelfSelectForm
    {
        /// <summary>本棚格納フォルダ</summary>
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Yomuko");

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
            var filePath = Path.Combine(this.folderPath, DateTime.Now.ToString("yyyyMMddHHmmss") + ".bls");

            var shelf = new ShelfModel().ReadXML(filePath);
            shelf.FilePath = filePath;
            shelf.Title = "新しい本棚";
            shelf.Initialize();
            shelf.WriteXML(filePath);
            this.ShowBooksList();
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
            File.Delete(this.SelectListView.SelectedItems[0].SubItems[1].Text);
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
                var distFilePath = Path.Combine(this.folderPath, e.Label + ".bls");
                File.Move(filePath, distFilePath);
                var shelf = new ShelfModel().ReadXML(distFilePath);
                shelf.FilePath = distFilePath;
                shelf.Title = e.Label;
                shelf.WriteXML(distFilePath);
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
            if (!Directory.Exists(this.folderPath))
            {
                Directory.CreateDirectory(this.folderPath);
                return;
            }

            this.SelectListView.Items.Clear();
            var shelfPaths = Directory.GetFiles(this.folderPath).Where(f => Path.GetExtension(f).ToLower() == ".bls");

            foreach (string filePath in shelfPaths)
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
