namespace Test20200502.Simulator.Sockets
{
    public class ServerInfo : IServer
    {
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

    }

    public interface IServer
    {
        string ServerName { get; set; }
        string Ip { get; set; }
        int Port { get; set; }
    }
}