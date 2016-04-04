using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class ReadyMessage : MessageWithBoard
    {
        public ReadyMessage()
        {
            _messageType = MessageType.Ready;
        }

        public static byte[] ToByteArray(ReadyMessage readyMessage)
        {
            return SerializerDeserializer.ToByteArray(readyMessage);
        }

        public static ReadyMessage Deserialize(byte[] result)
        {
            return SerializerDeserializer.DeserializeReadyMessage(result);
        }

        protected override byte GetTotalLengthOfMessage()
        {
            byte lengthOfPieces = Convert.ToByte(Piece.SerialLength * _pieces.Length);
            byte lengthOfHeader = Header.SerialLength;
            byte numOfPiecesInBoard = 1;

            byte total = Convert.ToByte((lengthOfPieces + lengthOfHeader + numOfPiecesInBoard));
            return total;
        }
    }
}
