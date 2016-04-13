using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public class Game
    {
        private int _portNumber;
        private ISocket _hostSocket;
        private ISocket _clientSocket;



        public Game()
        {
            _portNumber = 10801;
            HostSocket = new SocketAdapter(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartGame()
        {
            ListenForClients();
            SetupBoard();
        }

        private void ListenForClients()
        {
            TcpUtil.ListenForClients(HostSocket, _portNumber, new AsyncCallback(AcceptCallBack));
        }


        private void SetupBoard()
        {

        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            ExtractOtherPlayerSocket(ar);
            WaitForClientsReadyMessage();
        }

        private void WaitForClientsReadyMessage()
        {
            TcpUtil.Listen(new AsyncCallback(PopulateBoardWithClientPieces), _clientSocket);
        }

        public void PopulateBoardWithClientPieces(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
        }

        private void ExtractOtherPlayerSocket(IAsyncResult ar)
        {
            ISocket listener = ar.AsyncState as ISocket;
            _clientSocket = listener.EndAccept(ar);
        }

        public ISocket HostSocket
        {
            get
            {
                return _hostSocket;
            }

            set
            {
                _hostSocket = value;
            }
        }





    }
}
