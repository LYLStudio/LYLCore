using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface ICreateAsync
    {
        Task<IResult> CreateAsync<T>(params T[] entities) where T : class;
    }
}
