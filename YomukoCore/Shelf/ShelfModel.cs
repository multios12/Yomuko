﻿namespace Yomuko.Shelf
{
    using Book;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Yomuko.Utils;

    /// <summary>
    /// 本棚モデル
    /// </summary>
    public class ShelfModel
    {
        /// <summary>しおりリスト</summary>
        private List<BookmarkModel> bookmarks;

        /// <summary>コンストラクタ</summary>
        public ShelfModel()
        {
            this.Books = new BookList();
            this.FileNames = new FileNameList();
            this.Columns = new List<ColumnModel>();
            this.Bookmarks = new List<BookmarkModel>();
        }

        /// <summary>ファイルパス</summary>
        [IgnoreDataMember]
        public string FilePath { get; set; }

        /// <summary>本棚名</summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>本棚の説明</summary>
        [DataMember(EmitDefaultValue = false)]
        public string Remarks { get; set; }

        /// <summary>重複フォルダ</summary>
        [DataMember]
        public string DuplicateFolderPath { get; set; }

        /// <summary>サブタイトルと巻数をタイトルに表示する </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool CollectSubTitle { get; set; }

        /// <summary>画像表示サイズ</summary>
        [DataMember]
        public PageSizeConstants PageSize { get; set; }

        /// <summary>ファイル名生成情報リスト</summary>
        [DataMember]
        public FileNameList FileNames { get; set; }

        /// <summary>詳細リストの列情報</summary>
        [DataMember]
        public List<ColumnModel> Columns { get; set; }

        /// <summary>しおりリスト</summary>
        [DataMember]
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
        [DataMember]
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

        public ShelfModel ReadJson(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                filePath = Path.Combine(filePath, ".yomuko");
            }
            else if (Path.GetFileName(filePath) != ".yomuko")
            {
                throw new DirectoryNotFoundException("フォルダが存在しない");
            }

            if (!File.Exists(filePath))
            {
                this.Title = $"本棚[{Path.GetDirectoryName(filePath)}]";
                this.FilePath = filePath;
                this.Initialize();
                this.WriteJson();
                return this;
            }

            var target = SerializationExtensions.ReadJson(this, filePath);
            target.FilePath = filePath;

            var rootPath = Path.GetDirectoryName(filePath);

            foreach (var b in target.Books)
            {
                b.FilePath = rootPath + "\\" + b.FilePath;
            }

            return target;
        }

        /// <summary>
        /// オブジェクトの内容をXMLに書き込む
        /// </summary>
        public void WriteJson()
        {
            var rootPath = Path.GetDirectoryName(this.FilePath) + "\\";

            foreach (var b in this.Books)
            {
                b.FilePath = b.FilePath.Replace(rootPath, string.Empty);
            }

            SerializationExtensions.WriteJson(this, this.FilePath);

            foreach (var b in this.Books)
            {
                b.FilePath = rootPath + b.FilePath;
            }
        }
    }
}
