namespace ComicLaunch.Utils
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Threading;

    /// <summary>メモリマップトファイル操作ユーティリティ</summary>
    public static class MemoryMappedUtils
    {
        /// <summary>メモリマップトファイル</summary>
        private static MemoryMappedFile file;

        /// <summary>
        /// メモリマップトファイルから、データを読み込みます
        /// </summary>
        /// <returns>取得データ</returns>
        public static List<string> Read()
        {
            file = file ?? MemoryMappedFile.CreateOrOpen("test", 51200);

            using (var mutex = new Mutex(false, "test"))
            {
                try
                {
                    mutex.WaitOne();

                    using (var stream = file.CreateViewStream())
                    {
                        Stream s = stream;
                        List<string> target = new List<string>();

                        return target.ReadStream(s);
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// メモリマップトファイルにデータを書き込みます。
        /// </summary>
        /// <param name="items">メモリマップトファイルに保存するデータ</param>
        public static void Write(List<string> items)
        {
            file = file ?? MemoryMappedFile.CreateOrOpen("test", 51200);

            using (var mutex = new Mutex(false, "test"))
            {
                try
                {
                    mutex.WaitOne();

                    using (var stream = file.CreateViewStream())
                    {
                        Stream s = stream;

                        var writer = new BinaryWriter(s);
                        while (stream.Position < stream.Length)
                        {
                            writer.Write(0);
                        }
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
