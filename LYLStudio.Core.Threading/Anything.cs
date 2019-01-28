﻿using System;

namespace LYLStudio.Core.Threading
{
    public class Anything<T> : IAnything<T>
    {
        public Action<T> Callback { get; set; }
        public T Parameters { get; set; }

        public Anything()
        {

        }

        public Anything(T parameters) : this()
        {
            Parameters = parameters;
        }
    }
}
