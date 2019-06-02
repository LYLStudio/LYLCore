using System;

namespace LYLStudio.Core.Threading
{
    public interface IAnything<T>
    {
        Action<T> Callback { get; }
        T Parameters { get; }
    }
}
