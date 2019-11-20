namespace LYLStudio.Core.Threading
{
    using System;
    using System.Threading;

    public interface IOperator<T> : IDisposable
    {
        string Id { get; }

        ThreadPriority Priority { get; }

        int Sleep { get; set; }

        event EventHandler<OperatorEventArgs> OperationOccurred;

        void Enqueue(IAnything<T> anything, ThreadPriority priority = ThreadPriority.Normal);

        void Stop();
    }
}
