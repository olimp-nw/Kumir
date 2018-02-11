using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Kumir.Model
{
    public class Server
    {
        private DateTime startTime { get; set; }
        private DateTime finishTime { get; set; }
        private DateTime currentTime { get; set; }

        private Table globalTable { get; set; }

        static TcpListener server;
        private List<Client> clients = new List<Client>();
     

        protected internal void AddConnection(Client client)
        {
            clients.Add(client);
        }
        public List<Client> GetListClient
        {
            get
            {
                return clients;
            }
        }

        protected internal void RemoveConnection(string name)
        {
            Client client = clients.FirstOrDefault(c => c.name == name);
            
            if (client != null)
                clients.Remove(client);
        }

        public void Listen()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 8888);
                server.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = server.AcceptTcpClient();

                    Client client = new Client(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(client.Process));
                    clientThread.Start();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal string checkName(string nameClient, Server server)
        {
            return "all is ok!";
        }

        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
               // if (clients[i].name != id) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }

        protected internal void Ping(string name)
        {
            byte[] data = Encoding.Unicode.GetBytes("time" + name);
            for (int i = 0; i < clients.Count; i++)
            {
                 if (clients[i].name == name) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }

        public void Disconnect()
        {
            server.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }

    }
}
