namespace Yomuko.Book
{
    /// <summary>書籍解析結果</summary>
    public enum AnalyzeResult
    {
        /// <summary>同期未実施</summary>
        [Label("同期未実施")]
        NotRunning,

        /// <summary>登録済</summary>
        [Label("ファイルは登録済")]
        Always,

        /// <summary>ハッシュが同じファイルがリストに存在する</summary>
        [Label("ファイルの重複有")]
        Duplicate,

        /// <summary> リストに存在しないファイルだったが、解析に失敗した </summary>
        [Label("ファイルの解析に失敗")]
        AnalyzeFailed,

        /// <summary>指定されたパスには存在しないファイルであったため、追加できなかった</summary>
        [Label("ファイルは存在しない")]
        FileNotFound,

        /// <summary>ファイルは移動された</summary>
        [Label("ファイルは移動された")]
        FileMoved,

        /// <summary>ファイルサイズ0</summary>
        [Label("ファイルサイズ0")]
        FileSizeZero,

        /// <summary>正常に追加された</summary>
        [Label("正常に追加された")]
        Success
    }
}
