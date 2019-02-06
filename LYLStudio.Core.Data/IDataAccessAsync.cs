using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.Core.Data
{
    public interface IDataAccessAsync<TResult> 
        :ICreateAsync<TResult>, IFatchAsync, IUpdateAsync<TResult>, IDeleteAsync<TResult>, IExistAsync
        where TResult : IResult, new()
    {

    }
}
