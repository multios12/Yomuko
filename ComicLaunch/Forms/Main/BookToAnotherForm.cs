namespace ComicLaunch.Forms.Main
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using ComicLaunch.Shelf;
    using ComicLaunch.Utils;

    public partial class BookToAnotherForm : Form
    {
        /// <summary>本棚格納フォルダ</summary>
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Yomuko");

        private ShelfModel distShelf;

        /// <summary>本棚データディクショナリ</summary>
        private Dictionary<string, string> shelfDictionary = new Dictionary<string, string>();

        public BookToAnotherForm()
        {
            this.InitializeComponent();
        }

        public ShelfModel Shelf { get; set; }

        private void BookToAnotherForm_Load(object sender, EventArgs e)
        {
            this.ShowShelf();
        }

        /// <summary>選択されたファイルによって、フォームを表示する</summary>
        private void ShowShelf()
        {
            if (!Directory.Exists(this.folderPath))
            {
                Directory.CreateDirectory(this.folderPath);
                return;
            }

            var shelfPaths = Directory.GetFiles(this.folderPath).Where(f => Path.GetExtension(f).ToLower() == ".bls");
            this.shelfDictionary.Clear();
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

        private void ShelfListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filePath = null;
            if (!File.Exists(filePath))
            {
                return;
            }

            this.distShelf = new ShelfModel();
            this.distShelf = this.distShelf.ReadXML(filePath);

            var dirs = Directory.GetDirectories(this.distShelf.BaseFolderPaths[0]);
            this.FolderListBox.Items.Clear();

            foreach (var d in dirs)
            {
                this.FolderListBox.Items.Add(d);
            }
        }
    }
}
