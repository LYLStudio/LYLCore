using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public class ResultBase : IResult
    {
        public Guid Id { get; }
        public string Message { get; set; }
        public Exception Error { get; set; }
        public bool IsSuccess { get; set; }
        public object Payload { get; set; }
        public IList<IResult> InnerResults { get; }

        public ResultBase() : this(false)
        {

        }

        public ResultBase(bool isSuccess)
        {
            Id = Guid.NewGuid();
            IsSuccess = isSuccess;
            InnerResults = new List<IResult>();
        }
    }
}
