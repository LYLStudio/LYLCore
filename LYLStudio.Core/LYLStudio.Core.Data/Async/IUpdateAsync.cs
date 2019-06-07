using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IUpdateAsync<TResult>
        where TResult : IResult, new()
    {
        Task<TResult> UpdateAsync<T>(T entity) where T : class;
    }
}
