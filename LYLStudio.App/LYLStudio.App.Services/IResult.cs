using System;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 服務執行結果
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 執行結果編號
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 訊息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 附加資料
    /// </summary>
    /// <typeparam name="T">附加資料的資料型別</typeparam>
    public interface IExtendData<T>
    {
        /// <summary>
        /// 資料
        /// </summary>
        T Data { get; }
    }
}
