namespace LYLStudio.Core
{
    using System;

    public class EventArgsBase : EventArgs
    {
        public DateTime EventTime { get; }

        public IResult EventResult { get; set; }

        public bool HasError { get { return EventResult?.Error != null; } }

        public EventArgsBase()
        {
            EventTime = DateTime.Now;
        }

        public EventArgsBase(IResult result) : this()
        {
            EventResult = result;
        }
    }

    public class EventArgsBase<TResult, T> : EventArgs
        where TResult : ResultBase<T>
    {
        public DateTime EventTime { get; }

        public TResult EventResult { get; set; }

        public bool HasError { get { return EventResult?.Error != null; } }

        public EventArgsBase()
        {
            EventTime = DateTime.Now;
        }

        public EventArgsBase(TResult result) : this()
        {
            EventResult = result;
        }
    }
}