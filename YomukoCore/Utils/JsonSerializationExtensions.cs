namespace ComicLaunch.Utils
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Jsonへのシリアライズ・デシリアライズ機能を提供する拡張クラス
    /// </summary>
    /// <remacks>
    /// このクラスを使用するためには、「System.RuntimeSerialization」の参照が必要です。
    /// </remacks>
    public static class JsonSerializationExtensions
    {
        /// <summary>
        /// XMLから読み込んだ情報をオブジェクトに展開（デシリアライズ）します。
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="filePath">XMLファイルパス</param>
        /// <returns>XMLから読み込んだ情報が設定されたオブジェクト</returns>
        public static T ReadJson<T>(this T target, string filePath)
        {
            Type targetType = typeof(T);

            if (File.Exists(filePath) == false)
            {
                return (T)Activator.CreateInstance(targetType);
            }

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var serializer = new DataContractJsonSerializer(targetType);
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                // エラー情報を出力
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                return (T)Activator.CreateInstance(targetType);
            }
        }

        /// <summary>
        /// オブジェクトの内容をJsonファイルに書き込みます
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="filePath">XMLファイルパス</param>
        public static void WriteJson<T>(this T target, string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    var serializer = new DataContractJsonSerializer(target.GetType());
                    serializer.WriteObject(stream, target);
                }
            }
            catch (Exception ex)
            {
                // エラー情報を出力
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
