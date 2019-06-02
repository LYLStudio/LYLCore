namespace LYLStudio.Core.Data
{
    public interface ICreate<TResult> 
        where TResult : IResult, new()
    {        
        TResult Create<T>(params T[] entities) where T : class;
    }
}
