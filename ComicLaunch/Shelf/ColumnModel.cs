namespace ComicLaunch.Shelf
{
    using System;
    using System.Xml.Serialization;
    using Book;

    /// <summary>
    /// 詳細リスト列の構造体
    /// </summary>
    [Serializable]
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
        [XmlAttribute]
        public FieldType FieldType { get; set; }

        /// <summary>幅</summary>
        [XmlAttribute]
        public int Width { get; set; }
    }
}
