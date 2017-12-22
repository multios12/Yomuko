namespace UnitTest.Model
{
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FieldTypeExtensionsTest
    {
        [TestMethod]
        public void TestMethod()
        {
            FieldType fieldType = FieldType.Hash;
            Assert.AreEqual("ハッシュ", FieldTypeExtensions.Label(fieldType).LabelName);
            Assert.AreEqual("ハッシュ", FieldTypeExtensions.LabelName(fieldType));
            Assert.AreEqual(false, FieldTypeExtensions.IsReadOnly(fieldType));
            Assert.AreEqual(FieldType.Hash, FieldTypeExtensions.LabelNameToFieldType(fieldType, "ハッシュ"));
        }
    }
}
