using System;

namespace LYLStudio.Core.Logging
{
    public interface ILogItem
    {
        DateTime Time { get; }
        Guid Id { get; set; }
        Category Category { get; set; }
        Priority Priority { get; set; }
        string Message { get; set; }
        Exception Error { get; set; }
    }

    public enum Category
    {
        Debug = 0x0001,
        Exception = 0x0010,
        Warn = 0x0100,
        Info = 0x1000,
    }

    public enum Priority
    {
        None = 0,
        Low,
        Medium,
        High
    }
}
