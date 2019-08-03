namespace LYLStudio.Core.Data
{
    public interface IUpdate
    {
        IResult Update<T>(T entity) where T : class;
    }
}
