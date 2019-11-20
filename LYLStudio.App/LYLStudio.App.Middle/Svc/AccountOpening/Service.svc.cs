using System;
using System.ServiceModel;
using System.Web.Hosting;
using LYLStudio.App.Middle.Services;
using LYLStudio.App.Middle.Services.AccountOpening;
using LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson;
using LYLStudio.App.Middle.Services.Logging;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    [ServiceContract]
    public interface IService : IAccountOpeningService
    {
        [OperationContract]
        new ServiceResult Apply(ApplicationOfNaturalPerson application);

        [OperationContract]
        new ServiceResult Cancel(ApplicationOfNaturalPerson application);

        [OperationContract]
        new ServiceResult Keep(ApplicationOfNaturalPerson application);

        [OperationContract]
        new ServiceResult Query(BasicInfoOfNaturalPerson basicInfo);

        [OperationContract]
        new ServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None);
    }
    
    public class Service : IService
    {
                       

        private readonly IAccountOpeningService _accountOpeningService;
               
        public Service()
        {
            var logItem = new LogItem() { Message = "進入服務" };
            LogHelper.Log(TargetEnum.All,logItem);
            

            //初始化IAccountOpeningService
            _accountOpeningService = new AccountOpeningService();

            //其他
        }
        
        public ServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            
            return _accountOpeningService.Apply(application);
        }

        public ServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Cancel(application);
        }

        public ServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            return _accountOpeningService.Keep(application);
        }

        public ServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            return _accountOpeningService.Query(basicInfo);
        }

        public ServiceChecking CheckService(CheckTypeEnum checkType = CheckTypeEnum.None)
        {
            return _accountOpeningService.CheckService(checkType);
        }
    }
}
