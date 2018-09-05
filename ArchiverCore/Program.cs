namespace ArchiverCore
{
    using SharpCompress.Archives;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;

    public class Program
    {
        private static List<string> extensions = new List<string>() { ".jpg", ".jpeg", ".png", ".bmp" };

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
                if (!int.TryParse(args[1], out int index))
                {
                    Environment.Exit(-1);
                    return;
                }
                OutputImage(args[0], index);
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// リストを標準出力に出力する
        /// </summary>
        /// <param name="filePath">圧縮ファイル</param>
        private static void OutputList(string filePath)
        {
            var archive = ArchiveFactory.Open(filePath);
            var files = archive.Entries.Where(a => a.IsDirectory == false)
                .Where(entry => extensions.Contains(Path.GetExtension(entry.Key.ToLower())))
                .Select(e => e.Key)
                .OrderBy((e) => e)
                .ToList();

            var serializer = new DataContractJsonSerializer(typeof(List<String>));
            using (Stream distStream = Console.OpenStandardOutput())
            {
                serializer.WriteObject(distStream, files);
            }
        }

        /// <summary>
        /// イメージを標準出力に出力する
        /// </summary>
        /// <param name="filePath">圧縮ファイル</param>
        /// <param name="entryName">エントリ名</param>
        private static void OutputImage(string filePath, int index)
        {
            var archive = ArchiveFactory.Open(filePath);
            var entries = archive.Entries.Where(a => a.IsDirectory == false)
                .Where(e => extensions.Contains(Path.GetExtension(e.Key.ToLower())))
                .OrderBy((e) => e.Key)
                .ToList();

            var entry = entries[index];

            using (Stream sourceStream = entry.OpenEntryStream())
            using (Stream distStream = Console.OpenStandardOutput())
            {
                sourceStream.CopyTo(distStream);
            }
        }
    }

}
