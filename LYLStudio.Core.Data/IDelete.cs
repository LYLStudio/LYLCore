using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LYLStudio.Core.Data
{
    public interface IDelete<TResult>
        where TResult : IResult, new()
    {
        TResult DeleteByKey<T>(params object[] keyValues) where T : class;
        TResult Delete<T>(params T[] entities) where T : class;
        TResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}
