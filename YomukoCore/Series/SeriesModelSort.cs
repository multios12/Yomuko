namespace ComicLaunch.Series
{
    using System;
    using System.Collections.Generic;

    /// <summary>シリーズモデルソートクラス</summary>
    [Serializable]
    public class SeriesModelSort : IComparer<SeriesModel>
    {
        /// <summary>コンストラクタ</summary>
        public SeriesModelSort()
        {
            this.Order = SortOrder.Ascending;
        }

        /// <summary>ソート順(昇順・降順)</summary>
        public SortOrder Order { get; set; }

        /// <summary>ソート列</summary>
        public string Key { get; set; }

        /// <summary>2 つのオブジェクトを比較して、一方が他方より小さいか、同じか、または大きいかを示す値を返します。</summary>
        /// <param name="x">比較する最初のオブジェクト</param>
        /// <param name="y">比較する二つ目のオブジェクト</param>
        /// <returns>x と y の相対値を示す符号付き整数</returns>
        public int Compare(SeriesModel x, SeriesModel y)
        {
            int result = 0;

            // 文字列を比較し、値を格納
            switch (this.Key)
            {
                case "タイトル":
                    result = x.Title.CompareTo(y.Title);
                    break;
                case "著者":
                    result = x.Writer.CompareTo(y.Writer);
                    break;
                case "冊数":
                    result = x.Count.CompareTo(y.Count);
                    break;
                case "初巻発売日":
                    result = x.FirstReleaseDate.CompareTo(y.FirstReleaseDate);
                    break;
                case "最新刊":
                    result = x.LastNo != null ? x.LastNo.CompareTo(y.LastNo) : 0;
                    break;
            }

            // 降順のときは結果を逆転
            if (this.Order == SortOrder.Descending)
            {
                result = -result;
            }

            return result;
        }
    }
}
