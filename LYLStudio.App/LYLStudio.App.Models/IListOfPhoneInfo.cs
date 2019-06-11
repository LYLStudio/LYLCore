using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 電話資訊清單
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListOfPhoneInfo<T> where T : IPhoneInfo
    {
        /// <summary>
        /// 電話清單
        /// </summary>
        IEnumerable<T> Phones { get; }
    }

    /// <summary>
    /// 電話資訊
    /// </summary>
    public interface IPhoneInfo
    {
        /// <summary>
        /// 用途
        /// </summary>
        PhoneUsageTypeEnum UsageType { get; set; }

        /// <summary>
        /// 電話號碼
        /// </summary>
        string Number { get; set; }
    }

    /// <summary>
    /// 電話使用類型
    /// </summary>
    [Flags]
    public enum PhoneUsageTypeEnum
    {
        /// <summary>
        /// 住家
        /// </summary>
        Home = 0x0001,

        /// <summary>
        /// 公司
        /// </summary>
        Company = 0x0010,

        /// <summary>
        /// 傳真
        /// </summary>
        Fax = 0x0100,

        /// <summary>
        /// 行動電話
        /// </summary>
        Cellphone = 0x1000,

        /// <summary>
        /// 住家與公司相同
        /// </summary>
        HomeAndCompany = Home | Company,

        /// <summary>
        /// 住家與傳真相同
        /// </summary>
        HomeAndFax = Home | Fax,

        /// <summary>
        /// 公司與傳真相同
        /// </summary>
        CompanyAndFax = Company | Fax,
    }
}
