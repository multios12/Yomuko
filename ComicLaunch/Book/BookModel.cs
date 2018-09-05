namespace ComicLaunch.Book
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    /// <summary>
    ///  書籍情報モデル
    /// </summary>
    [Serializable]
    public partial class BookModel : INotifyPropertyChanged
    {
        /// <summary>コンストラクタ</summary>
        public BookModel()
        {
            this.Id = string.Empty;
            this.FilePath = string.Empty;
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="filePath">ファイルパス</param>
        public BookModel(string filePath)
            : this()
        {
            this.FilePath = filePath;

            // ファイル解析
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            var re = new Regex(string.Empty);
            Match ma;

            // ハッシュ取得
            // MD5ハッシュ値を計算する文字列
            byte[] fileData = new byte[10000];
            if (File.Exists(filePath))
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    // 文字列をbyte型配列に変換する
                    fileStream.Read(fileData, 0, 10000);
                }
            }

            // ハッシュ値を計算する
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bs = md5.ComputeHash(fileData);
            var result = new StringBuilder();

            foreach (byte b in bs)
            {
                result.Append(b.ToString("x2"));
            }

            this.Hash = result.ToString();

            // 日付の取得
            re = new Regex(@"(\[|\(|)([0-9][0-9]|)[0-9][0-9]([\/,\-]|)[0-9][0-9]([\/,\-]|)[0-9][0-9](\]|\)|)");
            if (re.IsMatch(fileName))
            {
                string matchString;
                matchString = re.Match(fileName).Value;
                matchString = matchString.Replace("/", string.Empty);
                matchString = matchString.Replace("-", string.Empty);
                matchString = matchString.Replace("[", string.Empty);
                matchString = matchString.Replace("]", string.Empty);
                matchString = matchString.Replace("(", string.Empty);
                matchString = matchString.Replace(")", string.Empty);

                matchString = matchString.Length == 6 ? "20" + matchString : matchString;
                matchString = matchString.Substring(0, 4) + "/" + matchString.Substring(4, 2) + "/" + matchString.Substring(6, 2);
                this.ReleaseDate = matchString;
                fileName = fileName.Replace(re.Match(fileName).Value, string.Empty);
            }

            // 完結
            re = new Regex(@"\(完結\)");

            if (re.IsMatch(fileName))
            {
                this.IsComplete = true;
                fileName = fileName.Replace("(完結)", string.Empty);
            }

            re = new Regex(@"\(完\)");

            if (re.IsMatch(fileName))
            {
                this.IsComplete = true;
                fileName = fileName.Replace("(完)", string.Empty);
            }

            // ジャンルの取得
            ma = Regex.Match(fileName, @"\([^\)]*\)");
            if (ma.Length > 0)
            {
                this.Type = Regex.Match(ma.Value, @"[^)|\(]+").Value;
                fileName = fileName.Replace(Regex.Match(fileName, @"\([^\)]*\)").Value, string.Empty);
            }

            if (this.Type?.Length == null)
            {
                ma = Regex.Match(fileName, @"（[^）]*）");
                if (ma.Length > 0)
                {
                    this.Type = Regex.Match(ma.Value, "[^）|（]+").Value;
                    fileName = fileName.Replace(Regex.Match(fileName, "（[^）]*）").Value, string.Empty);
                }
            }

            // 著者名の取得
            ma = Regex.Match(fileName, @"\[[^\]]*\]");
            if (ma.Length > 0)
            {
                this.Writer = Regex.Match(ma.Value, @"[^\]|\[]+").Value;
                fileName = fileName.Replace(Regex.Match(fileName, @"\[[^\]]*\]").Value, string.Empty);
            }

            // サブタイトルの取得
            ma = Regex.Match(fileName, @"第[0-9]*?巻.*");
            if (ma.Length > 0)
            {
                this.SubTitle = ma.Value;
                ma = Regex.Match(fileName, @"第[0-9]*?巻");
                this.SubTitle = this.SubTitle.Replace(ma.Value, string.Empty).Trim();
                fileName = fileName.Substring(0, fileName.Length - this.SubTitle.Length).Trim();
            }

            // Noの取得
            re = new Regex(@"第[0-9]*?巻");
            if (re.IsMatch(fileName))
            {
                this.No = re.Match(fileName).Value.Substring(1, re.Match(fileName).Value.Length - 2);
                fileName = fileName.Replace(re.Match(fileName).Value, string.Empty);
            }

            // タイトル
            this.Title = fileName.Trim();

            this.CreateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.UpdateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public BookModel(string filePath, AnalyzeResult status)
            : this(filePath)
        {
            this.Status = status;
        }

        /// <summary>プロパティ変更通知イベント</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region プロパティ：内容

        /// <summary>ファイルパス</summary>
        [Label("ファイルパス")]
        [XmlAttribute]
        public string FilePath { get; set; }

        /// <summary>タイトル</summary>
        [Label("タイトル")]
        [XmlAttribute]
        public string Title { get; set; }

        /// <summary>巻数</summary>
        [Label("巻数")]
        [XmlAttribute]
        public string No { get; set; }

        /// <summary>著者</summary>
        [Label("著者")]
        [XmlAttribute]
        public string Writer { get; set; }

        /// <summary>出版社</summary>
        [Label("出版社")]
        [XmlAttribute]
        public string PublishingCompany { get; set; }

        /// <summary>ジャンル</summary>
        [Label("ジャンル")]
        [XmlAttribute]
        public string Junle { get; set; }

        /// <summary>リリース日</summary>
        [Label("リリース日")]
        [XmlAttribute]
        public string ReleaseDate { get; set; }

        /// <summary>お気に入り</summary>
        [Label("お気に入り")]
        [XmlAttribute]
        public bool Favorite { get; set; }

        /// <summary>備考</summary>
        [Label("備考")]
        [XmlAttribute]
        public string Memo { get; set; }

        /// <summary>追加日</summary>
        [Label("追加日")]
        [XmlAttribute]
        public string CreateDate { get; set; }

        /// <summary>更新日</summary>
        [Label("更新日")]
        [XmlAttribute]
        public string UpdateDate { get; set; }

        /// <summary>ハッシュ</summary>
        [Label("ハッシュ")]
        [XmlAttribute]
        public string Hash { get; set; }

        /// <summary>種類</summary>
        [Label("種類")]
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>撮影者</summary>
        [Label("撮影者")]
        [XmlAttribute]
        public string Photographer { get; set; }

        /// <summary>掲載誌</summary>
        [Label("掲載誌")]
        [XmlAttribute]
        public string CarryMagazine { get; set; }

        /// <summary>サブタイトル</summary>
        [Label("サブタイトル")]
        [XmlAttribute]
        public string SubTitle { get; set; }

        /// <summary>表紙ファイルインデックス</summary>
        [Label("表紙ファイルインデックス")]
        [XmlAttribute]
        public int CoverFileIndex { get; set; }

        /// <summary>表紙表示幅</summary>
        [Label("表紙表示幅")]
        [XmlAttribute]
        public int CoverWidth { get; set; }

        /// <summary>表紙表示位置横方向</summary>
        [Label("表紙表示位置横方向")]
        [XmlAttribute]
        public int CoverLeft { get; set; }

        /// <summary>完結</summary>
        [Label("完結")]
        [XmlAttribute]
        public bool IsComplete { get; set; }

        /// <summary>タイトル（まとめ表示）</summary>
        public string CollectTitle
        {
            get
            {
                // タイトル（サブタイトルまとめ表示）
                var bulder = new StringBuilder();
                bulder.Append(this.Title);
                if (string.IsNullOrEmpty(this.No) == false)
                {
                    bulder.Append(" 第");
                    bulder.Append(this.No);
                    bulder.Append("巻");
                }

                if (this.IsComplete == true)
                {
                    bulder.Append("(完結)");
                }

                bulder.Append(" ");
                bulder.Append(this.SubTitle);
                return bulder.ToString().Trim();
            }
        }
        #endregion

        #region プロパティ

        /// <summary>ID</summary>
        [XmlIgnore]
        public string Id { get; set; }

        /// <summary>ファイル未検出フラグ </summary>
        [XmlIgnore]
        public bool IsDuplicate { get; set; }

        /// <summary>あいまい検索用タイトルデータ </summary>
        [XmlIgnore]
        public string EliminateTitle { get; set; }

        /// <summary>エラーが発生した場合True</summary>
        [XmlIgnore]
        public bool IsError { get; set; }

        /// <summary>エラーメッセージ</summary>
        [XmlIgnore]
        public string ErrorMessage { get; set; }

        /// <summary>結果ステータス</summary>
        [XmlIgnore]
        public AnalyzeResult Status { get; set; }
        #endregion

        /// <summary>指定された名前から、対応する書籍情報項目列挙型を返す</summary>
        /// <param name="fieldTypeName">書籍項目名</param>
        /// <returns>書籍情報項目列挙型</returns>
        /// <remarks>定義されていない名前が指定された場合、タイトルを返す</remarks>
        public static FieldType GetFieldType(string fieldTypeName)
        {
            foreach (FieldType value in Enum.GetValues(typeof(FieldType)))
            {
                if (value.ToString() == fieldTypeName)
                {
                    return value;
                }
            }

            foreach (FieldType value in Enum.GetValues(typeof(FieldType)))
            {
                if (value.LabelName() == fieldTypeName)
                {
                    return value;
                }
            }

            return FieldType.Title;
        }

        /// <summary>整形された値を返す</summary>
        /// <param name="fieldType">項目種類</param>
        /// <param name="isCollectSubTitle">サブタイトルをまとめて表示する場合、True</param>
        /// <returns>タイトル</returns>
        public string GetFormatValue(FieldType fieldType, bool isCollectSubTitle = false)
        {
            if (fieldType == FieldType.FilePath)
            {
                // ファイルパス
                return Path.GetDirectoryName(this.FilePath);
            }
            else if (fieldType == FieldType.Title && isCollectSubTitle)
            {
                // タイトル（サブタイトルまとめ表示）
                var item = new StringBuilder();
                item.Append(this.Title);
                if (string.IsNullOrWhiteSpace(this.No) == false)
                {
                    item.Append(" 第");
                    item.Append(this.No);
                    item.Append("巻");
                }

                if (this.IsComplete)
                {
                    item.Append("(完結)");
                }

                item.Append(" ");
                item.Append(this.SubTitle);
                return item.ToString();
            }
            else
            {
                // その他
                return this.GetValue(fieldType);
            }
        }

        /// <summary>ソートキーを生成して返します。</summary>
        /// <param name="keyFieldType">キー生成元項目</param>
        /// <returns>ソートキー</returns>
        public string GetSortKey(FieldType keyFieldType)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(this.GetValue(keyFieldType));

            if (keyFieldType != FieldType.Title && keyFieldType != FieldType.Title)
            {
                builder.Append(this.GetFormatValue(FieldType.Title));
            }

            return builder.ToString();
        }

        /// <summary>指定された項目の値を返します。</summary>
        /// <param name="fieldType">項目種類</param>
        /// <param name="collectSubTitle">サブタイトルをまとめて表示する場合、True</param>
        /// <returns>値</returns>
        public string GetValue(FieldType fieldType, bool collectSubTitle = false)
        {
            if (fieldType == FieldType.FilePath)
            {
                // ファイルパス
                if (string.IsNullOrEmpty(this.FilePath))
                {
                    return string.Empty;
                }
                else
                {
                    return this.FilePath;
                }
            }
            else if (fieldType == FieldType.Title && collectSubTitle == true)
            {
                var bulder = new StringBuilder();
                bulder.Append(this.Title);

                if (string.IsNullOrWhiteSpace(this.No) == false)
                {
                    bulder.Append(" 第");
                    bulder.Append(this.No);
                    bulder.Append("巻");
                }

                if (this.IsComplete == true)
                {
                    bulder.Append("(完結)");
                }

                bulder.Append(" ");
                bulder.Append(this.SubTitle);
                return bulder.ToString();
            }
            else
            {
                PropertyInfo info = typeof(BookModel).GetProperty(fieldType.ToString());
                string value = info.GetValue(this, null)?.ToString();

                if (value == null)
                {
                    value = string.Empty;
                }

                return value;
            }
        }

        /// <summary>
        /// 指定された値をタイトルに設定します。タイトルに指定された値の後尾以降に文字があった場合、サブタイトルに設定します。
        /// </summary>
        /// <param name="title">タイトル</param>
        public void ReplaceTitle(string title)
        {
            string targetTitle = this.Title;
            if (title.Length < targetTitle.Length)
            {
                targetTitle = targetTitle.Substring(0, title.Length);
            }

            if (title == targetTitle.Substring(0, title.Length))
            {
                string subTitle = this.Title
                    .Substring(title.Length, this.Title.Length - title.Length)
                    .Trim();
                this.Title = title;
                this.SubTitle = subTitle + this.SubTitle;
            }
        }

        /// <summary>指定された項目に値を設定する</summary>
        /// <param name="field">項目種類</param>
        /// <param name="value">値</param>
        public void SetValue(FieldType field, string value)
        {
            PropertyInfo info = typeof(BookModel).GetProperty(field.ToString());

            if (info.PropertyType == typeof(bool))
            {
                info.SetValue(this, value == "True", null);
            }
            else if (info.PropertyType == typeof(int))
            {
                int.TryParse(value, out int number);

                info.SetValue(this, number, null);
            }
            else
            {
                info.SetValue(this, value, null);
            }
        }

        /// <summary>指定された項目に値を設定する</summary>
        /// <param name="model">値</param>
        public void SetValues(BookModel model)
        {
            foreach (FieldType fieldType in Enum.GetValues(typeof(FieldType)))
            {
                this.SetValue(fieldType, model.GetValue(fieldType));
            }
        }

        /// <summary>エラー状態を変更します</summary>
        /// <param name="isError">trueの場合、エラー中</param>
        /// <param name="message">メッセージ</param>
        public void ChangeErrorStatus(bool isError, string message = null)
        {
            if (this.IsError != isError)
            {
                this.IsError = isError;
                this.ErrorMessage = message ?? message;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsError)));
            }
            else
            {
                this.ErrorMessage = message ?? message;
            }
        }
    }
}
