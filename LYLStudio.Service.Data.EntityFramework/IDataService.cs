using System;

using LYLStudio.Core;
using LYLStudio.Core.Data;

namespace LYLStudio.Service.Data.EntityFramework
{
    public interface IDataService<TResult, TContext> : IDisposable, IDataAccess<TResult>, IDataAccessAsync<TResult>
        where TResult : IResult, new()
    {
        TContext Context { get; }
        
        Action<string> Log { get; set; }

        event EventHandler<DataEventArgs> DataServiceEventOccurred;
    }
}
