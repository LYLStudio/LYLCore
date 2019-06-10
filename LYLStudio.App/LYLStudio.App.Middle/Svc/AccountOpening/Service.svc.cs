using System;
using System.ServiceModel;
using LYLStudio.App.Middle.Services;
using LYLStudio.App.Middle.Services.AccountOpening;
using LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    [ServiceContract]
    public interface IService : IAccountOpeningMiddleService, IAccountOpeningService
    {
        [OperationContract]
        AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application);

        [OperationContract]
        AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application);

        [OperationContract]
        AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application);

        [OperationContract]
        AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo);

        [OperationContract]
        AccountOpeningServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None);
    }
    
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
        
        public AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Apply(application);
        }

        public AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Cancel(application);
        }

        public AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Keep(application);
        }

        public AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            return _accountOpeningService.Query(basicInfo);
        }

        public AccountOpeningServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None)
        {
            //todo something check
            var result = new AccountOpeningServiceChecking
            {
                Status = App.Services.ServiceStatusEnum.Unknown,
                Message = checkType.ToString(),
                ReplyTime = DateTime.Now
            };

            return result;
        }
    }
}
