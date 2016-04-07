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
            Piece.Serialize(piece);
        }


        [TestMethod]
        public void APieceShouldHaveADeserializer()
        {
            Piece piece = GetPiece();
            byte[] pieceByteArray = Piece.Serialize(piece);
            Piece deserializedPeace = Piece.Deserialize(pieceByteArray);

            Assert.AreEqual(piece.PieceOwner, deserializedPeace.PieceOwner);
            Assert.AreEqual(piece.Rank, deserializedPeace.Rank);
            Assert.AreEqual(piece.Coordinate, deserializedPeace.Coordinate);
        }

        [TestMethod]
        public void APieceByteArraySerialized_ShouldHaveTheLengthOfFour()
        {
            Piece piece = new Piece(Rank.Private, PieceOwner.Client);
            piece.Coordinate = new Coordinate(11, 12);

            byte[] pieceByteArray = Piece.Serialize(piece);

            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(pieceByteArray);

            Assert.AreEqual(4, stream.ToArray().Length);
        }
        
        [TestMethod]
        public void AHeaderShouldBeSerialized_WithALengthOfEightBytes()
        {
            Header header = new Header();
            header.MessageLength = 9;
            header.MessageOrigination = MessageOrigination.Client;
            header.MessageType = MessageType.Ready;
            header.TurnNumber = 0;

            byte[] result = Header.Serialize(header);
            Assert.AreEqual(result.Length, 8);
        }

        [TestMethod]
        public void AHeaderShouldBeDeserializedProperly()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add(0xAA);
            byteList.Add(0xAA);

            byteList.Add(0x06);
            byteList.Add(0x00);

            byteList.Add(0x00);
            byteList.Add(0x01);

            byteList.Add(0x04);
            byteList.Add(0x00);

            Header result = Header.Deserialize(byteList.ToArray());

            Assert.AreEqual(6, result.MessageLength);
            Assert.AreEqual(MessageOrigination.Host, result.MessageOrigination);
            Assert.AreEqual(MessageType.Ready, result.MessageType);
            Assert.AreEqual(4, result.TurnNumber);
        }


        [TestMethod]
        public void MessageLengthOfBoardState_ShouldEqualTheLengthOfSerializedBoardState()
        {
            BoardStateMessage boardState = GetBoardStateMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            Header header = ExtractHeaderFromByteArray(result);

            Assert.AreEqual(result.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenBoardStateIsDeserialized_TurnNumberAndPiecesShouldBeTheSame()
        {
            BoardStateMessage boardState = GetBoardStateMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            BoardStateMessage deserializedBoardState = BoardStateMessage.Deserialize(result);


            CollectionAssert.AreEqual(boardState.Pieces, deserializedBoardState.Pieces);
            Assert.AreEqual(boardState.GetHeader(), deserializedBoardState.GetHeader());
        }

        [TestMethod]
        public void MessageLengthOfReadyMessage_ShouldEqualLengthOfSerializedReadyMessage()
        {
            ReadyMessage boardState = GetReadyMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            Header header = ExtractHeaderFromByteArray(result);

            Assert.AreEqual(result.Length, header.MessageLength);
        }

        [TestMethod]
        public void ReadyMessageWhenSerialized_ShouldHaveReadyAsItsMessageType()
        {
            ReadyMessage boardState = GetReadyMessage();
            byte[] result = BoardStateMessage.ToByteArray(boardState);

            Header header = ExtractHeaderFromByteArray(result);

            Assert.AreEqual(MessageType.Ready, header.MessageType);
        }

        [TestMethod]
        public void WhenMovePieceAckMessageIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            MovePieceAckMessage message = GetMovePieceAckMessage();
            byte[] result = AckMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(result);
            Assert.AreEqual(result.Length, header.MessageLength);
        }


        [TestMethod]
        public void WhenMovePieceAckIsDeserialized_ThePropertiesShouldBeIntact()
        {
            MovePieceAckMessage message = GetMovePieceAckMessage();
            byte[] serializedMessage = AckMessage.Serialize(message);
            AckMessage deserializedMessage = AckMessage.Deserialize(serializedMessage);

            CollectionAssert.AreEqual(message.Pieces, deserializedMessage.Pieces);
            Assert.AreEqual(message.GetHeader(), deserializedMessage.GetHeader());
            Assert.AreEqual(message.Result, deserializedMessage.Result);
        }

        [TestMethod]
        public void WhenRemovePieceAckIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            RemovePieceAckMessage message = GetRemovePieceAckMessage();
            byte[] result = AckMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(result);
            Assert.AreEqual(result.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenRemovePieceAckIsDeserialized_ThePropertiesShouldBeIntact()
        {
            RemovePieceAckMessage message = GetRemovePieceAckMessage();
            byte[] serializedMessage = AckMessage.Serialize(message);
            AckMessage deserializedMessage = AckMessage.Deserialize(serializedMessage);

            CollectionAssert.AreEqual(message.Pieces, deserializedMessage.Pieces);
            Assert.AreEqual(message.GetHeader(), deserializedMessage.GetHeader());
            Assert.AreEqual(message.Result, deserializedMessage.Result);
        }

        [TestMethod]
        public void WhenMovePieceMessageIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            MovePieceMessage message = GetMovePieceMessage();
            byte[] serializedMessage = MovePieceMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(serializedMessage);
            Assert.AreEqual(serializedMessage.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenMovePieceIsDeserialized_ThePropertiesShouldBeIntact()
        {
            MovePieceMessage message = GetMovePieceMessage();
            byte[] serializedMessage = MovePieceMessage.Serialize(message);
            MovePieceMessage deserializedMessage = MovePieceMessage.Deserialize(serializedMessage);

            Assert.AreEqual(message.FromCoordinate, deserializedMessage.FromCoordinate);
            Assert.AreEqual(message.ToCoordinate, deserializedMessage.ToCoordinate);
            Assert.AreEqual(message.MessageOrigination, deserializedMessage.MessageOrigination);
            Assert.AreEqual(message.Rank, deserializedMessage.Rank);
        }

        [TestMethod]
        public void WhenRemovePieceIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            RemovePieceMessage message = GetRemovePieceMessage();
            byte[] serializedMessage = RemovePieceMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(serializedMessage);
            Assert.AreEqual(serializedMessage.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenRemovePieceIsDeserialized_ThePropertiesShouldBeIntact()
        {
            RemovePieceMessage message = GetRemovePieceMessage();
            byte[] serializedMessage = RemovePieceMessage.Serialize(message);
            RemovePieceMessage deserializedMessage = RemovePieceMessage.Deserialize(serializedMessage);

            Assert.AreEqual(message.GetHeader(), deserializedMessage.GetHeader());
            Assert.AreEqual(message.Piece, deserializedMessage.Piece);
            Assert.AreEqual(message.PieceToBeRemoved, deserializedMessage.PieceToBeRemoved);
        }

        [TestMethod]
        public void WhenSetupFailMessageIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            SetupFailMessage message = GetSetupFailMessage();
            byte[] serializedMessage = SetupFailMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(serializedMessage);
            Assert.AreEqual(serializedMessage.Length, header.MessageLength);
        }

        [TestMethod]
        public void WhenSetupFailMessageIsDeserialized_ThePropertiesShouldRemainIntact()
        {
            SetupFailMessage message = GetSetupFailMessage();
            byte[] serializedMessage = SetupFailMessage.Serialize(message);
            SetupFailMessage deserializedMessage = SetupFailMessage.Deserialize(serializedMessage);

            Assert.AreEqual(message.GetHeader(), deserializedMessage.GetHeader());
        }

        [TestMethod]
        public void WhenGoodToGoMessageIsSerialized_TheHeaderLengthShouldBeEqualToTheLengthOfTheByteArray()
        {
            GoodToGoMessage message = GetGoodToGoMessage();
            byte[] serializedMessage = GoodToGoMessage.Serialize(message);

            Header header = ExtractHeaderFromByteArray(serializedMessage);
            Assert.AreEqual(serializedMessage.Length, header.MessageLength);
        }


        [TestMethod]
        public void WhenGoodToGoMessageIsDeserialized_ThePropertiesShouldRemainIntact()
        {
            GoodToGoMessage message = GetGoodToGoMessage();
            byte[] serializedMessage = GoodToGoMessage.Serialize(message);
            GoodToGoMessage deserializedMessage = GoodToGoMessage.Deserialize(serializedMessage);

            Assert.AreEqual(message.GetHeader(), deserializedMessage.GetHeader());
        }

        private GoodToGoMessage GetGoodToGoMessage()
        {
            GoodToGoMessage message = new GoodToGoMessage();
            message.MessageOrigination = MessageOrigination.Client;
            message.TurnNumber = 23;

            return message;
        }

        private SetupFailMessage GetSetupFailMessage()
        {
            SetupFailMessage message = new SetupFailMessage();
            message.MessageOrigination = MessageOrigination.Client;
            message.TurnNumber = 24;

            return message;
        }

        private RemovePieceMessage GetRemovePieceMessage()
        {
            RemovePieceMessage message = new RemovePieceMessage();
            message.MessageOrigination = MessageOrigination.Host;
            message.Piece = GetPiece();
            message.PieceToBeRemoved = PieceToBeRemoved.Yes;
            message.TurnNumber = 23;

            return message;
        }

        private MovePieceMessage GetMovePieceMessage()
        {
            MovePieceMessage message = new MovePieceMessage();
            message.FromCoordinate = new Coordinate(2, 3);
            message.ToCoordinate = new Coordinate(4, 6);
            message.Rank = Rank.Captain;
            message.TurnNumber = 23;
            message.MessageOrigination = MessageOrigination.Host;

            return message;
        }

        private static Header ExtractHeaderFromByteArray(byte[] result)
        {
            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            byte[] headerBytes = reader.ReadBytes(Header.SerialLength);
            Header header = Header.Deserialize(headerBytes);
            return header;
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

        private RemovePieceAckMessage GetRemovePieceAckMessage()
        {
            RemovePieceAckMessage message = new RemovePieceAckMessage();
            message.MessageOrigination = MessageOrigination.Host;
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
            pieceOne.Coordinate = new Coordinate(2, 3);

            Piece pieceTwo = new Piece(Rank.Sergeant, PieceOwner.Client);
            pieceTwo.Coordinate = new Coordinate(5, 5);

            Piece[] pieceArray = new Piece[2];
            pieceArray[0] = pieceOne;
            pieceArray[1] = pieceTwo;
            return pieceArray;
        }

        private static Piece GetPiece()
        {
            Piece piece = new Piece(Rank.BrigadierGeneral, PieceOwner.Client);
            piece.Coordinate = new Coordinate(10, 10);
            return piece;
        }

    }
}
