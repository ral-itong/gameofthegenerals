using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class MessageInterpreter
    {
        

        public static T DeserializeMessage<T>(MessageType type, byte[] byteArray)
        {
            Message message = null;
            switch (type)
            {
                case MessageType.BoardState:
                    message = BoardStateMessage.Deserialize(byteArray);
                    break;
                case MessageType.Ready:
                    message = ReadyMessage.Deserialize(byteArray);
                    break;
                case MessageType.SetupFail:
                    message = SetupFailMessage.Deserialize(byteArray);
                    break;
                case MessageType.MovePiece:
                    message = MovePieceMessage.Deserialize(byteArray);
                    break;
                case MessageType.MovePieceAck:
                    message = MovePieceAckMessage.Deserialize(byteArray);
                    break;
                case MessageType.GoodToGo:
                    message = GoodToGoMessage.Deserialize(byteArray);
                    break;
                case MessageType.RemovePiece:
                    message = RemovePieceMessage.Deserialize(byteArray);
                    break;
                case MessageType.RemovePieceAck:
                    message = RemovePieceAckMessage.Deserialize(byteArray);
                    break;
                default:
                    break;
            }

            return (T)message;
        }

    }
}
