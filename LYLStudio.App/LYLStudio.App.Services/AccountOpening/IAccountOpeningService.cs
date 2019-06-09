using LYLStudio.App.Models;

namespace LYLStudio.App.Services.AccountOpening
{
    /// <summary>
    /// 開戶申請服務
    /// </summary>
    public interface IAccountOpeningService<TResult, T1, T2>
        where TResult : IAccountOpeningServiceResultBase
        where T1 : IBasicInfoBase
        where T2 : IApplication
    {
        TResult Query(T1 basicInfo);

        TResult Apply(T2 application);

        TResult Keep(T2 application);

        TResult Cancel(T2 application);
    }
}
