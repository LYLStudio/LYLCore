using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Middle.Business.AccountOpening.Models
{
    /// <summary>
    /// 調查報告
    /// </summary>
    public interface IInvestigationReport
    {
        /// <summary>
        /// 調查報告類型
        /// </summary>
        InvestigationType InvestigationType { get; }
        /// <summary>
        /// 調查結果
        /// </summary>
        InvestigateResultType InvestigateResult { get; }
        /// <summary>
        /// 調查結果描述
        /// </summary>
        string Description { get; }        
        /// <summary>
        /// 案件記錄清單
        /// </summary>
        IEnumerable<ICaseRecord> CaseRecords { get; }
    }

    /// <summary>
    /// 案件記錄
    /// </summary>
    public interface ICaseRecord
    {
        /// <summary>
        /// 案件編號
        /// </summary>
        string CaseId { get; set; }
        /// <summary>
        /// 案件時間
        /// </summary>
        DateTime RecordTime { get; set; }
        /// <summary>
        /// 案件說明
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        bool IsValid { get; set; }
    }

    /// <summary>
    /// 調查類型
    /// </summary>
    public enum InvestigationType
    {
        /// <summary>
        /// 防制洗錢
        /// </summary>
        AML,
        /// <summary>
        /// 聯徵調查
        /// </summary>
        JCIC,

        //todo: 其他調查項目?
    }

    /// <summary>
    /// 調查結果類型
    /// </summary>
    public enum InvestigateResultType
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 警示
        /// </summary>
        Warning,
        
        //todo: 其他結果?
    }

}
