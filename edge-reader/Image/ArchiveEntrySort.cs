namespace ComicLaunch.Image
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using SharpCompress.Archives;

    /// <summary>アーカイブオブジェクトソート</summary>
    public class ArchiveEntrySort : IComparer<IArchiveEntry>
    {
        /// <summary>数字リスト</summary>
        private char[] chrNum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>コンストラクタ</summary>
        public ArchiveEntrySort()
        {
            this.Order = SortOrder.Ascending;
        }

        /// <summary>ソート順(昇順・降順)</summary>
        public SortOrder Order { get; set; }

        /// <summary>2 つのオブジェクトを比較して、一方が他方より小さいか、同じか、または大きいかを示す値を返します。</summary>
        /// <param name="x">比較する最初のオブジェクト</param>
        /// <param name="y">比較する二つ目のオブジェクト</param>
        /// <returns>x と y の相対値を示す符号付き整数</returns>
        public int Compare(IArchiveEntry x, IArchiveEntry y)
        {
            int result = 0;

            try
            {
                result = this.CompareFilePath(x.Key, y.Key);

                // 降順のときは結果を逆転
                if (this.Order == SortOrder.Descending)
                {
                    result = -result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // 結果を返す
            return result;
        }

        /// <summary>
        /// 文字列内の数値として認識できる部位を検査し、比較した値を返す
        /// </summary>
        /// <param name="path1">比較対象ファイルパス1</param>
        /// <param name="path2">比較対象ファイルパス2</param>
        /// <returns>比較結果</returns>
        private int CompareFilePath(string path1, string path2)
        {
            int intNext1 = 0;
            long lngNum1 = -1;

            // はじめの文字列から数値として認識できる部分を探す
            int idx1 = path1.IndexOfAny(this.chrNum);

            // 見つかった場合
            if (idx1 != -1)
            {
                // 位置を格納
                int position = idx1;

                // 長さの初期値
                int intLength = 1;

                // 見つかった位置から文字列の終わりまで検査
                for (int i = idx1 + 1; i < path1.Length; i++)
                {
                    // 数値として認識できるか検査
                    int idx = path1.Substring(i, 1).IndexOfAny(this.chrNum);

                    // 数値として認識できない場合は抜ける
                    if (idx == -1)
                    {
                        break;
                    }

                    // 長さを格納
                    intLength += 1;
                }

                // 数値をLong値として格納
                lngNum1 = long.Parse(path1.Substring(position, intLength));

                // 文字列の途中で終了した場合
                if (position + intLength != path1.Length)
                {
                    // ループを抜けたポイントを格納
                    intNext1 = position + intLength;
                }
            }

            // 次の文字列から数値として認識できる部分を探す
            int intNext2 = 0;
            long lngNum2 = -1;

            int idx2 = path2.IndexOfAny(this.chrNum);

            // 見つかった場合
            if (idx2 != -1)
            {
                // 位置を格納
                int position = idx2;

                // 長さの初期値
                int intLength = 1;

                // 見つかった位置から文字列の終わりまで検査
                for (int i = idx2 + 1; i < path2.Length; i++)
                {
                    // 数値として認識できるか検査
                    int idx = path2.Substring(i, 1).IndexOfAny(this.chrNum);

                    // 数値として認識できない場合は抜ける
                    if (idx == -1)
                    {
                        break;
                    }

                    // 長さを格納
                    intLength += 1;
                }

                // 数値をLong値として格納
                lngNum2 = long.Parse(path2.Substring(position, intLength));

                // 文字列の途中で終了した場合
                if (position + intLength != path2.Length)
                {
                    // ループを抜けたポイントを格納
                    intNext2 = position + intLength;
                }
            }

            // 数値が認識されなかったか、
            // または同じ位置ではない場合
            int result;
            if (idx1 == -1 || idx2 == -1 || (idx1 != idx2))
            {
                // 単純比較を行なう
                result = string.Compare(path1, path2);
            }
            else
            {
                // 文字列の先頭が数値として認識されたか、
                // または数値より前の文字列が同じ場合
                if ((idx1 == 0 && idx2 == 0) ||
                    (path1.Substring(0, path1.Length - (path1.Length - idx1)) == path2.Substring(0, path2.Length - (path2.Length - idx2))))
                {
                    // 数値として認識でき、ひとつめが大きい場合
                    if (lngNum1 != -1 && lngNum2 != -1 && lngNum1 > lngNum2)
                    {
                        // 入れ替える値を格納
                        result = 1;
                    }
                    else if (lngNum1 != -1 && lngNum2 != -1 && lngNum1 < lngNum2)
                    {
                        // 数値として認識でき、ひとつめが小さい場合は
                        // 入れ替えない値を格納
                        result = -1;
                    }
                    else if (intNext1 != 0 && intNext2 != 0)
                    {
                        // 文字列の最後まで調べていない場合は再帰
                        result = this.CompareFilePath(path1.Substring(intNext1), path2.Substring(intNext2));
                    }
                    else
                    {
                        // 入れ替えない値を格納
                        result = -1;
                    }
                }
                else
                {
                    // 数値より前の文字列が違う場合は単純比較
                    result = string.Compare(path1, path2);
                }
            }

            // 値を返す
            return result;
        }
    }
}
