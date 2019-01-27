using System;

namespace LYLStudio.Core.Threading
{
    public class OperatorEventArgs : EventArgsBase
    {
        public OperatorEventArgs() : base()
        {
            
        }

        public OperatorEventArgs(IResult result) : base(result)
        {            
        }
    }
}
