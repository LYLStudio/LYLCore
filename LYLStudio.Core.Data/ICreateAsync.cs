using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface ICreateAsync<TResult> 
        where TResult : IResult, new()
    {
        Task<TResult> CreateAsync<T>(params T[] entities) where T : class;
    }
}
