namespace UnitTest.Model
{
    using System;
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BookmarkModelTest
    {
        [TestMethod]
        public void TestMethod()
        {
            BookmarkModel model = new BookmarkModel("abc", 10);

            Assert.AreEqual(10, model.PageIndex);
            Assert.AreEqual("abc", model.Hash);
            Assert.AreNotEqual(DateTime.MinValue, model.CreateDate);
        }
    }
}
