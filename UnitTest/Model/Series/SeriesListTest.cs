namespace UnitTest.Model
{
    using ComicLaunch.Model;
    using ComicLaunch.Model.Series;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SeriesListTest
    {
        [TestMethod]
        public void Sort()
        {
            SeriesList list = new SeriesList
            {
                new BookModel() { Title = "テスト01テスト", Writer = "ジョン", No = "02" },
                new BookModel() { Title = "テスト02テスト", Writer = "ジョン", },
                new BookModel() { Title = "テスト03テスト", Writer = "アダムス", },
                new BookModel() { Title = "テスト01テスト", Writer = "ジョン", No = "03" },
                new BookModel() { Title = "テスト01テスト", Writer = "ジョン", No = "01" }
            };
            list.Sort();

            list.SortKey = "著者";
            list.Sort();

            Assert.AreEqual("著者", list.SortKey);
            Assert.AreEqual("アダムス", list[0].Writer);
            Assert.AreEqual("ジョン", list[1].Writer);

            list.SortKey = "タイトル";
            list.Sort();

            Assert.AreEqual("タイトル", list.SortKey);
            Assert.AreEqual("テスト01テスト", list[0].Title);
            Assert.AreEqual("テスト02テスト", list[1].Title);

            list.Sort();
            Assert.AreEqual("テスト03テスト", list[0].Title);
            Assert.AreEqual("テスト02テスト", list[1].Title);

            list.SortKey = "冊数";
            list.Sort();

            list.SortKey = "初巻発売日";
            list.Sort();

            list.SortKey = "最新刊";
            list.Sort();
        }
    }
}
