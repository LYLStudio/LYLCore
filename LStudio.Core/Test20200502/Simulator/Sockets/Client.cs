using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Test20200502.Simulator.Sockets
{
    public class Client
    {
        private readonly TcpClient tcpClient;
        private readonly NetworkStream stream;
        private readonly byte[] buffer = new byte[2048];
        private readonly string name;

        public Client(int port)
        {
            name = $"CLIENT|{port}";
            tcpClient = new TcpClient();
            tcpClient.Connect("localhost", port);
            stream = tcpClient.GetStream();
        }

        public void Request()
        {
            var val = tcpClient.Client.RemoteEndPoint.ToString();
            for (int i = 0; i < 1; i++)
            {
                val += $"${val}";
            }
            var cmd = Encoding.Unicode.GetBytes($"{val}");
            stream.Write(cmd, 0, cmd.Length);

            var readLength = stream.Read(buffer, 0, buffer.Length);

            var rs = Encoding.Unicode.GetString(buffer, 0, readLength);

            Output($"Received: {rs}");

        }

        private void Output(string output, bool isNewLine = true)
        {
            var log = $"[{DateTime.Now:O} {name}]{output}";
            //log = (isNewLine ? "\n" : string.Empty) + log;
            //Console.Write(log);
            Console.WriteLine(log);
        }
    }

}
