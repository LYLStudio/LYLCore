namespace LStudio.Core.Data
{
    using System;
    using System.Linq.Expressions;

    public interface IExist
    {
        bool IsExist<T>(params object[] keyValues) where T : class;
        bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
