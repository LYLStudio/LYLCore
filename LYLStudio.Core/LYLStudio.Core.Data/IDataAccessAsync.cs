namespace LYLStudio.Core.Data
{
    public interface IDataAccessAsync<TResult>
        : ICreateAsync<TResult>, IFatchAsync, IUpdateAsync<TResult>, IDeleteAsync<TResult>, IExistAsync, ISaveAsync
        where TResult : IResult, new()
    {

    }
}
