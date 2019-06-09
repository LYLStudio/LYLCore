using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services
{
    /// <summary>
    /// 中間件服務介面
    /// </summary>    
    public interface IMiddleService<T>
        where T : IServiceTest
    {
        ILogService Logger { get; }

        T ServiceCheck();
    }
}
