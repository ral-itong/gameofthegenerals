using System;

namespace GameOfTheGenerals
{
    public class BoardSyncer
    {
        private ISocket _clientSocket;


        public void ListenForClientsReadyMessage()
        {
            StateObject state = new StateObject();
            state.workSocket = _clientSocket;
            _clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }


        public void ReadCallback(IAsyncResult ar)
        {
            StateObject state = ar.AsyncState as StateObject;
            ISocket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
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
    }
}