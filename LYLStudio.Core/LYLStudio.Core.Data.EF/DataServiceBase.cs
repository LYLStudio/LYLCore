using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data.EF
{
    public abstract class DataServiceBase<TResult, TContext> : IDataService<TResult, TContext>
    where TResult : IResult, new()
    where TContext : DbContext
    {
        public abstract TContext Context { get; }
        public abstract Action<string> Log { get; set; }

        public event EventHandler<DataEventArgs> DataServiceEventOccurred;
        protected virtual void OnDataServiceEventOccurred(object sender, DataEventArgs eventArgs)
        {
            DataServiceEventOccurred?.Invoke(sender, eventArgs);
        }

        protected DataServiceBase()
        {
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

                // TODO: 釋放非受控資源 (非受控物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public virtual TResult Create<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                Context.Set<T>().AddRange(entities);
                Save();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual TResult DeleteByKey<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            TResult result = new TResult();

            try
            {
                T obj = Context.Set<T>().Find(keyValues);
                if (obj != null)
                {
                    result.Payload = Context.Set<T>().Remove(obj);
                    Save();
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual TResult Delete<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                Context.Set<T>().RemoveRange(entities);
                Save();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual TResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            TResult result = new TResult();

            try
            {
                var dbSet = Context.Set<T>();
                dbSet.RemoveRange(dbSet.Where(predicate));
                Save();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
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

        public virtual TResult Update<T>(T entity) where T : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            TResult result = new TResult();

            try
            {
                var state = Context.Entry(entity).State = EntityState.Modified;
                Save();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
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

        public virtual async Task<TResult> CreateAsync<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                Context.Set<T>().AddRange(entities);
                await SaveAsync();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual async Task<T> FetchAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return await Context.Set<T>().FindAsync(keyValues);
        }

        public virtual async Task<T> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await Context.Set<T>().FirstOrDefaultAsync();
        }

        public virtual async Task<TResult> UpdateAsync<T>(T entity) where T : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            TResult result = new TResult();

            try
            {
                var state = Context.Entry(entity).State = EntityState.Modified;
                await SaveAsync();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteByKeyAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            TResult result = new TResult();

            try
            {
                T obj = await Context.Set<T>().FindAsync(keyValues);
                if (obj != null)
                {
                    Context.Set<T>().Remove(obj);
                    await SaveAsync();
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteAsync<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                Context.Set<T>().RemoveRange(entities);
                await SaveAsync();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            TResult result = new TResult();

            try
            {
                var dbSet = Context.Set<T>();
                dbSet.RemoveRange(dbSet.Where(predicate));
                await SaveAsync();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        public virtual async Task<bool> IsExistAsync<T>(params object[] keyValues) where T : class
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            return await Context.Set<T>().FindAsync(keyValues) != null;
        }

        public virtual async Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await Context.Set<T>().FirstOrDefaultAsync() != null;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}