namespace Yomuko.Utils
{
    /// <summary>文字列拡張クラス</summary>
    public static class StringExtensions
    {
        /// <summary>文字列の書式項目を指定したオブジェクトの文字列形式に置き換えます。</summary>
        /// <param name="value">対象文字列</param>
        /// <param name="parameters">書式指定するオブジェクト</param>
        /// <returns>変換した文字列</returns>
        public static string FormatWith(this string value, params object[] parameters)
        {
            return string.Format(value, parameters);
        }
    }
}
