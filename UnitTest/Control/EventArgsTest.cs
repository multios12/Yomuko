namespace UnitTestProject1.Control
{
    using CLibrary.Control;
    using CLibrary.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// イベントデータのテストクラス
    /// </summary>
    [TestClass]
    public class EventArgsTest
    {
        [TestMethod]
        public void TestArchiveMovedEventArgs()
        {
            ArchiveMovedEventArgs e = new ArchiveMovedEventArgs(1, "test");

            Assert.AreEqual(1, e.Direction);
            Assert.AreEqual("test", e.NextFileName);
        }

        [TestMethod]
        public void TestSelectSearchEventArgs()
        {
            SelectSearchEventArgs e = new SelectSearchEventArgs(FieldType.FilePath, "test");
            Assert.AreEqual(FieldType.FilePath, e.FieldType);
            Assert.AreEqual("test", e.Value);
        }

        [TestMethod]
        public void TestPageEventArgs()
        {
            PageEventArgs e = new PageEventArgs("filepath", 10);

            Assert.AreEqual("filepath", e.FilePath);
            Assert.AreEqual(10, e.PageIndex);
        }

        [TestMethod]
        public void TestItemEventArgs()
        {
            ItemEventArgs<string> e = new ItemEventArgs<string>("テスト");
            Assert.AreEqual("テスト", e.Item);
        }
    }
}
