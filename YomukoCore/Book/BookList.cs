namespace Yomuko.Book
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// 情報リスト
    /// </summary>
    public partial class BookList : List<BookModel>
    {
        /// <summary>TIDカウンタ変数</summary>
        private long bookIDGen;

        #region イベント

        /// <summary>プロパティ変更イベント</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        /// <summary>生成元リストを表す</summary>
        public BookList Parent { get; set; }
        
        /// <summary>
        /// 指定した値をリストに追加します。
        /// </summary>
        /// <param name="model">書籍情報</param>
        public new void Add(BookModel model)
        {
            if (this.Parent != null)
            {
                this.Parent.Add(model);
            }
            else if (string.IsNullOrEmpty(model.Id))
            {
                this.bookIDGen = this.CreateTid();
                model.Id = this.bookIDGen.ToString();
            }

            if (!this.Any(b => b.Id == model.Id))
            {
                base.Add(model);
            }
        }

        /// <summary>
        /// 指定したファイルをリストに追加します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public void Add(string filePath)
        {
            var model = new BookModel(filePath);
        }

        /// <summary>
        /// すべての値を削除します。
        /// </summary>
        public new void Clear()
        {
            this.bookIDGen = 0;
            base.Clear();
        }

        /// <summary>
        /// 指定された値がリストに存在するとき、最初に見つかった値を削除します。
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>正常に終了した場合、true</returns>
        public bool Remove(string id)
        {
            if (this.Parent != null)
            {
                return this.Parent.Remove(id);
            }

            foreach (var model in this)
            {
                if (model.Id == id)
                {
                    return this.Remove(model);
                }
            }

            return false;
        }

        /// <summary>
        /// 指定された値がリストに存在するとき、最初に見つかった値を削除します。
        /// </summary>
        /// <param name="item">モデル</param>
        /// <returns>正常に終了した場合、true</returns>
        public new bool Remove(BookModel item)
        {
            if (this.Parent != null)
            {
                this.Parent.Remove(item);
            }

            return base.Remove(item);
        }

        /// <summary>
        /// 指定したインデックスにある要素を削除します。
        /// </summary>
        /// <param name="index">インデックス</param>
        public new void RemoveAt(int index)
        {
            if (this.Parent != null)
            {
                this.Parent.RemoveAt(index);
            }

            base.RemoveAt(index);
        }

        /// <summary>
        /// 指定された値がリストに存在するとき、最初に見つかった値を削除します。
        /// </summary>
        /// <param name="items">モデル</param>
        public void RemoveRange(IEnumerable<BookModel> items)
        {
            foreach (BookModel item in items)
            {
                this.Remove(item);
            }
        }

        /// <summary>指定された項目を置き換えます。</summary>
        /// <param name="fieldType">項目</param>
        /// <param name="beforeValue">置き換え前の値</param>
        /// <param name="afterValue">置き換え後の値</param>
        public void ReplaceValue(FieldType fieldType, string beforeValue, string afterValue)
        {
            foreach (BookModel model in this)
            {
                if (string.IsNullOrWhiteSpace(beforeValue) == true)
                {
                    model.SetValue(fieldType, afterValue);
                }
                else
                {
                    model.SetValue(fieldType, model.GetValue(fieldType).Replace(beforeValue, afterValue));
                }
            }
        }

        /// <summary>
        /// 新しいTIDを作成します。
        /// </summary>
        /// <returns>生成したTID</returns>
        private long CreateTid()
        {
            if (this.Parent == null)
            {
                this.bookIDGen += 1;
                return this.bookIDGen;
            }
            else
            {
                return this.Parent.CreateTid();
            }
        }

        /// <summary>
        /// プロパティ変更イベントを実行します。
        /// </summary>
        /// <param name="e">イベントデータ</param>
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            Debug.Print("[{0}]{1}", DateTime.Now.ToString("HH:mm:ss"), "BookList.OnPropertyChanged");

            this.PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// 検索条件で絞り込みを行います。
        /// </summary>
        partial void Fill();
    }
}
