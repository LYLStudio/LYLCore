using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.App.Models;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    internal interface IApplicationOfNaturalPerson: IApplicationOfNaturalPerson<BasicInfoOfNaturalPerson, ContactInfo, ListOfInvestigationReport>
    {

    }

    public class ApplicationOfNaturalPerson : IApplicationOfNaturalPerson
    {
        public BasicInfoOfNaturalPerson BasicInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ListOfInvestigationReport InvestigationReports { get; }
        public Guid Id { get; }
        public DateTime? ApplyTime { get; set; }
        public ApprovedResultType? ApprovedResult { get; set; }
        public DateTime? ApprovedTime { get; set; }
    }

    internal interface IApplicationOfNaturalPerson<T1, T2, T3> : IApplication
        where T1 : IBasicInfoOfNaturalPerson
        where T2 : IContactInfo
        where T3 : IListOfInvestigationReport
    {
        T1 BasicInfo { get; set; }
        T2 ContactInfo { get; set; }
        T3 InvestigationReports { get; }
    }



    internal interface IListOfInvestigationReport : IListOfInvestigationReport<InvestigationReport, CaseRecord>
    {
    }


    public class ListOfInvestigationReport : IListOfInvestigationReport
    {
        public IEnumerable<InvestigationReport> InvestigationReports { get; }
    }

    public class InvestigationReport : IInvestigationReport<CaseRecord>
    {
        public InvestigationType InvestigationType { get; }
        public InvestigateResultType InvestigateResult { get; }
        public string Description { get; }
        public IEnumerable<CaseRecord> CaseRecords { get; }
    }

    public class CaseRecord : ICaseRecord
    {
        public string CaseId { get; set; }
        public DateTime RecordTime { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
    }


    internal interface IContactInfo : IContactInfo<AddressInfo, PhoneInfo, EmailInfo>
    {

    }

    public class ContactInfo : IContactInfo
    {
        public IEnumerable<AddressInfo> Addresses { get; }
        public IEnumerable<PhoneInfo> Phones { get; }
        public IEnumerable<EmailInfo> Emails { get; }
    }


    public class EmailInfo : IEmailInfo
    {
        public EmailUsageType UsageType { get; set; }
        public string Email { get; set; }
    }

    public class PhoneInfo : IPhoneInfo
    {
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
    }

    public class AddressInfo : IAddressInfo
    {
        public AddressType AddressType { get; set; }
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
        public IdentityType IdentityType { get; set; }
        public IEnumerable<IdentityDocument> IdentityDocuments { get; }
        public GenderType Gender { get; set; }
        public string ElementarySchoolName { get; set; }
    }

    public class IdentityDocument : IIdentityDocument
    {
        public string DocumentId { get; set; }
        public string OwnerId { get; set; }
        public IdentityDocumentType DocumentType { get; set; }
    }


}
