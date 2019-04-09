namespace Yomuko
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Forms.Main;
    using Forms.ShelfSelect;
    using Forms.Viewer;
    using McMaster.Extensions.CommandLineUtils;
    using Yomuko.Shelf;

    /// <summary>
    /// アプリケーションクラス
    /// </summary>
    public class App
    {
        /// <summary>オートコンプリート[種別]</summary>
        public static List<string> AutoCompleteTypes { get; set; } = new List<string>();

        /// <summary>オートコンプリート[種別]</summary>
        public static List<string> AutoCompleteJunles { get; set; } = new List<string>();

        /// <summary>オートコンプリート[著者]</summary>
        public static List<string> AutoCompleteWriters { get; set; } = new List<string>();

        /// <summary>オートコンプリート[出版社]</summary>
        public static List<string> AutoCompletePublishers { get; set; } = new List<string>();

        /// <summary>本棚フォルダパス</summary>
        [Argument(0, "targetPath", "本棚フォルダパス")]
        public string TargetPath { get; }

        /// <summary>本棚フォルダパス</summary>
        [Option("-s|--sync", "同期を実行する", CommandOptionType.NoValue)]
        public bool IsSync { get; }

        ///// <summary>プログラムのエントリポイント</summary>
        ///// <param name="args">コマンドライン引数</param>
        [STAThread]
        public static int Main(string[] args) => CommandLineApplication.Execute<App>(args);

        /// <summary>実行イベント</summary>
        /// <returns>戻り値</returns>
        public int OnExecute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (this.IsSync)
                {
                    ExecuteSync(this.TargetPath);
                } else if (string.IsNullOrEmpty( this.TargetPath))
                {
                    ExecuteShowSelect();
                }
                else if (Directory.Exists(this.TargetPath))
                {
                    ExecuteShowList(this.TargetPath);
                }
                else
                {
                    ExecuteShowViewer(this.TargetPath);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"error: {ex.Message}\r\n{ex.StackTrace}");
                return -1;
            }
        }

        /// <summary>指定したパスを同期します</summary>
        /// <param name="folderPath">ファイルパス</param>
        public static void ExecuteSync(string folderPath)
        {
            var s = new ShelfModel();
            s = s.ReadJson(folderPath);

            s.Books.SyncBaseFolder(folderPath, s.DuplicateFolderPath);

            s.WriteJson();
       }

        /// <summary>ビュアーを表示します</summary>
        /// <param name="args">引数</param>
        public static void ExecuteShowViewer(string filePath)
        {
            int index = 0;

            var form = new ViewerForm();
            bool result = form.pictureList1.ShowArchive(filePath, index);

            if (result)
            {
                AddJumpList(filePath);
                Application.Run(form);
            }
        }

        public static void ExecuteShowSelect()
        {
            string filePath;
            DialogResult result = DialogResult.Retry;

            while (result == DialogResult.Retry)
            {
                using (var form = new ShelfSelectForm())
                {
                    result = form.ShowDialog();
                    filePath = form.ShelfPath;
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
        /// 表示します
        /// </summary>
        /// <param name="filePath">引数</param>
        public static void ExecuteShowList(string filePath)
        {
            DialogResult result = DialogResult.Retry;

            // メインフォームの表示
            while (result == DialogResult.Retry)
            {
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
