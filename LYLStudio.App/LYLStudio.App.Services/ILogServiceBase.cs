using System;
using System.Collections.Generic;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 記錄服務基底介面
    /// </summary>
    public interface ILogServiceBase<T>
        where T : ILogItemBase
    {
        /// <summary>
        /// 自訂Callback函式
        /// </summary>
        Action<string, IEnumerable<T>> Callback { get; }

        /// <summary>
        /// 將記錄寫入指定目標
        /// </summary>
        /// <param name="location">指定目標</param>
        /// <param name="logItems">單一記錄或集合</param>
        void Log(string location, params T[] logItems);     
    }

    /// <summary>
    /// 記錄物件基底介面
    /// </summary>
    public interface ILogItemBase
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 時間
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// 類別
        /// </summary>
        CategoryTypeEnum Category { get; set; }

        /// <summary>
        /// 優先權
        /// </summary>
        PriorityTypeEnum Priority { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 類別類型
    /// </summary>
    public enum CategoryTypeEnum
    {
        /// <summary>
        /// 資訊
        /// </summary>
        Info,
        /// <summary>
        /// 注意
        /// </summary>
        Warn,
        /// <summary>
        /// 例外
        /// </summary>
        Exception,
        /// <summary>
        /// 除錯
        /// </summary>
        Debug
    }


    /// <summary>
    /// 優先權類型
    /// </summary>
    public enum PriorityTypeEnum
    {
        /// <summary>
        /// 無差別
        /// </summary>
        None,
        /// <summary>
        /// 低
        /// </summary>
        Low,
        /// <summary>
        /// 中
        /// </summary>
        Medium,
        /// <summary>
        /// 高
        /// </summary>
        High
    }
}
