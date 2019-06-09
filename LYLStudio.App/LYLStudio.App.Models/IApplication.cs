using System;

namespace LYLStudio.App.Models
{
    /// <summary>
    /// 申請書
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// 開戶申請書編號
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 申請時間
        /// </summary>
        DateTime? ApplyTime { get; set; }

        /// <summary>
        /// 核定結果
        /// </summary>
        ApprovedResultType? ApprovedResult { get; set; }

        /// <summary>
        /// 核定時間
        /// </summary>
        DateTime? ApprovedTime { get; set; }
    }

    /// <summary>
    /// 申請書結果類型
    /// </summary>
    public enum ApprovedResultType
    {
        /// <summary>
        /// 拒絕
        /// </summary>
        Reject,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
    }
}
