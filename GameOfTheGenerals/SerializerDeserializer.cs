using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class SerializerDeserializer
    {
        public static byte[] ToByteArray(BoardStateMessage boardState)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.ToByteArray(boardState.GetHeader()));
            writer.Write(boardState.GetNumberOfPiecesInBoard());

            foreach (Piece piece in boardState.Pieces)
                writer.Write(Piece.ToByteArray(piece));

            return stream.ToArray();
        }



        public static BoardStateMessage DeserializeBoardStateMessage(byte[] result)
        {
            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            Header header = GetHeader(reader);
            byte numOfPiecesInBoard = reader.ReadByte();

            List<Piece> pieceList = new List<Piece>();
            for (int i = 0; i < numOfPiecesInBoard; i++)
            {
                byte[] pieceBytes = reader.ReadBytes(Piece.SerialLength);
                pieceList.Add(Piece.Deserialize(pieceBytes));
            }

            pieceList.ToArray();

            BoardStateMessage boardState = new BoardStateMessage();
            boardState.Pieces = pieceList.ToArray();
            boardState.MessageOrigination = header.MessageOrigination;

            return boardState;
        }


        public static ReadyMessage DeserializeReadyMessage(byte[] result)
        {
            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            Header header = GetHeader(reader);
            byte numOfPiecesInBoard = reader.ReadByte();

            List<Piece> pieceList = new List<Piece>();
            for (int i = 0; i < numOfPiecesInBoard; i++)
            {
                byte[] pieceBytes = reader.ReadBytes(Piece.SerialLength);
                pieceList.Add(Piece.Deserialize(pieceBytes));
            }

            pieceList.ToArray();

            ReadyMessage readyMessage = new ReadyMessage();
            readyMessage.Pieces = pieceList.ToArray();
            readyMessage.MessageOrigination = header.MessageOrigination;

            return readyMessage;
        }

        public static byte[] ToByteArray(ReadyMessage readyMessage)
        {
            throw new NotImplementedException();
        }



        private static Header GetHeader(BinaryReader reader)
        {
            return Header.Deserialize(reader.ReadBytes(Header.SerialLength));
        }
    }
}
