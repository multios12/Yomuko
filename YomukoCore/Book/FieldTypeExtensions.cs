namespace Yomuko.Book
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>FieldType型を対象とした拡張メソッド</summary>
    public static class FieldTypeExtensions
    {
        /// <summary>指定されたクラスに設定されているラベル属性を返します。</summary>
        /// <param name="value">処理対象オブジェクト</param>
        /// <returns>ラベル属性</returns>
        public static LabelAttribute Label(this FieldType value)
        {
            string enumName = Enum.GetName(typeof(FieldType), value);
            FieldInfo info = typeof(FieldType).GetField(enumName);
            LabelAttribute[] attrs = (LabelAttribute[])info.GetCustomAttributes(typeof(LabelAttribute), false);

            return attrs?[0];
        }

        /// <summary>指定されたクラスに設定されているラベル名を返します。</summary>
        /// <param name="value">対象オブジェクト</param>
        /// <returns>ラベル名</returns>
        public static string LabelName(this FieldType value)
        {
            string enumName = Enum.GetName(typeof(FieldType), value);
            var info = typeof(BookModel).GetProperty(enumName);
            var attrs = (LabelAttribute[])info.GetCustomAttributes(typeof(LabelAttribute), false);

            if (attrs.Length == 0)
            {
                return string.Empty;
            }

            return attrs[0].LabelName;
        }

        /// <summary>指定された項目が読み取り専用の時、Trueを返します。</summary>
        /// <param name="value">処理対象オブジェクト</param>
        /// <returns>読み取り専用の場合、True</returns>
        public static bool IsReadOnly(this FieldType value)
        {
            string enumName = Enum.GetName(typeof(FieldType), value);
            var info = typeof(FieldType).GetField(enumName);
            var attrs = (LabelAttribute[])info.GetCustomAttributes(typeof(LabelAttribute), false);

            if (attrs.Length == 0)
            {
                return false;
            }

            return attrs[0].IsHidden;
        }

        /// <summary>非表示項目を返します。</summary>
        /// <param name="fieldType">対象オブジェクト</param>
        /// <returns>項目種類リスト</returns>
        public static FieldType[] GetNotHiddenValues(this FieldType fieldType)
        {
            var types = new List<FieldType>();

            foreach (FieldType value in Enum.GetValues(typeof(FieldType)))
            {
                var attribute = Label(value);

                if (attribute.IsHidden == false)
                {
                    types.Add(value);
                }
            }

            return types.ToArray();
        }

        /// <summary>項目リストを返します。</summary>
        /// <param name="fieldType">処理対象オブジェクト</param>
        /// <returns>項目リスト</returns>
        public static IEnumerable<string> GetLabelNames(this FieldType fieldType)
        {
            return Enum.GetValues(typeof(FieldType)).Cast<FieldType>().Select(f => Label(f).LabelName).ToArray();
        }

        /// <summary>ラベル名を項目種類に変換して返します。</summary>
        /// <param name="fieldType">処理対象オブジェクト</param>
        /// <param name="labelName">ラベル名</param>
        /// <returns>項目種類</returns>
        public static FieldType LabelNameToFieldType(this FieldType fieldType, string labelName)
        {
            foreach (FieldType value in Enum.GetValues(typeof(FieldType))
                .Cast<FieldType>().Where(f => Label(f).LabelName == labelName))
            {
                return value;
            }

            return FieldType.Title;
        }
    }
}
