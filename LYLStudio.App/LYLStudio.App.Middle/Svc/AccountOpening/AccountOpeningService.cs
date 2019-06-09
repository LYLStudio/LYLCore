using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LYLStudio.App.Models;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Svc.AccountOpening
{

    public interface IAccountOpeningService : IAccountOpeningService<AccountOpeningServiceResult, BasicInfoOfNaturalPerson, ApplicationOfNaturalPerson>
    {

    }

    /* 單獨實作或直接由IService繼承IAccountOpeningService
    public class AccountOpeningService : IAccountOpeningService
    {      

    }
    */

}