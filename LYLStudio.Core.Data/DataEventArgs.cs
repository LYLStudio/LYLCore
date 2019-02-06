namespace LYLStudio.Core.Data
{
    public class DataEventArgs : EventArgsBase
    {
        public DataEventArgs() : base()
        {

        }

        public DataEventArgs(IResult result): base(result)
        {

        }
    }
}
