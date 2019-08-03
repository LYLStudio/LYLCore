using System;
using System.IO;
using System.Linq;
using LYLStudio.Core;
using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;

namespace LYLStudio.App.TestConsole.Services
{
    public class LogginService : LoggerBase, IDisposable
    {
        private readonly IOperator<ILogItem[]> _seqOperator;

        public override TraceLevel TraceLevel { get; set; }
        public override Action<string, ILogItem[]> Callback { get; set; }

        public LogginService(IOperator<ILogItem[]> seqOperator, TraceLevel traceLevel = TraceLevel.L1)
        {
            _seqOperator = seqOperator;
            TraceLevel = traceLevel;
        }

        public LogginService(IOperator<ILogItem[]> seqOperator, Action<string, ILogItem[]> callback) : this(seqOperator)
        {
            Callback = callback;
        }

        public override void Log(string target, params ILogItem[] logItems)
        {
            if (TraceLevel == TraceLevel.L0)
                return;

            if (Callback != null)
            {
                Callback.Invoke(target, logItems);
            }
            else
            {
                IAnything<ILogItem[]> anything = new Anything<ILogItem[]>()
                {
                    Parameters = logItems,
                    AnythingAction = async (o) =>
                    {
                        var items = o;
                        FileIOHelper.CheckAndCreateDirectory(target);

                        var text = string.Join("\r\n", items.Select(x => $"{x.Time.ToLogFormat()}|{x.Id}|{x.Category}|{x.Priority}|{x.Message}"));
                        text += "\r\n";

                        using (var sw = File.AppendText(target))
                        {
                            await sw.WriteAsync(text);
                            sw.Close();
                        }
                    }
                };
                _seqOperator.Enqueue(anything);
            }
        }

        public void Dispose()
        {
            _seqOperator?.Stop();
        }
    }
}
