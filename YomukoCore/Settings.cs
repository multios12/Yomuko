namespace Yomuko
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Yomuko.Utils;
    public class Settings
    {
        private static Settings settings;

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

        public void Save()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            filePath = Path.Combine(filePath, "yomuko.json");
            this.WriteJson(filePath);
        }

        public List<string> Shelfs;
        public int MainSplit = 0;
        public bool SideFilePanel = false;
        public string Location = "0, 0";
        public bool IsAutoSave = true;
        public string NameText1;
        public string NameText2;
        public string NameText3;
        public string NameText4;
        public string NameText7;
    }
}
