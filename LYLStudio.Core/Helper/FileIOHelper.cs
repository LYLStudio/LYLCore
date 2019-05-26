using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LYLStudio.Core.Helper
{
    public class FileIOHelper
    {
        /// <summary>
        /// 同步載入
        /// </summary>
        /// <param name="file"></param>
        /// <param name="callback"></param>
        public static void Load(string file, Action<string> callback)
        {
            string result = string.Empty;

            if (File.Exists(file))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    };
                }
                catch (Exception)
                {
                    throw;
                }
            }
            callback(result);
        }

        /// <summary>
        /// 非同步載入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<string> LoadAsync(string file)
        {
            string result = string.Empty;

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    result = await sr.ReadToEndAsync();
                    sr.Close();
                };
            }
            return result;
        }

        /// <summary>
        /// 同步儲存
        /// </summary>
        /// <param name="file"></param>
        /// <param name="writeString"></param>
        public static void Save(string file, string writeString)
        {
            CheckAndCreateDirectory(file);

            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(writeString);
                sw.Close();
            };
        }

        /// <summary>
        /// 非同步儲存
        /// </summary>
        /// <param name="file"></param>
        /// <param name="writeString"></param>
        /// <returns></returns>
        public static async Task SaveAsync(string file, string writeString)
        {
            CheckAndCreateDirectory(file);

            using (StreamWriter sw = new StreamWriter(file))
            {
                await sw.WriteAsync(writeString);
                sw.Close();
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="writeList"></param>
        public static void AppendLine(string file, List<string> writeList)
        {
            CheckAndCreateDirectory(file);

            using (StreamWriter sw = File.AppendText(file))
            {
                for (int i = 0; i < writeList.Count; i++)
                    sw.WriteLine(writeList[i]);
                sw.Close();
            };
        }

        public static async Task AppendLineAsync(string file, List<string> writeList)
        {
            CheckAndCreateDirectory(file);

            using (StreamWriter sw = File.AppendText(file))
            {
                for (int i = 0; i < writeList.Count; i++)
                    await sw.WriteLineAsync(writeList[i]);
                sw.Close();
            };
        }

        private static void CheckAndCreateDirectory(string path)
        {
            try
            {
                string directories = Path.GetDirectoryName(path);
                if (!Directory.Exists(directories) && !string.IsNullOrEmpty(directories))
                    Directory.CreateDirectory(directories);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
