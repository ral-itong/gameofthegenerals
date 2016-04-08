using System;

namespace GameOfTheGenerals
{
    public class ClientReader
    {
        private ISocket _clientSocket;
        private IReadCallback _callback;
        

        public ClientReader(IReadCallback callback, ISocket socket)
        {
            _callback = callback;
            _clientSocket = socket;
        }

        public void ListenForClientsReadyMessage()
        {
            StateObject state = new StateObject();
            state.workSocket = _clientSocket;
            _clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(_callback.ReadCallback), state);
        }

        
    }
}