using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LYLStudio.Core;
using LYLStudio.Core.Data;


namespace LYLStudio.Service.Data.EntityFramework
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual TResult Create<T>(params T[] entities) where T : class
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            TResult result = new TResult();

            try
            {
                result.Payload = Context.Set<T>().AddRange(entities);
                var changes = Context.SaveChanges();

                result.IsSuccess = true;
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
            finally
            {
                OnDataServiceEventOccurred(this, new DataEventArgs(result));
            }

            return result;
        }

        public virtual TResult DeleteByKey<T>(params object[] keyValues) where T : class
        {
            TResult result = new TResult();
            
            try
            {
                T obj = Context.Set<T>().Find(keyValues);
                if(obj != null)
                {
                    result.Payload = Context.Set<T>().Remove(obj);
                    var  changed = Context.SaveChanges();
                }

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }
            finally
            {
                OnDataServiceEventOccurred(this, new DataEventArgs(result));
            }

            return result;
        }

        public virtual TResult Delete<T>(params T[] entities) where T: class
        {
            TResult result = new TResult();

            try
            {
                result.Payload = Context.Set<T>().RemoveRange(entities);
                var changed = Context.SaveChanges();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }
            finally
            {
                OnDataServiceEventOccurred(this, new DataEventArgs(result));
            }

            return result;
        }

        public virtual TResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            TResult result = new TResult();

            try
            {
                var dbSet = Context.Set<T>();
                result.Payload = dbSet.RemoveRange(dbSet.Where(predicate));
                var changed = Context.SaveChanges();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.Message = ex.Message;
            }
            finally
            {
                OnDataServiceEventOccurred(this, new DataEventArgs(result));
            }

            return result;
        }

        public virtual TResult Fetch<T>(params object[] keyValues) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult Fetch<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult FetchList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult FetchAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult IsExist<T>(params object[] keyValues) where T : class
        {
            throw new NotImplementedException();
        }

        public virtual TResult IsExist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> CreateAsync<T>(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> FetchAsync<T>(params object[] keyValues) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> FetchAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> FetchListAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> FetchAllAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> DeleteByKeyAsync<T>(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> DeleteAsync<T>(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> DeleteAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> IsExistAsync<T>(params object[] keyValues) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> IsExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
    }

}
