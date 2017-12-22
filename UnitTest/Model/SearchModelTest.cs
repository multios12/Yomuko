namespace UnitTest.Model
{
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SearchModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            var model = new SearchModel(FieldType.Hash, "テスト");
            Assert.AreEqual(FieldType.Hash, model.FieldType);
            Assert.AreEqual("テスト", model.Value);
        }

        [TestMethod]
        public void Check_Ok_FilePath()
        {
            BookModel book = new BookModel() { FilePath = "hogehoge", Hash = "テスト" };

            var model = new SearchModel(FieldType.FilePath, string.Empty);
            Assert.IsTrue(model.Check(book));
        }

        [TestMethod]
        public void Check_Ok_FilePathAndDirectory()
        {
            BookModel book = new BookModel() { FilePath = @"C:\temp\test.zip", Hash = "テスト" };

            var model = new SearchModel(FieldType.FilePath, @"C:\temp");
            Assert.IsTrue(model.Check(book));
        }

        [TestMethod]
        public void Check_Ok_True()
        {
            BookModel book = new BookModel() {FilePath="hogehoge", Hash = "テスト" };

            var model = new SearchModel(FieldType.Hash, "テスト");
            Assert.IsTrue(model.Check(book));
        }

        [TestMethod]
        public void Check_Ok_False()
        {
            BookModel book = new BookModel() { Hash = "テスト" };

            var model = new SearchModel(FieldType.Hash, "test");
            Assert.IsFalse(model.Check(book));
        }
    }
}
