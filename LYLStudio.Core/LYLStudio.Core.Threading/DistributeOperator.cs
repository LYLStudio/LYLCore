namespace LYLStudio.Core.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class DistributeOperator<T> : IDistributeOperator<T>
    {
        private int _distributeNumber;

        public IDictionary<int, IOperator<T>> SequenceOperators { get; protected set; }
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
            if (SequenceOperators == null || SequenceOperators.Count == 0) throw new ArgumentNullException(nameof(SequenceOperators));

            _distributeNumber = ++_distributeNumber % SequenceOperators.Count;
            SequenceOperators[_distributeNumber].Enqueue(anything, priority);
        }

        public void Stop()
        {
            if (SequenceOperators == null || SequenceOperators.Count == 0) throw new ArgumentNullException(nameof(SequenceOperators));
            foreach (var item in SequenceOperators)
            {
                item.Value.OperationOccurred -= SequenceOperator_OperationOccurred;
                item.Value.Stop();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stop();
                    SequenceOperators?.Clear();
                }

                disposedValue = true;
            }
        }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
