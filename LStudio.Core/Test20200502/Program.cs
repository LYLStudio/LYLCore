using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Test20200502.Simulator;

namespace Test20200502
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Simulator.Program().Main();

            //var e = new Entrance();
            //var result = e.DoWork().Result;
            //Console.WriteLine(JsonConvert.SerializeObject(result, new JsonSerializerSettings() { Formatting = Formatting.Indented }));
            Console.ReadLine();
        }
    }


    public class Entrance
    {
        public async Task<object> DoWork()
        {

            var cts = new CancellationTokenSource();
            var edi = new Edi()
            {
                Head = new Edi.Header
                {
                    ConsumerId = "A123456789",
                    ServerId = "127.0.0.1:8888",
                    TicketId = "00000001",
                    CilentIP = "127.0.0.1"
                },
                Request = new Edi.Rq()
                {
                    Time = DateTime.Now,
                    Cmd = "TestEcho",
                    Parameter = "xxxxxxxxxxxxx"
                }
            };

            object result;
            try
            {
                cts.CancelAfter(500);

                result = await CallApi(edi, cts.Token);

            }
            catch (OperationCanceledException ex)
            {
                result = ex;
            }
            catch (Exception ex)
            {
                result = ex;
            }

            return result;
        }

        private async Task<Edi> CallApi(Edi edi, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            edi.Histories.Add(new LogItem()
            {
                Time = DateTime.Now,
                Message = $"fx:{nameof(CallApi)}"
            });

            //模擬IO等候
            int delay = 0;
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }

                await Task.Delay(100);
                delay += 100;
                if (delay >= 300)
                    break;
            }

            edi.Response = new Edi.Rs()
            {
                Time = DateTime.Now,
                Result = $"Echoxxxx"
            };

            edi.Histories.Add(new LogItem()
            {
                Time = DateTime.Now,
                Message = $"{JsonConvert.SerializeObject(new { edi.Response })}"
            });

            return edi;
        }
    }

    public class Edi
    {
        public Header Head { get; set; }
        public Rq Request { get; set; }
        public Rs Response { get; set; }

        public OperationHistories Histories { get; set; }

        public Edi()
        {
            Histories = new OperationHistories();
        }

        public class Header
        {
            public string ConsumerId { get; set; }
            public string TicketId { get; set; }
            public string ServerId { get; set; }
            public string CilentIP { get; set; }
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

    public class LogItem
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
