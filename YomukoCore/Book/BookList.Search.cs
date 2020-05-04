namespace Yomuko.Book
{
    using Series;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// 検索処理を集めたパーシャルクラス
    /// </summary>
    public partial class BookList
    {
        /// <summary>検索条件による検索結果</summary>
        private BookList searchedItems;

        /// <summary>検索条件による検索結果</summary>
        private SeriesList seriesItems = new SeriesList();

        /// <summary>検索条件</summary>
        private List<SearchModel> searchCriticas = new List<SearchModel>();

        /// <summary>シリーズモード</summary>
        private bool isSeriesMode;

        /// <summary>ソートキー</summary>
        private FieldType sortKey;

        /// <summary>ソートが昇順</summary>
        private bool isSortOrderAsc = true;

        /// <summary>検索値変更イベント</summary>
        public event EventHandler SearchCriteriasChanged;

        #region プロパティ

        /// <summary>シリーズモード</summary>
        public bool IsSeriesMode
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Parent.IsSeriesMode;
                }
                else
                {
                    return this.isSeriesMode;
                }
            }

            set
            {
                if (this.Parent != null)
                {
                    this.Parent.IsSeriesMode = value;
                }
                else
                {
                    this.isSeriesMode = value;
                }

                this.seriesItems.Clear();
                if (value)
                {
                    Array.ForEach(this.SearchedItems.ToArray(), b => this.seriesItems.Add(b));
                    this.seriesItems.Sort();

                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SeriesItems)));
                }
                else
                {
                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SearchedItems)));
                }
            }
        }

        /// <summary>検索条件による検索結果</summary>
        [XmlIgnore]
        public BookList SearchedItems
        {
            get
            {
                if (this.searchedItems == null)
                {
                    this.searchedItems = new BookList()
                    {
                        Parent = this
                    };
                }

                return this.searchedItems;
            }
        }

        /// <summary>検索条件による検索結果</summary>
        [XmlIgnore]
        public SeriesList SeriesItems
        {
            get
            {
                return this.seriesItems;
            }
        }

        /// <summary>ソートキー</summary>
        public FieldType SortKey
        {
            get
            {
                return this.sortKey;
            }

            set
            {
                if (this.Count() == 0)
                {
                    return;
                }

                if (this.sortKey == value)
                {
                    this.isSortOrderAsc = !this.isSortOrderAsc;
                }
                else
                {
                    this.sortKey = value;
                    this.isSortOrderAsc = true;

                    this.SearchedItems.SortKey = this.sortKey;
                }

                var list = this.SearchedItems.ToArray();
                list = this.isSortOrderAsc
                    ? list.OrderBy(b => b.GetSortKey(this.sortKey)).ToArray() : list.OrderByDescending(b => b.GetSortKey(this.sortKey)).ToArray();
                this.SearchedItems.Clear();
                Array.ForEach(list.ToArray(), b => this.SearchedItems.Add(b));

                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SearchedItems)));
            }
        }

        /// <summary>ソートオーダーが昇順の場合、True</summary>
        public bool IsSortOrderAsc
        {
            get
            {
                return this.isSortOrderAsc;
            }

            set
            {
                if (this.isSortOrderAsc != value)
                {
                    this.isSortOrderAsc = value;
                    var list = this.SearchedItems.AsEnumerable();
                    list = this.isSortOrderAsc
                        ? list.OrderBy(b => b.GetSortKey(this.sortKey)) : list.OrderByDescending(b => b.GetSortKey(this.sortKey));
                    Array.ForEach(list.ToArray(), b => this.SearchedItems.Add(b));

                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SearchedItems)));
                }
            }
        }
        #endregion

        #region パブリックメソッド

        /// <summary>指定された検索条件を追加します。</summary>
        /// <param name="items">検索条件</param>
        public void RefreshSearchCriterias(params SearchModel[] items)
        {
            this.searchCriticas.Clear();
            this.searchCriticas.AddRange(items);
            this.Fill();
            this.SearchCriteriasChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>検索条件をクリアします。</summary>
        public void ClearSearchCriterias()
        {
            this.searchCriticas.Clear();
            this.Fill();
            this.SearchCriteriasChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>検索条件を返します。</summary>
        /// <returns>検索条件</returns>
        public SearchModel[] GetSearchCriterias()
        {
            return this.searchCriticas.ToArray();
        }

        /// <summary>
        /// 指定された項目の重複を除いた値リストを返します。
        /// </summary>
        /// <param name="type">項目</param>
        /// <returns>値リスト</returns>
        public List<string> GetCollectValues(FieldType type)
        {
            var groups = new List<string>();

            Array.ForEach(
                this.ToArray(),
                book =>
                {
                    // グループ値の生成
                    string value = book.GetValue(type);

                    if (type == FieldType.ReleaseDate && !string.IsNullOrEmpty(value))
                    {
                        value = value.Substring(0, 4);
                    }
                    else if (type == FieldType.FilePath)
                    {
                        value = Path.GetDirectoryName(value);
                    }

                    // ループ値のチェック
                    bool check = true;
                    foreach (SearchModel searchItem in this.searchCriticas
                        .Where(s => string.IsNullOrEmpty(s.Value) == false))
                    {
                        if (book.GetValue(searchItem.FieldType).ToLower().IndexOf(searchItem.Value.ToLower()) == 0)
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check && groups.Contains(value) == false && string.IsNullOrEmpty(value) == false)
                    {
                        groups.Add(value);
                    }
                });

            groups.Sort();
            return groups;
        }

        /// <summary>選択値を更新します。</summary>
        public void Refresh()
        {
            this.Fill();
        }
        #endregion

        /// <summary>
        /// 検索条件で絞り込みを行います。
        /// </summary>
        partial void Fill()
        {
            Debug.Print("[{0}]{1}", DateTime.Now.ToString("HH:mm:ss"), "BookList.Fill:Start");

            var sw = new Stopwatch();
            sw.Start();
            this.SearchedItems.Clear();
            this.SeriesItems.Clear();

            if (this.searchCriticas.Count() == 0)
            {
                return;
            }

            // 検索条件による抽出
            BookModel[] list;
            if (this.searchCriticas.Count > 0 && this.searchCriticas[0].IsDuplicate)
            {
                this.CreateEliminateValue();

                list = this.Where(b => this.Exists((c) =>
                {
                    if (b.FilePath == c.FilePath || b.Writer != c.Writer)
                    {
                        return false;
                    }
                    return b.EliminateTitle == c.EliminateTitle;
                })).ToArray();
            }
            else
            {
                list = this.Where(book => this.searchCriticas.FirstOrDefault(s => !s.Check(book)) == null).ToArray();
            }

            Debug.Print("[{0}]{1}:{2}", DateTime.Now.ToString("HH:mm:ss"), "BookList.Fill:Filled", sw.ElapsedMilliseconds);

            // ソート
            list = this.isSortOrderAsc
                ? list.OrderBy(b => b.GetSortKey(this.sortKey)).ToArray() : list.OrderByDescending(b => b.GetSortKey(this.sortKey)).ToArray();
            Debug.Print("[{0}]{1}:{2}", DateTime.Now.ToString("HH:mm:ss"), "BookList.Fill:Sorted", sw.ElapsedMilliseconds);
            this.SearchedItems.Clear();

            this.SearchedItems.AddRange(list);
            //Array.ForEach(list, b => this.SearchedItems.Add(b));

            Debug.Print("[{0}]{1}:{2}", DateTime.Now.ToString("HH:mm:ss"), "BookList.Fill:SortedToArray", sw.ElapsedMilliseconds);


            this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SearchedItems)));

            // シリーズ抽出
            if (this.IsSeriesMode)
            {
                Parallel.ForEach(this.SearchedItems, b => this.seriesItems.Add(b));
                this.seriesItems.Sort();
            }

            // プロパティ変更イベント発生
            if (this.IsSeriesMode)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SeriesItems)));
            }
            else
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SearchedItems)));
            }

            this.SearchedItems.Refresh();
            Debug.Print("[{0}]{1}:{2}", DateTime.Now.ToString("HH:mm:ss"), "BookList.Fill:End", sw.ElapsedMilliseconds);
        }
    }
}