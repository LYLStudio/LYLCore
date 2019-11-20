namespace LStudio.Core.Data.EF
{
    using System;

    public interface IRepository<TContext> : IDisposable, IDataAccess, IDataAccessAsync
    {
        TContext Context { get; }

        Action<string> Log { get; set; }

        event EventHandler<DataEventArgs> DataServiceEventOccurred;
    }
}
