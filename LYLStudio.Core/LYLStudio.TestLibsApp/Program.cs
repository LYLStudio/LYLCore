using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LYLStudio.Core;
using LYLStudio.Core.Threading;
using LYLStudio.Utilities.ObjectOperation;

namespace LYLStudio.TestLibsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IOperator<string> op = new SequenceOperator<string>("ttt", sleep:1000);
            op.OperationOccurred += Op_OperationOccurred;

            for (int i = 0; i < 100; i++)
            {
                op.Enqueue(new Anything<string>(i.ToString())
                {
                    Callback = o => {
                        System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{o}");
                    }
                });
            }

            IOperator<string> op1 = new SequenceOperator<string>("ttt", sleep: 100);
            op1.OperationOccurred += Op_OperationOccurred;

            for (int i = 0; i < 100; i++)
            {
                op1.Enqueue(new Anything<string>(i.ToString())
                {
                    Callback = o => {
                        System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.Name}:{o}");
                    }
                });
            }

            Console.ReadLine();
            
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

        static void ProperitesDebugInfo(KeyValuePair<object, object> kv)
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
