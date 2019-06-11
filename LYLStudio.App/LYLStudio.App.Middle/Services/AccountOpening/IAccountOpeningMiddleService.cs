using System;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services.AccountOpening
{    
    public interface IAccountOpeningMiddleService : IMiddleService<AccountOpeningServiceChecking>
    {
    }

    /// <summary>
    /// 開戶服務檢查
    /// </summary>
    public class AccountOpeningServiceChecking : IServiceChecking
    {
        /// <summary>
        /// 回應時間
        /// </summary>
        public DateTime? ReplyTime { get; set; }
        /// <summary>
        /// 服務狀態
        /// </summary>
        public ServiceStatusEnum Status { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
    }
}