namespace ComicLaunch.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Utils;

    /// <summary>
    /// 情報リスト
    /// </summary>
    [Serializable]
    public partial class BookList : ObservableCollection<BookModel>
    {
        /// <summary>TIDカウンタ変数</summary>
        private long bookIDGen;

        /// <summary>対応拡張子</summary>
        private string[] extensions = { ".zip", ".lzh", ".rar" };

        #region イベント

        /// <summary>プロパティ変更イベント</summary>
        public new event PropertyChangedEventHandler PropertyChanged;

        /// <summary>同期状態変更イベント</summary>
        public event EventHandler<SyncStatusEventArgs> SyncStatusChanged;
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
            var model = this.AnalyzePath(filePath);
            if (model.Status == AnalyzeResult.Success)
            {
                model.Status = AnalyzeResult.NotRunning;
            }
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

        #region ベースフォルダ同期処理

        /// <summary>ベースフォルダが指定されている場合、ベースフォルダを検索し、登録されていないデータを新たに登録します</summary>
        /// <param name="baseFolders">ベースフォルダリスト</param>
        /// <param name="duplicateFolderPath">フォルダパス</param>
        /// <exception cref="DirectoryNotFoundException">ベースフォルダが存在しない。または指定されていない</exception>
        public void SyncBaseFolder(List<string> baseFolders, string duplicateFolderPath)
        {
            Debug.Print("■同期開始");

            Array.ForEach(this.ToArray(), b => b.Status = AnalyzeResult.NotRunning);

            // 既存ファイルチェック用パス配列の作成
            var syncPaths = new HashSet<string>(this.Select(b => b.FilePath).OrderBy(v => v));

            // ファイルの検索と存在確認
            IEnumerable<string> files = baseFolders
                .SelectMany(f => this.GetAllFiles(f, "*"))
                .Where(f => !syncPaths.Contains(f));

            int progressIndex = 0;
            int count = files.Count();
            try
            {
                foreach (string filePath in files)
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    BookModel model = this.AnalyzePath(filePath, syncPaths);
                    long em = sw.ElapsedMilliseconds;
                    Debug.Print(em + ":" + LabelAttributeUtils.GetLabelName(model.Status) + ":" + filePath);

                    if (model.Status == AnalyzeResult.Duplicate && duplicateFolderPath != null)
                    {
                        model.FileMove(duplicateFolderPath);
                        syncPaths.Remove(duplicateFolderPath);
                    } else if (model.Status == AnalyzeResult.Success)
                    {
                        this.Add(model);
                    }

                    var eventArgs = new SyncStatusEventArgs(filePath, progressIndex, count);

                    this.SyncStatusChanged?.Invoke(this, eventArgs);

                    if (eventArgs.Cancel)
                    {
                        break;
                    }

                    Debug.Print(sw.ElapsedMilliseconds + ":" + em);
                    progressIndex += 1;
                }
            }
            finally
            {
                this.Fill();
            }

            Debug.Print("■同期完了");
        }

        /// <summary>
        /// ファイルのパスを解析し、書籍リストに追加する
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        /// <param name="syncPaths">既存データのファイルパスリスト。二分探索で使用するため、昇順でソートする必要がある</param>
        /// <returns>処理結果</returns>
        /// <remarks>ファイルを解析し、リストに登録する</remarks>
        private BookModel AnalyzePath(string path, HashSet<string> syncPaths = null)
        {
            // 拡張子のチェック
            if (this.extensions.Contains(Path.GetExtension(path).ToLower()) == false)
            {
                return new BookModel(path, AnalyzeResult.AnalyzeFailed);
            }

            // 既存データかどうかをチェック(二分探索)
            if (syncPaths.Contains(path))
            {
                return new BookModel(path, AnalyzeResult.Always);
            }

            if (File.Exists(path) == false)
            {
                return new BookModel(path, AnalyzeResult.FileNotFound);
            }

            // パスに対するモデル取得
            var book = new BookModel(path);
            string hash = book.Hash;

            BookModel movedModel = this.Where(b => b.Hash == hash)
                .FirstOrDefault();

            if (movedModel != null && (movedModel.Status != AnalyzeResult.NotRunning || movedModel.FileExists() == false))
            {
                // ハッシュが同一で同期されていないデータが存在する場合、移動とみなす
                movedModel.FilePath = path;
                return movedModel;
            }
            else if (movedModel?.Status == AnalyzeResult.NotRunning)
            {
                // ハッシュが同一で同期されたデータが存在する場合、重複とみなす
                movedModel.Status = AnalyzeResult.Duplicate;
                book.Status = AnalyzeResult.Duplicate;
                return book;
            }
            else
            {
                // 同じハッシュを持つファイルが無い（新規ファイル）
                book.Status = AnalyzeResult.Success;
                return book;
            }
        }

        /// <summary>指定されたフォルダ以下にあるすべてのファイルを取得する
        /// </summary>
        /// <param name="folder">ファイルを検索するフォルダ名。</param>
        /// <param name="searchPattern">ファイル名検索文字列
        /// ワイルドカード指定子(*, ?)を使用する。</param>
        /// <returns>ファイル名リスト</returns>
        private List<string> GetAllFiles(string folder, string searchPattern)
        {
            // folderにあるファイルを取得する
            var files = new List<string>();
            IEnumerable<string> fs = Directory.GetFiles(folder, searchPattern);
            files.AddRange(fs);

            // folderのサブフォルダを取得する
            IEnumerable<string> subFolders = Directory.GetDirectories(folder);

            // サブフォルダにあるファイルも調べる
            foreach (string d in subFolders)
            {
                files.AddRange(this.GetAllFiles(d, searchPattern));
            }

            return files;
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
        #endregion

        /// <summary>
        /// プロパティ変更イベントを実行します。
        /// </summary>
        /// <param name="e">イベントデータ</param>
        private new void OnPropertyChanged(PropertyChangedEventArgs e)
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
