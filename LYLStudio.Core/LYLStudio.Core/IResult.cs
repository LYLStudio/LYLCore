using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public interface IResult
    {
        Guid Id { get; }

        string Message { get; set; }

        Exception Error { get; set; }

        bool IsSuccess { get; set; }

        object Payload { get; set; }

        IList<IResult> InnerResults { get; }
    }

    //public interface IResult<T> : IResult
    //{
    //    bool IsSuccess { get; set; }

    //    T Payload { get; set; }

    //    IList<IResult<T>> InnerResults { get; }
    //}   
}
