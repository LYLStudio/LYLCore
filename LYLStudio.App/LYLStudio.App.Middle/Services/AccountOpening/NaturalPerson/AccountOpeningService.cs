using System;
using LYLStudio.App.Services.AccountOpening;

namespace LYLStudio.App.Middle.Services.AccountOpening.NaturalPerson
{
    public interface IAccountOpeningService : IAccountOpeningService<AccountOpeningServiceResult, BasicInfoOfNaturalPerson, ApplicationOfNaturalPerson>
    {

    }

    public class AccountOpeningService : IAccountOpeningService
    {
        public AccountOpeningServiceResult Apply(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        public AccountOpeningServiceResult Cancel(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        public AccountOpeningServiceResult Keep(ApplicationOfNaturalPerson application)
        {
            throw new NotImplementedException();
        }

        public AccountOpeningServiceResult Query(BasicInfoOfNaturalPerson basicInfo)
        {
            throw new NotImplementedException();
        }
    }
}