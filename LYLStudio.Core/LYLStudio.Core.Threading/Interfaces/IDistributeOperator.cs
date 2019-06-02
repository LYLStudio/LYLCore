using System.Collections.Generic;

namespace LYLStudio.Core.Threading
{
    public interface IDistributeOperator<T> : IOperator<T>
    {
        IDictionary<int, IOperator<T>> SequenceOperators { get; }

        void Initialize(int threadCount = 2);
    }
}
