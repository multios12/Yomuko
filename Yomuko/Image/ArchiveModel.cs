namespace Yomuko.Image
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// 画像が入った圧縮ファイルを操作するためのクラス
    /// </summary>
    public class ArchiveModel : IDisposable
    {
        /// <summary>ファイルパス</summary>
        private string filePath;

        /// <summary>アーカイブ内のファイルリスト</summary>
        private List<string> entryNames = new List<string>();

        /// <summary>画像操作クラス</summary>
        private ImageOperator imageOperator = new ImageOperator();

        /// <summary>インデックス</summary>
        private int pageIndex;

        /// <summary>表示中のビットマップ</summary>
        private Bitmap pictureBitmap;

        /// <summary>重複する呼び出しを検出するには</summary>
        private bool disposedValue = false;

        /// <summary>
        /// new コンストラクタ
        /// </summary>
        /// <param name="filePath">読み込む圧縮ファイルのファイルパス</param>
        public ArchiveModel(string filePath)
        {
            this.MovementX = 800;
            this.MovementY = 800;

            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("圧縮ファイルが見つかりませんでした", filePath);
            }

            this.filePath = filePath;
            this.entryNames = ArchiveImagerHelper.Open(this.filePath);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="height">高さ</param>
        /// <param name="width">幅</param>
        public ArchiveModel(string filePath, int height, int width)
            : this(filePath)
        {
            this.DrawHeight = height;
            this.DrawWidth = width;
        }

        #region プロパティ

        /// <summary>表示モード</summary>
        public ResizeModeConstants PictureMode { get; set; }

        /// <summary>枠の高さ</summary>
        public int DrawHeight { get; set; }

        /// <summary>枠の幅</summary>
        public int DrawWidth { get; set; }

        /// <summary>表示位置(縦)</summary>
        public int ScreenTop { get; set; }

        /// <summary>表示位置(横)</summary>
        public int ScreenLeft { get; set; }

        /// <summary>レート</summary>
        public float Ratio { get; set; }

        /// <summary>サイズ変更モード</summary>
        public ResizeModeConstants ResizeMode { get; set; }

        /// <summary>サイズ変更時の高さ</summary>
        public long ResizeHeight { get; set; }

        /// <summary>サイズ変更時の幅</summary>
        public long ResizeWidth { get; set; }

        /// <summary>サイズ変更時のパーセンテージ</summary>
        public int ResizePercent { get; set; }

        /// <summary>移動距離（幅）</summary>
        public int MovementX { get; set; }

        /// <summary>移動距離（高さ）</summary>
        public int MovementY { get; set; }

        /// <summary>インデックス</summary>
        public int PageIndex
        {
            get
            {
                return this.pageIndex;
            }

            set
            {
                if (value > this.entryNames.Count)
                {
                    // MsgBox("エラー");
                    return;
                }

                this.pageIndex = value;

                // imageOperatorの設定変更
                this.imageOperator.Mode = this.ResizeMode;
                this.imageOperator.ResizeHeight = this.ResizeHeight;
                this.imageOperator.ResizeWidth = this.ResizeWidth;
                this.imageOperator.ResizePercent = this.ResizePercent;

                // 画像の取得
                try
                {
                    var i = ArchiveImagerHelper.GetStream(this.filePath, value);
                    this.pictureBitmap = this.imageOperator.ResizeBitmap(i);

                    this.ScreenLeft = this.pictureBitmap.Width - this.DrawWidth;
                    if (this.ScreenLeft < 0)
                    {
                        this.ScreenLeft = 0;
                    }

                    this.ScreenTop = 0;
                }
                catch (Exception)
                {
                    Debug.Print("画像取得に失敗");
                    this.pictureBitmap = null;
                }
            }
        }

        /// <summary>圧縮ファイルに含まれる画像の数を返します</summary>
        public int PageCount
        {
            get
            {
                return this.entryNames.Count;
            }
        }

        /// <summary>書籍のパスを返します</summary>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }

        /// <summary>
        /// エントリ名の一覧を返します。
        /// </summary>
        public IEnumerable<string> EntryNames
        {
            get
            {
                // return this.entries.Select(f => f.Key);
                return this.entryNames;
            }
        }

        /// <summary>現在のページを返します。</summary>
        /// <returns>ビットマップ</returns>
        public Bitmap PagePicture
        {
            get
            {
                if (this.pictureBitmap == null)
                {
                    this.PageIndex = this.pageIndex;
                    if (this.pictureBitmap == null)
                    {
                        return new Bitmap(this.DrawWidth, this.DrawHeight);
                    }
                }

                var distBitmap = new Bitmap(this.DrawWidth, this.DrawHeight);

                using (Graphics g = Graphics.FromImage(distBitmap))
                {
                    var rect = new Rectangle(this.ScreenLeft, this.ScreenTop, this.DrawWidth, this.DrawHeight);
                    g.DrawImage(this.pictureBitmap, 0, 0, rect, GraphicsUnit.Pixel);
                }

                return distBitmap;
            }
        }
        #endregion

        /// <summary>ポインタを次方向に移動します。</summary>
        /// <returns>終端である場合、-1</returns>
        public int ScrollNext()
        {
            if (this.pictureBitmap == null)
            {
                if (this.pageIndex + 1 < this.entryNames.Count)
                {
                    // 次の画像をスクロール
                    this.PageIndex += 1;
                    return this.PageIndex;
                }
                else
                {
                    // 圧縮ファイルの終端に達してる
                    return -1;
                }
            }

            if (!(this.DrawHeight + this.ScreenTop >= this.pictureBitmap.Height))
            {
                // 画像のY軸が画像枠をはみ出してる＆画像が下まで達していない
                // Y軸のスクロールを行う
                this.ScreenTop = this.ScreenTop + this.MovementY;

                if (this.ScreenTop + this.DrawHeight > this.pictureBitmap.Height)
                {
                    this.ScreenTop = this.pictureBitmap.Height - this.DrawHeight;
                }

                return this.PageIndex;
            }
            else
            {
                if (this.ScreenLeft > 0)
                {
                    // 画像のX軸が画像枠をはみ出してる＆画像が左端まで達してない
                    // X軸のスクロールを行う
                    this.ScreenTop = 0;
                    this.ScreenLeft -= this.MovementX;

                    if (this.ScreenLeft < 0)
                    {
                        this.ScreenLeft = 0;
                    }

                    return this.PageIndex;
                }
                else
                {
                    if (this.PageIndex + 1 < this.entryNames.Count)
                    {
                        // 次の画像をスクロール
                        this.PageIndex += 1;
                    }
                    else
                    {
                        // 圧縮ファイルの終端に達してる
                        return -1;
                    }

                    return this.PageIndex;
                }
            }
        }

        /// <summary>ポインタを前方向に移動します。</summary>
        /// <returns>終端である場合、-1</returns>
        public int ScroolBack()
        {
            if (this.pictureBitmap == null)
            {
                if (this.pageIndex == 0)
                {
                    return -1;
                }
                else
                {
                    this.PageIndex = this.PageIndex - 1;
                    this.ScreenTop = this.pictureBitmap.Height - this.DrawHeight;

                    if (this.ScreenTop < 0)
                    {
                        this.ScreenTop = 0;
                    }
                }
            }

            if (this.ScreenTop > 0)
            {
                // 画像が上端まで達していない
                // Y軸のスクロールを行う
                this.ScreenTop = this.ScreenTop - this.MovementY;
                if (this.ScreenTop < 0)
                {
                    this.ScreenTop = 0;
                }

                return this.PageIndex;
            }
            else
            {
                if (!(this.DrawWidth + this.ScreenLeft >= this.pictureBitmap.Width))
                {
                    // 画像のX軸が画像枠をはみ出してるor 画像が右端まで達していない
                    this.ScreenLeft = this.ScreenLeft + this.MovementY;
                    this.ScreenTop = this.pictureBitmap.Height - this.DrawHeight;
                    if (this.ScreenTop < 0)
                    {
                        this.ScreenTop = 0;
                    }

                    return this.PageIndex;
                }
                else
                {
                    if (this.pageIndex == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        this.PageIndex = this.PageIndex - 1;
                        if (this.pictureBitmap != null)
                        {
                            this.ScreenTop = this.pictureBitmap.Height - this.DrawHeight;

                            if (this.ScreenTop < 0)
                            {
                                this.ScreenTop = 0;
                            }
                        }

                        return this.PageIndex;
                    }
                }
            }
        }

        /// <summary>指定された方向にポインタを移動します。</summary>
        /// <param name="direction">1以上が指定された場合順方向、マイナスの値が指定された場合、逆方向</param>
        /// <returns>終端である場合、-1</returns>
        public int Scroll(int direction)
        {
            if (direction > 0)
            {
                // 次にスクロール
                return this.ScrollNext();
            }
            else if (direction < 0)
            {
                // 前にスクロール
                return this.ScroolBack();
            }

            return 0;
        }

        /// <summary>
        /// ページサイズ設定により、動作モードを変更します。
        /// </summary>
        /// <param name="value">ページサイズ設定</param>
        /// <param name="height">高さ</param>
        /// <param name="width">幅</param>
        public void SetPageSize(PageSizeConstants value, long height, long width)
        {
            switch (value)
            {
                case PageSizeConstants.Fit:
                    this.ResizeMode = ResizeModeConstants.RatioKeep;
                    this.ResizeHeight = height;
                    this.ResizeWidth = width;
                    break;
                case PageSizeConstants.FitWidth:
                    this.ResizeMode = ResizeModeConstants.RatioKeep;
                    this.ResizeHeight = -1;
                    this.ResizeWidth = width;
                    break;
                case PageSizeConstants.Percent050:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 50;
                    break;
                case PageSizeConstants.Percent075:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 75;
                    break;
                case PageSizeConstants.Percent100:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 100;
                    break;
                case PageSizeConstants.Percent150:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 150;
                    break;
                case PageSizeConstants.Percent200:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 200;
                    break;
                case PageSizeConstants.Percent300:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 300;
                    break;
                case PageSizeConstants.Percent400:
                    this.ResizeMode = ResizeModeConstants.Percent;
                    this.ResizePercent = 400;
                    break;
            }
        }

        #region IDisposable Support

        /// <summary>リソースを解放します。</summary>
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            this.Dispose(true);
        }

        /// <summary>リソースを解放します。</summary>
        /// <param name="disposing">マネージオブジェクトを解放する場合、Trueを設定します。</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // マネージ状態を破棄します (マネージ オブジェクト)。
                    // this.archive.Dispose();
                }

                // アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // 大きなフィールドを null に設定します。
                this.disposedValue = true;
            }
        }
        #endregion
    }
}
