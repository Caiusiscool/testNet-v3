using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using testNet_v3.Util;
namespace testNet_v3
{
    class Client
    {
        public static List<Client> clients = new List<Client>();
        public string name;
        public TcpClient conn;
        public int id;
        public string ip;
        public void Write(string content)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(content);
            NetworkStream ns = conn.GetStream();
            ns.Write(buffer, 0, buffer.Length);
            Logger.Log(Logger.LogType.INFO, "Sent " + content + " to client " + name + " with id " + id);
        }

    }
}
