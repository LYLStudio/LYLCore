using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 識別文件資訊清單
    /// </summary>
    /// <typeparam name="T"><see cref="IIdentityDocument"/></typeparam>
    public interface IListOfIdentityDocument<T>
        where T : IIdentityDocument
    {
        /// <summary>
        /// 識別文件清單
        /// </summary>
        IEnumerable<T> IdentityDocuments { get; }
    }

    /// <summary>
    /// 識別文件
    /// </summary>
    public interface IIdentityDocument
    {
        /// <summary>
        /// 證件編號
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// 擁有者識別編號
        /// </summary>
        string OwnerId { get; set; }

        /// <summary>
        /// 證件類型
        /// </summary>
        IdentityDocumentTypeEnum DocumentType { get; set; }

        /// <summary>
        /// 簽發日期
        /// </summary>
        DateTime? IssuedDate { get; set; }

        /// <summary>
        /// 簽發類型
        /// </summary>
        IssuedTypeEnum? IssuedType { get; set; }

        /// <summary>
        /// 簽發地點
        /// </summary>
        string IssuedPlace { get; set; }
    }

    /// <summary>
    /// 身分識別文件類型
    /// </summary>
    public enum IdentityDocumentTypeEnum
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,

        /// <summary>
        /// 身分證
        /// </summary>
        IdentificationCard,

        /// <summary>
        /// 健保卡
        /// </summary>
        HealthInsuranceCard,

        /// <summary>
        /// 駕照
        /// </summary>
        DriverLicense,

        /// <summary>
        /// 自然人憑證
        /// </summary>
        NaturalPerson,

        /// <summary>
        /// 護照
        /// </summary>
        Passport,
    }

    /// <summary>
    /// 簽發類型
    /// </summary>
    public enum IssuedTypeEnum
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,

        /// <summary>
        /// 新簽
        /// </summary>
        New,

        /// <summary>
        /// 補發
        /// </summary>
        Reissued,

        /// <summary>
        /// 換發
        /// </summary>
        Renewed,
    }
}
