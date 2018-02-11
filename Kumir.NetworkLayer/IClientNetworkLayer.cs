using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Kumir.Model;

namespace Kumir.NetworkLayer
{
    public interface IClientNetworkLayer
    {
        string connectServ(Socket socet, Client client);
        string sendData(NetworkStream stream, Line line);       
        DateTime pingServ(NetworkStream stream);
    }
}
