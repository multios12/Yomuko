namespace UnitTestProject1.Model
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComicLaunch.Model;
    using System.IO;
    using System.Reflection;
    using ComicLaunch.Utils;
    using Helper;
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    [DeploymentItem(@"Resources/testData.zip")]
    [DeploymentItem(@"Resources/testData2.zip")]
    public class ModelTest
    {
        /// <summary>リソースフォルダパス</summary>
        private static string resourcePath;

        public const string CONSTRUCTORTEST2 = "(あああ)[いいい] testData 第10巻 [20160101] aiue(完).zip";
        public const string CONSTRUCTORTEST3 = "（あああ）[いいい] testData 第10巻 [20160101] aiue(完結).zip";

        /// <summary>ユニットテスト実行前に動作し、クラスの初期化を行います。</summary>
        /// <param name="testContext">テストコンテキスト</param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {

            // リソースフォルダパス取得
            resourcePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // resourcePath = Path.Combine(resourcePath, "Resources");

            File.Copy(Path.Combine(resourcePath, "testData.zip"), Path.Combine(resourcePath, CONSTRUCTORTEST2), true);
            File.Copy(Path.Combine(resourcePath, "testData.zip"), Path.Combine(resourcePath, CONSTRUCTORTEST3), true);
        }

        /// <summary>コンストラクタのテスト</summary>
        [TestMethod]
        public void Constructor()
        {
            var model = new BookModel();
            Assert.AreEqual(string.Empty, model.FilePath);
        }

        /// <summary>コンストラクタのテスト</summary>
        [TestMethod]
        public void Constructor_Ok_1Argument()
        {
            var model = new BookModel(Path.Combine(resourcePath, "testData.zip"));
            Assert.AreEqual(Path.Combine(resourcePath, "testData.zip"), model.FilePath);
            Assert.AreEqual("testData", model.Title);
            Assert.AreEqual("testData", model.CollectTitle);

            var model2 = new BookModel(Path.Combine(resourcePath, CONSTRUCTORTEST2));
            Assert.AreEqual("testData", model2.Title);
            Assert.AreEqual("あああ", model2.Type);
            Assert.AreEqual("いいい", model2.Writer);
            Assert.AreEqual("2016/01/01", model2.ReleaseDate);
            Assert.AreEqual(true, model2.IsComplete);
            Assert.AreEqual("aiue", model2.SubTitle);
            Assert.AreEqual("10", model2.No);
            Assert.AreEqual("testData 第10巻(完結) aiue", model2.CollectTitle);

            var model3 = new BookModel(Path.Combine(resourcePath, CONSTRUCTORTEST3));
            Assert.AreEqual("testData", model3.Title);
            Assert.AreEqual("あああ", model3.Type);
            Assert.AreEqual("いいい", model3.Writer);
            Assert.AreEqual("2016/01/01", model3.ReleaseDate);
            Assert.AreEqual(true, model3.IsComplete);
            Assert.AreEqual("aiue", model3.SubTitle);
            Assert.AreEqual("10", model3.No);

            BookList list = new BookList
            {
                model
            };
            list.WriteXML(@"d:\test.xml");
        }

        #region スタティックメソッド
        [TestMethod]
        public void GetFieldType_Ok()
        {
            Assert.AreEqual(FieldType.FilePath, BookModel.GetFieldType("FilePath"));
            Assert.AreEqual(FieldType.Title, BookModel.GetFieldType("Title"));
            Assert.AreEqual(FieldType.No, BookModel.GetFieldType("No"));
            Assert.AreEqual(FieldType.Writer, BookModel.GetFieldType("Writer"));
            Assert.AreEqual(FieldType.PublishingCompany, BookModel.GetFieldType("PublishingCompany"));
            Assert.AreEqual(FieldType.Junle, BookModel.GetFieldType("Junle"));
            Assert.AreEqual(FieldType.ReleaseDate, BookModel.GetFieldType("ReleaseDate"));
            Assert.AreEqual(FieldType.Memo, BookModel.GetFieldType("Memo"));
            Assert.AreEqual(FieldType.Favorite, BookModel.GetFieldType("Favorite"));
            Assert.AreEqual(FieldType.CreateDate, BookModel.GetFieldType("CreateDate"));
            Assert.AreEqual(FieldType.UpdateDate, BookModel.GetFieldType("UpdateDate"));
            Assert.AreEqual(FieldType.Hash, BookModel.GetFieldType("Hash"));
            Assert.AreEqual(FieldType.Type, BookModel.GetFieldType("Type"));
            Assert.AreEqual(FieldType.Photographer, BookModel.GetFieldType("Photographer"));
            Assert.AreEqual(FieldType.CarryMagazine, BookModel.GetFieldType("CarryMagazine"));
            Assert.AreEqual(FieldType.SubTitle, BookModel.GetFieldType("SubTitle"));
            Assert.AreEqual(FieldType.CoverFileIndex, BookModel.GetFieldType("CoverFileIndex"));
            Assert.AreEqual(FieldType.CoverWidth, BookModel.GetFieldType("CoverWidth"));
            Assert.AreEqual(FieldType.CoverLeft, BookModel.GetFieldType("CoverLeft"));
            Assert.AreEqual(FieldType.IsComplete, BookModel.GetFieldType("IsComplete"));

            Assert.AreEqual(FieldType.FilePath, BookModel.GetFieldType("ファイルパス"));
            Assert.AreEqual(FieldType.Title, BookModel.GetFieldType("タイトル"));
            Assert.AreEqual(FieldType.No, BookModel.GetFieldType("巻数"));
            Assert.AreEqual(FieldType.Writer, BookModel.GetFieldType("著者"));
            Assert.AreEqual(FieldType.PublishingCompany, BookModel.GetFieldType("出版社"));
            Assert.AreEqual(FieldType.Junle, BookModel.GetFieldType("ジャンル"));
            Assert.AreEqual(FieldType.ReleaseDate, BookModel.GetFieldType("リリース日"));
            Assert.AreEqual(FieldType.Memo, BookModel.GetFieldType("備考"));
            Assert.AreEqual(FieldType.Favorite, BookModel.GetFieldType("お気に入り"));
            Assert.AreEqual(FieldType.CreateDate, BookModel.GetFieldType("追加日"));
            Assert.AreEqual(FieldType.UpdateDate, BookModel.GetFieldType("更新日"));
            Assert.AreEqual(FieldType.Hash, BookModel.GetFieldType("ハッシュ"));
            Assert.AreEqual(FieldType.Type, BookModel.GetFieldType("種類"));
            Assert.AreEqual(FieldType.Photographer, BookModel.GetFieldType("撮影者"));
            Assert.AreEqual(FieldType.CarryMagazine, BookModel.GetFieldType("掲載誌"));
            Assert.AreEqual(FieldType.SubTitle, BookModel.GetFieldType("サブタイトル"));
            Assert.AreEqual(FieldType.CoverFileIndex, BookModel.GetFieldType("表紙ファイルインデックス"));
            Assert.AreEqual(FieldType.CoverWidth, BookModel.GetFieldType("表紙表示幅"));
            Assert.AreEqual(FieldType.CoverLeft, BookModel.GetFieldType("表紙表示位置横方向"));
            Assert.AreEqual(FieldType.IsComplete, BookModel.GetFieldType("完結"));
        }

        [TestMethod]
        public void GetFieldType_Ng()
        {
            Assert.AreEqual(FieldType.Title, BookModel.GetFieldType(""));
            Assert.AreEqual(FieldType.Title, BookModel.GetFieldType("Error"));
        }
        #endregion

        #region パブリックメソッド
        [TestMethod]
        public void GetFormatValue()
        {
            var model = new BookModel();
            model.CarryMagazine = "テスト";
            model.CoverFileIndex = 10;
            model.CoverLeft = 10;
            model.CoverWidth = 10;
            model.CreateDate = "2016/01/01";
            model.Favorite = true;
            model.Hash = "XXXXX";
            model.Id = "0001";
            model.IsComplete = true;
            model.IsDuplicate = true;
            model.Status = AnalyzeResult.Success;
            model.Junle = "テスト";
            model.Memo = "テスト";
            model.No = "01";
            model.Photographer = "テスト";
            model.PublishingCompany = "テスト";
            model.ReleaseDate = "2016/01/02";
            model.SubTitle = "テスト";
            model.Title = "テスト";
            model.Type = "テスト";
            model.UpdateDate = "2016/01/03";
            model.Writer = "テスト";
            model.FilePath = Path.Combine(resourcePath, "testData.zip");
            Assert.AreEqual("テスト", model.GetFormatValue(FieldType.Title));
            Assert.AreEqual(resourcePath, model.GetFormatValue(FieldType.FilePath));
            Assert.AreEqual("テスト", model.GetFormatValue(FieldType.Title));
            Assert.AreEqual("テスト 第01巻(完結) テスト", model.GetFormatValue(FieldType.Title, true));
        }

        /// <summary>GetSortKeyメソッドテスト</summary>
        [TestMethod]
        public void GetSortKey()
        {
            var model = new BookModel();
            model.FilePath = "test";
            model.CarryMagazine = "テスト";
            model.CoverFileIndex = 10;
            model.CoverLeft = 10;
            model.CoverWidth = 10;
            model.CreateDate = "2016/01/01";
            model.Favorite = true;
            model.Hash = "XXXXX";
            model.Id = "0001";
            model.IsComplete = true;
            model.IsDuplicate = true;
            model.Status = AnalyzeResult.Success;
            model.Junle = "テスト";
            model.Memo = "テスト";
            model.No = "01";
            model.Photographer = "テスト";
            model.PublishingCompany = "テスト";
            model.ReleaseDate = "2016/01/02";
            model.SubTitle = "テスト";
            model.Title = "タイトル";
            model.Type = "テスト";
            model.UpdateDate = "2016/01/03";
            model.Writer = "テスト";

            Assert.AreEqual("2016/01/03タイトル", model.GetSortKey(FieldType.UpdateDate));

            Assert.AreEqual("タイトル", model.GetSortKey(FieldType.Title));
        }

        /// <summary>GetValueメソッドテスト</summary>
        [TestMethod]
        public void GetValue()
        {
            var model = new BookModel();
            model.FilePath = "test";
            model.CarryMagazine = "テスト";
            model.CoverFileIndex = 10;
            model.CoverLeft = 10;
            model.CoverWidth = 10;
            model.CreateDate = "2016/01/01";
            model.Favorite = true;
            model.Hash = "XXXXX";
            model.Id = "0001";
            model.IsComplete = true;
            model.IsDuplicate = true;
            model.Status = AnalyzeResult.Success;
            model.Junle = "テスト";
            model.Memo = "テスト";
            model.No = "01";
            model.Photographer = "テスト";
            model.PublishingCompany = "テスト";
            model.ReleaseDate = "2016/01/02";
            model.SubTitle = "テスト";
            model.Title = "テスト";
            model.Type = "テスト";
            model.UpdateDate = "2016/01/03";
            model.Writer = "テスト";

            Assert.AreEqual("test", model.GetValue(FieldType.FilePath));
            model.FilePath = null;
            Assert.AreEqual(string.Empty, model.GetValue(FieldType.FilePath));
            Assert.AreEqual("テスト", model.GetValue(FieldType.CarryMagazine));
            Assert.AreEqual("10", model.GetValue(FieldType.CoverFileIndex));
            Assert.AreEqual("2016/01/01", model.GetValue(FieldType.CreateDate));
            Assert.AreEqual("True", model.GetValue(FieldType.Favorite));
            Assert.AreEqual("XXXXX", model.GetValue(FieldType.Hash));
            Assert.AreEqual("True", model.GetValue(FieldType.IsComplete));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Junle));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Memo));
            Assert.AreEqual("01", model.GetValue(FieldType.No));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Photographer));
            Assert.AreEqual("テスト", model.GetValue(FieldType.PublishingCompany));
            Assert.AreEqual("2016/01/02", model.GetValue(FieldType.ReleaseDate));
            Assert.AreEqual("テスト", model.GetValue(FieldType.SubTitle));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Title));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Type));
            Assert.AreEqual("2016/01/03", model.GetValue(FieldType.UpdateDate));
            Assert.AreEqual("テスト", model.GetValue(FieldType.Writer));

            model.Writer = null;
            Assert.AreEqual(string.Empty, model.GetValue(FieldType.Writer));

            Assert.AreEqual("10", model.GetValue(FieldType.CoverLeft));
            Assert.AreEqual("10", model.GetValue(FieldType.CoverWidth));

            Assert.AreEqual("テスト 第01巻(完結) テスト", model.GetValue(FieldType.Title, true));

        }

        /// <summary>SetValueメソッドテスト</summary>
        [TestMethod]
        public void SetValue()
        {
            // 文字列型プロパティ
            var item = new BookModel();
            item.SetValue(FieldType.Title, "テスト");
            Assert.AreEqual("テスト", item.Title);

            // 真偽値型プロパティ
            var boolItem = new BookModel();
            boolItem.SetValue(FieldType.IsComplete, "True");
            Assert.AreEqual(boolItem.IsComplete, true);

            // 数値型プロパティ
            var numericItem = new BookModel();
            numericItem.SetValue(FieldType.CoverFileIndex, "10");
            Assert.AreEqual<long>(numericItem.CoverFileIndex, 10);
        }

        /// <summary>SetValuesメソッドテスト</summary>
        [TestMethod]
        public void SetValues()
        {
            var sourceItem = new BookModel();
            sourceItem.CarryMagazine = "テスト";
            sourceItem.CoverFileIndex = 10;
            sourceItem.CoverLeft = 10;
            sourceItem.CoverWidth = 10;
            sourceItem.CreateDate = "2016/01/01";
            sourceItem.Favorite = true;
            sourceItem.Hash = "XXXXX";
            sourceItem.Id = "0001";
            sourceItem.IsComplete = true;
            sourceItem.IsDuplicate = true;
            sourceItem.Status = AnalyzeResult.Success;
            sourceItem.Junle = "テスト";
            sourceItem.Memo = "テスト";
            sourceItem.No = "01";
            sourceItem.Photographer = "テスト";
            sourceItem.PublishingCompany = "テスト";
            sourceItem.ReleaseDate = "2016/01/02";
            sourceItem.SubTitle = "テスト";
            sourceItem.Title = "テスト";
            sourceItem.Type = "テスト";
            sourceItem.UpdateDate = "2016/01/03";
            sourceItem.Writer = "テスト";
            var targetItem = new BookModel();

            targetItem.SetValues(sourceItem);
            Assert.AreEqual("テスト", sourceItem.CarryMagazine);
            Assert.AreEqual(10, sourceItem.CoverFileIndex);
            Assert.AreEqual(10, sourceItem.CoverLeft);
            Assert.AreEqual(10, sourceItem.CoverWidth);
            Assert.AreEqual("2016/01/01", sourceItem.CreateDate);
            Assert.AreEqual(true, sourceItem.Favorite);
            Assert.AreEqual("XXXXX", sourceItem.Hash);
            Assert.AreEqual("0001", sourceItem.Id);
            Assert.AreEqual(true, sourceItem.IsComplete);
            Assert.AreEqual(true, sourceItem.IsDuplicate);
            Assert.AreEqual(AnalyzeResult.Success, sourceItem.Status);
            Assert.AreEqual("テスト", sourceItem.Junle);
            Assert.AreEqual("テスト", sourceItem.Memo);
            Assert.AreEqual("01", sourceItem.No);
            Assert.AreEqual("テスト", sourceItem.Photographer);
            Assert.AreEqual("テスト", sourceItem.PublishingCompany);
            Assert.AreEqual("2016/01/02", sourceItem.ReleaseDate);
            Assert.AreEqual("テスト", sourceItem.SubTitle);
            Assert.AreEqual("テスト", sourceItem.Title);
            Assert.AreEqual("テスト", sourceItem.Type);
            Assert.AreEqual("2016/01/03", sourceItem.UpdateDate);
            Assert.AreEqual("テスト", sourceItem.Writer);
        }

        [TestMethod]
        public void ReplaceTitle_Ok()
        {
            var model = new BookModel();
            model.FilePath = "test";
            model.SubTitle = "サブタイトル";
            model.Title = "テスト awisjx テスト";

            model.ReplaceTitle("テスト");
            Assert.AreEqual("テスト", model.Title);
            Assert.AreEqual("awisjx テストサブタイトル", model.SubTitle);
        }

        [TestMethod]
        public void ReplaceTitle_Ok_NotFound()
        {
            var model = new BookModel();
            model.FilePath = "test";
            model.SubTitle = "サブタイトル";
            model.Title = "テスト awisjx テスト";

            model.ReplaceTitle("あい");
            Assert.AreEqual("テスト awisjx テスト", model.Title);
            Assert.AreEqual("サブタイトル", model.SubTitle);
        }

        [TestMethod]
        public void ChangeFileName()
        {
            UnitTestUtils.CreateMethodResource();

            var nameList = new FileNameList();
            nameList.Initialize();

            var model = new BookModel(Path.Combine(UnitTestUtils.GetMethodResourcePath(), "testData.zip"));
            model.CarryMagazine = "テスト";
            model.CoverFileIndex = 10;
            model.CoverLeft = 10;
            model.CoverWidth = 10;
            model.CreateDate = "2016/01/01";
            model.Favorite = true;
            model.Hash = "XXXXX";
            model.Id = "0001";
            model.IsComplete = true;
            model.IsDuplicate = true;
            model.Status = AnalyzeResult.Success;
            model.Junle = "テスト";
            model.Memo = "テスト";
            model.No = "01";
            model.Photographer = "テスト";
            model.PublishingCompany = "テスト";
            model.ReleaseDate = "2016/01/02";
            model.SubTitle = "テスト";
            model.Title = "テスト";
            model.Type = "テスト";
            model.UpdateDate = "2016/01/03";
            model.Writer = "テスト";

            model.ChangeFileName(nameList);
            Assert.AreEqual("(テスト) [テスト] テスト 第01巻 (完結)[20160102].zip", Path.GetFileName(model.FilePath));

            // ファイル名変更無
            model.ChangeFileName();
            Assert.AreEqual("(テスト) [テスト] テスト 第01巻 (完結)[20160102].zip", Path.GetFileName(model.FilePath));
        }

        [TestMethod]
        public void ChangeFileName_Ng_FileNotFoundAndRootDirectory()
        {
            var nameList = new FileNameList();
            nameList.Initialize();

            var model = new BookModel(@"C:\testData.zip");
            model.CarryMagazine = "テスト";
            model.CoverFileIndex = 10;
            model.CoverLeft = 10;
            model.CoverWidth = 10;
            model.CreateDate = "2016/01/01";
            model.Favorite = true;
            model.Hash = "XXXXX";
            model.Id = "0001";
            model.IsComplete = true;
            model.IsDuplicate = true;
            model.Status = AnalyzeResult.Success;
            model.Junle = "テスト";
            model.Memo = "テスト";
            model.No = "01";
            model.Photographer = "テスト";
            model.PublishingCompany = "テスト";
            model.ReleaseDate = "2016/01/02";
            model.SubTitle = "テスト";
            model.Title = "テスト";
            model.Type = "テスト";
            model.UpdateDate = "2016/01/03";
            model.Writer = "テスト";

            model.ChangeFileName(nameList);

            Assert.IsTrue(model.IsError);
        }

        [TestMethod]
        public void FileExists_Ok_Exists()
        {
            string filePath = Path.Combine(resourcePath, "testData.zip");
            var model = new BookModel(filePath);
            Assert.IsTrue(model.FileExists());
        }

        [TestMethod]
        public void FileExists_Ok_NotExists()
        {
            string filePath = Path.Combine(resourcePath, "testData.zip");
            var model = new BookModel("notFound");
            Assert.IsFalse(model.FileExists());
        }

        [TestMethod]
        public void FileMove_Ok()
        {
            // テスト環境構築
            UnitTestUtils.CreateMethodResource();
            string filePath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "testData2.zip");
            string distPath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "Moved");
            Directory.CreateDirectory(distPath);

            var model = new BookModel(filePath);
            model.FileMove(distPath);
            Assert.AreEqual(Path.Combine(distPath, "testData2.zip"), model.FilePath);
            Assert.IsFalse(model.IsError);
        }

        [TestMethod]
        public void FileMove_Ng()
        {
            // テスト環境構築
            UnitTestUtils.CreateMethodResource();
            string testDataPath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "testData.zip");
            string testData2Path = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "testData2.zip");
            string movedPath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "Moved");
            Directory.CreateDirectory(movedPath);

            var model = new BookModel(testData2Path);
            model.FileMove(movedPath);
            Assert.AreEqual(Path.Combine(movedPath, "testData2.zip"), model.FilePath);
            Assert.IsFalse(model.IsError);

            // 重複有時、名前変更
            model.FileMove(movedPath);
            Assert.IsFalse(model.IsError);

            // 移動先フォルダと同名のファイル有
            model = new BookModel(testDataPath);
            model.FileMove(testDataPath);
            Assert.IsTrue(model.IsError, model.ErrorMessage);
        }

        [TestMethod]
        public void FileMove_Ng_FilePathNotFound()
        {
            string movedPath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "Moved");
            Directory.CreateDirectory(movedPath);

            var falseModel = new BookModel("notFound");
            falseModel.FileMove(movedPath);
            Assert.IsTrue(falseModel.IsError);
        }

        [TestMethod]
        public void FileDelete_Ok()
        {
            UnitTestUtils.CreateMethodResource();

            string filePath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "testData.zip");

            var model = new BookModel(filePath);
            model.FileDelete();

            Assert.IsFalse(model.IsError);
            Assert.IsFalse(model.FileExists());
        }

        [TestMethod]
        public void FileDelete_Ng_FilePathNotFound()
        {
            string filePath = Path.Combine(UnitTestUtils.GetMethodResourcePath(), "notFound");

            var model = new BookModel(filePath);
            model.FileDelete();

            Assert.IsFalse(model.IsError);
        }
        #endregion
    }
}
