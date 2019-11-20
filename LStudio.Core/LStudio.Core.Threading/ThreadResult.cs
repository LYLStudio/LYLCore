namespace LStudio.Core.Threading
{
    public class ThreadResult<T> : ResultBase<T>
    {
        public ThreadResult() : base() { }
        public ThreadResult(bool isSuccess) : base(isSuccess) { }
    }
}
