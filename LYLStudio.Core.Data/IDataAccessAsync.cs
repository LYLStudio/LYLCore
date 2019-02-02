using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IDataAccessAsync<TResult> 
        : ICreateAsync<TResult>, IFatchAsync<TResult>, IUpdateAsync<TResult>, IDeleteAsync<TResult>, IExistAsync<TResult>
        where TResult : IResult, new()
    {

    }
}
