using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kumir.NetworkLayer;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Kumir.NetworkLayer.TCP
{
    public class ServerNetworLayerTCP : IServerNetworkLayer
    {
        void listenClient(IPAddress ipAdress, Int32 port)
        {
            TcpListener server = null;
            try {
                server = new TcpListener(ipAdress, port);
                

                server.Start();


            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally {
                server.Stop();
            }
        }
    }
}
