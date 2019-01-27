using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public class Result : IResult<object>
    {
        public Guid Id { get; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
        public object Payload { get; set; }
        public IList<IResult<object>> InnerResults { get; }

        public Result() : this(false)
        {

        }

        public Result(bool isSuccess)
        {
            Id = Guid.NewGuid();
            IsSuccess = isSuccess;
            InnerResults = new List<IResult<object>>();
        }
    }
}
