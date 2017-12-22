using System;
using System.Drawing;
using System.IO;
using ComicLaunch.Control;
using ComicLaunch.Image;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Image
{

    /// <summary>
    /// ArchiveModelテストクラス
    /// </summary>
    [DeploymentItem(@"Resources/testData.zip")]
    [DeploymentItem(@"Resources/testData3.zip")]
    [TestClass]
    public class ArchiveModelTest
    {
        [TestMethod]
        public void Constructor_Ok()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath);
            Assert.AreEqual(ResizeModeConstants.Fit, model.ResizeMode);
        }

        [TestMethod]
        public void Constructor_Ng_FileNotFoundException()
        {
            try
            {
                ArchiveModel model = new ArchiveModel(string.Empty);
                Assert.Fail();
            }
            catch (FileNotFoundException)
            {
            }
        }

        [TestMethod]
        public void PageCount()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            ArchiveModel model = new ArchiveModel(filePath);
            Assert.AreEqual(2, model.PageCount);
        }

        [TestMethod]
        public void PageIndex()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath)
            {
                PageIndex = 0
            };
            Assert.AreEqual(0, model.PageIndex);
        }

        [TestMethod]
        public void PageIndex_Ng()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath, 100, 100)
            {
                PageIndex = 5
            };
            Assert.AreEqual(0, model.PageIndex);
            Assert.IsTrue( model.PagePicture is Bitmap);
        }


        [TestMethod]
        public void FilePath()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            using (var model = new ArchiveModel(filePath))
            {
                Assert.AreEqual(filePath, model.FilePath);
            }
        }

        [TestMethod]
        public void Dispose()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath);
            model.Dispose();
        }

        [TestMethod]
        public void SetPageSize()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath);
            model.SetPageSize(PageSizeConstants.Fit, 80, 100);
            Assert.AreEqual(ResizeModeConstants.RatioKeep, model.ResizeMode);
            Assert.AreEqual(80, model.ResizeHeight);
            Assert.AreEqual(100, model.ResizeWidth);

            model.SetPageSize(PageSizeConstants.FitWidth, 80, 100);
            Assert.AreEqual(ResizeModeConstants.RatioKeep, model.ResizeMode);
            Assert.AreEqual(-1, model.ResizeHeight);
            Assert.AreEqual(100, model.ResizeWidth);

            model.SetPageSize(PageSizeConstants.Percent050, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(50, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent075, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(75, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent100, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(100, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent150, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(150, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent200, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(200, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent300, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(300, model.ResizePercent);

            model.SetPageSize(PageSizeConstants.Percent400, 80, 100);
            Assert.AreEqual(ResizeModeConstants.Percent, model.ResizeMode);
            Assert.AreEqual(400, model.ResizePercent);
        }

        [TestMethod]
        public void Scroll()
        {
            string filePath = Path.Combine(Helper.UnitTestUtils.GetExecutingPath(), "testData3.zip");
            var model = new ArchiveModel(filePath, 100, 100);
            var a = model.PagePicture;

            model.Scroll(0);
            model.Scroll(1);
            model.Scroll(-1); 
        }

    }
}
