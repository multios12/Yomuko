namespace CLibrary.Model
{
    public enum Actions
    {
        /// <summary>シリーズモード変更</summary>
        ChangeSeriesMode,
        /// <summary>アーカイブ状態確認</summary>
        CheckArchives,
        /// <summary>イメージ描画</summary>
        PaintCoverImage,
        /// <summary>ファイル保存</summary>
        SaveShelf,
        /// <summary>絞り込み検索</summamry>
        SearchRefine,
        /// <summary>アーカイブ表示</summary>
        ShowArchive,
        /// <summary>ブックマーク表示</summary>
        ShowBookmark,
        /// <summary>プロパティ表示</summary>
        ChangeProperty,
        /// <summary>設定表示</summary>
        ShowSetting,
        /// <summary>ベースフォルダ同期</summary>
        SyncBaseFolder
    }
}
