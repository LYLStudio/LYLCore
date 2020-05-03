using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Test20200502.Simulator.Sockets
{
    public class Server : ServerInfo
    {
        private TcpListener server;


        public Server(string serverName)
        {
            ServerName = serverName;
        }

        public void Start(int port)
        {
            try
            {
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                byte[] bytes = new byte[4096];
                string data = null;

                // Enter the listening loop.
                while (true)
                {
                    Output("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Output("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.Unicode.GetString(bytes, 0, i);
                        Output($"Received: {data}");

                        // Process the data sent by the client.
                        //data = data.ToUpper();
                        Task.Delay(100).Wait();
                        byte[] msg = System.Text.Encoding.Unicode.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        //Output($"Sent: {data}");
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Output($"SocketException: {e}");
            }
            finally
            {
                // Stop listening for new clients.
                //server.Stop();
            }

            //Output("Hit enter to continue...");
            //Console.Read();
        }

        private void Output(string output, bool isNewLine = true)
        {
            var log = $"[{DateTime.Now:O} {ServerName}]{output}";
            //log = (isNewLine ? "\n" : string.Empty) + log;
            //Console.Write(log);
            Console.WriteLine(log);
        }
    }

}
