namespace UnitTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ComicLaunch.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileNameListTest
    {
        [TestMethod]
        public void TestMethod()
        {
            FileNameList list = new FileNameList();
            list.Initialize();

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("( ) " , list[0].SampleText);
            Assert.AreEqual("[ ] ", list[1].SampleText);
            Assert.AreEqual("  ", list[2].SampleText);
        }
    }
}
