namespace ComicLaunch.Forms.Viewer
{
    /// <summary>イベントデータクラス</summary>
    public class PageEventArgs
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="pageIndex">ページインデックス</param>
        public PageEventArgs(string filePath, int pageIndex)
        {
            this.FilePath = filePath;
            this.PageIndex = pageIndex;
        }

        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        /// <summary>ページインデックス</summary>
        public int PageIndex { get; set; }
    }
}
