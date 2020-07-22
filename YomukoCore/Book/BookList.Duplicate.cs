namespace Yomuko.Book
{
    using Duplicate;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// リスト（重複検出）
    /// </summary>
    public partial class BookList
    {
        /// <summary>除外文字</summary>
        private List<string> ignoreChars = new List<string>() { " ", "　", "[", "]" };

        private Regex regex = new Regex(@"\(\d\)");


        /// <summary>
        /// 重複リストを作成します。
        /// </summary>
        /// <returns>重複リスト</returns>
        public List<DuplicateModel> CreateDuplicateList()
        {
            Debug.Print("[{0}]{1}", DateTime.Now.ToString("HH:mm:ss"), "BookList.CreateDuplicateList:Start");

            this.CreateEliminateValue();

            var group = this.GroupBy(b => b.EliminateTitle);
            group = group.Where(g => g.Count() > 1);

            var gr = group.Select(g => new DuplicateModel(g)).ToList();
            Debug.Print("[{0}]{1}", DateTime.Now.ToString("HH:mm:ss"), "BookList.CreateDuplicateList:End");
            return gr;
        }

        /// <summary>
        /// 指定したモデルから、タイトルのあいまい検索データを返します。
        /// </summary>
        /// <param name="model">モデル</param>
        /// <remarks>
        /// タイトルのあいまい検索データは、小文字で表現され、重複チェックに必要がない記号・空白等が排除されます。
        /// </remarks>
        public void CreateEliminateValue()
        {
            foreach (var model in this)
            {
                model.Status = AnalyzeResult.NotRunning;

                if (string.IsNullOrWhiteSpace(model.Title))
                {
                    continue;
                }

                string value = model.GetFormatValue(FieldType.Title, true);
                value = value.Replace("[DL版]", "");
                value = value.Trim();
                value = Utils.Kanaxas.ToHankaku(value);
                value = value.ToLower();

                this.ignoreChars.ForEach(c => value = value.Replace(c, string.Empty));
                value = regex.Replace(value, String.Empty);

                model.EliminateTitle = value;
            }
        }
    }
}
