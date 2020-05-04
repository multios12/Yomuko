namespace Yomuko.Forms.Sync
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using Yomuko.Book;
    using Yomuko.Image;
    using Yomuko.Shelf;
    using Yomuko.Sync;

    public partial class SyncForm : Form
    {
        private string _basePath;
        private ShelfSyncHelper helper;
        private string _errorValue = string.Empty;
        private Shelf.ShelfModel shelf;


        /// <summary>ベースパス</summary>
        public string BasePath
        {
            get
            {
                return _basePath;
            }
            set
            {
                this._basePath = value;
            }
        }
        public SyncForm()
        {
            InitializeComponent();
        }

        public void Show(string basePath)
        {
            this.BasePath = basePath;
            base.ShowDialog();
        }

        private void outputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => this.ResultTextBox.Text += e.Data + Environment.NewLine));

            if (e.Data == null)
            {
                return;
            }

            var values = e.Data.Split(">");

            if (values[0] == "ファイルの重複有")
            {
                this.Invoke((MethodInvoker)(() => this.DuplicateListBox.Items.Add(values[1])));
            }
            else if (values[0] == "ファイルは存在しない")
            {
                this.Invoke((MethodInvoker)(() => this.NotFoundListBox.Items.Add(values[1])));
            }
            else if (values[0] == "ファイル")
            {
                var counts = values[1].Split(",");
                counts[0] = counts[0].Replace("書籍ファイル総数:", string.Empty);
                counts[1] = counts[1].Replace("新規・変更数:", string.Empty);
                this.Invoke((MethodInvoker)(() =>
                    {
                        this.toolStripStatusLabel1.Text = $"同期ファイル数:{counts[1]}";
                        this.toolStripProgressBar1.Maximum = int.Parse(counts[1]);
                    }));
                return;
            } else if (values[0] == "正常に追加された" || values[0] == "同期未実施") {

                }
                else
            {
                Debug.WriteLine("");
            }

            if (this.toolStripProgressBar1.Maximum > this.toolStripProgressBar1.Value)
            {
                this.Invoke((MethodInvoker)(() => this.toolStripProgressBar1.Value += 1));
            }
        }

        private void errorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this._errorValue += e.Data;
        }

        private void exited(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() => this.ResultTextBox.Text += this._errorValue));
            this.Invoke((MethodInvoker)(() =>
            {
                this.toolStripStatusLabel1.Text = $"同期完了";
            }));

        this.shelf = new ShelfModel();
            this.shelf = this.shelf.ReadJson(this.BasePath);
        }
        private void SyncForm_Load(object sender, EventArgs e)
        {
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox3.Dock = DockStyle.Fill;
            this.MenuListBox.SelectedIndex = 0;
        }

        private void SyncForm_Shown(object sender, EventArgs e)
        {
            this.helper = new ShelfSyncHelper();
            this.helper.OutputDataReceivedEvent += outputDataReceived;
            this.helper.ErrorDataReceivedEvent += errorDataReceived;
            this.helper.ExitedEvent += exited;
            Task.Run(() =>
            {
                this.helper.SyncBasePath(this._basePath);
            });
        }

        private void MenuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)MenuListBox.SelectedItem == "同期結果")
            {
                this.groupBox1.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;

            }
            else if ((string)MenuListBox.SelectedItem == "同一ファイル")
            {
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = true;
                this.groupBox3.Visible = false;

            }
            else if ((string)MenuListBox.SelectedItem == "ファイルが存在しない本")
            {
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = true;
            }
        }

        /// <summary>
        /// 重複リストボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DuplicateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBook = new BookModel((String)DuplicateListBox.SelectedItem);

            var books = shelf.Books.Where((b) => b.Hash == selectedBook.Hash);
            books = books.Where(b => Path.GetFullPath(b.FilePath).ToLower() != Path.GetFullPath(selectedBook.FilePath).ToLower());

            if (books.Count() == 0)
            {
                File1Textbox.Text = string.Empty;
                return;
            }

            File1Textbox.Text = books.FirstOrDefault().FilePath;
            using (var archiveBook = new ArchiveModel(selectedBook.FilePath))
            {
                archiveBook.ResizeHeight = this.pictureBox1.Height;
                archiveBook.ResizeWidth = this.pictureBox1.Width;
                archiveBook.DrawHeight = this.pictureBox1.Height;
                archiveBook.DrawWidth = this.pictureBox1.Width;
                archiveBook.PageIndex = selectedBook.CoverFileIndex;
                this.pictureBox1.Image = archiveBook.PagePicture;
            }
            using (var archiveBook = new ArchiveModel(books.FirstOrDefault().FilePath))
            {
                archiveBook.ResizeHeight = this.pictureBox2.Height;
                archiveBook.ResizeWidth = this.pictureBox2.Width;
                archiveBook.DrawHeight = this.pictureBox2.Height;
                archiveBook.DrawWidth = this.pictureBox2.Width;
                archiveBook.PageIndex = books.FirstOrDefault().CoverFileIndex;
                this.pictureBox2.Image = archiveBook.PagePicture;
            }
        }


        private void SelectAllDuplicateButton_Click(object sender, EventArgs e)
        {

        }

        private void DuplicateMoveButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "移動先フォルダを指定してください";

                // 読み取り専用フォルダ/コントロールパネルは開かない
                // dialog.EnsureReadOnly = false;
                // dialog.AllowNonFileSystemItems = false;
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var selectedPath = dialog.SelectedPath;
                if (!Directory.Exists(selectedPath))
                {
                    return;
                }


                var items = DuplicateListBox.Items.Cast<string>().Select(f=> new BookModel() { FilePath = f });

                foreach (var book in items)
                {
                    book.FileMove(selectedPath);
                }
            }

        }
        private void NotFoundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllNotFoundDeleteButton_Click(object sender, EventArgs e)
        {
            var items = this.NotFoundListBox.Items.Cast<string>().Select(f => f.ToLower());
            var books = items.Select(item => this.shelf.Books.Where(b => b.FilePath.ToLower() == item).FirstOrDefault());
            this.shelf.Books.RemoveRange(books);
            this.NotFoundListBox.Items.Clear();
            this.shelf.WriteJson();

        }
        private void NotFoundDeleteButton_Click(object sender, EventArgs e)
        {
        }
    }
}
