﻿using System;
using System.Collections.Generic;

namespace LYLStudio.Core.Threading
{
    public class ThreadResult<T> : IResult<IAnything<T>>
    {
        public IAnything<T> Payload { get; set; }
        public IList<IResult<IAnything<T>>> InnerResults { get; }
        public Guid Id { get; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public ThreadResult() : this(false)
        {

        }

        public ThreadResult(bool isSuccess)
        {
            Id = Guid.NewGuid();
            IsSuccess = isSuccess;
            InnerResults = new List<IResult<IAnything<T>>>();
        }
    }
}
