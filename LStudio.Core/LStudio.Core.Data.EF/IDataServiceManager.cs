namespace LStudio.Core.Data.EF
{
    using System;

    public interface IDataServiceManager : IDisposable, ICommittable
    {
        Action<string> DbLog { get; set; }

        void AddDbContext(params IDbContextFactory[] factories);
    }
}
