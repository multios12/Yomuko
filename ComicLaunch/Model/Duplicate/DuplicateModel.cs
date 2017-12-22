namespace ComicLaunch.Model.Duplicate
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>重複検出モデル</summary>
    public class DuplicateModel
    {
        /// <summary>コンストラクタ</summary>
        public DuplicateModel()
        {
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="books">書籍リスト</param>
        public DuplicateModel(IEnumerable<BookModel> books)
        {
            this.Books = books.ToList();
            this.EliminateTitle = books.FirstOrDefault()?.EliminateTitle;
            this.No = books.FirstOrDefault()?.No;
        }

        /// <summary>タイトル</summary>
        public string EliminateTitle { get; set; }

        /// <summary>No</summary>
        public string No { get; set; }

        /// <summary>リスト</summary>
        public List<BookModel> Books { get; set; }
    }
}
