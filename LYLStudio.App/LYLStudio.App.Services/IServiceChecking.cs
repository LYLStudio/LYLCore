using System;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 服務測試
    /// </summary>
    public interface IServiceChecking
    {
        /// <summary>
        /// 回應時間
        /// </summary>
        DateTime? ReplyTime { get; set; }
        /// <summary>
        /// 服務狀態
        /// </summary>
        ServiceStatus Status { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 服務狀態
    /// </summary>
    public enum ServiceStatus
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
