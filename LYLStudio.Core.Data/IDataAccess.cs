namespace LYLStudio.Core.Data
{
    public interface IDataAccess<TResult> 
        : ICreate<TResult>, IFatch, IUpdate<TResult>, IDelete<TResult>, IExist
        where TResult : IResult, new()
    {
    }
}
