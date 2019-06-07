using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.App.Middle.Services;

namespace LYLStudio.App.Middle.Business.AccountOpening.Services
{
    public interface IAccountOpeningService : IMiddleService
    {
        IAccountOpeningServiceResult Apply();

        IAccountOpeningServiceResult<T> Check<T>(string message);
    }
}
