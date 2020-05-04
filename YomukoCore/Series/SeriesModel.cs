namespace Yomuko.Series
{
    using Book;
    using System.Collections.Generic;

    /// <summary>
    /// シリーズモデル
    /// </summary>
    public class SeriesModel
    {
        /// <summary>完結</summary>
        private bool isComplete;

        /// <summary>コンストラクタ</summary>
        public SeriesModel()
        {
            this.Title = string.Empty;
            this.Writer = string.Empty;
            this.FirstReleaseDate = string.Empty;
            this.LastReleaseDate = string.Empty;
            this.LastNo = string.Empty;

            this.Books = new List<BookModel>();
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="model">モデル</param>
        public SeriesModel(BookModel model)
            : this()
        {
            this.Title = model.Title;
            this.Writer = model.Writer;
            this.Count = 1;
            this.IsComplete = model.IsComplete;

            this.FirstBook = model;
            this.FirstReleaseDate = string.IsNullOrEmpty(model.ReleaseDate) ? string.Empty : model.ReleaseDate;

            this.LastBook = model;
            this.LastNo = model.No;
            this.LastReleaseDate = string.IsNullOrEmpty(model.ReleaseDate) ? string.Empty : model.ReleaseDate;

            this.Books.Add(model);
        }

        /// <summary>タイトル</summary>
        public string Title { get; set; }

        /// <summary>著者</summary>
        public string Writer { get; set; }

        /// <summary>冊数</summary>
        public long Count { get; set; }

        /// <summary>初巻 リリース日</summary>
        public string FirstReleaseDate { get; set; }

        /// <summary>初巻 TID</summary>
        public BookModel FirstBook { get; set; }

        /// <summary>最新刊 巻数＆リリース日</summary>
        public string LastReleaseDate { get; set; }

        /// <summary>最新刊 巻数</summary>
        public string LastNo { get; set; }

        /// <summary>最新刊 TID</summary>
        public BookModel LastBook { get; set; }

        /// <summary>完結</summary>
        public bool IsComplete
        {
            get
            {
                return this.isComplete;
            }

            set
            {
                if (this.LastBook != null)
                {
                    this.LastBook.IsComplete = value;
                }

                this.isComplete = value;
            }
        }

        /// <summary>
        /// 書籍リスト
        /// </summary>
        public List<BookModel> Books { get; }
    }
}
