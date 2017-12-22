namespace ComicLaunch.Model.Shelf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    using Image;

    /// <summary>
    /// 本棚モデル
    /// </summary>
    [XmlRoot("Shelf")]
    public class ShelfModel
    {
        /// <summary>しおりリスト</summary>
        private List<BookmarkModel> bookmarks;

        /// <summary>コンストラクタ</summary>
        public ShelfModel()
        {
            this.Books = new BookList();
            this.BaseFolderPaths = new List<string>();
            this.FileNames = new FileNameList();
            this.Columns = new List<ColumnModel>();
            this.Bookmarks = new List<BookmarkModel>();
        }

        /// <summary>ファイルパス</summary>
        [XmlIgnore]
        public string FilePath { get; set; }

        /// <summary>本棚名</summary>
        public string Title { get; set; }

        /// <summary>本棚の説明</summary>
        public string Remarks { get; set; }

        /// <summary>ベースフォルダを使用するか</summary>
        public bool UseBaseFolder { get; set; }

        /// <summary>重複フォルダ</summary>
        public string DuplicateFolderPath { get; set; }

        /// <summary>サブタイトルと巻数をタイトルに表示する </summary>
        public bool CollectSubTitle { get; set; }

        /// <summary>画像表示サイズ</summary>
        public PageSizeConstants PageSize { get; set; }

        /// <summary>ベースフォルダリスト</summary>
        [XmlArrayItem("Path")]
        public List<string> BaseFolderPaths { get; set; }

        /// <summary>ファイル名生成情報リスト</summary>
        [XmlArrayItem("FileName")]
        public FileNameList FileNames { get; set; }

        /// <summary>詳細リストの列情報</summary>
        [XmlArrayItem("Column")]
        public List<ColumnModel> Columns { get; set; }

        /// <summary>しおりリスト</summary>
        [XmlArrayItem("Bookmark")]
        public List<BookmarkModel> Bookmarks
        {
            get
            {
                List<string> hashs = this.Books.Select(b => b.Hash).OrderBy(b => b).ToList();
                return this.bookmarks.Where(b => hashs.BinarySearch(b.Hash) >= 0).ToList();
            }

            set
            {
                this.bookmarks = value;
            }
        }

        /// <summary>本リスト</summary>
        [XmlArrayItem("Book")]
        public BookList Books { get; set; }

        /// <summary>
        /// 設定を初期化します。データには影響を与えません。
        /// </summary>
        public void Initialize()
        {
            this.CollectSubTitle = true;

            this.FileNames = this.FileNames ?? new FileNameList();
            this.FileNames.Initialize();

            this.Columns = this.Columns ?? new List<ColumnModel>();
            this.Columns.Add(new ColumnModel(FieldType.Type, 100));
            this.Columns.Add(new ColumnModel(FieldType.Title, 200));
            this.Columns.Add(new ColumnModel(FieldType.Writer, 100));
            this.Columns.Add(new ColumnModel(FieldType.Junle, 100));
            this.Columns.Add(new ColumnModel(FieldType.ReleaseDate, 100));
        }
    }
}
