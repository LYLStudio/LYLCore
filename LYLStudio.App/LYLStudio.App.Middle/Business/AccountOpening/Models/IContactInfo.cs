using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Middle.Business.AccountOpening.Models
{
    /// <summary>
    /// 聯絡資訊
    /// </summary>
    public interface IContactInfo
    {
        /// <summary>
        /// 地址清單
        /// </summary>
        IEnumerable<IAddressInfo> Addresses { get; }
        /// <summary>
        /// 電話清單
        /// </summary>
        IEnumerable<IPhoneInfo> Phones { get; }
        /// <summary>
        /// 電子郵件信箱
        /// </summary>        
        string Email { get; set; }
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
    /// 電話資訊
    /// </summary>
    public interface IPhoneInfo
    {
        /// <summary>
        /// 電話類型
        /// </summary>
        PhoneType PhoneType { get; set; }
        /// <summary>
        /// 電話號碼
        /// </summary>
        string Number { get; set; }
    }

    #region Enum
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

    /// <summary>
    /// 電話類型
    /// </summary>
    [Flags]
    public enum PhoneType
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
    #endregion

}
