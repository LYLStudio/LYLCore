using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LYLStudio.App.Middle.Services;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    [ServiceContract]
    public class Service : IService
    {
        public ILogService Logger { get; }

        public Service()
        {
            
        }

        [OperationContract]
        public AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        [OperationContract]
        public AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        [OperationContract]
        public AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        [OperationContract]
        public AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            throw new NotImplementedException();
        }

        [OperationContract]
        public ServiceTest ServiceCheck()
        {
            throw new NotImplementedException();
        }
    }
}
