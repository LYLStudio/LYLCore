namespace LYLStudio.Core.Data
{
    public interface IDataAccessAsync<TResult> 
        :ICreateAsync<TResult>, IFatchAsync, IUpdateAsync<TResult>, IDeleteAsync<TResult>, IExistAsync
        where TResult : IResult, new()
    {

    }
}
