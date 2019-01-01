namespace Yomuko.Forms.Viewer
{
    using System;

    /// <summary>ArchiveMovedイベントデータクラス</summary>
    public class ArchiveMovedEventArgs : EventArgs
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="direction">移動方向</param>
        /// <param name="fileName">移動先ファイル名</param>
        public ArchiveMovedEventArgs(int direction, string fileName)
        {
            this.Direction = direction;
            this.NextFileName = fileName;
        }

        /// <summary>移動方向</summary>
        public int Direction { get; set; }

        /// <summary>移動先ファイル名</summary>
        public string NextFileName { get; set; }
    }
}
