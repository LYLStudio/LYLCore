using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LYLStudio.App.Middle.Services;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{
    public interface IService : IAccountOpeningMiddleService, IAccountOpeningService
    {
       
    }
}
