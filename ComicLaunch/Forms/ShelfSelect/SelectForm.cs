namespace ComicLaunch.Forms.ShelfSelect
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using Models.Shelf;
    using Properties;
    using Utils;

    /// <summary>
    /// ファイル選択フォーム
    /// </summary>
    public partial class SelectForm
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectForm()
        {
            this.InitializeComponent();
        }

        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        /// <summary>シェルフリスト</summary>
        private StringCollection Shelfs
        {
            get
            {
                Settings.Default.Shelfs = Settings.Default.Shelfs ?? new StringCollection();
                return Settings.Default.Shelfs;
            }
        }

        #region イベントプロシージャ

        /// <summary>読み込みボタン クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            this.dlgFile.ShowDialog();

            if (!File.Exists(this.dlgFile.FileName))
            {
                return;
            }

            if (this.Shelfs.Contains(this.dlgFile.FileName) == false)
            {
                this.Shelfs.Add(this.dlgFile.FileName);
                Settings.Default.Save();
                this.ShowBooksList();
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

        /// <summary>「本棚ファイルの作成ボタン」クリックイベント</summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateBookListDialog dialog = new CreateBookListDialog();

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var shelf = new ShelfModel().ReadXML(dialog.FilePath);
                shelf.FilePath = dialog.FilePath;
                shelf.Title = dialog.Title;
                shelf.Initialize();
                shelf.WriteXML(dialog.FilePath);

                this.Shelfs.Add(shelf.FilePath);
                this.ShowBooksList();
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
            if (this.SelectListView.SelectedItems.Count != 0)
            {
                this.Shelfs.Remove(this.SelectListView.SelectedItems[0].SubItems[1].Text);
                this.ShowBooksList();
                Settings.Default.Save();
            }
        }
        #endregion

        /// <summary>選択されたファイルによって、フォームを表示する</summary>
        private void ShowBooksList()
        {
            if (this.Shelfs == null)
            {
                return;
            }

            this.SelectListView.Items.Clear();

            foreach (string filePath in this.Shelfs)
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
