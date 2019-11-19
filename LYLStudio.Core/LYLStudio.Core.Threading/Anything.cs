namespace LYLStudio.Core.Threading
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

    public class Anything<T, IResult> : IAnything<T, IResult>
    {
        public T Parameter { get; set; }
        public Func<T, IResult> Callback { get; set; }

        public Anything()
        {

        }

        public Anything(T parameter) : this()
        {
            Parameter = parameter;
        }

        public Anything(T parameter, Func<T, IResult> callback): this(parameter)
        {
            Callback = callback;
        }
    }
}
