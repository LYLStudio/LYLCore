namespace LYLStudio.Core.Data
{
    public interface IDataAccess<TResult> 
        : ICreate<TResult>, IFatch<TResult>, IUpdate<TResult>, IDelete<TResult>, IExist<TResult>
        where TResult : IResult, new()
    {
    }
}
