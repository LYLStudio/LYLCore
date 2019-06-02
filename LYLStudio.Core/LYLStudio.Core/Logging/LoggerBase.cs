using System;

namespace LYLStudio.Core.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public abstract TraceLevel TraceLevel { get; set; }
        public abstract Action<string, ILogItem[]> Callback { get; set; }

        public virtual void Log(string target, params ILogItem[] logItems)
        {
        }
    }
}