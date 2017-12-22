namespace UnitTestProject1.Utils
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComicLaunch.Utils;

    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TestFormatWith()
        {
            Assert.AreEqual("1 / 2" ,"{0} / {1}".FormatWith(1, 2));
        }
    }
}
