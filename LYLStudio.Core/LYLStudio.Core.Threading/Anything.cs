using System;

namespace LYLStudio.Core.Threading
{
    public class Anything<T> : IAnything<T>
    {
        public T Parameters { get; set; }
        public Action<T> AnythingAction { get; set; }
        
        public Anything()
        {

        }

        public Anything(T parameters) : this()
        {
            Parameters = parameters;
        }

        public Anything(T parameters, Action<T> action) : this(parameters)
        {
            AnythingAction = action;
        }      
    }

    public class Anything<T, IResult> : IAnything<T, IResult>
    {
        public T Parameters { get; set; }
        public Func<T, IResult> AnythingFunc { get; set; }

        public Anything()
        {

        }

        public Anything(T parameters) : this()
        {
            Parameters = parameters;
        }

        public Anything(T parameters, Func<T, IResult> func): this(parameters)
        {
            AnythingFunc = func;
        }
    }
}
