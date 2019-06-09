using System;
using System.Collections.Generic;

namespace LYLStudio.App.Models
{
    public interface IListOfCaseRecord<T>
        where T : ICaseRecord
    {
        /// <summary>
        /// 案件記錄清單
        /// </summary>
        IEnumerable<T> CaseRecords { get; }
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
}
