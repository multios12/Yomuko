namespace UnitTest.Model.Shelf
{
    using ComicLaunch.Model.Shelf;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ShelfModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            ShelfModel model = new ShelfModel();
            Assert.AreEqual(0, model.BaseFolderPaths.Count);
            Assert.AreEqual(0, model.Bookmarks.Count);
            Assert.AreEqual(0, model.Books.Count);
            Assert.AreEqual(false, model.CollectSubTitle);
            Assert.AreEqual(0, model.Columns.Count);
            Assert.AreEqual(null, model.DuplicateFolderPath);
            Assert.AreEqual(0, model.FileNames.Count);
            Assert.AreEqual(null, model.FilePath);
            Assert.AreEqual(ComicLaunch.Image.PageSizeConstants.Fit, model.PageSize);
            Assert.AreEqual(null, model.Remarks);
            Assert.AreEqual(null, model.Title);
            Assert.AreEqual(false, model.UseBaseFolder);
        }
    }
}
