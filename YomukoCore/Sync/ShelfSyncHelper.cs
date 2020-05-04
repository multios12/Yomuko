namespace Yomuko.Sync
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 本棚ファイル同期
    /// </summary>
    public class ShelfSyncHelper
    {

        public DataReceivedEventHandler OutputDataReceivedEvent { get; set; }

        public DataReceivedEventHandler ErrorDataReceivedEvent { get; set; }

        public EventHandler ExitedEvent { get; set; }

        public void SyncBasePath(string basePath)
        {
            var appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            appPath = Path.Combine(appPath, "ShelfSync.exe");
            var info = new ProcessStartInfo(appPath, basePath)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            // StandardOutputEncoding = Encoding.UTF8,

            Process process = new Process() { StartInfo = info };
            process.OutputDataReceived += OutputDataReceivedEvent;
            process.ErrorDataReceived += ErrorDataReceivedEvent;
            process.Exited += ExitedEvent;
            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
        }
    }
}
