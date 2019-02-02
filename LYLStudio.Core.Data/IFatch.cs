using System;
using System.Linq.Expressions;

namespace LYLStudio.Core.Data
{
    public interface IFatch<TResult>
        where TResult : IResult, new()
    {
        TResult Fetch<T>(params object[] keyValues) where T : class;
        TResult Fetch<T>(Expression<Func<T, bool>> predicate) where T : class;
        TResult FetchList<T>(Expression<Func<T, bool>> predicate) where T : class;
        TResult FetchAll<T>() where T : class;
    }
}
