namespace Yomuko.Shelf
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Yomuko.Book;

    /// <summary>ファイル名生成定義構造体</summary>
    [DataContract]
    public class FileNameModel
    {
        /// <summary>コンストラクタ</summary>
        public FileNameModel()
        {
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="front">区切り文字(先頭)</param>
        /// <param name="back">区切り文字(後尾)</param>
        /// <param name="fieldType">項目種別</param>
        /// <param name="value">値</param>
        public FileNameModel(string front, string back, FieldType? fieldType, string value)
        {
            this.Back = back;
            this.Front = front;
            this.FieldType = fieldType;
            this.Value = value;
        }

        /// <summary>区切り文字(後尾)</summary>
        [DataMember]
        public string Back { get; set; }

        /// <summary>区切り文字(先頭)</summary>
        [DataMember]
        public string Front { get; set; }

        /// <summary>種別</summary>
        [DataMember]
        public string TypeName
        {
            get
            {
                return this.FieldType.ToString();
            }

            set
            {
                try
                {
                    this.FieldType = (FieldType)Enum.Parse(typeof(FieldType), value);
                }
                catch (Exception)
                {
                    this.FieldType = null;
                }
            }
        }

        /// <summary>値</summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>項目種別</summary>
        [IgnoreDataMember]
        public FieldType? FieldType { get; set; }

        /// <summary>サンプル</summary>
        [IgnoreDataMember]
        public string SampleText => this.Front + " " + this.Back;
    }
}