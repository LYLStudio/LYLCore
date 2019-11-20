using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using LYLStudio.App.Services;

namespace LYLStudio.App.Middle.Services.Logging
{
    public abstract class LogServiceBase : ILogService, IDisposable
    {
        protected readonly ThreadService _threadService = null;

        public event EventHandler<Exception> LogExceptionOccurred;

        public Action<string, IEnumerable<LogItem>> Callback { get; set; }

        protected LogServiceBase()
        {
            _threadService = new ThreadService(nameof(LogServiceBase));
            _threadService.ExceptionOccurred += ExceptionOccurred;
        }

        public abstract void Log(string location, params LogItem[] logItems);

        private void ExceptionOccurred(object sender, Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e);
            LogExceptionOccurred?.Invoke(sender, e);
        }       

        protected class ThreadService : IThreadService<Anything>
        {
            private Dictionary<ThreadPriority, ConcurrentQueue<Anything>> _queueList;
            private AutoResetEvent _resetEvent;
            private Thread _thread;
            private bool _isTerminateService = false;

            public event EventHandler<Exception> ExceptionOccurred;

            public string Id { get; }
            public ThreadPriority Priority { get; }
            public int Sleep { get; set; }

            #region IDisposable Support
            private bool disposedValue = false; // 偵測多餘的呼叫

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 處置 Managed 狀態 (Managed 物件)。                                               
                        if (_queueList != null)
                        {
                            _queueList.Clear();
                            _queueList = null;
                        }

                        if (_resetEvent != null)
                        {
                            _resetEvent.Dispose();
                            _resetEvent = null;
                        }

                        if (_thread != null)
                        {
                            _thread = null;
                        }
                    }

                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                // GC.SuppressFinalize(this);
            }
            #endregion

            public ThreadService(string id, int sleep = 1)
            {
                Id = id;
                Priority = ThreadPriority.BelowNormal;
                Sleep = sleep;

                _queueList = new Dictionary<ThreadPriority, ConcurrentQueue<Anything>>(Enum.GetNames(typeof(ThreadPriority)).Length)
                {
                    { Priority, new ConcurrentQueue<Anything>() }
                };

                _resetEvent = new AutoResetEvent(false);
                _thread = new Thread(Start)
                {
                    Name = Id,
                    Priority = Priority,
                    IsBackground = true
                };

                _thread.Start();
            }

            public void Enqueue(Anything anything)
            {
                if (!_isTerminateService)
                {
                    try
                    {
                        _queueList[Priority].Enqueue(anything);
                        _resetEvent.Set();
                    }
                    catch (Exception ex)
                    {
                        OnExceptionOccurred(ex);
                    }
                }
            }

            public void Stop()
            {
                _isTerminateService = true;
            }

            private void Start()
            {
                while (true && !_isTerminateService)
                {
                    if (!_queueList[Priority].IsEmpty)
                    {
                        Dequeue();
                    }
                    else
                    {
                        _resetEvent.WaitOne();
                    }

                    _resetEvent.WaitOne(Sleep);
                }

                while (!_queueList[Priority].IsEmpty)
                {
                    Dequeue();
                    _resetEvent.WaitOne(Sleep);
                }
            }

            private void Dequeue()
            {
                try
                {
                    if (_queueList[Priority].TryDequeue(out Anything anything))
                    {
                        anything.Callback(anything.Parameter);
                    }
                }
                catch (Exception ex)
                {
                    OnExceptionOccurred(ex);
                }
            }

            private void OnExceptionOccurred(Exception exception)
            {
                ExceptionOccurred?.Invoke(this, exception);
            }

        }

        protected class Anything : IAnything<List<LogItem>>
        {
            public List<LogItem> Parameter { get; set; }
            public Action<List<LogItem>> Callback { get; set; }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _threadService.Stop();
                    _threadService.Dispose();

                    if (Callback != null)
                    {
                        foreach (var deleg in Callback.GetInvocationList())
                        {
                            Callback -= (Action<string, IEnumerable<LogItem>>)deleg;
                        }

                        Callback = null;
                    }
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~LogServiceBase()
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