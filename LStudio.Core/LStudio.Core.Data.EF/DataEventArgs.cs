namespace LStudio.Core.Data.EF
{
    public class DataEventArgs : BaseEventArgs
    {
        public DataEventArgs() : base()
        {

        }

        public DataEventArgs(IResult result) : base(result)
        {

        }
    }
}
