namespace UnitTestProject1.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComicLaunch.Model.Series;
    using ComicLaunch.Model;
    [TestClass]
    public class SeriesModelTest
    {
        /// <summary>コンストラクタテスト 正常系 引数なし</summary>
        [TestMethod]
        public void Constructor_Ok_ArgumentNull()
        {
            SeriesModel model = new SeriesModel();
            Assert.AreEqual(0, model.Count);
            Assert.AreEqual(null, model.FirstBook);
            Assert.AreEqual(string.Empty, model.FirstReleaseDate);

            Assert.AreEqual(null, model.LastBook);
            Assert.AreEqual(string.Empty, model.LastNo);
            Assert.AreEqual(string.Empty, model.LastReleaseDate);

            Assert.AreEqual(false, model.IsComplete);
            Assert.AreEqual(string.Empty, model.Title);
            Assert.AreEqual(string.Empty, model.Writer);
        }

        /// <summary>コンストラクタテスト 正常系 引数1</summary>
        [TestMethod]
        public void Constructor_Ok_1Argument()
        {
            BookModel bookmodel = new BookModel();
            bookmodel.IsComplete = true;
            bookmodel.No = "02";
            bookmodel.ReleaseDate = "2010/01/01";
            bookmodel.Title = "テスト１";
            bookmodel.Writer = "テスト２";

            SeriesModel model = new SeriesModel(bookmodel);
            Assert.AreEqual(1, model.Count);

            Assert.AreEqual(bookmodel, model.FirstBook);
            Assert.AreEqual("2010/01/01", model.FirstReleaseDate);

            Assert.AreEqual(bookmodel, model.LastBook);
            Assert.AreEqual("02", model.LastNo);
            Assert.AreEqual("2010/01/01", model.LastReleaseDate);

            Assert.AreEqual(true, model.IsComplete);
            Assert.AreEqual("テスト１", model.Title);
            Assert.AreEqual("テスト２", model.Writer);
        }
    }
}
