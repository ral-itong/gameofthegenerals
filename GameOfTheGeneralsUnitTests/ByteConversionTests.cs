using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;
using System.IO;
using System.Collections.Generic;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class ByteConversionTests
    {
        [TestMethod]
        public void PieceShouldBeShouldHaveAByteConverter()
        {
            Piece piece = GetPiece();
            Piece.ToByteArray(piece);
        }


        [TestMethod]
        public void APieceShouldHaveADeserializer()
        {
            Piece piece = GetPiece();
            byte[] pieceByteArray = Piece.ToByteArray(piece);
            Piece deserializedPeace = Piece.Deserialize(pieceByteArray);

            Assert.AreEqual(piece.PieceOwner, deserializedPeace.PieceOwner);
            Assert.AreEqual(piece.Rank, deserializedPeace.Rank);
            Assert.AreEqual(piece.XCoordinate, deserializedPeace.XCoordinate);
            Assert.AreEqual(piece.YCoordinate, deserializedPeace.YCoordinate);
        }

        [TestMethod]
        public void APieceByteArraySerialized_ShouldHaveTheLengthOfFour()
        {
            Piece piece = new Piece(Rank.Private, PieceOwner.Client);
            piece.XCoordinate = 11;
            piece.YCoordinate = 12;

            byte[] pieceByteArray = Piece.ToByteArray(piece);

            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(pieceByteArray);

            Assert.AreEqual(4, stream.ToArray().Length);
        }
        
        
        [TestMethod]
        public void AHeaderShouldBeSerialized_WithALengthOfSixBytes()
        {
            Header header = new Header();
            header.MessageLength = 6;
            header.MessageOrigination = MessageOrigination.Client;
            header.MessageType = MessageType.Ready;
            header.TurnNumber = 0;

            byte[] result = Header.ToByteArray(header);
            Assert.AreEqual(result.Length, 6);
        }

        [TestMethod]
        public void AHeaderShouldBeDeserializedProperly()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add(0xAA);
            byteList.Add(0xAA);
            byteList.Add(0x06);
            byteList.Add(0x00);
            byteList.Add(0x01);
            byteList.Add(0x00);

            Header result = Header.Deserialize(byteList.ToArray());

            Assert.AreEqual(6, result.MessageLength);
            Assert.AreEqual(MessageOrigination.Host, result.MessageOrigination);
            Assert.AreEqual(MessageType.Ready, result.MessageType);
            Assert.AreEqual(0, result.TurnNumber);
        }


        [TestMethod]
        public void MessageLengthOfBoardState_ShouldEqualTheLengthOfSerializedBoardState()
        {
            BoardStateMessage boardState = GetBoardStateMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            byte[] headerBytes = reader.ReadBytes(Header.SerialLength);
            Header header = Header.Deserialize(headerBytes);

            Assert.AreEqual(result.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenBoardStateIsDeserialized_TurnNumberAndPiecesShouldBeTheSame()
        {
            BoardStateMessage boardState = GetBoardStateMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            BoardStateMessage deserializedBoardState = BoardStateMessage.Deserialize(result);

            Assert.AreEqual(boardState.MessageOrigination, deserializedBoardState.MessageOrigination);

            CollectionAssert.AreEqual(boardState.Pieces, deserializedBoardState.Pieces);
            Assert.AreEqual(boardState.TurnNumber, deserializedBoardState.TurnNumber);
        }

        [TestMethod]
        public void MessageLengthOfReadyMessage_ShouldEqualLengthOfSerializedReadyMessage()
        {
            ReadyMessage boardState = GetReadyMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            byte[] headerBytes = reader.ReadBytes(Header.SerialLength);
            Header header = Header.Deserialize(headerBytes);

            Assert.AreEqual(result.Length, header.MessageLength);
        }

        [TestMethod]
        public void ReadyMessageWhenSerialized_ShouldHaveReadyAsItsMessageType()
        {
            ReadyMessage boardState = GetReadyMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            byte[] headerBytes = reader.ReadBytes(Header.SerialLength);
            Header header = Header.Deserialize(headerBytes);

            Assert.AreEqual(MessageType.Ready, header.MessageType);
        }

        [TestMethod]
        public void WhenMovePieceAckMessageIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            MovePieceAckMessage message = GetMovePieceAckMessage();
            byte[] result = MovePieceAckMessage.Serialize(message);

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            byte[] headerBytes = reader.ReadBytes(Header.SerialLength);
            Header header = Header.Deserialize(headerBytes);

            Assert.AreEqual(result.Length, header.MessageLength);
        }



        private MovePieceAckMessage GetMovePieceAckMessage()
        {
            MovePieceAckMessage message = new MovePieceAckMessage();
            message.MessageOrigination = MessageOrigination.Client;
            message.Pieces = GetPiecesArray();
            message.Result = MovePieceResult.Sucessful;
            message.TurnNumber = 22;

            return message;
        }

        private static BoardStateMessage GetBoardStateMessage()
        {
            BoardStateMessage boardState = new BoardStateMessage();
            boardState.MessageOrigination = MessageOrigination.Client;

            boardState.Pieces = GetPiecesArray();
            return boardState;
        }


        private static ReadyMessage GetReadyMessage()
        {
            ReadyMessage readyMessage = new ReadyMessage();
            readyMessage.MessageOrigination = MessageOrigination.Client;
            Piece[] pieceArray = GetPiecesArray();

            readyMessage.Pieces = pieceArray;
            return readyMessage;
        }

        private static Piece[] GetPiecesArray()
        {
            Piece pieceOne = new Piece(Rank.Private, PieceOwner.Client);
            pieceOne.XCoordinate = 2;
            pieceOne.YCoordinate = 3;

            Piece pieceTwo = new Piece(Rank.Sergeant, PieceOwner.Client);
            pieceTwo.XCoordinate = 5;
            pieceTwo.YCoordinate = 5;

            Piece[] pieceArray = new Piece[2];
            pieceArray[0] = pieceOne;
            pieceArray[1] = pieceTwo;
            return pieceArray;
        }

        private static Piece GetPiece()
        {
            Piece piece = new Piece(Rank.BrigadierGeneral, PieceOwner.Client);
            piece.XCoordinate = 10;
            piece.YCoordinate = 10;
            return piece;
        }

    }
}
