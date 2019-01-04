namespace Yomuko
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Forms.Main;
    using Forms.ShelfSelect;
    using Forms.Viewer;

    /// <summary>
    /// アプリケーションクラス
    /// </summary>
    public static class App
    {
        /// <summary>オートコンプリート[種別]</summary>
        public static List<string> AutoCompleteTypes { get; set; } = new List<string>();

        /// <summary>オートコンプリート[種別]</summary>
        public static List<string> AutoCompleteJunles { get; set; } = new List<string>();

        /// <summary>オートコンプリート[著者]</summary>
        public static List<string> AutoCompleteWriters { get; set; } = new List<string>();

        /// <summary>オートコンプリート[出版社]</summary>
        public static List<string> AutoCompletePublishers { get; set; } = new List<string>();

        /// <summary>
        /// アプリケーションスタートアップポイント
        /// </summary>
        /// <param name="args">引数</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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

        /// <summary>
        /// 表示します
        /// </summary>
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
                AddJumpList(args[0]);
                Application.Run(form);
            }
        }

        /// <summary>
        /// 表示します
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
                    AddJumpList(filePath);
                    result = form.ShowDialog(filePath);
                }
            }
        }

        /// <summary>
        /// ジャンプリストに追加します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        private static void AddJumpList(string filePath)
        {
            // JumpList list = new JumpList()
            // {
            //     ShowRecentCategory = true
            // };
            // JumpList.AddToRecentCategory(filePath);
        }
    }
}
