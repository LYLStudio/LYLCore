using System;

namespace LYLStudio.Core.Logging
{
    public interface ILogger<T>
    {
        Action<T> LogCallback { get; set; }

        void Log(T logItem);
    }
}
