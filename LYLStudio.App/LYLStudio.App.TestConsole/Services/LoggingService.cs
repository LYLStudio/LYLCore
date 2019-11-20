using System;
using System.IO;
using System.Linq;
using LStudio.Core;
using LStudio.Core.Logging;
using LStudio.Core.Threading;

namespace LYLStudio.App.TestConsole.Services
{
    public class LogginService : LoggerBase, IDisposable
    {
        private readonly IOperator<ILogItem[]> _seqOperator;

        public override Action<string, ILogItem[]> Callback { get; set; }

        public LogginService(IOperator<ILogItem[]> seqOperator)
        {
            _seqOperator = seqOperator;
        }

        public LogginService(IOperator<ILogItem[]> seqOperator, Action<string, ILogItem[]> callback) : this(seqOperator)
        {
            Callback = callback;
        }

        public override void Log(string target, params ILogItem[] logItems)
        {
            if (Callback != null)
            {
                Callback.Invoke(target, logItems);
            }
            else
            {
                IAnything<ILogItem[]> anything = new Anything<ILogItem[]>()
                {
                    Parameter = logItems,
                    Callback = async (o) =>
                    {
                        var items = o;
                        FileIOHelper.CheckAndCreateDirectory(target);

                        var text = string.Join("\r\n", items.Select(x => $"{x.Time.ToLogTime()}|{x.Id}|{x.Category}|{x.Priority}|{x.Message}"));
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

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _seqOperator?.Dispose();
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~LogginService()
        // {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
