using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using testNet_v3.Util;
namespace testNet_v3.Networking
{
    class Listener
    {
        public static void StartListening()
        {
            
            TcpListener listener = new TcpListener(netCfg.port);
            listener.Start();
            Byte[] bytes;
            Logger.Log(Logger.LogType.INFO, "Started NetworkListener on port " + netCfg.port);
            while (true)
            {

                TcpClient client = listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                if (client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[client.ReceiveBufferSize];
                    ns.Read(bytes, 0, client.ReceiveBufferSize);
                    string s = Encoding.ASCII.GetString(bytes);
                    if (s.Contains("[") && s.Contains("]") && s.Contains("(") && s.Contains(")"))
                    {
                        connectionEstablished(client, Parser.Parse(s, "[", "]"), Parser.Parse(s, "(", ")"));
                    }

                }
            }
        }
        private static void connectionEstablished(TcpClient tc, string user, string c_ip)
        {
            int i = 0;
            foreach(Client c in Client.clients)
            {
                if(c.name == user)
                {
                    c.conn = tc;
                    i = 1;
                }
            }
            if (i == 0)
            {
                Client client = new Client()
                {
                    conn = tc,
                    name = user,
                    id = Client.clients.Count + 1,
                    ip = c_ip
                };
                Client.clients.Add(client);
                Logger.Log(Logger.LogType.INFO, "New client added, " + user);
            }
        }
    }
}

