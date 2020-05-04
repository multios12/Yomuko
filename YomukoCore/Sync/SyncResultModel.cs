namespace YomukoCore.Sync
{
    /// <summary>
    /// 同期結果ベースモデル
    /// </summary>
    public class SyncResultModel
    {
        /// <summary>ファイルパス</summary>
        public string FilePath { get; set; }

        /// <summary>コンストラクタ</summary>
        public SyncResultModel()
        {
            this.FilePath = string.Empty;
        }

        /// <summary>コンストラクタ</summary>
        public SyncResultModel(string filePath)
        {
            this.FilePath = filePath;
        }
    }
}
