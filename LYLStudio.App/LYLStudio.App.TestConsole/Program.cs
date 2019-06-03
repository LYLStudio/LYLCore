using System;
using System.IO;
using LYLStudio.App.TestConsole.Models;
using LYLStudio.App.TestConsole.Services;
using LYLStudio.Core;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;

namespace LYLStudio.App.TestConsole
{
    class Program
    {
        static readonly string logTarget = Path.Combine(Properties.Settings.Default.LOG_PATH, $"{DateTime.Today.ToDateFormated()}.log");
        static readonly LogginService logSvc = new LogginService(new SequenceOperator<ILogItem[]>(nameof(LogginService)));
        static void Main(string[] args)
        {
            logSvc.Callback = (target, log) =>
            {
                foreach (var item in log)
                {
                    Console.WriteLine($"{item.Time.ToLogFormat()},{item.Message},{item.Error?.GetAllMessages()}");
                }
            };
            logSvc.Log(logTarget, new LogItem("START!!"));
            var seqOperator = new SequenceOperator<string>(nameof(TestModelService));
            seqOperator.OperationOccurred += SeqOperator_OperationOccurred;
            seqOperator.Enqueue(new Anything<string>()
            {
                Callback = o =>
                {
                    using (var svc = new TestModelService())
                    {
                        var result = svc.Create(new Account() { Id = 1, Name = "aaaa" });
                        logSvc.Log(logTarget, new LogItem($"{result.Id}|{result.IsSuccess}|{result.Message}") { Error = result.Error });
                    }

                }
            });


            Console.ReadLine();

            logSvc.Log(logTarget, new LogItem("END!!"));
        }

        private static void SeqOperator_OperationOccurred(object sender, OperatorEventArgs e)
        {
            if (e.HasError)
            {
                logSvc.Log(logTarget, new LogItem($"{nameof(SeqOperator_OperationOccurred)}") { Error = e.EventResult.Error });
            }
        }
    }
}
