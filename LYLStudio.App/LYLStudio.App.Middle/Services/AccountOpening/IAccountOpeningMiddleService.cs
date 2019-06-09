using System;
using LYLStudio.App.Middle.Services;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services.AccountOpening
{
    public interface IAccountOpeningMiddleService : IMiddleService<AccountOpeningServiceChecking>
    {
    }

    public class AccountOpeningServiceChecking : IServiceChecking
    {
        public DateTime? ReplyTime { get; set; }
        public ServiceStatus Status { get; set; }
        public string Message { get; set; }
    }
}