using System.Collections.Generic;

namespace LYLStudio.Core.Threading
{
    public interface IDistributeOperator<T> : ISequenceOperator<T>
    {
        IDictionary<int, ISequenceOperator<T>> SequenceOperators { get; }

        void Initialize(int threadCount = 2);
    }
}
