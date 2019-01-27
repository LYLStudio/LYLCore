using System;

namespace LYLStudio.Core
{
    public class EventArgsBase : EventArgs
    {
        /// <summary>
        /// UTC Time
        /// </summary>
        public DateTime EventTime { get; }

        public IResult EventResult { get; set; }

        public bool HasError { get { return EventResult?.Error != null; } }

        public EventArgsBase()
        {
            EventTime = DateTime.UtcNow;            
        }

        public EventArgsBase(IResult result) : this()
        {
            EventResult = result;
        }     
    }
}
