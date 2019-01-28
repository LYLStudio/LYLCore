using System;
using System.Collections.Generic;
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
            IThreadOperator<MyStruct> op1 = new ThreadOperator<MyStruct>("thread01", ThreadPriority.Normal, 10);
            IThreadOperator<object[]> op2 = new ThreadOperator<object[]>("thread02", ThreadPriority.Normal, 15);
            op1.OperationOccurred += OnOperationOccurred;
            op2.OperationOccurred += OnOperationOccurred;
            for (int i = 0; i < 100; i++)
            {
                op1.Enqueue(new Anything<MyStruct>() 
                {
                    Parameters = new MyStruct { Name = op1.Id, Value = i },
                    Callback = o =>
                    {
                        if(o.Value == 44) throw new Exception("xxxxx");
                        Console.WriteLine($"{o.Name}\t{o.Value}");
                    }
                });
            }

            for (int i = 0; i < 100; i++)
            {
                op2.Enqueue(new Anything<object[]>()
                {
                    Parameters = new object[] { op2.Id, i },
                    Callback = objs =>
                    {
                        if ((int)objs[1] == 90) throw new Exception("xxxxx");
                        Console.WriteLine($"{objs[0]}\t{objs[1]}");
                    }
                });
            }

            Console.ReadLine();
        }

        private static void OnOperationOccurred(object sender, OperatorEventArgs e)
        {
            Console.WriteLine($"{e.EventTime}|{e.HasError}|{e.EventResult.Error.StackTrace}");
        }
    }
}
