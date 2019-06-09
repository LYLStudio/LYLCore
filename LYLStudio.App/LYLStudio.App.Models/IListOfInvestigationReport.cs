using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    public interface IListOfInvestigationReport<T1, T2>
        where T1 : IInvestigationReport<T2>
        where T2 : ICaseRecord
    {
        /// <summary>
        /// 調查報告清單
        /// </summary>
        IEnumerable<T1> InvestigationReports { get; }
    }

    /// <summary>
    /// 調查報告
    /// </summary>
    public interface IInvestigationReport<T> : IListOfCaseRecord<T>
        where T : ICaseRecord
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
