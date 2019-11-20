namespace LStudio.Core.Threading
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;

    public class SequenceOperator<T> : IOperator<T>
    {
        private AutoResetEvent _resetEvent;
        private readonly Dictionary<ThreadPriority, ConcurrentQueue<IAnything<T>>> _queueList;
        private readonly Thread _thread;

        public string Id { get; }
        public ThreadPriority Priority { get; }
        public int Sleep { get; set; }

        public event EventHandler<OperatorEventArgs> OperationOccurred;

        public SequenceOperator(string id, ThreadPriority priority = ThreadPriority.Normal, int sleep = 1)
        {
            Id = id;
            Priority = priority;
            Sleep = sleep;

            _queueList = new Dictionary<ThreadPriority, ConcurrentQueue<IAnything<T>>>(Enum.GetNames(typeof(ThreadPriority)).Length);
            foreach (ThreadPriority item in Enum.GetValues(typeof(ThreadPriority)))
            {
                _queueList.Add(item, new ConcurrentQueue<IAnything<T>>());
            }

            _resetEvent = new AutoResetEvent(false);
            _thread = new Thread(Start)
            {
                Name = Id,
                Priority = Priority,
                IsBackground = true
            };

            _thread.Start();
        }

        private void Start()
        {
            while (true && !_disposedValue)
            {
                T payload = default;

                if (!_queueList[ThreadPriority.Highest].IsEmpty)
                {
                    try
                    {
                        if (_queueList[ThreadPriority.Highest].TryDequeue(out IAnything<T> anything))
                        {
                            payload = anything.Parameter;
                            anything.Callback(anything.Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorProcess(ex, payload);
                    }
                }
                else if (!_queueList[ThreadPriority.AboveNormal].IsEmpty)
                {
                    try
                    {
                        if (_queueList[ThreadPriority.AboveNormal].TryDequeue(out IAnything<T> anything))
                        {
                            payload = anything.Parameter;
                            anything.Callback(anything.Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorProcess(ex, payload);
                    }
                }
                else if (!_queueList[ThreadPriority.Normal].IsEmpty)
                {
                    try
                    {
                        if (_queueList[ThreadPriority.Normal].TryDequeue(out IAnything<T> anything))
                        {
                            payload = anything.Parameter;
                            anything.Callback(anything.Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorProcess(ex, payload);
                    }
                }
                else if (!_queueList[ThreadPriority.BelowNormal].IsEmpty)
                {
                    try
                    {
                        if (_queueList[ThreadPriority.BelowNormal].TryDequeue(out IAnything<T> anything))
                        {
                            payload = anything.Parameter;
                            anything.Callback(anything.Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorProcess(ex, payload);
                    }
                }
                else if (!_queueList[ThreadPriority.Lowest].IsEmpty)
                {
                    try
                    {
                        if (_queueList[ThreadPriority.Lowest].TryDequeue(out IAnything<T> anything))
                        {
                            payload = anything.Parameter;
                            anything.Callback(anything.Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorProcess(ex, payload);
                    }
                }
                else
                {
                    _resetEvent.WaitOne();
                }

                _resetEvent.WaitOne(Sleep);
            }
        }

        private void ErrorProcess(Exception ex, T payload = default)
        {
            IResult result = new ThreadResult<T>(true)
            {
                Message = ex.Message,
                ResultException = ex,
                Payload = payload
            };

            OnOperationOccured(this, new OperatorEventArgs(result));
        }

        public void Enqueue(IAnything<T> anything, ThreadPriority priority = ThreadPriority.Normal)
        {
            if (_disposedValue)
            {
                ErrorProcess(new ObjectDisposedException(nameof(SequenceOperator<T>), Id));
                return;
            }

            if (anything is null || anything.Callback is null)
            {
                ErrorProcess(new ArgumentNullException(nameof(anything)));
                return;
            }

            try
            {
                _queueList[priority].Enqueue(anything);
                _resetEvent.Set();
            }
            catch (Exception ex)
            {
                ErrorProcess(ex, anything.Parameter);
            }
        }

        private void OnOperationOccured(object sender, OperatorEventArgs eventArgs)
        {
            OperationOccurred?.Invoke(sender, eventArgs);
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;

                if (disposing)
                {
                    _resetEvent?.Dispose();
                    _resetEvent = null;
                }                
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
