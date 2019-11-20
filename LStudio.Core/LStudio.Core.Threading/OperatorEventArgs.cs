namespace LStudio.Core.Threading
{
    public class OperatorEventArgs : BaseEventArgs
    {
        public OperatorEventArgs() : base()
        {

        }

        public OperatorEventArgs(IResult result) : base(result)
        {
        }
    }
}
