using System;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Linq;
using System.IO;

namespace LYLStudio.App.Middle.Services.Logging
{
    public class LogHelper
    {
        private static Dictionary<TargetEnum, ILogService> _loggers = null;
        public static Dictionary<TargetEnum, ILogService> Loggers
        {
            get
            {
                return _loggers ?? (_loggers = new Dictionary<TargetEnum, ILogService>());
            }
        }

        static LogHelper()
        {
            foreach (var item in Enum.GetNames(typeof(TargetEnum)))
            {
                if (item.Equals(TargetEnum.All.ToString()))
                    continue;

                var type = Type.GetType(($"{typeof(LogHelper).Namespace}.{item}.LogService"));
                if (type == null)
                    continue;//TODO: Database Logger

                var target = (TargetEnum)Enum.Parse(typeof(TargetEnum), item);
                var svc = (LogServiceBase)Activator.CreateInstance(type);
                svc.LogExceptionOccurred += Svc_LogExceptionOccurred;
                Loggers.Add(target, svc);
            }
        }

        private static void Svc_LogExceptionOccurred(object sender, Exception e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"{sender.GetType().FullName}{Environment.NewLine}{e}");
#endif
        }

        public static void Log(TargetEnum target = TargetEnum.All, params LogItem[] logItems)
        {
            switch (target)
            {
                case TargetEnum.TextFile:
                    {
                        LogToTextFile(logItems);
                    }
                    break;
                case TargetEnum.Database:
                    {
                        LogToDatabase(logItems);
                    }
                    break;
                case TargetEnum.All:
                    {
                        LogToTextFile(logItems);
                        LogToDatabase(logItems);
                    }
                    break;
            }
        }

        private static void LogToTextFile(params LogItem[] logItems )
        {
            var now = DateTime.Now;
            var textFileLocation = HostingEnvironment.MapPath($@"{Properties.Settings.Default.FILE_BASEPATH_LOG}{now.ToString("yyyyMMdd")}\{now.ToString("HH")}.log");
            string folder = Path.GetDirectoryName(textFileLocation);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            Loggers[TargetEnum.TextFile].Log(textFileLocation, logItems);
        }

        private static void LogToDatabase(params LogItem[] logItems)
        {
            //TODO: 
            var dbConnectionString = string.Empty;
            Loggers[TargetEnum.Database].Log(dbConnectionString, logItems);
        }
    }

    /// <summary>
    /// 記錄類型目標
    /// </summary>
    [Flags]
    public enum TargetEnum
    {
        /// <summary>
        /// 文字檔案
        /// </summary>
        TextFile = 0x01,
        /// <summary>
        /// 資料庫
        /// </summary>
        Database = 0x10,

        /// <summary>
        /// 所有目標
        /// </summary>
        All = TextFile | Database
    }
}