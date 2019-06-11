using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// Email資訊清單
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListOfEmailInfo<T> where T : IEmailInfo
    {
        /// <summary>
        /// Email清單
        /// </summary>
        IEnumerable<T> Emails { get; }
    }

    /// <summary>
    /// Email資訊
    /// </summary>
    public interface IEmailInfo
    {
        /// <summary>
        /// 用途
        /// </summary>
        EmailUsageTypeEnum UsageType { get; set; }

        /// <summary>
        /// 電子郵件信箱
        /// </summary>        
        string Email { get; set; }
    }

    /// <summary>
    /// Email用途類型
    /// </summary>
    [Flags]
    public enum EmailUsageTypeEnum
    {
        /// <summary>
        /// 主要Email
        /// </summary>
        Main = 0x0001,

        /// <summary>
        /// 交易通知
        /// </summary>
        NotificationOfTransaction = 0x0010,

        /// <summary>
        /// 活動通知
        /// </summary>
        NotificationOfActivity = 0x0100,

        /// <summary>
        /// 對帳單
        /// </summary>
        Reconciliation = 0x1000
    }
}
