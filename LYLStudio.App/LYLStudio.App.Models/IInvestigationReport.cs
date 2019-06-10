using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 調查報告
    /// </summary>
    /// <typeparam name="T"><see cref="ICaseRecord"/></typeparam>
    public interface IInvestigationReport<T> : IListOfCaseRecord<T>
        where T : ICaseRecord
    {
        /// <summary>
        /// <see cref="InvestigateTypeEnum"/>
        /// </summary>
        InvestigateTypeEnum InvestigateType { get; }
        /// <summary>
        /// <see cref="InvestigateResultTypeEnum"/>
        /// </summary>
        InvestigateResultTypeEnum InvestigateResult { get; }
        /// <summary>
        /// 調查結果描述
        /// </summary>
        string Description { get; }
    }

    /// <summary>
    /// 調查類型
    /// </summary>
    public enum InvestigateTypeEnum
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
    public enum InvestigateResultTypeEnum
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
