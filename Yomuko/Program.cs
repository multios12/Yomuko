namespace Yomuko
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Forms.Main;
    using Forms.ShelfSelect;
    using Yomuko.Forms.Viewer;

    /// <summary>
    /// アプリケーションクラス
    /// </summary>
    public static class Program
    {
        /// <summary>アプリケーションスタートアップポイント</summary>
        /// <param name="args">引数</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_OnThreadException);

            if (args.Count() == 0)
            {
                Console.WriteLine(args);
                ShowList(args);
                return;
            }

            if (Path.GetExtension(args[0]).ToLower() != ".bls")
            {
                ShowViewer(args);
            }
            else
            {
                ShowList(args);
            }
        }

        public static void Application_OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        /// <summary>
        /// 書籍管理フォームを表示する
        /// 
        /// </summary>
        /// <param name="args">引数</param>
        public static void ShowList(string[] args)
        {
            DialogResult result = DialogResult.Retry;

            while (result == DialogResult.Retry)
            {
                // 選択フォームの表示
                string filePath;
                if (args.Count() == 0)
                {
                    using (var form = new ShelfSelectForm())
                    {
                        result = form.ShowDialog();
                        filePath = form.ShelfPath;
                    }
                }
                else
                {
                    filePath = args[0];
                    args = new string[] { };
                }

                if (result != DialogResult.OK)
                {
                    return;
                }

                // メインフォームの表示
                using (MainForm form = new MainForm())
                {
                    result = form.ShowDialog(filePath);
                }
            }
        }

        /// <summary>ビュアフォームを表示する</summary>
        /// <param name="args">引数</param>
        public static void ShowViewer(string[] args)
        {
            int index = 0;

            if (args.Count() >= 2)
            {
                int.TryParse(args[1], out index);
            }

            var form = new ViewerForm();
            bool result = form.pictureList1.ShowArchive(args[0], index);

            if (result)
            {
                Application.Run(form);
            }
        }
    }
}
