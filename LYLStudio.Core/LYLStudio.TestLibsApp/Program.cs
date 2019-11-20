using System;
using System.Collections.Generic;
using System.Threading;
using LYLStudio.Core;
using LYLStudio.Core.Helper;
using LYLStudio.Core.Threading;

namespace LYLStudio.TestLibsApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!(args is null) && args.Length > 0)
            {
                //
            }

            IOperator<string> op1 = new SequenceOperator<string>("ttt1", sleep: 1000);
            IOperator<string> op2 = new SequenceOperator<string>("ttt2", sleep: 100);

            try
            {
                op1.OperationOccurred += Op_OperationOccurred;

                for (int i = 0; i < 100; i++)
                {
                    op1.Enqueue(new Anything<string>(i.ToString())
                    {
                        Callback = o =>
                        {
                            System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{o}");
                        }
                    });
                }

                op2.OperationOccurred += Op_OperationOccurred;

                for (int i = 0; i < 100; i++)
                {
                    op2.Enqueue(new Anything<string>(i.ToString())
                    {
                        Callback = o =>
                        {
                            System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.Name}:{o}");
                        }
                    });
                }

                Console.ReadLine();
            }
            finally
            {
                op1?.Dispose();
                op2?.Dispose();
            }


            //var result = new SampleResult();
            //var result2 = new SampleResult(parentId: result.Id);
            //var tmpResult = result2.InnerResults as List<IResult>;
            //tmpResult.Add(new SampleResult(parentId: result2.Id));
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //tmpResult.Add(result2);
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //tmpResult.Add(new SampleResult(parentId: result.Id));
            //result.ForEachProperty(ProperitesDebugInfo);
        }

        private static void Op_OperationOccurred(object sender, OperatorEventArgs e)
        {

        }

        private static void ProperitesDebugInfo(KeyValuePair<object, object> kv)
        {

            if (kv.Value is List<IResult> list)
            {
                System.Diagnostics.Debug.WriteLine($"{kv.Key}({list.Count}):");
                list.ForEach((o) =>
                {
                    o.ForEachProperty(ProperitesDebugInfo);
                });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"{kv.Key}: {kv.Value}");

            }
        }
    }
}
