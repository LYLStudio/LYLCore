namespace LYLStudio.Core.Logging
{
    using System;

    public interface ILogger
    {
        Action<string, ILogItem[]> Callback { get; set; }

        void Log(string destination, params ILogItem[] logItems);
    }
}