namespace LStudio.Core.Data
{
    using System;
    using System.Linq.Expressions;

    public interface IDelete
    {
        IResult DeleteByKey<T>(params object[] keyValues) where T : class;
        IResult Delete<T>(params T[] entities) where T : class;
        IResult Delete<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}
