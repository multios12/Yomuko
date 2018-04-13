namespace ArchiveImager
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SharpCompress.Archives;
    using SharpCompress.Common.Zip;

    public class Program
    {
        /// <summary>
        /// スタートアップポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        public static void Main(string[] args)
        {
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Environment.Exit(-1);
            }
            else if (args.Length == 1)
            {
                OutputList(args[0]);
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
            var v = (ZipVolume)archive.Volumes;

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
        private static void OutputImage(string filePath, string entryName)
        {
            var archive = ArchiveFactory.Open(filePath);
            var entry = archive.Entries.Where(e => e.Key == entryName).FirstOrDefault();
            using (Stream sourceStream = entry.OpenEntryStream())
            {
                using (Stream distStream = Console.OpenStandardOutput())
                {
                    sourceStream.CopyTo(distStream);
                }
            }
        }
    }
}
