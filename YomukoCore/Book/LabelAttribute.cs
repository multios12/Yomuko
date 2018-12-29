namespace ComicLaunch.Book
{
    using System;

    /// <summary>
    /// ラベル属性
    /// </summary>
    public class LabelAttribute : Attribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">名前</param>
        public LabelAttribute(string name)
        {
            this.LabelName = name;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="isHidden">隠し項目の場合、Trueを設定します。</param>
        public LabelAttribute(string name, bool isHidden)
        {
            this.LabelName = name;
            this.IsHidden = isHidden;
        }

        /// <summary>名前</summary>
        public string LabelName { get; set; }

        /// <summary>隠し項目の場合、Trueを設定します。</summary>
        public bool IsHidden { get; set; }
    }
}
