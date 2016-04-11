using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class Game
    {
        IManualResetEvent _resetEvent;
        ISocket _otherPlayerSocket;


        public void ListenToClients()
        {
            ClientSocketListener socketListener = new ClientSocketListener();
            socketListener.OtherPlayerConnected = _resetEvent;
            socketListener.StartListening();
            _resetEvent.Set();
            _otherPlayerSocket = socketListener.OtherPlayerSocketAdapter;
        }


    }
}
