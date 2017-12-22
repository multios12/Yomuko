namespace UnitTestProject1.Model.Shelf
{
    using ComicLaunch.Model;
    using ComicLaunch.Model.Shelf;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ColumnModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            ColumnModel model = new ColumnModel();

            model = new ColumnModel(FieldType.Hash, 120);
            Assert.AreEqual(120, model.Width);
            Assert.AreEqual(FieldType.Hash, model.FieldType);
        }
    }
}
