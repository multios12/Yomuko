namespace Yomuko.Shelf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Book;

    /// <summary>
    /// ファイル名リスト
    /// </summary>
    [Serializable]
    public class FileNameList : List<FileNameModel>
    {
        /// <summary>
        /// 初期化を行います。
        /// </summary>
        public void Initialize()
        {
            this.Clear();
            this.Add(new FileNameModel() { Front = "(", Back = ") ", Value = string.Empty, FieldType = FieldType.Type });
            this.Add(new FileNameModel() { Front = "[", Back = "] ", Value = string.Empty, FieldType = FieldType.Writer });
            this.Add(new FileNameModel() { Front = string.Empty, Back = " ", Value = string.Empty, FieldType = FieldType.Title });
            this.Add(new FileNameModel() { Front = "第", Back = "巻 ", Value = string.Empty, FieldType = FieldType.No });
            this.Add(new FileNameModel() { Front = string.Empty, Back = " ", Value = string.Empty, FieldType = FieldType.SubTitle });
            this.Add(new FileNameModel() { Front = "[", Back = "] ", Value = string.Empty, FieldType = FieldType.ReleaseDate });
        }

        /// <summary>書籍情報をもとにファイル名を変更する</summary>
        /// <param name="model">ファイル名整形情報</param>
        /// <returns>自分自身のモデル</returns>
        public BookModel ChangeFileName(BookModel model)
        {
            model.ChangeErrorStatus(false);

            // ファイル名生成
            StringBuilder builder = new StringBuilder();

            if (this.Count == 0)
            {
                this.Initialize();
            }

            // ルートフォルダの場合の処理
            if (Path.GetDirectoryName(model.FilePath).Equals(
                    Path.GetPathRoot(model.FilePath)))
            {
                builder.Append(Path.DirectorySeparatorChar);
            }

            // ファイル名生成
            foreach (FileNameModel item in this)
            {
                string value = string.Empty;

                if (model.GetValue(item.FieldType.Value).Length > 0)
                {
                    value = model.GetValue(item.FieldType.Value);
                }

                if (value.Length == 0)
                {
                    continue;
                }

                if (item.FieldType == FieldType.Type && !String.IsNullOrWhiteSpace(model.Junle))
                {
                    value = value + "・" + model.Junle;
                }

                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    value = value.Replace(c.ToString(), string.Empty);
                }

                builder.Append(item.Front);
                builder.Append(value.Trim());
                builder.Append(item.Back);
                if (item.FieldType == FieldType.No)
                {
                    if (model.IsComplete)
                    {
                        builder.Append("(完結)");
                    }
                }
            }

            string tmpFileName = builder.ToString().Trim() + Path.GetExtension(model.FilePath);
            tmpFileName = Path.Combine(Path.GetDirectoryName(model.FilePath), tmpFileName);

            // ファイル名置き換え
            var fi = new FileInfo(model.FilePath);

            if (tmpFileName == model.FilePath)
            {
                // 置き換え前と置き換え後が同一の場合、特に処理を行わない
                Debug.Print("・未変更        ：" + model.FilePath);
            }
            else if (File.Exists(tmpFileName) == false)
            {
                // ファイル名を変更する
                Debug.Print("・ファイル名変更：" + model.FilePath);
                Debug.Print("　　　　　　　　→" + builder.ToString());
                try
                {
                    File.Move(model.FilePath, tmpFileName);
                    model.FilePath = tmpFileName;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                    Debug.Print(ex.StackTrace);

                    model.IsError = true;
                    model.ErrorMessage = ex.Message;

                    // エラーを通知する
                    // model.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(model.IsError)));
                }

                // ファイルパスの変更を通知する
                // model.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(model.FilePath)));
            }
            else
            {
                // 重複エラーを通知する
                model.ChangeErrorStatus(true, "既にファイルが存在しています。");
            }

            return model;
        }
    }
}