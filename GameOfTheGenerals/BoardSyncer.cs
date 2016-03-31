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
            _clientSocket
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