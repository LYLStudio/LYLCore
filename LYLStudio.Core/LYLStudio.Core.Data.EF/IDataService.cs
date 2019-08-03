using System;

namespace LYLStudio.Core.Data.EF
{
    public interface IDataService<TContext> : IDisposable, IDataAccess, IDataAccessAsync        
    {
        TContext Context { get; }

        Action<string> Log { get; set; }

        event EventHandler<DataEventArgs> DataServiceEventOccurred;
    }
}
