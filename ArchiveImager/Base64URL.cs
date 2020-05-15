namespace ArchiveImager
{
    using System;
    using System.Text;

    /// <summary>
    /// Base64 URLセーフ エンコード・デコードクラス
    /// </summary>
    public static class Base64URL
    {
        /// <summary>
        /// 指定された文字列をエンコードする
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>エンコードされた文字列</returns>
        public static string Encode(string value)
        {
            value = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            value = value.TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return value;
        }

        /// <summary>
        /// 指定された文字列をデコードする
        /// </summary>
        /// <param name="value">文字列</param>
        /// <returns>デコードされた文字列</returns>
        public static string Decode(string value)
        {
            int paddingNum = value.Length % 4;
            paddingNum = (paddingNum != 0) ? 4 - paddingNum : 0;

            value = Encoding.UTF8.GetString(Convert.FromBase64String(
                    (value + new string('=', paddingNum))
                    .Replace('-', '+')
                    .Replace('_', '/')));
            return value;
        }
    }
}
