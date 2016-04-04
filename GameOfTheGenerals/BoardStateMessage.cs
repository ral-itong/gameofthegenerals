using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class BoardStateMessage : MessageWithBoard
    {
        public BoardStateMessage()
        {
            _messageType = MessageType.BoardState;
        }

        public static byte[] ToByteArray(BoardStateMessage boardStateMessage)
        {
            return SerializerDeserializer.ToByteArray(boardStateMessage);
        }

        public static BoardStateMessage Deserialize(byte[] result)
        {
            return SerializerDeserializer.DeserializeBoardStateMessage(result);
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
