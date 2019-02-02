using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IFatchAsync<TResult>
        where TResult : IResult, new()
    {
        Task<TResult> FetchAsync<T>(params object[] keyValues) where T : class;
        Task<TResult> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<TResult> FetchListAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<TResult> FetchAllAsync<T>() where T : class;
    }
}
