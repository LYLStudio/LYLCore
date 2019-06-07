using System;
using System.Linq.Expressions;

namespace LYLStudio.Core.Data
{
    public interface IExist
    {
        bool IsExist<T>(params object[] keyValues) where T : class;
        bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
