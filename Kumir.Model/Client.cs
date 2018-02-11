using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Kumir.Model
{
    public class Client
    {
        public string name { get; set; }
        public string password { get; set; }
        public IPAddress ip { get; set; }
        public bool changeIP { get; set; }
        protected internal NetworkStream Stream { get; private set; }

        TcpClient tcpClient;
        Server server;

        IPAddress getIpAdress()
        {
            var hostName = System.Net.Dns.GetHostName();
            return System.Net.Dns.GetHostByName(hostName).AddressList[0];
        }

        public Client(TcpClient tcpClient, Server server)
        {
            ip = getIpAdress();
            this.tcpClient = tcpClient;
            this.server = server;
            this.server.AddConnection(this);
        }

        public void Process()
        {
            try {
              Stream = tcpClient.GetStream();
            // получаем имя пользователя
                string message = GetMessage();
                name = message;
           
                // посылаем сообщение о входе в чат всем подключенным пользователям
                server.BroadcastMessage(message, this.name);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if (message == "ping") { server.Ping(this.name); } else
                        server.BroadcastMessage(message, this.name);
                    }
                    catch
                    {
                        server.Ping(this.name);
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.name);
                Close();
            }
        }
private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);
            
            return builder.ToString();
            
        }
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (tcpClient != null)
                tcpClient.Close();
        }
    }
}
