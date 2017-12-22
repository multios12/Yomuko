using System.Windows.Forms;

namespace CLibrary.Model
{
    /// <summary>
    /// 機能割り当てモデル
    /// </summary>
    public class AssignModel
    {
        /// <summary>トリガー</summary>
        public int Trigger { get; set; }

        /// <summary>トリガーが「キー入力」の場合の入力キー</summary>
        public Keys Key { get; set; }

        /// <summary>アクション</summary>
        public Actions Action { get; set; }

        public string Value { get; set; }
    }
}
