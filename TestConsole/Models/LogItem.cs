using System;

using LYLStudio.Core.Logging;

namespace TestConsole.Models
{
    public class LogItem : ILogItem
    {
        public long TimeTicks { get; }
        public DateTime Time { get { return new DateTime(TimeTicks, DateTimeKind.Utc).ToLocalTime(); } }
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public LogItem(string message, Category category = Category.Debug, Priority priority = Priority.Low)
        {
            TimeTicks = DateTime.UtcNow.Ticks;
            Id = Guid.NewGuid();
            Category = category;
            Priority = priority;
            Message = message;
        }

    }
}
