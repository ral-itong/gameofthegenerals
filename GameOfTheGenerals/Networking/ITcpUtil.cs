using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public interface ITcpUtil
    {
        void ListenForClients(ISocket socket, int portNumber, AsyncCallback asyncCallback);
        void Listen(ISocket clientSocket, AsyncCallback asyncCallback);
        void Send(ISocket socket, AsyncCallback callback, byte[] data);
        IPAddress GetLocalHostIpAddress();
    }
}
