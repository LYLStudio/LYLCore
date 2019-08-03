namespace LYLStudio.Core.Data
{
    public interface IDataAccessAsync
        : ICreateAsync, IFatchAsync, IUpdateAsync, IDeleteAsync, IExistAsync, ISaveAsync        
    {
    }
}
