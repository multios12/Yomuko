namespace ClTest.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using ComicLaunch.Model;
    using ComicLaunch.Utils;
    using Helper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem(@"Resources/testData.zip")]
    [DeploymentItem(@"Resources/testData2.zip")]
    [DeploymentItem(@"Resources/bookListTest.xml")]
    public class ListTest
    {

        [TestMethod]
        public void Add_Ok_Model()
        {
            var list = new BookList
            {
                new BookModel()
            };
            PrivateObject listObject = new PrivateObject(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, (long)listObject.GetFieldOrProperty("bookIDGen"));
        }

        [TestMethod]
        public void Add_Ok_FilePath()
        {
            var list = new BookList
            {
                "testData.zip"
            };
            PrivateObject listObject = new PrivateObject(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, (long)listObject.GetFieldOrProperty("bookIDGen"));
        }

        [TestMethod]
        public void Remove()
        {
            var list = new BookList();
            var item = new BookModel();
            list.Add(item);
            list.Remove(item);
            PrivateObject listObject = new PrivateObject(list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(1L, (long)listObject.GetFieldOrProperty("bookIDGen"));
        }

        [TestMethod]
        public void RemoveAt()
        {
            var list = new BookList
            {
                new BookModel() { Title = "1" },
                new BookModel() { Title = "2" },
                new BookModel() { Title = "3" }
            };
            list.RemoveAt(1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("1", list[0].Title);
            Assert.AreEqual("3", list[1].Title);
        }

        [TestMethod]
        public void RemoveRange()
        {
            var list = new BookList();
            BookModel item1 = new BookModel() { Title = "1" };
            BookModel item2 = new BookModel() { Title = "2" };
            BookModel item3 = new BookModel() { Title = "3" };
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            list.RemoveRange(new BookModel[] { item1, item2 });

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("3", list[0].Title);
        }

        [TestMethod]
        public void Clear()
        {
            var list = new BookList
            {
                new BookModel()
            };
            list.Clear();
            PrivateObject listObject = new PrivateObject(list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(0L, (long)listObject.GetFieldOrProperty("bookIDGen"));
        }

        [TestMethod]
        public void Refresh()
        {
            var list = new BookList();
            list = list.ReadXML(@"bookListTest.xml");
            list.Refresh();
        }

        [TestMethod]
        public void RefreshSearchCriterias()
        {
            var list = new BookList();
            list = list.ReadXML(@"bookListTest.xml");
            list.RefreshSearchCriterias(new SearchModel(FieldType.Title, "testData"));
        }

        [TestMethod]
        public void ClearSearchCriterias()
        {
            var list = new BookList();
            list.ClearSearchCriterias();
        }

        [TestMethod]
        public void GetCollectValues()
        {
            var list = new BookList();
            list = list.ReadXML(@"bookListTest.xml");

            list.GetCollectValues(FieldType.Favorite);
        }

        [TestMethod]
        public void GetSearchCriterias()
        {
            var list = new BookList();
            list = list.ReadXML(@"bookListTest.xml");
            list.GetSearchCriterias();
        }

        [TestMethod]
        public void SyncBaseFolder()
        {
            UnitTestUtils.CreateMethodResource();

            var list = new BookList();
            var bases = new List<string>() { UnitTestUtils.GetMethodResourcePath() };
            list.SyncStatusChanged += List_SyncStatusChanged;

            list.SyncBaseFolder(bases, null);
            Assert.AreEqual(2, list.Count);
        }

        private void List_SyncStatusChanged(object sender, SyncStatusEventArgs e)
        {


            // Assert.AreEqual(2, e.ProgressCount);
        }
    }
}
