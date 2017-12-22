namespace UnitTestProject1.Utils
{
    using ComicLaunch.Model;
    using ComicLaunch.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabelAttributeUtilsTest
    {
        [TestMethod]
        public void GetLabelNameTest()
        {
            Assert.AreEqual("タイトル", LabelAttributeUtils.GetLabelName(FieldType.Title));

            Assert.AreEqual("ファイルは登録済", LabelAttributeUtils.GetLabelName(AnalyzeResult.Always));
        }
    }
}
