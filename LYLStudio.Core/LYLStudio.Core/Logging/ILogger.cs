using System;

namespace LYLStudio.Core.Logging
{
    public interface ILogger
    {
        TraceLevel TraceLevel { get; set; }
        Action<string, ILogItem[]> Callback { get; set; }

        void Log(string target, params ILogItem[] logItems);
    }

    [Flags]
    public enum TraceLevel
    {
        L0 = 0x0000,
        L1 = 0x0001,
        L2 = L1 | 0x0010,
        L3 = L2 | 0x0100,
        L4 = L3 | 0x1000,
    } 
}
