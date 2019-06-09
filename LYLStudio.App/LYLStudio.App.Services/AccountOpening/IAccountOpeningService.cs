using LYLStudio.App.Models;

namespace LYLStudio.App.Services.AccountOpening
{
    /// <summary>
    /// 開戶申請服務
    /// </summary>
    public interface IAccountOpeningService
    {
        IAccountOpeningServiceResult Query(IBasicInfoBase basicInfo);

        IAccountOpeningServiceResult Apply(IApplication application);

        IAccountOpeningServiceResult Keep(IApplication application);

        IAccountOpeningServiceResult Cancel(IApplication application);
    }
}
