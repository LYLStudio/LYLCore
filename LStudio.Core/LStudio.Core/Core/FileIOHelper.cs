namespace LStudio.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class FileIOHelper
    {
        /// <summary>
        /// 同步載入
        /// </summary>
        /// <param name="file"></param>
        /// <param name="callback"></param>
        public static void Load(string file, Action<string> callback)
        {
            if (callback is null) throw new ArgumentNullException(nameof(callback));

            string result = string.Empty;

            if (File.Exists(file))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        result = sr.ReadToEnd();
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
                    Task<string> task = sr.ReadToEndAsync();
                    result = await task.ConfigureAwait(false);
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
                Task task = sw.WriteAsync(writeString);
                await task.ConfigureAwait(false);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="writeList"></param>
        public static void AppendLine(string file, ICollection<string> writeList)
        {
            if (writeList is null || writeList.Count == 0) throw new ArgumentNullException(nameof(writeList));

            CheckAndCreateDirectory(file);

            using (StreamWriter sw = File.AppendText(file))
            {
                foreach (var item in writeList)
                {
                    sw.WriteLine(item);
                }
            };
        }

        public static async Task AppendLineAsync(string file, ICollection<string> writeList)
        {
            if (writeList is null || writeList.Count == 0) throw new ArgumentNullException(nameof(writeList));

            CheckAndCreateDirectory(file);

            using (StreamWriter sw = File.AppendText(file))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in writeList)
                {
                    stringBuilder.Append(item);
                }                
                Task task = sw.WriteAsync(stringBuilder.ToString());
                await task.ConfigureAwait(false);
            };
        }

        public static void CheckAndCreateDirectory(string path)
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
