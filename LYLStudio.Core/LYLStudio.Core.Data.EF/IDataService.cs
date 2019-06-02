using System;

namespace LYLStudio.Core.Data.EF
{
    public interface IDataService<TResult, TContext> : IDisposable, IDataAccess<TResult>, IDataAccessAsync<TResult>
        where TResult : IResult, new()
    {
        TContext Context { get; }

        Action<string> Log { get; set; }

        event EventHandler<DataEventArgs> DataServiceEventOccurred;
    }
}
