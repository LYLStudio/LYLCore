using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LYLStudio.App.Middle.Services;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    public interface IAccountOpeningMiddleService : IMiddleService<ServiceTest>
    {
    }
   
    public class ServiceTest : IServiceTest
    {
        public DateTime SendTime { get; }
        public DateTime? ReplyTime { get; }
        public ServiceStatus Status { get; }
        public string Message { get; }
    }
}