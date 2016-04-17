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
        private List<Piece> _pieces;
        private ITcpUtil _tcpUtil;
        private short _turnNumber;




        public Game()
        {
            _portNumber = 10801;
            HostSocket = new SocketAdapter(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Pieces = new List<Piece>();
            TcpUtil = new TcpUtilAdapter();
        }

        public void StartGame()
        {
            ListenForClients();
            SetupBoard();
        }

        private void ListenForClients()
        {
            TcpUtil.ListenForClients(HostSocket, _portNumber, new AsyncCallback(GetClientSocketAndWaitForClientReadyMessage));
        }

        private void SetupBoard()
        {

        }

        private void GetClientSocketAndWaitForClientReadyMessage(IAsyncResult ar)
        {
            ExtractClientSocket(ar);
            WaitForClientsReadyMessage();
        }

        private void WaitForClientsReadyMessage()
        {
            TcpUtil.Listen(ClientSocket, new AsyncCallback(PopulateBoardWithClientPieces));
        }

        public void PopulateBoardWithClientPieces(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            BoardStateMessage message = ReadyMessage.Deserialize(state.buffer);
            Pieces.AddRange(message.Pieces);

        }

        public void SendClientReadyMessage()
        {
            ReadyMessage readyMessage = new ReadyMessage();
            readyMessage.MessageOrigination = MessageOrigination.Host;
            readyMessage.Pieces = Pieces.ToArray();

            TcpUtil.Send(ClientSocket, new AsyncCallback(WaitForClientBoardStateMessage), ReadyMessage.Serialize(readyMessage));
        }

        public void WaitForClientBoardStateMessage(IAsyncResult ar)
        {
            TcpUtil.Listen(ClientSocket, new AsyncCallback(CheckIfBoardStateMatch));
        }

        public void CheckIfBoardStateMatch(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            BoardStateMessage message = BoardStateMessage.Deserialize(state.buffer);
            if (Enumerable.SequenceEqual(message.Pieces, Pieces.ToArray()))
                StartMovePieceSequence();
            else
                SendClientSetupFailed();

        }

        private void SendClientSetupFailed()
        {
            SetupFailMessage message = new SetupFailMessage();
            message.TurnNumber = _turnNumber;
            message.MessageOrigination = MessageOrigination.Host;
            TcpUtil.Send(ClientSocket, new AsyncCallback(SendClientSetupFailedCallback), SetupFailMessage.Serialize(message));
        }

        private void SendClientSetupFailedCallback(IAsyncResult ar)
        {

        }

        private void ExtractClientSocket(IAsyncResult ar)
        {
            ISocket listener = ar.AsyncState as ISocket;
            ClientSocket = listener.EndAccept(ar);
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

        public ISocket ClientSocket
        {
            get
            {
                return _clientSocket;
            }

            set
            {
                _clientSocket = value;
            }
        }

        public List<Piece> Pieces
        {
            get
            {
                return _pieces;
            }

            set
            {
                _pieces = value;
            }
        }

        public void StartMovePieceSequence()
        {

        }

        public void MovePiece(Piece piece, Coordinate coordinate)
        {

        }

        public ITcpUtil TcpUtil
        {
            get
            {
                return _tcpUtil;
            }

            set
            {
                _tcpUtil = value;
            }
        }
    }
}
