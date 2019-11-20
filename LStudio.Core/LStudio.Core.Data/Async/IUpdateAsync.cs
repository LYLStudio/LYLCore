namespace LStudio.Core.Data
{
    using System.Threading.Tasks;

    public interface IUpdateAsync
    {
        Task<IResult> UpdateAsync<T>(T entity) where T : class;
    }
}
