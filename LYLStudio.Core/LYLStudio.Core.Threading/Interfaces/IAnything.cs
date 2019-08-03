using System;

namespace LYLStudio.Core.Threading
{
    public interface IAnything<T>
    {
        T Parameters { get; }
        Action<T> AnythingAction { get; }        
    }

    public interface IAnything<T, IResult>
    {
        T Parameters { get; set; }
        Func<T, IResult> AnythingFunc { get; }
    }
}
