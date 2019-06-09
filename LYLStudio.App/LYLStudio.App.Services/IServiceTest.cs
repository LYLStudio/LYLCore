using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Services
{
    public interface IServiceTest
    {
        DateTime SendTime { get; }
        DateTime? ReplyTime { get; }
        ServiceStatus Status { get; }
        string Message { get; }
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
