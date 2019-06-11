namespace LYLStudio.App.Models
{
    /// <summary>
    /// 調查報告
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInvestigationReport<T> : IListOfCaseRecord<T> where T : ICaseRecord
    {
        /// <summary>
        /// 調查類型
        /// </summary>
        InvestigateTypeEnum InvestigateType { get; }

        /// <summary>
        /// 調查結果類型
        /// </summary>
        InvestigateResultTypeEnum? InvestigateResult { get; }

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

        /// <summary>
        /// 內部黑名單
        /// </summary>
        InternalBlackList,
    }

    /// <summary>
    /// 調查結果類型
    /// </summary>
    public enum InvestigateResultTypeEnum
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,

        /// <summary>
        /// 正常
        /// </summary>
        Normal,

        /// <summary>
        /// 警示
        /// </summary>
        Warning,
    }

}
