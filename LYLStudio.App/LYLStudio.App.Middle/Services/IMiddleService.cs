using System;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    /// <summary>
    /// 中間件服務介面
    /// </summary>
    /// <typeparam name="T"><see cref="IServiceChecking"/></typeparam>
    public interface IMiddleService<T>
        where T : IServiceChecking
    {
        /// <summary>
        /// 記錄器<see cref="ILogService"/>
        /// </summary>
        ILogService Logger { get; }

        /// <summary>
        /// 檢查服務狀態
        /// </summary>
        /// <param name="checkType"><see cref="CheckTypeEnum"/></param>
        /// <returns>服務檢查結果<see cref="IServiceChecking"/></returns>
        T CheckService(CheckTypeEnum checkType = CheckTypeEnum.None);
    }

    /// <summary>
    /// 服務檢查類型
    /// </summary>
    [Flags]
    public enum CheckTypeEnum
    {
        /// <summary>
        /// 不檢查
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// 儲存相關檢查
        /// </summary>
        Storage = 0x0001,
        /// <summary>
        /// 網路相關檢查
        /// </summary>
        Networking = 0x0010,
        /// <summary>
        /// 依此服務專用的檢查
        /// </summary>
        ByServiceFeature = 0x0100,
        /// <summary>
        /// 全部檢查
        /// </summary>
        All = Networking | Storage | ByServiceFeature
        //todo 其他?
    }
}
