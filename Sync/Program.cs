namespace Sync
{
    using System;
    using System.IO;
    using ComicLaunch.Shelf;

    class Program
    {
        /// <summary>
        /// プログラムのスタートアップポイント
        /// </summary>
        /// <param name="args">引数</param>
        static void Main(string[] args)
        {
            var filePath = args[0];
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
            {
                Environment.Exit(-1);
                return;
            }

            var s = new ShelfModel();
            s = s.ReadXML(args[0]);

            s.Books.SyncBaseFolder(s.BaseFolderPaths, s.DuplicateFolderPath);

            s.WriteXML(s.FilePath);

        }
    }
}
