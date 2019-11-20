namespace LStudio.Core.Data.EF
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public interface ICommittable
    {
        /// <summary>
        /// Commit by customize callback function
        /// </summary>
        /// <param name="callback"></param>
        void Commit(Action callback);
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="callback"></param>
        /// <param name="dbContexts"></param>
        void Commit<TContext>(Action callback, params TContext[] dbContexts) where TContext : DbContext;
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="callback"></param>
        /// <param name="dbContexts"></param>
        void CommitAsync<TContext>(Task<Action> callback, params TContext[] dbContexts) where TContext : DbContext;
    }
}
