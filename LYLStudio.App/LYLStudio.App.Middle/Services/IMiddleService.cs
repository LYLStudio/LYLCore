using LYLStudio.App.Middle.Models;

namespace LYLStudio.App.Middle.Services
{
    /// <summary>
    /// 中間件服務介面
    /// </summary>
    public interface IMiddleService
    {
        /// <summary>
        /// 服務檢查方法
        /// </summary>
        /// <typeparam name="T">指定回傳物件類型</typeparam>
        /// <param name="model">測試物件</param>
        /// <returns>服務執行結果</returns>
        IResult<T> ServiceCheck<T>(T model);
    }
}
