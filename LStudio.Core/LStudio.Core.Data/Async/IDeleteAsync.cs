namespace LStudio.Core.Data
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IDeleteAsync
    {
        Task<IResult> DeleteByKeyAsync<T>(params object[] keyValues) where T : class;
        Task<IResult> DeleteAsync<T>(params T[] entities) where T : class;
        Task<IResult> DeleteAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}
