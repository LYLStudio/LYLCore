﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public bool IsCUDBaseMethodsSaveChangesByDefault { get; private set; }

        public event EventHandler<DataEventArgs> DataServiceEventOccurred;

        protected virtual void OnDataServiceEventOccurred(object sender, DataEventArgs eventArgs)
        {
            DataServiceEventOccurred?.Invoke(sender, eventArgs);
        }

        protected DataServiceBase(bool isCUDBaseMethodsSaveChangesByDefault = false)
        {
            IsCUDBaseMethodsSaveChangesByDefault = isCUDBaseMethodsSaveChangesByDefault;
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
                result.Payload = Context.Set<T>().AddRange(entities);
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = Save() == entities.Count();
                }
            }
            catch (DbUpdateException ex)
            {
                result.Error = ex;
                result.Message = ex.Message;

                foreach (var item in ex.Entries.Select(o => (T)o.Entity))
                    result.InnerResults.Add(new TResult() { Payload = item });
            }
            catch (DbEntityValidationException ex)
            {
                result.Error = ex;
                result.Message = ex.Message;

                foreach (var item in ex.EntityValidationErrors.Select(o => o))
                    result.InnerResults.Add(new TResult() { Payload = item });
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual TResult DeleteByKey<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();

            try
            {
                T obj = Context.Set<T>().Find(keyValues);
                if (obj != null)
                {
                    result.Payload = Context.Set<T>().Remove(obj);
                    if (IsCUDBaseMethodsSaveChangesByDefault)
                    {
                        result.IsSuccess = Save() == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual TResult Delete<T>(params T[] entities) where T : class
        {
            TResult result = new TResult();

            try
            {
                result.Payload = Context.Set<T>().RemoveRange(entities);
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = Save() == entities.Count();
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual TResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            TResult result = new TResult();

            try
            {
                var dbSet = Context.Set<T>();
                var count = dbSet.Where(predicate).Count();
                result.Payload = dbSet.RemoveRange(dbSet.Where(predicate));
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = Save() == count;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual T Fetch<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();
            T entity = default;

            try
            {
                entity = Context.Set<T>().Find(keyValues);
                result.Payload = entity;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entity;
        }

        public virtual T Fetch<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            TResult result = new TResult();
            T entity = default;

            try
            {
                entity = Context.Set<T>().FirstOrDefault(predicate);
                result.Payload = entity;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entity;
        }

        public virtual IEnumerable<T> FetchList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            TResult result = new TResult();
            IQueryable<T> entities = null;

            try
            {
                entities = Context.Set<T>().Where(predicate);
                result.Payload = entities;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entities;
        }

        public virtual IEnumerable<T> FetchAll<T>() where T : class
        {
            TResult result = new TResult();
            IQueryable<T> entities = null;

            try
            {
                entities = Context.Set<T>().AsQueryable();
                result.Payload = entities;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entities;
        }

        public virtual TResult Update<T>(T entity) where T : class
        {
            TResult result = new TResult();

            try
            {
                var state = Context.Entry(entity).State = EntityState.Modified;
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = Save() == 1;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual bool IsExist<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();

            try
            {
                result.IsSuccess = Context.Set<T>().Find(keyValues) != null;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result.IsSuccess;
        }

        public virtual bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            TResult result = new TResult();

            try
            {
                result.IsSuccess = Context.Set<T>().FirstOrDefault() != null;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result.IsSuccess;
        }

        public virtual async Task<TResult> CreateAsync<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                result.Payload = Context.Set<T>().AddRange(entities);
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = await SaveAsync() == entities.Count();
                }
            }
            catch (DbUpdateException ex)
            {
                result.Error = ex;
                result.Message = ex.Message;

                foreach (var item in ex.Entries.Select(o => (T)o.Entity))
                    result.InnerResults.Add(new TResult() { Payload = item });
            }
            catch (DbEntityValidationException ex)
            {
                result.Error = ex;
                result.Message = ex.Message;

                foreach (var item in ex.EntityValidationErrors.Select(o => o))
                    result.InnerResults.Add(new TResult() { Payload = item });
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual async Task<T> FetchAsync<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();
            T entity = default;

            try
            {
                entity = await Context.Set<T>().FindAsync(keyValues);
                result.Payload = entity;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entity;
        }

        public virtual async Task<T> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            TResult result = new TResult();
            T entity = default;

            try
            {
                entity = await Context.Set<T>().FirstOrDefaultAsync();
                result.Payload = entity;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return entity;
        }

        public virtual async Task<TResult> UpdateAsync<T>(T entity) where T : class
        {
            TResult result = new TResult();

            try
            {
                var state = Context.Entry(entity).State = EntityState.Modified;
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = await SaveAsync() == 1;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteByKeyAsync<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();

            try
            {
                T obj = await Context.Set<T>().FindAsync(keyValues);
                if (obj != null)
                {
                    result.Payload = Context.Set<T>().Remove(obj);
                    if (IsCUDBaseMethodsSaveChangesByDefault)
                    {
                        result.IsSuccess = await SaveAsync() == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteAsync<T>(params T[] entities) where T : class
        {
            TResult result = new TResult();

            try
            {
                result.Payload = Context.Set<T>().RemoveRange(entities);
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = await SaveAsync() == entities.Count();
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual async Task<TResult> DeleteAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            TResult result = new TResult();

            try
            {
                var dbSet = Context.Set<T>();
                var count = await dbSet.Where(predicate).CountAsync();
                result.Payload = dbSet.RemoveRange(dbSet.Where(predicate));
                if (IsCUDBaseMethodsSaveChangesByDefault)
                {
                    result.IsSuccess = await SaveAsync() == count;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public virtual async Task<bool> IsExistAsync<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();

            try
            {
                T obj = await Context.Set<T>().FindAsync(keyValues);
                result.IsSuccess = obj != null;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result.IsSuccess;
        }

        public virtual async Task<bool> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            TResult result = new TResult();

            try
            {
                T obj = await Context.Set<T>().FirstOrDefaultAsync();
                result.IsSuccess = obj != null;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }

            return result.IsSuccess;
        }

        public virtual int Save()
        {
            return Context.SaveChanges();
        }

        public virtual Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }

}
