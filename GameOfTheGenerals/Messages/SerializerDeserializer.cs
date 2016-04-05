using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    internal class SerializerDeserializer
    {
        public static byte[] SerializeBoardStateMessage(BoardStateMessage boardState)
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
            Piece[] pieces = GetArrayOfPiecesFromReader(reader, numOfPiecesInBoard);

            BoardStateMessage boardState = new BoardStateMessage();
            boardState.Pieces = pieces;
            boardState.MessageOrigination = header.MessageOrigination;

            return boardState;
        }


        public static ReadyMessage DeserializeReadyMessage(byte[] result)
        {
            BoardStateMessage message = DeserializeBoardStateMessage(result);
            ReadyMessage readyMessage = new ReadyMessage();
            readyMessage.MessageOrigination = message.MessageOrigination;
            readyMessage.Pieces = message.Pieces;
            readyMessage.TurnNumber = message.TurnNumber;

            return readyMessage;
        }

        public static byte[] SerializeReadyMessage(ReadyMessage readyMessage)
        {
            return SerializeBoardStateMessage(readyMessage);
        }

        public static MovePieceAckMessage DeserializeMovePieceAckMessage(byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BinaryReader reader = new BinaryReader(stream);

            Header header = GetHeader(reader);
            MovePieceResult result = (MovePieceResult)Enum.ToObject(typeof(MovePieceResult), reader.ReadByte());
            byte numOfPiecesInBoard = reader.ReadByte();

            Piece[] pieces = GetArrayOfPiecesFromReader(reader, numOfPiecesInBoard);

            MovePieceAckMessage message = new MovePieceAckMessage();
            message.MessageOrigination = header.MessageOrigination;
            message.Pieces = pieces;
            message.Result = result;
            message.TurnNumber = header.TurnNumber;

            return message;
        }

        public static byte[] SerializeMovePieceAckMessage(MovePieceAckMessage message)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.ToByteArray(message.GetHeader()));
            writer.Write(Convert.ToByte(message.Result));
            writer.Write(message.GetNumberOfPiecesInBoard());

            foreach (Piece piece in message.Pieces)
                writer.Write(Piece.ToByteArray(piece));

            return stream.ToArray();
        }
        

        private static Header GetHeader(BinaryReader reader)
        {
            return Header.Deserialize(reader.ReadBytes(Header.SerialLength));
        }

        private static Piece[] GetArrayOfPiecesFromReader(BinaryReader reader, byte numOfPiecesInBoard)
        {
            List<Piece> pieceList = new List<Piece>();
            for (int i = 0; i < numOfPiecesInBoard; i++)
            {
                byte[] pieceBytes = reader.ReadBytes(Piece.SerialLength);
                pieceList.Add(Piece.Deserialize(pieceBytes));
            }

            return pieceList.ToArray();
        }
    }
}
