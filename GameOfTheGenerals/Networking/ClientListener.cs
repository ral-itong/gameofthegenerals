using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GameOfTheGenerals
{
    public class ClientListener
    {
        private ManualResetEvent _otherPlayerConnected;
        private int _portNumber;
        private ISocket _socketAdapter;
        private ISocket _otherPlayerSocketAdapter;
        

        public ClientListener()
        {
            _portNumber = 10801;
            _socketAdapter = new SocketAdapter(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            OtherPlayerSocketAdapter = new SocketAdapter(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[5];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _portNumber);

            try
            {
                _socketAdapter.Bind(localEndPoint);
                _socketAdapter.Listen(100);
                _socketAdapter.BeginAccept(new AsyncCallback(AcceptCallBack), _socketAdapter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void AcceptCallBack(IAsyncResult ar)
        {
            if (_otherPlayerConnected != null)
                _otherPlayerConnected.Set();

            ISocket listener = ar.AsyncState as ISocket;
            _otherPlayerSocketAdapter = listener.EndAccept(ar);
        }


        public ISocket OtherPlayerSocketAdapter
        {
            get
            {
                return _otherPlayerSocketAdapter;
            }

            set
            {
                _otherPlayerSocketAdapter = value;
            }
        }

        public ManualResetEvent OtherPlayerConnected
        {
            get
            {
                return _otherPlayerConnected;
            }

            set
            {
                _otherPlayerConnected = value;
            }
        }


    }
}