namespace LYLStudio.Core.Data
{
    public interface ICreate       
    {
        IResult Create<T>(params T[] entities) where T : class;
    }
}
