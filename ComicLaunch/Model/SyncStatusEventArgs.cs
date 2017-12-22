namespace ComicLaunch.Model
{
    /// <summary>
    /// 同期状態イベントデータ
    /// </summary>
    public class SyncStatusEventArgs
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="progressIndex">進捗インデックス</param>
        /// <param name="count">カウント</param>
        public SyncStatusEventArgs(string filePath, int progressIndex, int count)
        {
            this.FilePath = filePath;
            this.ProgressIndex = progressIndex;
            this.ProgressCount = count;
        }

        /// <summary>キャンセル</summary>
        public bool Cancel { get; set; }

        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        /// <summary>進捗カウンタ</summary>
        public int ProgressCount { get; set; }

        /// <summary>進捗インデックス</summary>
        public int ProgressIndex { get; set; }
    }
}
