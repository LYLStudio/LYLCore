using System;

using LYLStudio.Core.Logging;
using LYLStudio.Core.Threading;

namespace TestConsole.Services
{
    public class LogginService<T> : LoggerBase<T>, IDisposable
    {
        private IOperator<T> _seqOperator;

        public override Action<T> LogCallback { get; set; }

        public LogginService(IOperator<T> seqOperator)
        {
            _seqOperator = seqOperator;
        }

        public LogginService(IOperator<T> seqOperator, Action<T> logCallback) : this(seqOperator)
        {
            LogCallback = logCallback;
        }

        public override void Log(T logItem)
        {
            IAnything<T> anything = new Anything<T>(logItem)
            {
                Callback = o =>
                {
                    LogCallback?.Invoke(o);
                }
            };

            _seqOperator.Enqueue(anything);
        }

        public void Dispose()
        {
            _seqOperator?.Stop();
        }
    }
}
