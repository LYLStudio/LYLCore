namespace LStudio.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using LStudio.Core.Data.EF;


    public class DataServiceManager : IDataServiceManager
    {
        private Dictionary<string, Repository<DbContext>> RepositoryList { get; set; }

        public Action<string> DbLog { get; set; }

        public DataServiceManager()
        {
            RepositoryList = new Dictionary<string, Repository<DbContext>>();
        }

        public void AddDbContext(params IDbContextFactory[] factories)
        {
            if (factories is null) throw new ArgumentNullException(nameof(factories));

            factories.ToList().ForEach(o =>
            {
                RepositoryList.Add(o.Id, new Repository<DbContext>(o)
                {
                    Log = DbLog
                });
            });
        }

        public IRepository<DbContext> GetContext(string name)
        {            
            RepositoryList.TryGetValue(name, out Repository<DbContext> repo);            
            return repo;
        }

        public void Commit(Action callback)
        {
            callback?.Invoke();
        }

        public void Commit<TContext>(Action callback, params TContext[] dbContexts) where TContext : DbContext
        {
            callback?.Invoke();

            foreach (var item in dbContexts)
            {
                item.SaveChanges();
            }
        }

        public void CommitAsync<TContext>(Task<Action> callback, params TContext[] dbContexts) where TContext : DbContext
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in RepositoryList.Values)
                    {
                        item?.Dispose();
                    }
                    RepositoryList?.Clear();
                    RepositoryList = null;
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }      
        #endregion
    }
}
