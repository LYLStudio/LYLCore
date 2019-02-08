using System.Data.Entity;

namespace LYLStudio.Service.Data.EntityFramework
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
