using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LStudio.Core;
using LStudio.Core.Threading;

using Test20200502.Simulator.Sockets;

namespace Test20200502.Simulator
{
    public class ServerManager
    {
        //private DistributeOperator<object> RequestOeprator { get; set; }
        private Dictionary<string, Server> Servers { get; set; }
        //private Dictionary<int, ServerInfo> ServerInfos { get; set; }        

        public ServerManager()
        {
            var serverCount = 5;
            //RequestOeprator = new DistributeOperator<object>(nameof(ServerManager), sleep: 250);
            //RequestOeprator.OperationOccurred += RequestOeprator_OperationOccurred;
            //RequestOeprator.Initialize(serverCount);

            Servers = new Dictionary<string, Server>();
            //ServerInfos = new Dictionary<int, ServerInfo>();
            for (int i = 0; i < serverCount; i++)
            {
                var name = $"SERVER|1000{i}";
                Servers.Add(name, new Server(name));

                var thread = new Thread(() =>
                {
                    var port = int.Parse(name.Split('|')[1]);
                    Servers[name].Start(port);
                })
                {
                    IsBackground = true
                };
                thread.Start();
                //ServerInfos.Add(i, new ServerInfo() { Ip = Servers[name].Ip, Port = Servers[name].Port });
            }
        }

        private void RequestOeprator_OperationOccurred(object sender, OperatorEventArgs e)
        {
            throw new NotImplementedException();
        }

        //private int token = -1;
        //public Response Send(Request request, string serverName = "")
        //{
        //    Response rs;
        //    IServer server;

        //    if (string.IsNullOrWhiteSpace(serverName))
        //    {
        //        token = ++token % ServerInfos.Count;
        //        server = ServerInfos[token];
        //    }
        //    else
        //    {
        //        server = Servers.Values
        //            .Select(o=> new ServerInfo() { ServerName =o.ServerName, Ip = o.Ip, Port = o.Port })
        //            .FirstOrDefault(o => o.ServerName.Equals(serverName));
        //    }

        //    var anything = new Anything<object>
        //    {
        //        Parameter = new { server, request },
        //        Callback = param => {
        //            var p0 = param[0]
        //            using (var client = new TcpClient())
        //            {
        //                try
        //                {
        //                    client.Connect(server.Ip, server.Port);
        //                    var stream = client.GetStream();



        //                }
        //                catch (ArgumentNullException ex)
        //                {

        //                }
        //                catch (ArgumentOutOfRangeException ex)
        //                {

        //                }
        //                catch (SocketException ex)
        //                {

        //                }
        //                catch (ObjectDisposedException ex)
        //                {

        //                }
        //                catch (InvalidOperationException ex)
        //                {

        //                }
        //                catch (Exception ex)
        //                {

        //                    throw;
        //                }
        //                finally
        //                {

        //                }
        //            }
        //        }
        //    };
        //    RequestOeprator.Enqueue(anything);



        //    return rs;
        //}
    }


}
