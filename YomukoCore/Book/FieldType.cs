namespace Yomuko.Book
{
    /// <summary>書籍情報項目</summary>
    public enum FieldType
    {
        /// <summary>ファイルパス</summary>
        [Label("ファイルパス")]
        FilePath = -1,

        /// <summary>タイトル</summary>
        [Label("タイトル")]
        Title = 0,

        /// <summary>巻数</summary>
        [Label("巻数")]
        No,

        /// <summary>著者またはモデル</summary>
        [Label("著者")]
        Writer,

        /// <summary>出版社</summary>
        [Label("出版社")]
        PublishingCompany,

        /// <summary>ジャンル</summary>
        [Label("ジャンル")]
        Junle,

        /// <summary>リリース日</summary>
        [Label("リリース日")]
        ReleaseDate,

        /// <summary>備考</summary>
        [Label("備考")]
        Memo,

        /// <summary>お気に入りフラグ</summary>
        [Label("お気に入り")]
        Favorite,

        /// <summary>追加日</summary>
        [Label("追加日")]
        CreateDate,

        /// <summary>更新日</summary>
        [Label("更新日")]
        UpdateDate,

        /// <summary>ハッシュ</summary>
        [Label("ハッシュ")]
        Hash,

        /// <summary>種類</summary>
        [Label("種類")]
        Type,

        /// <summary>撮影者</summary>
        [Label("撮影者")]
        Photographer,

        /// <summary>掲載誌</summary>
        [Label("掲載誌")]
        CarryMagazine,

        /// <summary>サブタイトル</summary>
        [Label("サブタイトル")]
        SubTitle,

        /// <summary>表紙ファイルインデックス</summary>
        [Label("表紙ファイルインデックス")]
        CoverFileIndex,

        /// <summary>表紙表示幅</summary>
        [Label("表紙表示幅")]
        CoverWidth,

        /// <summary>表紙表示位置横方向</summary>
        [Label("表紙表示位置横方向")]
        CoverLeft,

        /// <summary>完結</summary>
        [Label("完結")]
        IsComplete
    }
}
