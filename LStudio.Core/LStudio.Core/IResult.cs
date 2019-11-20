namespace LStudio.Core
{
    using System;
    using System.Collections.Generic;

    public interface IResult
    {
        string Id { get; }

        string ParentId { get; set; }

        bool IsSuccess { get; set; }

        string StatusCode { get; set; }

        string Message { get; set; }

        Exception ResultException { get; set; }

        IEnumerable<IResult> InnerResults { get; }
    }

    public interface IResult<T> : IResult
    {
        T Payload { get; set; }
    }
}

namespace LStudio.Core
{
    using System;
    using System.Collections.Generic;

    public class ResultBase<T> : IResult<T>
    {
        public string Id { get; }
        public string ParentId { get; set; }
        public bool IsSuccess { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }
        public Exception ResultException { get; set; }
        public IEnumerable<IResult> InnerResults { get; }

        protected virtual Func<string> GenIdFunc { get; }

        public ResultBase()
        {
            Id = GenIdFunc == null ? Guid.NewGuid().ToString() : GenIdFunc.Invoke();
            StatusCode = string.Empty;
            Message = string.Empty;
            InnerResults = new List<IResult>();
        }

        public ResultBase(bool isSuccess) : this()
        {
            IsSuccess = isSuccess;
        }

        public ResultBase(bool isSuccess, string parentId) : this(isSuccess)
        {
            ParentId = parentId;
        }
    }
}