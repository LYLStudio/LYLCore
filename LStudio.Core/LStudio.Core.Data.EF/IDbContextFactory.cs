using System.Data.Entity;

namespace LStudio.Core.Data.EF
{
    public interface IDbContextFactory
    {
        string Id { get; }

        DbContext GetContext();
    }
}
