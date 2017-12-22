namespace Helper
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// テストユニットユーティリティクラス
    /// </summary>
    public class UnitTestUtils
    {
        /// <summary>実行フォルダパスを取得します。</summary>
        /// <returns>実行フォルダパス</returns>
        public static string GetExecutingPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>呼び出し元メソッド用のリソースフォルダパスを取得します。</summary>
        public static string GetMethodResourcePath()
        {
            var method = (new StackTrace()).GetFrame(1).GetMethod();

            // 実行プログラム直下にメソッドリソースフォルダを作成
            // 「呼び出し元クラス＋ "_" ＋ 呼び出し元メソッド」
            string folderPath = method.DeclaringType.Name + "_" + method.Name;
            return Path.Combine(GetExecutingPath(), folderPath);
        }

        /// <summary>
        /// 呼出し元メソッド用のリソースフォルダを作成し、フォルダにDeploymentItem属性で設定したファイルをコピーします。
        /// </summary>
        public static void CreateMethodResource()
        {
            var method = (new StackTrace()).GetFrame(1).GetMethod();

            // 実行プログラム直下にメソッドリソースフォルダを作成
            // 「呼び出し元クラス＋ "_" ＋ 呼び出し元メソッド」
            string folderPath = method.DeclaringType.Name + "_" + method.Name;
            folderPath = Path.Combine(GetExecutingPath(), folderPath);
            Directory.CreateDirectory(folderPath);

            // 呼び出し元クラス・メソッドのDeploymentItem属性に記載されたファイルをメソッドリソースフォルダにコピー
            IEnumerable<string> attributes = method.GetCustomAttributes()
                .Union(method.DeclaringType.GetCustomAttributes())
                .Where(a => a.GetType() == typeof(DeploymentItemAttribute))
                .Select(a => (DeploymentItemAttribute)a)
                .Select(d => string.IsNullOrEmpty(d.OutputDirectory) ? Path.GetFileName(d.Path) : Path.Combine(d.OutputDirectory, Path.GetFileName(d.Path)))
                .Distinct();

            foreach (string sourcePath in attributes)
            {
                string distPath = Path.Combine(folderPath, Path.GetFileName(sourcePath));

                File.Copy(sourcePath, distPath, true);
            }

        }
    }
}
