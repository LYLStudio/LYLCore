using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Middle.Business.AccountOpening.Models
{
    /// <summary>
    /// 基本資訊
    /// </summary>
    public interface IBasicInfo
    {
        /// <summary>
        /// 識別編號(身分證/統編/其他)
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 法定日期(出生/公司註冊日期)
        /// </summary>
        DateTime LegalDate { get; set; }
        /// <summary>
        /// 身分別
        /// </summary>
        IdentityType IdentityType { get; set; }
        /// <summary>
        /// 識別文件清單
        /// </summary>
        IEnumerable<IIdentityDocument> IdentityDocuments { get; }
    }

    /// <summary>
    /// 識別文件
    /// </summary>
    public interface IIdentityDocument
    {
        /// <summary>
        /// 證號
        /// </summary>
        string DocumentId { get; set; }
        /// <summary>
        /// 擁有者識別編號
        /// </summary>
        string OwnerId { get; set; }
        /// <summary>
        /// 識別文件類型
        /// </summary>
        IdentityDocumentType DocumentType { get; set; }
    }

    /// <summary>
    /// 自然人其他資訊
    /// </summary>
    public interface INaturalPersonAdditional
    {
        /// <summary>
        /// 性別
        /// </summary>
        GenderType Gender { get; set; }
        /// <summary>
        /// 畢業小學
        /// </summary>
        string ElementarySchoolName { get; set; }
    }

    #region Enum
    /// <summary>
    /// 身分別
    /// </summary>
    public enum IdentityType
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,
        /// <summary>
        /// 自然人
        /// </summary>
        [Display(Name = "自然人")]
        [DBValue("P")]
        NaturalPerson,
        /// <summary>
        /// 法人
        /// </summary>
        [DBValue("X")]
        JuridicalPerson,
        //todo 其他類型
    }

    /// <summary>
    /// 身分識別文件類型
    /// </summary>
    public enum IdentityDocumentType
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
    /// 性別
    /// </summary>
    public enum GenderType
    {
        Unknown,
        Male,
        Female,
    }
    #endregion
}
