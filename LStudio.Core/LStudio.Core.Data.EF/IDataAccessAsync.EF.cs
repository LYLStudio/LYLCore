using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LStudio.Core.Data.EF
{
    public interface IDataAccessAsync : IFatchAsync, IExistAsync, ISaveAsync
    {

    }
}
