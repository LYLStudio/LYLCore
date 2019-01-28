using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LYLStudio.Core;
using LYLStudio.Core.Threading;

namespace TestConsole
{
    public struct MyStruct
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }   

    class Program
    {
        static void Main(string[] args)
        {
            //IOperator<MyStruct> op = new SequenceOperator<MyStruct>("op1");
            //op.OperationOccurred += OnOperationOccurred;

            //for (int i = 0; i < 100; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        op.Enqueue(new Anything<MyStruct>(new MyStruct() { Name = op.Id, Value = i })
            //        {
            //            Callback = o => {
            //                Console.WriteLine($"{o.Name}\t{o.Value}");
            //            }
            //        });
            //    }
            //    else
            //    {
            //        op.Enqueue(new Anything<MyStruct>(new MyStruct() { Name = op.Id, Value = i })
            //        {
            //            Callback = o => {
            //                Console.WriteLine($"{o.Name}\t{o.Value}");
            //            }
            //        });
            //    }
            //}

            IOperator<MyStruct> disOp = new DistributeOperator<MyStruct>("disOp");
            disOp.OperationOccurred += OnOperationOccurred;
            (disOp as IDistributeOperator<MyStruct>).Initialize();

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    disOp.Enqueue(new Anything<MyStruct>(new MyStruct() { Name = disOp.Id, Value = i })
                    {
                        Callback = o => {
                            Console.WriteLine($"{o.Name}\t{o.Value}");
                        }
                    });
                }
                else
                {
                    disOp.Enqueue(new Anything<MyStruct>(new MyStruct() { Name = disOp.Id, Value = i })
                    {
                        Callback = o => {
                            Console.WriteLine($"{o.Name}\t{o.Value}");
                        }
                    });
                }
            }

            Console.ReadLine();
        }

        private static void OnOperationOccurred(object sender, OperatorEventArgs e)
        {
            Console.WriteLine($"{e.EventTime}|{e.HasError}|{e.EventResult.Error.StackTrace}");
        }
    }
}
