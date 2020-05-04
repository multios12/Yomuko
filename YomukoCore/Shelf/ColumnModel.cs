namespace Yomuko.Shelf
{
    using Book;
    using System.Runtime.Serialization;

    /// <summary>
    /// 詳細リスト列の構造体
    /// </summary>
    [DataContract]
    public class ColumnModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ColumnModel()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fieldType">項目種類</param>
        /// <param name="width">幅</param>
        public ColumnModel(FieldType fieldType, int width)
        {
            this.FieldType = fieldType;
            this.Width = width;
        }

        /// <summary>項目種類</summary>
        [DataMember]
        public FieldType FieldType { get; set; }

        /// <summary>幅</summary>
        [DataMember]
        public int Width { get; set; }
    }
}
