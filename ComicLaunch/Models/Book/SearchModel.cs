namespace ComicLaunch.Models.Book
{
    using System;
    using System.IO;
    using Models.Book;

    /// <summary>
    /// 表示状態構造体
    /// </summary>
    [Serializable]
    public class SearchModel
    {
        /// <summary>「全て対象」を表す値</summary>
        public const string ALL = "*";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fieldType">種類</param>
        /// <param name="value">値</param>
        public SearchModel(FieldType fieldType, string value)
        {
            this.FieldType = fieldType;
            this.Value = value;
        }

        /// <summary>種類</summary>
        public FieldType FieldType { get; set; }

        /// <summary>値</summary>
        public string Value { get; set; }

        /// <summary>
        /// 指定されたモデルが、検索条件に合致する場合、Trueを返します。
        /// </summary>
        /// <param name="model">モデル</param>
        /// <returns>該当する場合、True</returns>
        public bool Check(BookModel model)
        {
            if (this.Value == ALL)
            {
                return true;
            }

            if (this.FieldType == FieldType.FilePath)
            {
                // 後ろから、パス区切り文字を検索、区切り文字以前をディレクトリパスとして判定する
                if (model.FilePath.Contains(Path.DirectorySeparatorChar.ToString()))
                {
                    string folder = model.FilePath.Substring(0, model.FilePath.LastIndexOf(Path.DirectorySeparatorChar.ToString()));
                    return folder == this.Value;
                }
                else
                {
                    // パス区切り文字が見つからない場合、フォルダが存在無いものとみなす
                    return this.Value == string.Empty;
                }
            }

            var modelValue = model.GetValue(this.FieldType).ToLower();
            return this.Value == string.Empty | modelValue.IndexOf(this.Value.ToLower()) >= 0;
        }
    }
}
