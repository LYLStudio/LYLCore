namespace LStudio.Core.Data
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IExistAsync
    {
        Task<bool> IsExistAsync<T>(params object[] keyValues) where T : class;
        Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
