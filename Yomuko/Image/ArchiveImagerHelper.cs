namespace Yomuko.Image
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// ArchiveImager.exeサポートクラス
    /// </summary>
    public class ArchiveImagerHelper
    {
        /// <summary>
        /// 指定された圧縮ファイルから、エントリ名リストを読み込みます。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>エントリ名リスト</returns>
        public static List<string> Open(string filePath)
        {
            Debug.Print("ArchiveImagerHelper.Open:Start");
            var appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            appPath = Path.Combine(appPath, "ArchiveImager.exe");
            var info = new ProcessStartInfo(appPath, $"\"{filePath}\"")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            Process process = new Process { StartInfo = info };
            process.Start();

            process.WaitForExit(2000);
            var value = process.StandardOutput.ReadToEnd();
            Debug.Print("ArchiveImagerHelper.Open:End");
            return value.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
        }

        /// <summary>
        /// 指定された圧縮ファイルから、指定されたエントリのストリームを返す
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="entryName">エントリ名</param>
        /// <returns>ストリーム</returns>
        public static Stream GetStream(string filePath, int entryName)
        {
            var args = "\"" + filePath + "\" \"" + entryName + "\"";
            Debug.Print($"{args}");
            var info = new ProcessStartInfo("ArchiveImager.exe", args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process process = new Process();
            process.StartInfo = info;
            process.Start();

            return process.StandardOutput.BaseStream;
        }
    }
}
