namespace Yomuko
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Yomuko.Utils;

    /// <summary>設定管理</summary>
    /// .net Framework4のwindowsFormsと同じメソッド名で、設定機能を提供する
    public class Settings
    {
        /// <summary>設定オブジェクト</summary>
        private static Settings settings;

        /// <summary>現在の設定</summary>
        public static Settings Default
        {
            get
            {
                if (Settings.settings == null)
                {
                    settings = new Settings();
                    var filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    filePath = Path.Combine(filePath, "yomuko.json");

                    if (File.Exists(filePath))
                    {
                        settings = settings.ReadJson(filePath);
                    }
                }

                return settings;
            }
        }

        /// <summary>設定を保存する</summary>
        public void Save()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            filePath = Path.Combine(filePath, "yomuko.json");
            this.WriteJson(filePath);
        }

        /// <summary>選択フォームに表示する本棚ファイル</summary>
        public List<string> Shelfs { get; set; }
        public int MainSplit { get; set; } = 0;
        public bool SideFilePanel { get; set; }
        public bool IsAutoSave { get; set; } = true;
        public string NameText1 { get; set; }
        public string NameText2 { get; set; }
        public string NameText3 { get; set; }
        public string NameText4 { get; set; }
        public string NameText7 { get; set; }
    }
}
