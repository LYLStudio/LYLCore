using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Middle.Business.AccountOpening.Models
{
    /// <summary>
    /// 開戶申請
    /// </summary>
    public interface IAccountOpeningApplication
    {
        /// <summary>
        /// 開戶申請書編號
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// 基本資料
        /// </summary>
        IBasicInfo BasicInfo { get; set; }
        /// <summary>
        /// 聯絡資訊
        /// </summary>
        IContactInfo ContactInfo { get; set; }
        /// <summary>
        /// 調查報告清單
        /// </summary>
        IEnumerable<IInvestigationReport> InvestigationReports {get;}
    }

    
}
