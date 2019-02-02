using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IExistAsync<TResult>
        where TResult : IResult, new()
    {
        Task<TResult> IsExistAsync<T>(params object[] keyValues) where T : class;
        Task<TResult> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
