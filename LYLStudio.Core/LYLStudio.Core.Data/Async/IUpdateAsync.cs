using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IUpdateAsync
    {
        Task<IResult> UpdateAsync<T>(T entity) where T : class;
    }
}
