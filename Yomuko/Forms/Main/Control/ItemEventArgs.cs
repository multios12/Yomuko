namespace Yomuko.Forms.Main.Control
{
    using System;

    /// <summary>選択されたアイテムに関するイベントデータクラス</summary>
    /// <typeparam name="T">選択されたアイテムの型</typeparam>
    public class ItemEventArgs<T> : EventArgs
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="item">選択されたアイテム</param>
        public ItemEventArgs(T item)
        {
            this.Item = item;
        }

        /// <summary>選択アイテム</summary>
        public T Item { get; set; }
    }
}
