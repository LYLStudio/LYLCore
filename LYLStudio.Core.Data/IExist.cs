using System;
using System.Linq.Expressions;

namespace LYLStudio.Core.Data
{
    public interface IExist<TResult>
        where TResult : IResult, new()
    {
        TResult IsExist<T>(params object[] keyValues) where T : class;
        TResult IsExist<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
