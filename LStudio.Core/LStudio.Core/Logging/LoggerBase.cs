using System;

namespace LStudio.Core.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public abstract Action<string, ILogItem[]> Callback { get; set; }

        public abstract void Log(string destination, params ILogItem[] logItems);
    }
}