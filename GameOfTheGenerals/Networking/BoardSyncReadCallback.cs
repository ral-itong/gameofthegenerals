using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GameOfTheGenerals
{
    public class BoardSyncReadCallback : IReadCallback
    {
        private ReadyMessage _readyMessage;
        private IManualResetEvent _resetEvent;

 

        public void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            ISocket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                Header header = Header.Deserialize(state.buffer);
                if (header.MessageType == MessageType.Ready)
                    ReadyMessage = MessageInterpreter.DeserializeMessage<ReadyMessage>(MessageType.Ready, state.buffer);
            }
        }

        public ReadyMessage ReadyMessage
        {
            get
            {
                return _readyMessage;
            }

            set
            {
                _readyMessage = value;
            }
            
        }

        internal IManualResetEvent ResetEvent
        {
            get
            {
                return _resetEvent;
            }

            set
            {
                _resetEvent = value;
            }
        }
    }
}
