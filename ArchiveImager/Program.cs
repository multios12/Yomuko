namespace ArchiveImager2
{
    using ArchiveImager;
    using SharpCompress.Archives;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        /// <summary>
        /// スタートアップポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        public static void Main(string[] args)
        {
            if(args.Length == 2 && args[0].ToLower() == "encode")
            {
                var value = Base64URL.Encode(args[1]);
                Console.Write(value);
                Environment.Exit(0);
                return;
            }
            else if (args.Length == 2 && args[0].ToLower() == "decode")
            {
                var value = Base64URL.Encode(args[1]);
                Console.Write(value);
                Environment.Exit(0);
                return;
            }

            int index;
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Environment.Exit(-1);
            }
            else if (args.Length == 1)
            {
                OutputList(args[0]);
            }
            else if (int.TryParse(args[1], out index))
            {
                OutputImage(args[0], index);
            }
            else
            {
                OutputImage(args[0], args[1]);
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// リストを標準出力に出力する
        /// </summary>
        /// <param name="filePath">圧縮ファイル</param>
        private static void OutputList(string filePath)
        {
            List<string> extensions = new List<string>() { ".jpg", ".jpeg", ".png", ".bmp" };

            var archive = ArchiveFactory.Open(filePath);
            var files = archive.Entries.Where(a => a.IsDirectory == false).Where((entry) => extensions.Contains(Path.GetExtension(entry.Key.ToLower()))).Select(e => e.Key).ToList();
            files.Sort();

            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
        }

        /// <summary>
        /// イメージを標準出力に出力する
        /// </summary>
        /// <param name="filePath">圧縮ファイル</param>
        /// <param name="entryName">エントリ名</param>
        private static void OutputImage(String filePath, int index)
        {
            List<string> extensions = new List<string>() { ".jpg", ".jpeg", ".png", ".bmp" };

            var archive = ArchiveFactory.Open(filePath);
            var files = archive.Entries.Where(a => a.IsDirectory == false).Where((ex) => extensions.Contains(Path.GetExtension(ex.Key.ToLower()))).Select(e => e.Key).ToList();
            files.Sort();

            var entry = archive.Entries.Where(e => e.Key == files[index]).FirstOrDefault();

            using (Stream sourceStream = entry.OpenEntryStream())
            {
                using (Stream distStream = Console.OpenStandardOutput())
                {
                    sourceStream.CopyTo(distStream);
                }
            }

        }

        /// <summary>
        /// イメージを標準出力に出力する
        /// </summary>
        /// <param name="filePath">圧縮ファイル</param>
        /// <param name="entryName">エントリ名</param>
        private static void OutputImage(string filePath, string entryName)
        {
            var archive = ArchiveFactory.Open(filePath);
            System.Diagnostics.Debug.WriteLine(filePath);
            var entry = archive.Entries.Where(e => e.Key == entryName).FirstOrDefault();

            using (Stream sourceStream = entry.OpenEntryStream())
            {
                using (Stream distStream = Console.OpenStandardOutput())
                {
                    sourceStream.CopyTo(distStream);
                }
            }
        }


        /// <summary>
        /// 指定された文字列のハッシュを作成し返す
        /// </summary>
        /// <param name="value">エンコードする文字列</param>
        /// <returns>ハッシュ文字列</returns>
        private static string EncodeBase64Url(string value)
        {
            return Base64URL.Encode(value);
        }

        /// <summary>
        /// 指定されたBase64Url文字列から元の文字列を返す
        /// </summary>
        /// <param name="value"></param>
        private static string DecodeBase64Url(string value)
        {
            return Base64URL.Decode(value);
        }
    }
}
