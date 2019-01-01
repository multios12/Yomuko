namespace Yomuko.Book
{
    using System;

    /// <summary>
    /// ラベル属性に関するユーティリティクラス
    /// </summary>
    public class LabelAttributeUtils
    {
        /// <summary>指定されたオブジェクトに設定されているラベル名を返します。</summary>
        /// <param name="value">対象オブジェクト</param>
        /// <returns>ラベル名</returns>
        public static string GetLabelName(Enum value)
        {
            if (value.GetType() == typeof(FieldType))
            {
                string enumName = Enum.GetName(value.GetType(), value);
                var info = typeof(BookModel).GetProperty(enumName);
                var attrs = (LabelAttribute[])info.GetCustomAttributes(typeof(LabelAttribute), false);

                return attrs[0].LabelName;
            }
            else
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(LabelAttribute), false) as LabelAttribute[];
                return (descriptionAttributes?.Length ?? 0) > 0 ? descriptionAttributes[0].LabelName : string.Empty;
            }
        }
    }
}
