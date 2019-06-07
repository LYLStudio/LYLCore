using LYLStudio.App.Middle.Models;

namespace LYLStudio.App.Middle.Services
{
    public abstract class MiddleServiceBase : IMiddleService
    {
        protected static ILogService Logger { get; private set; }

        protected MiddleServiceBase(ILogService logger)
        {
            Logger = logger;
        }

        public abstract IResult<T> ServiceCheck<T>(T model);
    }
}