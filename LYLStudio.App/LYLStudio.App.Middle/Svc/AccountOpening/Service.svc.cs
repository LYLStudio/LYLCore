using System;
using System.ServiceModel;
using LYLStudio.App.Middle.Services;
using LYLStudio.App.Middle.Services.AccountOpening;
using LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    public interface IService : IAccountOpeningMiddleService, IAccountOpeningService
    {
    }

    [ServiceContract]
    public class Service : IService
    {
        private readonly IAccountOpeningService _accountOpeningService;
        public ILogService Logger { get; }

        public Service()
        {
            //初始化ILogService

            //初始化IAccountOpeningService
            _accountOpeningService = new AccountOpeningService();

            //其他
        }

        [OperationContract]
        public AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Apply(application);
        }

        [OperationContract]
        public AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Cancel(application);
        }

        [OperationContract]
        public AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Keep(application);
        }

        [OperationContract]
        public AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            return _accountOpeningService.Query(basicInfo);
        }
        
        [OperationContract]
        public AccountOpeningServiceChecking CheckService(CheckType checkType = CheckType.None)
        {
            var result = new AccountOpeningServiceChecking
            {
                Message = checkType.ToString(),
                ReplyTime = DateTime.Now
            };

            return result;
        }
    }
}
