namespace ComicLaunch.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// ファイル名リスト
    /// </summary>
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
            this.Add(new FileNameModel() { Front = "[", Back = "] ", Value = string.Empty, FieldType = FieldType.ReleaseDate });
        }
    }
}