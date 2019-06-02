using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IExistAsync
    {
        Task<bool> IsExistAsync<T>(params object[] keyValues) where T : class;
        Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
