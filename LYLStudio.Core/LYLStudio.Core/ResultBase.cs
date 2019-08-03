using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public class ResultBase<T> : IResult<T>
    {     
        public Guid Id { get; }
        public bool IsSuccess { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
        public IList<IResult> InnerResults { get; }
        public T Payload { get; set; }

        public ResultBase() : this(false)
        {

        }

        public ResultBase(bool isSuccess)
        {
            Id = Guid.NewGuid();
            IsSuccess = isSuccess;
            InnerResults = (IList<IResult>)new List<ResultBase<T>>();
        }
    }
}
