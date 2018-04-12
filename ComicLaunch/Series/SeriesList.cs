namespace ComicLaunch.Series
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Book;

    /// <summary>シリーズリスト</summary>
    [Serializable]
    public class SeriesList : List<SeriesModel>
    {
        /// <summary>ソートクラス</summary>
        private SeriesModelSort modelSort = new SeriesModelSort();

        /// <summary>ソートキー</summary>
        public string SortKey
        {
            get
            {
                return this.modelSort.Key;
            }

            set
            {
                if (this.modelSort.Key != value)
                {
                    this.modelSort.Key = value;
                    this.modelSort.Order = SortOrder.Descending;
                }
            }
        }

        /// <summary>
        /// 並べ替えを行います。
        /// </summary>
        public new void Sort()
        {
            if (string.IsNullOrEmpty(this.SortKey))
            {
                return;
            }

            this.modelSort.Order = this.modelSort.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            this.Sort(this.modelSort);
        }

        /// <summary>
        /// リストの末尾にオブジェクトを追加します。
        /// </summary>
        /// <param name="model">追加するモデル</param>
        public void Add(BookModel model)
        {
            var series = this.FirstOrDefault(b => b.Title == model.Title);

            if (series == null)
            {
                this.Add(new SeriesModel(model));
                return;
            }

            series.Count += 1;
            series.Books.Add(model);
            series.LastNo = model.No;
            series.LastBook = model;

            if (series.LastReleaseDate?.CompareTo(model.ReleaseDate) > 0)
            {
                series.LastReleaseDate = model.ReleaseDate;
            }

            series.IsComplete = model.IsComplete;
        }

        /// <summary>
        /// リスト内のすべての要素と指定された文字とを比較し、前方一致する部分を返します。
        /// </summary>
        /// <param name="seriesName">検索対象とする文字</param>
        /// <returns>指定された文字と前方一致する文字、見つからなければ、空文字</returns>
        public string GetBeginWithMatchTitle(string seriesName)
        {
            foreach (var series in this)
            {
                string title = series.Title;
                int lastindex;

                // 指定されたリストと一致する文字部分を検索する。
                for (lastindex = title.Length; lastindex > 0; lastindex--)
                {
                    seriesName = (seriesName.Length < lastindex) ? seriesName : seriesName.Substring(0, lastindex);

                    title = title.Substring(0, lastindex);

                    if (seriesName == title)
                    {
                        seriesName = seriesName.Substring(0, lastindex);
                        break;
                    }
                }

                if (lastindex <= 0)
                {
                    return string.Empty;
                }
            }

            seriesName = seriesName.Trim();

            return seriesName;
        }
    }
}
