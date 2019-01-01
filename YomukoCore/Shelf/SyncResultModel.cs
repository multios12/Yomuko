namespace Yomuko.Shelf
{
    using Book;

    /// <summary>
    /// 同期結果モデル
    /// </summary>
    public class SyncResultModel
    {
        /// <summary>書籍</summary>
        public BookModel Book { get; set; }

        /// <summary>結果ステータス</summary>
        public AnalyzeResult Status { get; set; }
    }
}
