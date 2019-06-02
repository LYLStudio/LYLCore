namespace LYLStudio.Core.Data
{
    public interface IUpdate<TResult>
        where TResult : IResult, new()
    {
        TResult Update<T>(T entity) where T : class;
    }
}
