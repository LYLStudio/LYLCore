namespace LYLStudio.Core
{
    using System;

    public interface IAnything<T>
    {
        T Parameter { get; }
        Action<T> Callback { get; }
    }

    public interface IAnything<T, IResult>
    {
        T Parameter { get; set; }
        Func<T, IResult> Callback { get; }
    }
}
