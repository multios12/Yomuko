namespace Yomuko.Forms.Main
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Yomuko.Book;
    using Yomuko.Shelf;

    public partial class BookToAnotherForm : Form
    {
        private ShelfModel distShelf;

        /// <summary>本棚データディクショナリ</summary>
        private Dictionary<string, string> shelfDictionary = new Dictionary<string, string>();

        /// <summary>コンストラクタ</summary>
        public BookToAnotherForm()
        {
            this.InitializeComponent();
        }

        public List<BookModel> Books { get; set; }

        #region イベント

        /// <summary>
        /// フォーム読み込みイベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void BookToAnotherForm_Load(object sender, EventArgs e)
        {
            this.ShowShelf();
        }

        private void ShelfListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filePath = Settings.Default.Shelfs[this.ShelfListBox.SelectedIndex];
            if (!Directory.Exists(filePath))
            {
                return;
            }

            this.distShelf = new ShelfModel();
            this.distShelf = this.distShelf.ReadJson(filePath);

            var dirs = Directory.GetDirectories(filePath);
            this.FolderListBox.Items.Clear();
            this.FolderListBox.Items.Add(Path.GetDirectoryName(filePath));
            this.FolderListBox.Items.AddRange(dirs);
            this.FolderListBox.Enabled = true;
        }

        /// <summary>
        /// 開始ボタン クリック イベント
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.StartButton.Visible = false;
                this.ProgressBar.Visible = true;

                string distFolderPath = (string)this.FolderListBox.SelectedItem;

                var index = 0;
                foreach (var b in this.Books)
                {
                    b.FileMove(distFolderPath);

                    this.ProgressBar.Value = index / this.Books.Count() * 100;

                    this.distShelf.Books.Add(b);
                    index++;
                }

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            finally
            {
                this.distShelf.WriteJson();

                this.StartButton.Visible = true;
                this.ProgressBar.Visible = false;
            }
        }
        #endregion

        /// <summary>選択されたファイルによって、フォームを表示する</summary>
        private void ShowShelf()
        {
            this.shelfDictionary.Clear();
            foreach (string filePath in Settings.Default.Shelfs)
            {
                string title = string.Empty;
                try
                {
                    var targetShelf = new ShelfModel();
                    targetShelf = targetShelf.ReadJson(filePath);
                    title = String.IsNullOrEmpty(targetShelf.Title) ? filePath : targetShelf.Title;

                    this.shelfDictionary.Add(filePath, title);
                }
                catch (Exception)
                {
                }

                this.ShelfListBox.Items.Clear();
                foreach (var k in this.shelfDictionary.Values)
                {
                    this.ShelfListBox.Items.Add(k);
                }
            }
        }
    }
}
