using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public interface IResult
    {
        Guid Id { get; }

        bool IsSuccess { get; set; }

        string StatusCode { get; set; }

        string Message { get; set; }

        Exception Error { get; set; }

        IList<IResult> InnerResults { get; }
    }

    public interface IResult<T> : IResult
    {
        T Payload { get; set; }
    }   
}
