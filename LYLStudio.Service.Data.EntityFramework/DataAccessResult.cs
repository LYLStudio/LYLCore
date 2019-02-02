using LYLStudio.Core;

namespace LYLStudio.Service.Data.EntityFramework
{
    public class DataAccessResult : ResultBase
    {
        public DataAccessResult() : base()
        {

        }

        public DataAccessResult(bool isSuccess) : base(isSuccess)
        {

        }
    }
}
