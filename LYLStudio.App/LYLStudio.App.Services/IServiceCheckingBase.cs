using System;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 服務檢查基底介面
    /// </summary>
    public interface IServiceCheckingBase
    {
        /// <summary>
        /// 回應時間
        /// </summary>
        DateTime? ReplyTime { get; set; }

        /// <summary>
        /// 服務狀態
        /// </summary>
        ServiceStatusEnum Status { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 服務狀態類型
    /// </summary>
    public enum ServiceStatusEnum
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 可用
        /// </summary>
        Available,
        /// <summary>
        /// 無法取得
        /// </summary>
        Unreachable,
        /// <summary>
        /// 維護中
        /// </summary>
        UnderMaintenance
    }
}
