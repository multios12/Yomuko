namespace UnitTest.Model
{
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// SyncStatusEventArgs
    /// 
    /// </summary>
    [TestClass]
    public class SyncStatusEventArgsTest
    {
        [TestMethod]
        public void TestMethod()
        {
            SyncStatusEventArgs e = new SyncStatusEventArgs("テスト", 12, 30);
            Assert.AreEqual(false, e.Cancel);
            Assert.AreEqual("テスト", e.FilePath);
            Assert.AreEqual(12, e.ProgressIndex);
            Assert.AreEqual(30, e.ProgressCount);

            e.Cancel = true;
            Assert.AreEqual(true, e.Cancel);
        }
    }
}
