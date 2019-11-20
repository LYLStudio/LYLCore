namespace LStudio.Core
{
    using System;

    public interface IAnything<T>
    {
        T Parameter { get; }
        Action<T> Callback { get; }
    }

    public interface IAnything<T, TResult>
    {
        T Parameter { get; set; }
        Func<T, TResult> Callback { get; }
    }
}
