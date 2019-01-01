namespace Yomuko.Book
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using YomukoCore.Properties;
    using Utils;

    /// <summary>
    /// 管理モデル
    /// </summary>
    public partial class BookModel
    {
        /// <summary>
        /// ファイルが存在するかどうかを確認します。
        /// </summary>
        /// <returns>ファイルが存在する場合、True</returns>
        public bool FileExists()
        {
            return File.Exists(this.FilePath);
        }

        /// <summary>
        /// ファイルを削除します。
        /// </summary>
        /// <returns>自分自身のモデル</returns>
        public BookModel FileDelete()
        {
            this.ChangeErrorStatus(false);
            try
            {
                if (this.FileExists() == false)
                {
                    return this;
                }

                FileAttributes attributes = File.GetAttributes(this.FilePath);
                attributes = attributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(this.FilePath, attributes);

                File.Delete(this.FilePath);
            }
            catch (Exception ex)
            {
                this.ChangeErrorStatus(true, "ファイルを削除できませんでした。");
                Debug.Print(ex.Message);
                Debug.Print(ex.StackTrace);
            }

            return this;
        }

        /// <summary>
        /// 指定したフォルダにファイルを移動します。
        /// </summary>
        /// <param name="distPath">フォルダパス</param>
        /// <returns>自分自身のモデル</returns>
        public BookModel FileMove(string distPath)
        {
            this.ChangeErrorStatus(false);

            if (this.FileExists() == false)
            {
                this.ChangeErrorStatus(true, Resources.ErrorFileNotFound.FormatWith(this.FilePath));
                return this;
            }

            if (File.Exists(distPath) == true)
            {
                this.ChangeErrorStatus(true, Resources.ErrorMoveExists.FormatWith(distPath));
                return this;
            }

            try
            {
                string distFilePath = Path.Combine(distPath, Path.GetFileName(this.FilePath));

                if (File.Exists(distFilePath))
                {
                    distFilePath = Path.GetFileNameWithoutExtension(distFilePath) + DateTime.Now.ToString("yyyyMMdd") +
                        Path.GetRandomFileName();
                    distFilePath += Path.GetExtension(this.FilePath);
                    distFilePath = Path.Combine(distPath, distFilePath);
                }

                File.Move(this.FilePath, distFilePath);
                this.FilePath = distFilePath;

                // ファイルパスの変更を通知する
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FilePath)));
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print(ex.StackTrace);

                // エラーの発生を通知する
                this.ChangeErrorStatus(true, "ファイルを移動できませんでした。");
            }

            return this;
        }
    }
}
