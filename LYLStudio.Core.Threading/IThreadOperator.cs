using System;
using System.Threading;

namespace LYLStudio.Core.Threading
{
    public interface IThreadOperator<T>
    {
        string Id { get; }

        ThreadPriority Priority { get; }

        int Sleep { get; set; }

        event EventHandler<OperatorEventArgs> OperationOccurred;

        void Enqueue(IAnything<T> anything, ThreadPriority priority = ThreadPriority.Normal);

        void Stop();
    }
}
