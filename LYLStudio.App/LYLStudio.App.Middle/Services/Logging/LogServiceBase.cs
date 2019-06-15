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

        public LogServiceBase()
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

        public void Dispose()
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

        protected class Anything : IAnything<LogItem[]>
        {
            public LogItem[] Parameter { get; set; }
            public Action<LogItem[]> Callback { get; set; }
        }
    }
}