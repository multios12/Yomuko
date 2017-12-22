namespace UnitTest.Utils
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComicLaunch.Utils;
    using System.Collections.Generic;
    using System.IO;
    using System;
    using ComicLaunch.Image;
    [TestClass]
    public class SerializationExtensionsTest
    {
        [TestMethod]
        public void TestDeepCopy()
        {
            List<string> list = new List<string>() { "1", "2" };
            List<string> list2 = list.DeepCopy();
            Assert.AreEqual(list2.Count, 2);
            Assert.AreEqual(list2[0], "1");
            Assert.AreEqual(list2[1], "2");

            // シリアライズされていないクラスに対する処理
            ArchiveEntrySort c = new ArchiveEntrySort();

            try
            {
                ArchiveEntrySort c2 = c.DeepCopy();
                Assert.Fail();
            }
            catch
            {
            }
        }

        [TestMethod]
        public void TestReadXMLAndWriteXML()
        {
            List<string> list = new List<string>() { "1", "2" };

            list.WriteXML("TestWriteXml.xml");

            var list2 = list.ReadXML("TestWriteXml.xml");
            Assert.AreEqual(list2.Count, 2);
            Assert.AreEqual(list2[0], "1");
            Assert.AreEqual(list2[1], "2");

            var list3 = list.ReadXML("notfound");
            Assert.AreEqual(typeof(List<string>), list3.GetType());

            // シリアライズされていないクラスに対する処理
            ArchiveEntrySort c = new ArchiveEntrySort();
            c.WriteXML("TestWriteXml.xml");

            ArchiveEntrySort c2 = c.ReadXML("TestWriteXml.xml");
            Assert.IsNotNull( c2);
        }

        [TestMethod]
        public void TestReadStreamAndWriteStream()
        {
            List<string> list = new List<string>() { "1", "2" };
            MemoryStream stream = list.WriteStream();

            List<string> list2 = list.ReadStream(stream);
            Assert.AreEqual(list2.Count, 2);
            Assert.AreEqual(list2[0], "1");
            Assert.AreEqual(list2[1], "2");
        }
    }
}