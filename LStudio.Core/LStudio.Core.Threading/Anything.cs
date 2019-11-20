namespace LStudio.Core.Threading
{
    using System;

    public class Anything<T> : IAnything<T>
    {
        public T Parameter { get; set; }
        public Action<T> Callback { get; set; }
        
        public Anything()
        {

        }

        public Anything(T parameter) : this()
        {
            Parameter = parameter;
        }

        public Anything(T parameter, Action<T> callback) : this(parameter)
        {
            Callback = callback;
        }      
    }

    public class Anything<T, TResult> : IAnything<T, TResult>
    {
        public T Parameter { get; set; }
        public Func<T, TResult> Callback { get; set; }

        public Anything()
        {

        }

        public Anything(T parameter) : this()
        {
            Parameter = parameter;
        }

        public Anything(T parameter, Func<T, TResult> callback): this(parameter)
        {
            Callback = callback;
        }
    }
}
