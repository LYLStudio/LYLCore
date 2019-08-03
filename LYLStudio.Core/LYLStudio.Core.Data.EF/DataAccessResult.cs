namespace LYLStudio.Core.Data.EF
{
    public class DataAccessResult<T> : ResultBase<T>
    {
        public DataAccessResult() : base()
        {

        }

        public DataAccessResult(bool isSuccess) : base(isSuccess)
        {

        }
    }
}
