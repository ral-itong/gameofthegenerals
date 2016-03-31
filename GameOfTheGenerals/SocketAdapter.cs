using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public class SocketAdapter : ISocket
    {
        private AddressFamily _addressFamily;
        private SocketType _socketType;
        private ProtocolType _protocolType;
        private Socket _socket;

       

        public SocketAdapter(AddressFamily addressFanily, SocketType socketType, ProtocolType protocolType)
        {
            _addressFamily = addressFanily;
            _socketType = socketType;
            _protocolType = protocolType;
            _socket = new Socket(_addressFamily, _socketType, _protocolType);
        }

        public SocketAdapter(Socket socket)
        {
            _socket = socket;
        }

        

        public void Bind(IPEndPoint localEndPoint)
        {
            
        }

        public void Listen(int backLog)
        {
            
        }

        public void BeginAccept(AsyncCallback asyncCallback, ISocket socket)
        {
            
        }
   
        ISocket ISocket.EndAccept(IAsyncResult ar)
        {
            Socket socket = _socket.EndAccept(ar);
            return new SocketAdapter(socket);
        }

        public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
        {
            return _socket.BeginReceive(buffer, offset, size, socketFlags, callback, state);
        }

        public Socket Socket
        {
            get
            {
                return _socket;
            }

            set
            {
                _socket = value;
            }
        }
    }
}
