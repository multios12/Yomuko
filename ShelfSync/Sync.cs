namespace ShelfSync
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Yomuko.Book;
    using Yomuko.Shelf;

    public static class Sync
    {
        /// <summary>対応拡張子</summary>
        private static string[] extensions = { ".zip", ".lzh", ".rar" };

        private static ShelfModel shelf = new ShelfModel();

        private static Dictionary<string, BookModel> sortedbooks = new Dictionary<string, BookModel>();

        /// <summary>ベースフォルダが指定されている場合、ベースフォルダを検索し、登録されていないデータを新たに登録します</summary>
        /// <param name="baseFolderPath">ベースフォルダリスト</param>
        /// <exception cref="DirectoryNotFoundException">ベースフォルダが存在しない。または指定されていない</exception>
        public static void SyncBaseFolder(string baseFolderPath)
        {
            shelf = shelf.ReadJson(baseFolderPath);
            Array.ForEach(shelf.Books.ToArray(), b => b.Status = AnalyzeResult.NotRunning);
            foreach (var b in shelf.Books.Where(b => sortedbooks.ContainsKey(b.Hash)))
            {
                sortedbooks.Add(b.Hash, b);
            }

            // ファイルの検索と除外処理
            var syncPaths = new HashSet<string>(shelf.Books.Select(b => b.FilePath.ToLower()).OrderBy(v => v));
            IEnumerable<string> files = GetAllFiles(baseFolderPath, "*").AsParallel();
            files = files.Where(f => extensions.Contains(Path.GetExtension(f).ToLower()));
            var count = files.Count();
            files = files.Where(f => !syncPaths.Contains(f.ToLower()));
            Console.WriteLine($"ファイル>書籍ファイル総数:{count},新規・変更数:{files.Count()}");

            foreach (var filePath in files)
            {
                var book = new BookModel(filePath);
                book = CheckHash(book);
                Console.WriteLine($"{LabelAttributeUtils.GetLabelName(book.Status)}>{book.FilePath}");
            }

            var books = shelf.Books.Where(b => b.Status == AnalyzeResult.NotRunning);
            foreach (var book in books)
            {
                if (!book.FileExists())
                {
                    book.Status = AnalyzeResult.FileNotFound;
                    Console.WriteLine($"{LabelAttributeUtils.GetLabelName(book.Status)}>{book.FilePath}");
                }
            }

            shelf.WriteJson();
        }


        /// <summary>ハッシュの状態を確認する</summary>
        /// <param name="book">書籍</param>
        /// <returns>処理結果</returns>
        /// <remarks>ファイルを解析し、リストに登録する</remarks>
        private static BookModel CheckHash(BookModel book)
        {
            if (book.Status == AnalyzeResult.FileSizeZero ||
                book.Status == AnalyzeResult.FileNotFound)
            {
                // ファイルサイズがゼロの場合、ハッシュチェック処理を行わず終了する
                return book;
            }

            // 同一ハッシュチェック
            BookModel movedModel = sortedbooks.ContainsKey(book.Hash) ? sortedbooks[book.Hash] : null;
            //BookModel movedModel =  shelf.Books.Where(b => b.Hash == book.Hash).FirstOrDefault();

            if (movedModel != null && (movedModel.Status != AnalyzeResult.NotRunning || !movedModel.FileExists()))
            {
                // ハッシュが同一で、見つかったデータが処理済みか、ファイルが存在しない場合、移動とみなす
                movedModel.FilePath = book.FilePath;
                return movedModel;
            }
            else if (movedModel?.Status == AnalyzeResult.NotRunning)
            {
                // ハッシュが同一で同期されたデータが存在する場合、重複とみなす
                movedModel.Status = AnalyzeResult.Duplicate;
                book.Status = AnalyzeResult.Duplicate;
                return book;
            }

            // 同じハッシュを持つファイルが無い（新規ファイル）
            book.Status = AnalyzeResult.Success;
            shelf.Books.Add(book);
            sortedbooks.Add(book.Hash, book);
            return book;
        }

        /// <summary>指定されたフォルダ以下にあるすべてのファイルを取得する
        /// </summary>
        /// <param name="folder">ファイルを検索するフォルダ名。</param>
        /// <param name="searchPattern">ファイル名検索文字列
        /// ワイルドカード指定子(*, ?)を使用する。</param>
        /// <returns>ファイル名リスト</returns>
        private static List<string> GetAllFiles(string folder, string searchPattern)
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
                files.AddRange(GetAllFiles(d, searchPattern));
            }

            return files;
        }
    }
}
