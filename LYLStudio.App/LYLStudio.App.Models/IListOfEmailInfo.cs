using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// Email資訊清單
    /// </summary>
    /// <typeparam name="T"><see cref="IEmailInfo"/></typeparam>
    public interface IListOfEmailInfo<T>
        where T : IEmailInfo
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
        /// <see cref="EmailUsageTypeEnum"/>
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
        Unknown = 0x0000,
        Ntd,
        Fund,
        Fe,
        Gold,
        Ecc,
        All = Ntd | Fund | Fe | Gold | Ecc
        //todo: 其他用途
    }
}
