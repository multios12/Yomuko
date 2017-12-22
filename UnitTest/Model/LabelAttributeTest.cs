
namespace ClTest.Model.B
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComicLaunch.Model;

    /// <summary>
    /// LabelAttributeテストクラス
    /// </summary>
    [TestClass]
    public class LabelAttributeTest
    {
        [TestMethod]
        public void Constructor_Ok_ArgumentNull()
        {
            var attribute = new LabelAttribute("テスト");
            Assert.AreEqual("テスト", attribute.LabelName);
        }

        [TestMethod]
        public void Constructor_Ok_2Arguments()
        {
            var attribute = new LabelAttribute("テスト", true);
            Assert.AreEqual("テスト", attribute.LabelName);
            Assert.AreEqual(true, attribute.IsHidden);
        }
    }
}
