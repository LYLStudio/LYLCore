using System.Collections.Generic;

namespace LStudio.Core.Threading
{
    public interface IDistributeOperator<T> : IOperator<T>
    {
        IDictionary<int, IOperator<T>> SequenceOperators { get; }

        void Initialize(int threadCount = 2);        
    }
}
