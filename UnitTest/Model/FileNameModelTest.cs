namespace UnitTest.Model
{
    using System;
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileNameModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            FileNameModel m = new FileNameModel();
            Assert.AreEqual(null, m.Back);
            Assert.AreEqual(null, m.Front);
            Assert.AreEqual(null, m.FieldType);
            Assert.AreEqual(string.Empty, m.TypeName);
            Assert.AreEqual(null, m.Value);
            Assert.AreEqual(" ", m.SampleText);

            FileNameModel model = new FileNameModel("「", "」", FieldType.SubTitle, "テスト");
            Assert.AreEqual("「 」", model.SampleText);
            Assert.AreEqual("SubTitle", model.TypeName);

            model.TypeName = "Type";
            Assert.AreEqual(FieldType.Type, model.FieldType);

            model.TypeName = "無効な文字";
            Assert.AreEqual(null, model.FieldType);
        }

        [TestMethod]
        public void TypeName_Ok()
        {
            FileNameModel model = new FileNameModel("「", "」", FieldType.SubTitle, "テスト");
            Assert.AreEqual("「 」", model.SampleText);
            Assert.AreEqual("SubTitle", model.TypeName);

            model.TypeName = "Type";
            Assert.AreEqual(FieldType.Type, model.FieldType);

            model.TypeName = "無効な文字";
            Assert.AreEqual(null, model.FieldType);
        }

        [TestMethod]
        public void TypeName_Ng_InvalidTypeName()
        {
            FileNameModel model = new FileNameModel("」", "「", FieldType.SubTitle, "テスト");
            model.TypeName = "無効な文字";
            Assert.AreEqual(null, model.FieldType);
        }
    }
}
