namespace LYLStudio.Core.Data.EF
{
    public class DataEventArgs : EventArgsBase
    {
        public DataEventArgs() : base()
        {

        }

        public DataEventArgs(IResult result) : base(result)
        {

        }
    }
}
