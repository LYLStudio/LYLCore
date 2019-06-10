using System;
using System.Collections.Generic;
using LYLStudio.App.Models;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    /// <summary>
    /// 自然人開戶申請書
    /// </summary>
    internal interface IApplicationOfNaturalPerson : IApplicationOfNaturalPerson<BasicInfoOfNaturalPerson, ContactInfo, InvestigationReport, CaseRecord>
    {
        /// <summary>
        /// <see cref="DigitalDemandSavingsDepositTypeEnum"/>
        /// </summary>
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
        /// 申請書編號
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime? ApplyTime { get; set; }
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

        /// <summary>
        /// 建構式
        /// </summary>
        public ApplicationOfNaturalPerson()
        {
            Id = Guid.NewGuid();
            InvestigationReports = new List<InvestigationReport>();
        }
    }

    /// <summary>
    /// 自然人開戶申請書
    /// </summary>
    /// <typeparam name="T1"><see cref="IBasicInfoOfNaturalPerson"/></typeparam>
    /// <typeparam name="T2"><see cref="IContactInfo"/></typeparam>
    /// <typeparam name="T3"></typeparam>
    internal interface IApplicationOfNaturalPerson<T1, T2, T3,T4> : IApplication
        where T1 : IBasicInfoOfNaturalPerson
        where T2 : IContactInfo
        where T3 : IInvestigationReport<T4>
        where T4 : ICaseRecord
    {
        /// <summary>
        /// 自然人基本資料
        /// </summary>
        T1 BasicInfo { get; set; }
        /// <summary>
        /// 聯絡資訊
        /// </summary>
        T2 ContactInfo { get; set; }
        /// <summary>
        /// 調查報告清單
        /// </summary>
        IEnumerable<T3>  InvestigationReports { get; }
    }   

    /// <summary>
    /// <see cref="IInvestigationReport{T}"/>
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
        public InvestigateResultTypeEnum InvestigateResult { get; set; }
        /// <summary>
        /// 說明
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
    /// <see cref="ICaseRecord"/>
    /// </summary>
    public class CaseRecord : ICaseRecord
    {
        /// <summary>
        /// <see cref="ICaseRecord.CaseId"/>
        /// </summary>
        public string CaseId { get; set; }
        /// <summary>
        /// <see cref="ICaseRecord.RecordTime"/>
        /// </summary>
        public DateTime RecordTime { get; set; }
        /// <summary>
        /// <see cref="ICaseRecord.Description"/>
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// <see cref="ICaseRecord.IsValid"/>
        /// </summary>
        public bool IsValid { get; set; }
    }

    /// <summary>
    /// <see cref="IContactInfo{T1, T2, T3}"/>
    /// </summary>
    internal interface IContactInfo : IContactInfo<AddressInfo, PhoneInfo, EmailInfo>
    {

    }

    /// <summary>
    /// <see cref="IContactInfo"/>
    /// </summary>
    public class ContactInfo : IContactInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AddressInfo> Addresses { get; set; }
        public IEnumerable<PhoneInfo> Phones { get; set; }
        public IEnumerable<EmailInfo> Emails { get; set; }

        public ContactInfo()
        {
            Addresses = new List<AddressInfo>();
            Phones = new List<PhoneInfo>();
            Emails = new List<EmailInfo>();
        }
    }


    public class EmailInfo : IEmailInfo
    {
        public EmailUsageTypeEnum UsageType { get; set; }
        public string Email { get; set; }
    }

    public class PhoneInfo : IPhoneInfo
    {
        public PhoneTypeEnum PhoneType { get; set; }
        public string Number { get; set; }
    }

    public class AddressInfo : IAddressInfo
    {
        public AddressTypeEnum AddressType { get; set; }
        public string ZipCode { get; set; }
        public string FullAddress { get; }
    }


    internal interface IBasicInfoOfNaturalPerson : IBasicInfoOfNaturalPerson<IdentityDocument>
    {
    }

    public class BasicInfoOfNaturalPerson : IBasicInfoOfNaturalPerson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime LegalDate { get; set; }
        public IdentityTypeEnum IdentityType { get; set; }
        public IEnumerable<IdentityDocument> IdentityDocuments { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public string ElementarySchoolName { get; set; }

        public BasicInfoOfNaturalPerson()
        {
            IdentityDocuments = new List<IdentityDocument>();
        }
    }

    public class IdentityDocument : IIdentityDocument
    {
        public string DocumentId { get; set; }
        public string OwnerId { get; set; }
        public IdentityDocumentTypeEnum DocumentType { get; set; }
        public DateTime? IssuedDate { get; set; }
        public IssuedTypeEnum? IssuedType { get; set; }
    }


}
