using System;

namespace LYLStudio.Core.Logging
{
    public abstract class LoggerBase<T> : ILogger<T>
    {
        public abstract Action<T> LogCallback { get; set; }

        public virtual void Log(T logItem)
        {
            
        }
    }
}
