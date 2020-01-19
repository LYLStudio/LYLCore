using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LStudio.Core.Threading;

namespace LStudio.TestLibsApp.EncryptionTest
{
    public class TestRun : IDisposable
    {
        private readonly string _distributeOpName = "RunTestCase1";
        private readonly int _distributeOpSleep = 100;
        private readonly int _distributeOpThreadCount = 4;
        private readonly DistributeOperator<object> _distributeOp = null;

        private static ConcurrentDictionary<int, string> _logHistories;

        public TestRun()
        {
            _logHistories = new ConcurrentDictionary<int, string>();

            _distributeOp = new DistributeOperator<object>(_distributeOpName, sleep: _distributeOpSleep);
            _distributeOp.OperationOccurred += (o, e) =>
            {
                var xx = e.EventResult.Message;
            };
            _distributeOp.Initialize(_distributeOpThreadCount);
        }

        public void RunTestCase1()
        {
            int baseCount = 1000;
            for (int i = 1; i <= 1000; i++)
            {
                _distributeOp.Enqueue(new Anything<object>(
                    new object[] { i, i * baseCount },
                    p =>
                    {
                        TestCase1(new Anything<object>(
                            p,
                            (pp) =>
                            {
                                var ppp = (object[])pp;
                                //var p1 = (int)ppp[0];
                                var p2 = (int)ppp[1];
                                List<AuthenHistory> list = new List<AuthenHistory>(p2);

                                for (int j = 0; j < p2; j++)
                                {
                                    var salt = Encryption.GenSaltBase64String(4);
                                    var id = Encryption.SHA256(Encryption.SHA1("testuser"), salt);
                                    var pwd = Encryption.SHA256("HnwHJM0lBJLc33pvVlZ5mWAq900=", salt);

                                    list.Add(new AuthenHistory() { Id = id, Pwd = pwd, Salt = salt });
                                }
                            }));
                    }));
            }
        }

        private static void TestCase1(Anything<object> anything)
        {
            if (anything is null) throw new ArgumentNullException(nameof(anything));

            var param = (object[])anything.Parameter;
            var runId = param[0].ToString();
            var count = param[1];
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var start = $"runId:{runId,8}\tcount:{count,8}\t{DateTime.Now:O}";

            anything.Callback.Invoke(anything.Parameter);

            stopwatch.Stop();
            var end = $"{start} - {DateTime.Now:O},\tElapsed:{stopwatch.Elapsed}";
            Debug.WriteLine(end);
            //_logHistories.TryAdd(int.Parse(runId, CultureInfo.InvariantCulture), end);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _distributeOp.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class AuthenHistory
    {
        public string Id { get; set; }
        public string Pwd { get; set; }
        public string Salt { get; set; }

    }
}
