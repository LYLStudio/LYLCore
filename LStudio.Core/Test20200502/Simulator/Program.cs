using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LStudio.Core.Threading;

using Test20200502.Simulator.Sockets;

namespace Test20200502.Simulator
{
    public class Program
    {
        public void Main()
        {
            new ServerManager();

            Dictionary<int, Client> clients = new Dictionary<int, Client>();
            //var response = manager.Send(new Request());
            for (int i = 0; i < 5; i++)
            {
                var port = 10000 + i;
                clients.Add(port, new Client(port));
            }

            DistributeOperator<int> operator1 = new LStudio.Core.Threading.DistributeOperator<int>("xx");
            operator1.Initialize();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        operator1.Enqueue(new Anything<int>()
                        {
                            Parameter = i,
                            Callback = p =>
                            {
                                var mod = p % 5;
                                clients[10000 + mod].Request();
                            }
                        });
                    }
                }
                else
                {
                    break;
                }
            }

            Console.Read();
        }
    }
}
