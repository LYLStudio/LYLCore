namespace LStudio.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<TContext> : IRepository<TContext>
        where TContext : DbContext
    {
        public TContext Context { get; }

        public Action<string> Log { get => Context.Database.Log; set => Context.Database.Log = value; }

        public event EventHandler<DataEventArgs> DataServiceEventOccurred;

        public Repository(IDbContextFactory contextFactory)
        {
            if (contextFactory is null) throw new ArgumentNullException(nameof(contextFactory));

            Context = contextFactory.GetContext() as TContext;
        }

        protected virtual void OnDataServiceEventOccurred(object sender, DataEventArgs eventArgs)
        {
            DataServiceEventOccurred?.Invoke(sender, eventArgs);
        }        

        public virtual IResult Create<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            IResult result = new DataAccessResult<T>();

            try
            {
                Context.Set<T>().AddRange(entities);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual IResult DeleteByKey<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            IResult result = new DataAccessResult<T>();

            try
            {
                T obj = Context.Set<T>().Find(keyValues);
                if (obj != null)
                {
                    (result as DataAccessResult<T>).Payload = Context.Set<T>().Remove(obj);
                    result.IsSuccess = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual IResult Delete<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            IResult result = new DataAccessResult<T>();

            try
            {
                Context.Set<T>().RemoveRange(entities);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual IResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            IResult result = new DataAccessResult<T>();

            try
            {
                var dbSet = Context.Set<T>();
                dbSet.RemoveRange(dbSet.Where(predicate));
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual T Fetch<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return Context.Set<T>().Find(keyValues);
        }

        public virtual T Fetch<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> FetchList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return Context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> FetchAll<T>() where T : class
        {
            return Context.Set<T>().AsQueryable();
        }

        public virtual IResult Update<T>(T entity) where T : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            IResult result = new DataAccessResult<T>();

            try
            {
                var state = Context.Entry(entity).State = EntityState.Modified;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual bool IsExist<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return Context.Set<T>().Find(keyValues) != null;
        }

        public virtual bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return Context.Set<T>().FirstOrDefault() != null;
        }

        public virtual async Task<T> FetchAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return await (Context.Set<T>().FindAsync(keyValues)).ConfigureAwait(false);
        }

        public virtual async Task<T> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await (Context.Set<T>().FirstOrDefaultAsync()).ConfigureAwait(false);
        }

        public virtual async Task<IResult> DeleteByKeyAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            IResult result = new DataAccessResult<T>();

            try
            {
                T obj = await (Context.Set<T>().FindAsync(keyValues)).ConfigureAwait(false);
                if (obj != null)
                {
                    Context.Set<T>().Remove(obj);
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.ResultException = ex;
            }

            return result;
        }

        public virtual async Task<bool> IsExistAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return await Context.Set<T>().FindAsync(keyValues).ConfigureAwait(false) != null;
        }

        public virtual async Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await Context.Set<T>().FirstOrDefaultAsync().ConfigureAwait(false) != null;
        }

        public virtual IResult Save()
        {
            var result = new DataAccessResult<int>();

            try
            {
                result.Payload = Context.SaveChanges();
                result.IsSuccess = result.IsSaveChanged = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (DbEntityValidationException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (NotSupportedException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }

            return result;
        }

        public async Task<IResult> SaveAsync()
        {
            var result = new DataAccessResult<int>();

            try
            {
                result.Payload = await Context.SaveChangesAsync().ConfigureAwait(false);
                result.IsSuccess = result.IsSaveChanged = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (DbEntityValidationException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (NotSupportedException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return PublishExceptionInfo(ex, ex.Message);
            }

            return result;
        }

        private IResult PublishExceptionInfo<T>(T exception, string message)
        {
            var result = new DataAccessResult<T>()
            {
                Payload = exception,
                Message = message
            };

            var eventArgs = new DataEventArgs()
            {
                EventResult = result
            };

            OnDataServiceEventOccurred(this, eventArgs);

            return result;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DataServiceEventOccurred -= OnDataServiceEventOccurred;
                    Context?.Dispose();
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