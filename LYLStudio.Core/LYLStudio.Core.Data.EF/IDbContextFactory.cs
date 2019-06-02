using System.Data.Entity;

namespace LYLStudio.Core.Data.EF
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
