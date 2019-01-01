namespace Yomuko.Forms.Main.Control
{
    using System;
    using Book;

    /// <summary>検索条件選択イベント データクラス</summary>
    public class SelectSearchEventArgs : EventArgs
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="fieldType">項目</param>
        /// <param name="value">値</param>
        public SelectSearchEventArgs(FieldType fieldType, string value)
        {
            this.FieldType = fieldType;
            this.Value = value;
        }

        /// <summary>項目</summary>
        public FieldType FieldType { get; set; }

        /// <summary>値</summary>
        public string Value { get; set; }
    }
}
