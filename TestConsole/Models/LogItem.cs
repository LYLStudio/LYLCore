using System;

using LYLStudio.Core.Logging;

namespace TestConsole.Models
{
    public class LogItem : ILogItem
    {
        public DateTime Time { get; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public string Message { get; set; }

        public LogItem(string message, Category category = Category.Debug, Priority priority = Priority.Low)
        {
            Time = DateTime.Now;
            Category = category;
            Priority = priority;
            Message = message;
        }
    }
}
