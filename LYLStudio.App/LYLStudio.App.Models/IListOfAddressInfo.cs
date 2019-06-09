using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 地址資訊
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListOfAddressInfo<T>
         where T : IAddressInfo
    {
        /// <summary>
        /// 地址清單
        /// </summary>
        IEnumerable<T> Addresses { get; }
    }

    /// <summary>
    /// 地址資訊
    /// </summary>
    public interface IAddressInfo
    {
        /// <summary>
        /// 地址類型
        /// </summary>
        AddressType AddressType { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        string ZipCode { get; set; }
        /// <summary>
        /// 地址全文
        /// </summary>
        string FullAddress { get; }
    }

    /// <summary>
    /// 地址類型
    /// </summary>
    [Flags]
    public enum AddressType
    {
        /// <summary>
        /// 戶籍地址
        /// </summary>
        Household = 0x0001,
        /// <summary>
        /// 居住/通訊地址
        /// </summary>
        Residence = 0x0010,
        /// <summary>
        /// 公司地址
        /// </summary>
        Company = 0x0100,
        /// <summary>
        /// 郵政信箱
        /// </summary>
        PostBox = 0x1000
    }
}
