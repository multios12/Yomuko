namespace ComicLaunch.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using Duplicate;

    /// <summary>
    /// リスト（重複検出）
    /// </summary>
    public partial class BookList
    {
        /// <summary>除外文字</summary>
        private List<string> ignoreChars = new List<string>() { " ", "　", "[", "]" };

        /// <summary>
        /// 重複リストを作成します。
        /// </summary>
        /// <returns>重複リスト</returns>
        public List<DuplicateModel> CreateDuplicateList()
        {
            this.ToList().ForEach(b => b.Status = AnalyzeResult.NotRunning);
            this.ToList().ForEach(b => this.CreateEliminateValue(b));

            var group = this.GroupBy(b => b.EliminateTitle);
            group = group.Where(g => g.Count() > 1);
            return group.Select(g => new DuplicateModel(g)).ToList();
        }

        /// <summary>
        /// 指定したモデルから、タイトルのあいまい検索データを返します。
        /// </summary>
        /// <param name="model">モデル</param>
        /// <remarks>
        /// タイトルのあいまい検索データは、小文字で表現され、重複チェックに必要がない記号・空白等が排除されます。
        /// </remarks>
        public void CreateEliminateValue(BookModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) == true)
            {
                return;
            }

            string value = model.GetFormatValue(FieldType.Title, false).Trim();
            value = Utils.Kanaxas.ToHankaku(value);
            value = value.ToLower();

            this.ignoreChars.ForEach(c => value = value.Replace(c, string.Empty));

            model.EliminateTitle = value;
        }
    }
}
