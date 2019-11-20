namespace LStudio.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IFatch
    {
        T Fetch<T>(params object[] keyValues) where T : class;
        T Fetch<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> FetchList<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> FetchAll<T>() where T : class;
    }
}
