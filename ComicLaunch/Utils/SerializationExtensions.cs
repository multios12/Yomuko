namespace ComicLaunch.Utils
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;

    /// <summary>
    /// XMLへのシリアライズ・デシリアライズ機能を提供する拡張クラス
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// XMLから読み込んだ情報をオブジェクトに展開（デシリアライズ）します。
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="filePath">XMLファイルパス</param>
        /// <returns>XMLから読み込んだ情報が設定されたオブジェクト</returns>
        public static T ReadXML<T>(this T target, string filePath)
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
                    var serializer = new XmlSerializer(targetType);
                    return (T)serializer.Deserialize(stream);
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
        /// XMLファイルが格納されたメモリストリームををオブジェクトに展開（デシリアライズ）します。
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="stream">メモリストリーム</param>
        /// <returns>XMLから読み込んだ情報が設定されたオブジェクト</returns>
        public static T ReadStream<T>(this T target, Stream stream)
        {
            Type targetType = typeof(T);

            try
            {
                var serializer = new XmlSerializer(targetType);
                target = (T)serializer.Deserialize(stream);
                stream.Close();
                return target;
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
        /// オブジェクトの内容をXMLに書き込む
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="filePath">XMLファイルパス</param>
        public static void WriteXML<T>(this T target, string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    var serializer = new XmlSerializer(target.GetType());
                    serializer.Serialize(stream, target);
                }
            }
            catch (Exception ex)
            {
                // エラー情報を出力
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>オブジェクトの内容をメモリストリームに書き込み、返します。</summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <param name="stream">メモリストリーム</param>
        public static void WriteStream<T>(T target, ref Stream stream)
        {
            try
            {
                var serializer = new XmlSerializer(target.GetType());
                serializer.Serialize(stream, target);
            }
            catch (Exception ex)
            {
                // エラー情報を出力
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// オブジェクトの内容をメモリストリームに書き込み、返します。
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <returns>オブジェクトの内容が書き込まれたメモリストリーム</returns>
        public static MemoryStream WriteStream<T>(this T target)
        {
            var stream = new MemoryStream();

            try
            {
                var serializer = new XmlSerializer(target.GetType());
                serializer.Serialize(stream, target);
                stream.Position = 0;
            }
            catch (Exception ex)
            {
                // エラー情報を出力
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            return stream;
        }

        /// <summary>
        /// オブジェクトをディープコピーします。
        /// </summary>
        /// <typeparam name="T">オブジェクトの型（シリアライズ属性が必要です。）</typeparam>
        /// <param name="target">処理対象オブジェクト</param>
        /// <returns>ディープコピーされたオブジェクト</returns>
        public static T DeepCopy<T>(this T target)
        {
            T result = default(T);
            var b = new BinaryFormatter();
            var mem = new MemoryStream();

            try
            {
                b.Serialize(mem, target);
                mem.Position = 0;
                result = (T)b.Deserialize(mem);
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
            finally
            {
                mem.Close();
            }

            return result;
        }
    }
}
