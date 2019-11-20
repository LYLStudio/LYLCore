namespace LStudio.Core
{
    using System;

    public class BaseEventArgs : EventArgs
    {
        public DateTime EventTime { get; }

        public IResult EventResult { get; set; }

        public bool HasError { get { return EventResult?.ResultException != null; } }

        public BaseEventArgs()
        {
            EventTime = DateTime.Now;
        }

        public BaseEventArgs(IResult result) : this()
        {
            EventResult = result;
        }
    }

    public class BaseEventArgs<TResult, T> : EventArgs
        where TResult : ResultBase<T>
    {
        public DateTime EventTime { get; }

        public TResult EventResult { get; set; }

        public bool HasError { get { return EventResult?.ResultException != null; } }

        public BaseEventArgs()
        {
            EventTime = DateTime.Now;
        }

        public BaseEventArgs(TResult result) : this()
        {
            EventResult = result;
        }
    }
}