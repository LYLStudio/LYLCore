using System;
using System.Collections.Generic;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    /// <summary>
    /// 記錄服務
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// 記錄Callback
        /// </summary>
        Action<IEnumerable<ILogItem>> Callback { get; set; }
        /// <summary>
        /// 寫入記錄
        /// </summary>
        /// <param name="location">儲存位置</param>
        /// <param name="logItems">記錄資料列清單<see cref="ILogItem"/></param>
        void Log(string location, params ILogItem[] logItems);
    }
}
