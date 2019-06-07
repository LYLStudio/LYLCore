using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IDeleteAsync<TResult> where TResult : IResult, new()
    {
        Task<TResult> DeleteByKeyAsync<T>(params object[] keyValues) where T : class;
        Task<TResult> DeleteAsync<T>(params T[] entities) where T : class;
        Task<TResult> DeleteAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}
