using System;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    /// <summary>
    /// 中間件服務介面
    /// </summary>    
    public interface IMiddleService<T>
        where T : IServiceChecking
    {
        ILogService Logger { get; }

        T CheckService(CheckType checkType = CheckType.None);
    }

    /// <summary>
    /// 系統檢查類型
    /// </summary>
    [Flags]
    public enum CheckType
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
