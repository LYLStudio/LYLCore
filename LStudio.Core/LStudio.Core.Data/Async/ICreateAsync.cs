namespace LStudio.Core.Data
{
    using System.Threading.Tasks;

    public interface ICreateAsync
    {
        Task<IResult> CreateAsync<T>(params T[] entities) where T : class;
    }
}
