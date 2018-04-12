namespace ComicLaunch.Image
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>画像操作クラス</summary>
    public class ImageOperator
    {
        /// <summary>コンストラクタ</summary>
        public ImageOperator()
        {
            this.SaveFormat = ImageFormat.Jpeg;
        }

        /// <summary>保存時の画像フォーマット</summary>
        public ImageFormat SaveFormat { get; set; }

        /// <summary>サイズ変更モード</summary>
        public ResizeModeConstants Mode { get; set; }

        /// <summary>サイズ変更時の高さ</summary>
        public long ResizeHeight { get; set; }

        /// <summary>サイズ変更時の幅</summary>
        public long ResizeWidth { get; set; }

        /// <summary>サイズ変更時のパーセンテージ</summary>
        public int ResizePercent { get; set; }

        /// <summary>保存時の品質</summary>
        public int SaveQuality { get; set; }

        /// <summary>画像サイズ変更して返す</summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>サイズを変更した画像</returns>
        public Bitmap ResizeBitmap(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return this.ResizeBitmap(stream);
            }
        }

        /// <summary>画像サイズ変更して返す</summary>
        /// <param name="stream">ストリーム</param>
        /// <returns>サイズを変更した画像</returns>
        public Bitmap ResizeBitmap(Stream stream)
        {
            return this.ResizeBitmap(new Bitmap(stream));
        }

        /// <summary>画像サイズ変更して返す</summary>
        /// <param name="image">画像</param>
        /// <returns>サイズを変更した画像</returns>
        public Bitmap ResizeBitmap(Bitmap image)
        {
            float ratioHeight = 1;
            float ratioWidth = 1;

            switch (this.Mode)
            {
                case ResizeModeConstants.Fit:
                    ratioHeight = (float)this.ResizeHeight / image.Height;
                    ratioWidth = (float)this.ResizeWidth / image.Width;
                    break;
                case ResizeModeConstants.RatioKeep:
                    if (image.Height > image.Width)
                    {
                        ratioHeight = (float)this.ResizeHeight / image.Height;
                        ratioWidth = (float)this.ResizeHeight / image.Height;
                    }
                    else
                    {
                        ratioHeight = (float)this.ResizeWidth / image.Width;
                        ratioWidth = (float)this.ResizeWidth / image.Width;
                    }

                    break;
                case ResizeModeConstants.Percent:
                    // 指定のパーセンテージ拡大する
                    ratioHeight = (float)this.ResizePercent / 100;
                    ratioWidth = (float)this.ResizePercent / 100;
                    break;
            }

            // 変更後の画像を格納するためのキャンパス
            var distBitmap = new Bitmap((int)(image.Width * ratioWidth), (int)(image.Height * ratioHeight));

            // 画像の縮小処理
            using (Graphics g = Graphics.FromImage(distBitmap))
            {
                // 保管方法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                RectangleF rect =
                    new RectangleF(0, 0, ratioWidth * image.Width, ratioHeight * image.Height);
                g.DrawImage(image, 0, 0, ratioWidth * image.Width, ratioHeight * image.Height);
            }

            return distBitmap;
        }

        /// <summary>
        /// 指定されたbitmapをJpegで保存し、Byte型データとして受け渡す
        /// </summary>
        /// <param name="bmp">保存するビットマップオブジェクト</param>
        /// <param name="quality">保存する画像の品質</param>
        /// <returns>保存に成功した場合、JPEG画像をビットマップとして返す</returns>
        public byte[] SaveImageToByte(Bitmap bmp, int quality)
        {
            // EncoderParameterオブジェクトを1つ格納できるEncoderParametersクラスの新しいインスタンスを初期化ここでは品質のみ指定するため1つだけ用意する
            var eps = new EncoderParameters(1);

            // EncoderParametersにセットする
            eps.Param[0] = new EncoderParameter(Encoder.Quality, this.SaveQuality);

            // イメージエンコーダに関する情報を取得する
            ImageCodecInfo ici = this.GetEncoderInfo(this.SaveFormat);

            // 保存する
            var memory = new MemoryStream();
            byte[] buffer = null;

            try
            {
                bmp.Save(memory, ici, eps);
                Array.Resize(ref buffer, (int)memory.Length - 1);
                memory.Seek(0, SeekOrigin.Begin);
                memory.Read(buffer, 0, (int)memory.Length);
            }
            catch (Exception)
            {
                buffer = null;
            }
            finally
            {
                memory.Close();
            }

            return buffer;
        }

        /// <summary>指定されたフォーマットのエンコーダ情報を返します。</summary>
        /// <param name="format">フォーマット</param>
        /// <returns>エンコーダ情報</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            foreach (var encoder in ImageCodecInfo.GetImageEncoders())
            {
                if (encoder.FormatID == format.Guid)
                {
                    return encoder;
                }
            }

            return null;
        }
    }
}