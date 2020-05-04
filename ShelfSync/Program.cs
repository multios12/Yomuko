namespace ShelfSync
{
    using System;
    using System.Text;

    public class Program
    {
        /// <summary>
        /// アプリケーションのスタートアップポイント
        /// </summary>
        /// <param name="args">引数</param>
        public static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Sync.SyncBaseFolder(args[0]);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"{ex.Message}\r{ex.StackTrace}");
                Environment.Exit(-1);
                return;
            }

            Environment.Exit(0);
        }
    }
}
