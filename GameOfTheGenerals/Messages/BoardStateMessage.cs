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
            MessageType = MessageType.BoardState;
        }


        public override byte GetTotalLengthOfMessage()
        {
            return GetLengthOfHeaderLengthOfPieceAndNumberOfPieces();
        }

        public static byte[] ToByteArray(BoardStateMessage boardStateMessage)
        {
            return SerializerDeserializer.SerializeBoardStateMessage(boardStateMessage);
        }

        public static BoardStateMessage Deserialize(byte[] result)
        {
            return SerializerDeserializer.DeserializeBoardStateMessage(result);
        }
    }
}
