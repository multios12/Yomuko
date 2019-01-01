namespace Yomuko.Image
{
    /// <summary>ページサイズ設定列挙型</summary>
    public enum PageSizeConstants
    {
        /// <summary>高さ・幅をウィンドウサイズに合わせます</summary>
        Fit,

        /// <summary>幅をウィンドウサイズに合わせます</summary>
        FitWidth,

        /// <summary>実サイズから、50パーセント縮小して表示します</summary>
        Percent050,

        /// <summary>実サイズから、75パーセント縮小して表示します</summary>
        Percent075,

        /// <summary>実サイズから、変更せずに100パーセントのサイズで表示します</summary>
        Percent100,

        /// <summary>実サイズから、150パーセント拡大して表示します</summary>
        Percent150,

        /// <summary>実サイズから、200パーセント拡大して表示します</summary>
        Percent200,

        /// <summary>実サイズから、300パーセント拡大して表示します</summary>
        Percent300,

        /// <summary>実サイズから、400パーセント拡大して表示します</summary>
        Percent400
    }
}
