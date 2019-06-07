using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IFatchAsync
    {
        Task<T> FetchAsync<T>(params object[] keyValues) where T : class;
        Task<T> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
