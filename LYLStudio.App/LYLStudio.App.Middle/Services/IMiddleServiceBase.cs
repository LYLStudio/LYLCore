using System;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    public interface IMiddleService : IMiddleServiceBase<ServiceChecking>
    {
    }

    /// <summary>
    /// 中間件服務基底介面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMiddleServiceBase<T> 
        where T : IServiceCheckingBase
    {        
        /// <summary>
        /// 檢查服務狀態
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        T CheckService(CheckTypeEnum checkType = CheckTypeEnum.None);
    }

    /// <summary>
    /// 開戶服務檢查
    /// </summary>
    public class ServiceChecking : IServiceCheckingBase
    {
        /// <summary>
        /// 回應時間
        /// </summary>
        public DateTime? ReplyTime { get; set; }
        /// <summary>
        /// 服務狀態
        /// </summary>
        public ServiceStatusEnum Status { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
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
