using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public interface ISocket
    {
        Socket Socket { get; set; }

        void Bind(IPEndPoint localEndPoint);
        void Listen(int backLog);
        void BeginAccept(AsyncCallback asyncCallback, ISocket socket);
        ISocket EndAccept(IAsyncResult ar);
        IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state);
    }
}
