using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public class TcpUtil
    {
        public static void ListenForClients(ISocket socket, int portNumber, AsyncCallback asyncCallback)
        {
            IPAddress ipAddress = GetLocalHostIpAddress();
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
            socket.Bind(localEndPoint);
            socket.Listen(1);

            socket.BeginAccept(asyncCallback, socket);
        }

        public static void Listen(ISocket clientSocket, AsyncCallback asyncCallback)
        {
            StateObject state = new StateObject();
            state.workSocket = clientSocket;
            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, asyncCallback, state);
        }

        public static void Send(ISocket socket, AsyncCallback callback, byte[] data)
        {
            socket.BeginSend(data, 0, data.Length, 0, callback, socket);
        }

        public static IPAddress GetLocalHostIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}
