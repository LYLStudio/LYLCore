using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test20200502.Simulator.Models
{
    public class Message
    {
        public Header Head { get; set; }
        public Rq Request { get; set; }
        public Rs Response { get; set; }

        public OperationHistories Histories { get; set; }

        public Message()
        {
            Histories = new OperationHistories();
        }

        public class Header
        {
            public Consumer Consumer { get; set; }
            public string TicketId { get; set; }
            public string ServerToken { get; set; }
        }
        public class Consumer
        {
            public string Id { get; set; }
            public string IP { get; set; }
        }
        public class Rq
        {
            public DateTime Time { get; set; }
            public string Cmd { get; set; }
            public string Parameter { get; set; }
        }

        public class Rs
        {
            public DateTime? Time { get; set; }
            public string Result { get; set; }
        }

        public class OperationHistories : List<LogItem>
        {
        }
    }

}
