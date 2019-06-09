using LYLStudio.App.Models;

namespace LYLStudio.App.Services.AccountOpening
{
    /// <summary>
    /// 開戶申請服務
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface IAccountOpeningService<TResult, T1, T2>
        where TResult : IAccountOpeningServiceResultBase
        where T1 : IBasicInfoBase
        where T2 : IApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basicInfo"></param>
        /// <returns></returns>
        TResult Query(T1 basicInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        TResult Apply(T2 application);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        TResult Keep(T2 application);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        TResult Cancel(T2 application);
    }
}
