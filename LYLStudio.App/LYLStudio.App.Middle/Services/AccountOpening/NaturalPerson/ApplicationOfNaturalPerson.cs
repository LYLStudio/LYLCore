using System;
using System.Collections.Generic;
using LYLStudio.App.Models;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    internal interface IApplicationOfNaturalPerson : IApplicationOfNaturalPerson<BasicInfoOfNaturalPerson, ContactInfo, InvestigationReport, CaseRecord>
    {
        DigitalDemandSavingsDepositTypeEnum DigitalDemandSavingsDepositType { get; set; }
    }

    /// <summary>
    /// 數位活儲類型
    /// </summary>
    public enum DigitalDemandSavingsDepositTypeEnum
    {
        /// <summary>
        /// 非數位
        /// </summary>
        None,

        /// <summary>
        /// 第一類
        /// </summary>
        Class1,

        /// <summary>
        /// 第二類
        /// </summary>
        Class2,

        /// <summary>
        /// 第三類
        /// </summary>
        Class3
    }

    /// <summary>
    /// 自然人開戶申請書
    /// </summary>    
    public class ApplicationOfNaturalPerson : IApplicationOfNaturalPerson
    {
        /// <summary>
        /// 申請書編號
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime? ApplyTime { get; set; }
        /// <summary>
        /// 申請書名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 自然人基本資料
        /// </summary>
        public BasicInfoOfNaturalPerson BasicInfo { get; set; }
        /// <summary>
        /// 聯絡資訊
        /// </summary>
        public ContactInfo ContactInfo { get; set; }
        /// <summary>
        /// 調查報告清單
        /// </summary>
        public IEnumerable<InvestigationReport> InvestigationReports { get; set; }
        /// <summary>
        /// 核定結果
        /// </summary>
        public ApprovedResultTypeEnum? ApprovedResult { get; set; }
        /// <summary>
        /// 核定時間
        /// </summary>
        public DateTime? ApprovedTime { get; set; }
        /// <summary>
        /// 數位活儲類型
        /// </summary>
        public DigitalDemandSavingsDepositTypeEnum DigitalDemandSavingsDepositType { get; set; }

        public ApplicationOfNaturalPerson()
        {
            Id = Guid.NewGuid();
            InvestigationReports = new List<InvestigationReport>();
        }
    }

    internal interface IApplicationOfNaturalPerson<T1, T2, T3, T4> : IApplication
        where T1 : IBasicInfoOfNaturalPerson
        where T2 : IContactInfo
        where T3 : IInvestigationReport<T4>
        where T4 : ICaseRecord
    {
        T1 BasicInfo { get; set; }
        T2 ContactInfo { get; set; }
        IEnumerable<T3> InvestigationReports { get; }
    }

    /// <summary>
    /// 調查報告
    /// </summary>
    public class InvestigationReport : IInvestigationReport<CaseRecord>
    {
        /// <summary>
        /// 調查類型
        /// </summary>
        public InvestigateTypeEnum InvestigateType { get; set; }
        /// <summary>
        /// 調查結果
        /// </summary>
        public InvestigateResultTypeEnum? InvestigateResult { get; set; }
        /// <summary>
        /// 描述說明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 案件清單
        /// </summary>
        public IEnumerable<CaseRecord> CaseRecords { get; set; }

        public InvestigationReport()
        {
            CaseRecords = new List<CaseRecord>();
        }
    }

    /// <summary>
    /// 案件紀錄
    /// </summary>
    public class CaseRecord : ICaseRecord
    {
        /// <summary>
        /// 案件編號
        /// </summary>
        public string CaseId { get; set; }
        /// <summary>
        /// 案件時間
        /// </summary>
        public DateTime RecordTime { get; set; }
        /// <summary>
        /// 案件說明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool? IsValid { get; set; }
    }

    internal interface IContactInfo : IContactInfo<AddressInfo, PhoneInfo, EmailInfo>
    {

    }

    /// <summary>
    /// 聯絡資訊
    /// </summary>
    public class ContactInfo : IContactInfo
    {
        /// <summary>
        /// 地址清單
        /// </summary>
        public IEnumerable<AddressInfo> Addresses { get; set; }
        /// <summary>
        /// 電話清單
        /// </summary>
        public IEnumerable<PhoneInfo> Phones { get; set; }
        /// <summary>
        /// 電子郵件清單
        /// </summary>
        public IEnumerable<EmailInfo> Emails { get; set; }

        public ContactInfo()
        {
            Addresses = new List<AddressInfo>();
            Phones = new List<PhoneInfo>();
            Emails = new List<EmailInfo>();
        }
    }

    /// <summary>
    /// 郵件資訊
    /// </summary>
    public class EmailInfo : IEmailInfo
    {
        /// <summary>
        /// 用途
        /// </summary>
        public EmailUsageTypeEnum UsageType { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// 電話資訊
    /// </summary>
    public class PhoneInfo : IPhoneInfo
    {
        /// <summary>
        /// 用途
        /// </summary>
        public PhoneUsageTypeEnum UsageType { get; set; }
        /// <summary>
        /// 電話號碼
        /// </summary>
        public string Number { get; set; }
    }

    /// <summary>
    /// 地址清單
    /// </summary>
    public class AddressInfo : IAddressInfo
    {
        /// <summary>
        /// 用途
        /// </summary>
        public AddressUsageTypeEnum UsageType { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 地址全文
        /// </summary>
        public string FullAddress { get; }
    }

    internal interface IBasicInfoOfNaturalPerson : IBasicInfoOfNaturalPerson<IdentityDocument>
    {
    }

    /// <summary>
    /// 自然人基本資訊
    /// </summary>
    public class BasicInfoOfNaturalPerson : IBasicInfoOfNaturalPerson
    {
        /// <summary>
        /// 識別編號
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生日或登記日
        /// </summary>
        public DateTime? LegalDate { get; set; }
        /// <summary>
        /// 身分別
        /// </summary>
        public IdentityTypeEnum IdentityType { get; set; }
        /// <summary>
        /// 識別文件清單
        /// </summary>
        public IEnumerable<IdentityDocument> IdentityDocuments { get; }
        /// <summary>
        /// 性別
        /// </summary>
        public GenderTypeEnum Gender { get; set; }
        /// <summary>
        /// 小學名稱
        /// </summary>
        public string ElementarySchoolName { get; set; }

        public BasicInfoOfNaturalPerson()
        {
            IdentityDocuments = new List<IdentityDocument>();
        }
    }

    /// <summary>
    /// 識別文件
    /// </summary>
    public class IdentityDocument : IIdentityDocument
    {
        /// <summary>
        /// 證件編號
        /// </summary>
        public string DocumentId { get; set; }
        /// <summary>
        /// 擁有者識別編號
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// 文件類型
        /// </summary>
        public IdentityDocumentTypeEnum DocumentType { get; set; }
        /// <summary>
        /// 簽發日期
        /// </summary>
        public DateTime? IssuedDate { get; set; }
        /// <summary>
        /// 簽發類型
        /// </summary>
        public IssuedTypeEnum? IssuedType { get; set; }
        /// <summary>
        /// 簽發地點
        /// </summary>
        public string IssuedPlace { get; set; }
    }


}
