namespace CLibrary.Model
{
    public class ActionEventArgs
    {
        private BookModel book;

        /// <summary>アクション</summary>
        public Actions Action { get; set; }
        /// <summary>追加情報</summary>
        public object Value { get; set; }
        /// <summary>追加情報2</summary>
        public object Value2 { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="action">アクション</param>
        public ActionEventArgs(Actions action)
        {
            this.Action = action;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        public ActionEventArgs(Actions action, object value) : this(action)
        {
            this.Action = action;
            this.Value = value;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        public ActionEventArgs(Actions action, object value,object value2) : this(action)
        {
            this.Action = action;
            this.Value = value;
            this.Value2 = value2;
        }
    }
}
