using System;
using System.Collections.Generic;
using System.Threading;

namespace LYLStudio.Core.Threading
{
    public class DistributeOperator<T> : IDistributeOperator<T>
    {
        private int _distributeNumber;

        public IDictionary<int, ISequenceOperator<T>> SequenceOperators { get; protected set; }
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
            SequenceOperators = new Dictionary<int, ISequenceOperator<T>>(threadCount);
            for (int i = 0; i < threadCount; i++)
            {
                ISequenceOperator<T> sequenceOperator = new SequenceOperator<T>($"{Id}{i}", Priority, Sleep);
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

            SequenceOperators.Clear();
        }
    }
}
