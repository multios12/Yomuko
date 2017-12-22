﻿namespace ComicLaunch.Model
{
    using System;
    using System.Xml.Serialization;

    /// <summary>ファイル名生成定義構造体</summary>
    [Serializable]
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
        [XmlAttribute]
        public string Back { get; set; }

        /// <summary>区切り文字(先頭)</summary>
        [XmlAttribute]
        public string Front { get; set; }

        /// <summary>種別</summary>
        [XmlAttribute]
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
        [XmlAttribute]
        public string Value { get; set; }

        /// <summary>項目種別</summary>
        [XmlIgnore]
        public FieldType? FieldType { get; set; }

        /// <summary>サンプル</summary>
        [XmlIgnore]
        public string SampleText => this.Front + " " + this.Back;
    }
}