using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameOfTheGenerals;

namespace GameOfTheGenerals
{
    internal class SerializerDeserializer
    {
        public static byte[] SerializeBoardStateMessage(BoardStateMessage boardState)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.Serialize(boardState.GetHeader()));
            writer.Write(boardState.GetNumberOfPiecesInBoard());

            foreach (Piece piece in boardState.Pieces)
                writer.Write(Piece.Serialize(piece));

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
            boardState.TurnNumber = header.TurnNumber;

            return boardState;
        }



        public static SetupFailMessage DeserializeSetupFailMessage(byte[] serializedMessage)
        {
            MemoryStream stream = new MemoryStream(serializedMessage);
            BinaryReader reader = new BinaryReader(stream);

            SetupFailMessage message = new SetupFailMessage();

            Header header = GetHeader(reader);
            message.MessageOrigination = header.MessageOrigination;
            message.TurnNumber = header.TurnNumber;

            return message;
        }

        public static byte[] SerializeSetupFailMessage(SetupFailMessage message)
        {
            return SerializeHeaderOnlyMessage(message);
        }

        public static GoodToGoMessage DeserializeGoodToMessage(byte[] serializedMessage)
        {
            MemoryStream stream = new MemoryStream(serializedMessage);
            BinaryReader reader = new BinaryReader(stream);

            GoodToGoMessage message = new GoodToGoMessage();

            Header header = GetHeader(reader);
            message.MessageOrigination = header.MessageOrigination;
            message.TurnNumber = header.TurnNumber;

            return message;
        }

        public static byte[] SerializeGoodToGoMessage(GoodToGoMessage message)
        {
            return SerializeHeaderOnlyMessage(message);
        }


        public static byte[] SerializeRemovePieceMessage(RemovePieceMessage removePiece)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.Serialize(removePiece.GetHeader()));
            writer.Write(Convert.ToByte(removePiece.PieceToBeRemoved));
            writer.Write(Piece.Serialize(removePiece.Piece));

            return stream.ToArray();
        }

        public static MovePieceMessage DeserializeMovePieceMessage(byte[] result)
        {
            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);


            Header header = GetHeader(reader);
            MessageOrigination origination = (MessageOrigination)Enum.ToObject(typeof(MessageOrigination), reader.ReadByte());
            Rank rank = (Rank)Enum.ToObject(typeof(Rank), reader.ReadByte());
            Coordinate fromCoordinate = DeserializeCoordinate(reader.ReadBytes(2));
            Coordinate toCoordinate = DeserializeCoordinate(reader.ReadBytes(2));

            MovePieceMessage message = new MovePieceMessage();
            message.MessageOrigination = origination;
            message.Rank = rank;
            message.FromCoordinate = fromCoordinate;
            message.ToCoordinate = toCoordinate;

            return message;
        }

        public static RemovePieceMessage DeserializeRemovePieceMessage(byte[] serializedMessage)
        {
            MemoryStream stream = new MemoryStream(serializedMessage);
            BinaryReader reader = new BinaryReader(stream);

            Header header = GetHeader(reader);
            PieceToBeRemoved pieceToBeRemoved = (PieceToBeRemoved)reader.ReadByte();
            Piece piece = Piece.Deserialize(reader.ReadBytes(Piece.SerialLength));

            RemovePieceMessage message = new RemovePieceMessage();
            message.MessageOrigination = header.MessageOrigination;
            message.TurnNumber = header.TurnNumber;
            message.Piece = piece;
            message.PieceToBeRemoved = pieceToBeRemoved;

            return message;
        }

        private static Coordinate DeserializeCoordinate(byte[] byteArray)
        {
            Coordinate coordinate = new Coordinate(byteArray[0], byteArray[1]);
            return coordinate;
        }

        public static byte[] SerializeMovePieceMessage(MovePieceMessage movePieceMessage)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.Serialize(movePieceMessage.GetHeader()));
            writer.Write(Convert.ToByte(movePieceMessage.MessageOrigination));
            writer.Write(Convert.ToByte(movePieceMessage.Rank));
            writer.Write(SerializeCoordinate(movePieceMessage.FromCoordinate));
            writer.Write(SerializeCoordinate(movePieceMessage.ToCoordinate));
            

            return stream.ToArray();
        }

        private static byte[] SerializeCoordinate(Coordinate coordinate)
        {
            List<byte> byteArray = new List<byte>();
            byteArray.Add(coordinate.XCoordinate);
            byteArray.Add(coordinate.YCoordinate);
            return byteArray.ToArray();
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

        public static AckMessage DeserializeAckMessage(byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BinaryReader reader = new BinaryReader(stream);

            Header header = GetHeader(reader);
            MovePieceResult result = (MovePieceResult)Enum.ToObject(typeof(MovePieceResult), reader.ReadByte());
            byte numOfPiecesInBoard = reader.ReadByte();

            Piece[] pieces = GetArrayOfPiecesFromReader(reader, numOfPiecesInBoard);

            AckMessage message;
            if (header.MessageType == MessageType.MovePieceAck)
                message = new MovePieceAckMessage();
            else
                message = new RemovePieceAckMessage();

            message.MessageOrigination = header.MessageOrigination;
            message.Pieces = pieces;
            message.Result = result;
            message.TurnNumber = header.TurnNumber;
            return message;
        }

        public static byte[] SerializeAckMessage(AckMessage message)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.Serialize(message.GetHeader()));
            writer.Write(Convert.ToByte(message.Result));
            writer.Write(message.GetNumberOfPiecesInBoard());

            foreach (Piece piece in message.Pieces)
                writer.Write(Piece.Serialize(piece));

            return stream.ToArray();
        }


        private static byte[] SerializeHeaderOnlyMessage(Message message)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Header.Serialize(message.GetHeader()));

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
