using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface ISaveAsync
    {
        Task<int> SaveAsync();
    }
}
