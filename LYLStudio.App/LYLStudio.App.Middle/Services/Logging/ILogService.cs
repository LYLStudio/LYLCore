using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services.Logging
{
    public interface ILogService : ILogServiceBase<LogItem>
    {
    }  

    public class LogItem : ILogItemBase
    {
        public DateTime Time { get; }
        public Guid Id { get; }
        public CategoryTypeEnum Category { get; set; }
        public PriorityTypeEnum Priority { get; set; }
        public string Message { get; set; }

        public LogItem(CategoryTypeEnum category = CategoryTypeEnum.Info, PriorityTypeEnum priority = PriorityTypeEnum.None)
        {
            Time = DateTime.Now;
            Id = Guid.NewGuid();
            Category = category;
            Priority = priority;
        }
    }
}
