using GameOfTheGenerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace GameOfTheGeneralsUnitTests
{
    public class MockSocketAdapter : ISocket
    {
        private AddressFamily _addressFamily;
        private SocketType _socketType;
        private ProtocolType _protocolType;
        private Socket _socket;

        public MockSocketAdapter(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            _addressFamily = addressFamily;
            _socketType = socketType;
            _protocolType = protocolType;
            _socket = new Socket(_addressFamily, _socketType, _protocolType);
        }

        public MockSocketAdapter()
        {

        }

        public void BeginAccept(AsyncCallback asyncCallback, ISocket socket)
        {
            asyncCallback.Invoke(new MockAsyncResult());
        }

        public void Bind(IPEndPoint localEndPoint)
        {
            
        }

        public void Listen(int backLog)
        {
            
        }

        

        ISocket ISocket.EndAccept(IAsyncResult ar)
        {
            return new MockSocketAdapter();
        }

        public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
        {
            return new MockAsyncResult();
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
