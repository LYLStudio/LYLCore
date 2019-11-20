namespace LStudio.Core.Data.EF
{
    public class DataAccessResult<T> : ResultBase<T>
    {
        public bool IsSaveChanged { get; set; }

        public DataAccessResult() : base()
        {

        }

        public DataAccessResult(bool isSuccess) : base(isSuccess)
        {

        }
    }
}
