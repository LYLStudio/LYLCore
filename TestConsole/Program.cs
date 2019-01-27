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
            IResult result = new Result();
            OperatorEventArgs operatorEventArgs = new OperatorEventArgs(result);
            
            IThreadOperator<MyStruct> op1 = new ThreadOperator<MyStruct>("thread01", ThreadPriority.Normal, 100);
            IThreadOperator<object[]> op2 = new ThreadOperator<object[]>("thread02", ThreadPriority.Normal, 150);

            for (int i = 0; i < 100; i++)
            {
                op1.Enqueue(new Anything<MyStruct>() 
                {
                    Parameters = new MyStruct { Name = op1.Id, Value = i },
                    Callback = o =>
                    {
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
                        Console.WriteLine($"{objs[0]}\t{objs[1]}");
                    }
                });
            }

            Console.ReadLine();
        }
    }
}
