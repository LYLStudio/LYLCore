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
}
