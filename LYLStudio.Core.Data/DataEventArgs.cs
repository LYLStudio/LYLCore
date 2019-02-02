using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
