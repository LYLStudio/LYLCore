using System;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 服務執行結果介面
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
    /// 服務執行結果介面
    /// </summary>
    /// <typeparam name="T">指定服務回應資料型別</typeparam>
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// 回傳服務泛型資料
        /// </summary>
        T Data { get; }
    }
}
