namespace LStudio.Core.Logging
{
    using System;

    public interface ILogItem
    {
        DateTime Time { get; }
        Guid Id { get; set; }
        Category Category { get; set; }
        Priority Priority { get; set; }
        string Message { get; set; }        
    }

    public enum Category
    {
        Debug,
        Exception,
        Warn,
        Info
    }

    public enum Priority
    {
        None = 0,
        Low,
        Medium,
        High
    }
}
