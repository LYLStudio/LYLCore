using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.Core
{
    public interface IResult
    {
        Guid Id { get; }

        bool IsSuccess { get; set; }

        string Message { get; set; }

        Exception Error { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T Payload { get; set; }

        IList<IResult<T>> InnerResults { get; }
    }   
}
