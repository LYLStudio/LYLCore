namespace LStudio.Core.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class DistributeOperator<T> : IDistributeOperator<T>
    {
        private int _distributeNumber;

        public IDictionary<int, IOperator<T>> SequenceOperators { get; private set; }
        public string Id { get; }
        public ThreadPriority Priority { get; }
        public int Sleep { get; set; }

        public event EventHandler<OperatorEventArgs> OperationOccurred;

        public DistributeOperator(string id, ThreadPriority priority = ThreadPriority.Normal, int sleep = 1)
        {
            _distributeNumber = -1;

            Id = id;
            Priority = priority;
            Sleep = sleep;
        }

        public void Initialize(int threadCount = 4)
        {
            SequenceOperators = new Dictionary<int, IOperator<T>>(threadCount);
            for (int i = 0; i < threadCount; i++)
            {
                IOperator<T> sequenceOperator = new SequenceOperator<T>($"{Id}{i}", Priority, Sleep);
                sequenceOperator.OperationOccurred += SequenceOperator_OperationOccurred;
                SequenceOperators.Add(i, sequenceOperator);
            }
        }

        private void SequenceOperator_OperationOccurred(object sender, OperatorEventArgs e)
        {
            OperationOccurred?.Invoke(sender, e);
        }

        public void Enqueue(IAnything<T> anything, ThreadPriority priority = ThreadPriority.Normal)
        {
            if (_disposedValue) throw new ObjectDisposedException(nameof(DistributeOperator<T>));
            if (anything is null) throw new ArgumentNullException(nameof(anything));

            _distributeNumber = ++_distributeNumber % SequenceOperators.Count;
            SequenceOperators[_distributeNumber].Enqueue(anything, priority);
        }

        private void Stop()
        {
            if (_disposedValue) throw new ObjectDisposedException(nameof(DistributeOperator<T>));

            foreach (var item in SequenceOperators)
            {
                item.Value.OperationOccurred -= SequenceOperator_OperationOccurred;
                item.Value.Dispose();
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Stop();
                    SequenceOperators?.Clear();
                    SequenceOperators = null; 
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
