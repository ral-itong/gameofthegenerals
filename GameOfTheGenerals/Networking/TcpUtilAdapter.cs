using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public class TcpUtilAdapter : ITcpUtil
    {
        public IPAddress GetLocalHostIpAddress()
        {
            return TcpUtil.GetLocalHostIpAddress();
        }

        public void Listen(ISocket clientSocket, AsyncCallback asyncCallback)
        {
            TcpUtil.Listen(clientSocket, asyncCallback);
        }

        public void ListenForClients(ISocket socket, int portNumber, AsyncCallback asyncCallback)
        {
            TcpUtil.ListenForClients(socket, portNumber, asyncCallback);
        }

        public void Send(ISocket socket, AsyncCallback callback, byte[] data)
        {
            TcpUtil.Send(socket, callback, data);
        }
    }
}
