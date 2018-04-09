namespace ComicLaunch.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>しおりリスト定義構造体</summary>
    [Serializable]
    public class BookmarkModel
    {
        /// <summary>コンストラクタ</summary>
        public BookmarkModel()
        {
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="hash">ハッシュ</param>
        /// <param name="pageIndex">ページ</param>
        public BookmarkModel(string hash, int pageIndex)
        {
            this.Hash = hash;
            this.PageIndex = pageIndex;
            this.CreateDate = DateTime.Now.ToString("yyyy/MM/dd");
        }

        /// <summary>ページ</summary>
        [XmlAttribute]
        public int PageIndex { get; set; }

        /// <summary>ハッシュ</summary>
        [XmlAttribute]
        public string Hash { get; set; }

        /// <summary>作成日</summary>
        [XmlAttribute]
        public string CreateDate { get; set; }
    }
}
