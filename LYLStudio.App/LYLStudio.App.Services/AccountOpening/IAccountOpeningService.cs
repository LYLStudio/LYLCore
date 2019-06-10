using LYLStudio.App.Models;

namespace LYLStudio.App.Services.AccountOpening
{
    /// <summary>
    /// 開戶申請服務
    /// </summary>
    /// <typeparam name="TResult"><see cref="IAccountOpeningServiceResultBase"/></typeparam>
    /// <typeparam name="T1"><see cref="IBasicInfoBase"/></typeparam>
    /// <typeparam name="T2"><see cref="IApplication"/></typeparam>
    public interface IAccountOpeningService<TResult, T1, T2>
        where TResult : IAccountOpeningServiceResultBase
        where T1 : IBasicInfoBase
        where T2 : IApplication
    {
        /// <summary>
        /// 查詢申請
        /// </summary>
        /// <param name="basicInfo">基本資料</param>
        /// <returns>服務結果</returns>
        TResult Query(T1 basicInfo);

        /// <summary>
        /// 提交申請
        /// </summary>
        /// <param name="application">申請書</param>
        /// <returns>服務結果</returns>
        TResult Apply(T2 application);

        /// <summary>
        /// 保留申請
        /// </summary>
        /// <param name="application">申請書</param>
        /// <returns>服務結果</returns>
        TResult Keep(T2 application);

        /// <summary>
        /// 取消申請
        /// </summary>
        /// <param name="application">申請書</param>
        /// <returns>服務結果</returns>
        TResult Cancel(T2 application);
    }
}
