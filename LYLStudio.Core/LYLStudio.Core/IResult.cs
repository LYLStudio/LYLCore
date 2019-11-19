using System;
using System.Collections.Generic;

namespace LYLStudio.Core
{
    public interface IResult
    {
        string Id { get; }

        string ParentId { get; }

        bool IsSuccess { get; set; }

        string StatusCode { get; set; }

        string Message { get; set; }

        Exception Error { get; set; }

        IEnumerable<IResult> InnerResults { get; }
    }

    public interface IResult<T> : IResult
    {
        T Payload { get; set; }
    }
}

namespace LYLStudio.Core
{
    public class ResultBase<T> : IResult<T>
    {
        public string Id { get; }
        public string ParentId { get; }
        public bool IsSuccess { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }
        public Exception Error { get; set; }
        public IEnumerable<IResult> InnerResults { get; }

        protected virtual Func<string> GenIdFunc { get; }

        public ResultBase() : this(false)
        {
        }

        public ResultBase(bool isSuccess, string parentId = "")
        {
            Id = GenIdFunc == null ? Guid.NewGuid().ToString() : GenIdFunc.Invoke();
            ParentId = parentId;
            IsSuccess = isSuccess;
            StatusCode = string.Empty;
            Message = string.Empty;
            InnerResults = new List<IResult>();
        }
    }

    public class SampleResult : ResultBase<object>
    {
        protected override Func<string> GenIdFunc => GenId;

        public SampleResult(bool isSuccess = false, string parentId = "") : base(isSuccess, parentId)
        {
        }

        private string GenId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}