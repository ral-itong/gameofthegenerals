using GameOfTheGenerals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TypeMock.ArrangeActAssert;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class GameTests
    {
        Game game;

        [TestInitialize]
        public void initTest()
        {
            game = new Game();
        }

        [TestMethod]
        public void GameShouldBeAbleToListenToClients()
        {
            var mockSocket = new Mock<ISocket>();
            var mockAsyncResult = new Mock<IAsyncResult>();


            mockAsyncResult.Setup(foo => foo.AsyncState).Returns(mockSocket.Object);


            mockSocket.Setup(foo => foo
            .BeginAccept(
                It.IsAny<AsyncCallback>(),
                It.IsAny<ISocket>())
                )
            .Callback<AsyncCallback, ISocket>(
                (asyncCallback, socket) => asyncCallback.Invoke(mockAsyncResult.Object));

            mockSocket.Setup(foo => foo.EndAccept(It.IsAny<IAsyncResult>())).Returns(mockSocket.Object);

            game.HostSocket = mockSocket.Object;
            game.StartGame();
        }

        [TestMethod]
        public void WhenClientSendsReadyMessageToHost_MessageShouldBeDeserializedProperly()
        {
            Mock<IAsyncResult> mockAsyncResult = GetMockAsyncResultWithReadyMessage();
            game.PopulateBoardWithClientPieces(mockAsyncResult.Object);
            CollectionAssert.AreEqual(GetReadyMessage().Pieces, game.Pieces.ToArray());
        }

        [TestMethod]
        [Ignore]
        public void WhenHostSendsReadyMessageToHost_MessageShouldBeAValidReadyMessage()
        {

            game.Pieces.Add(GetPiece(Rank.BrigadierGeneral, PieceOwner.Host, new Coordinate(3, 3)));
            var mockTcpUtil = new Mock<ITcpUtil>();


            game.SendClientReadyMessage();



            //mockTcpUtil.Verify(foo => foo.Send(
            //It.IsAny<ISocket>(),
            //It.IsAny<AsyncCallback>(),
            //It.Is<byte[]>(data => data.Equals())
            //);


        }

        [TestMethod]
        [Ignore]
        public void WhenClientSendsBoardStateMessage_WhenTwoBoardStatesMatchClientMovePieceShouldBeCalled()
        {
            var mockGame = Isolate.Fake.Instance<Game>();

            BoardStateMessage message = new BoardStateMessage();
            List<Piece> pieceList = new List<Piece>();
            pieceList.Add(GetPiece(Rank.Captain, PieceOwner.Client, new Coordinate(2, 2)));
            pieceList.Add(GetPiece(Rank.Private, PieceOwner.Host, new Coordinate(2, 2)));
            message.MessageOrigination = MessageOrigination.Client;
            message.Pieces = pieceList.ToArray();
            

            StateObject state = new StateObject();
            state.buffer = BoardStateMessage.Serialize(message);

            mockGame.Pieces = pieceList;

            var mockAsyncResult = Isolate.Fake.Instance<IAsyncResult>();
            Isolate.WhenCalled(() => mockAsyncResult.AsyncState).WillReturn(state);
            mockGame.CheckIfBoardStateMatch(mockAsyncResult);

            Isolate.Verify.WasCalledWithAnyArguments(() => mockGame.StartMovePieceSequence());

        }

        [TestMethod]
        public void WhenHostSendsMovePieceMessage_TheHostShouldWaitForMovePieceAckMessageFromTheClient()
        {
            var mockGame = new Mock<Game>();
            //mockGame.Object.SendToClientMovePieceMessage();

        }
        [TestMethod]
        [Ignore]
        public void WhenHostReceivesTheMovePieceAckMessage_ItShouldSendARemovePieceMessage()
        {

        }

        [TestMethod]
        [Ignore]
        public void WhenHostReceivesTheRemovePieceAckMessage_ItShouldWaitForAMovePieceMessage()
        {

        }

        [TestMethod]
        [Ignore]
        public void WhenHostReceivesTheMovePieceMessage_ItShouldSendMovePieceAckMessage()
        {

        }

        [TestMethod]
        [Ignore]
        public void AfterHostSentAMovePieceMessage_ItShouldCheckForOverlappingPiece()
        {

        }

        [TestMethod]
        [Ignore]
        public void IfThereIsAnOverlappingPiece_HostShouldSendARemovePieceMessage()
        {

        }

        [TestMethod]
        [Ignore]
        public void AfterClientSentARemovePieceAckMessage_HostShouldStartTheMoveSequenceAgain()
        {

        }

        private static Mock<IAsyncResult> GetMockAsyncResultWithReadyMessage()
        {
            var mockAsyncResult = new Mock<IAsyncResult>();
            StateObject state = new StateObject();
            ReadyMessage message = GetReadyMessage();
            state.buffer = ReadyMessage.Serialize(message);
            mockAsyncResult.Setup(foo => foo.AsyncState).Returns(state);
            return mockAsyncResult;
        }

        private static ReadyMessage GetReadyMessage()
        {
            ReadyMessage message = new ReadyMessage();
            Piece piece = GetPiece(Rank.Captain, PieceOwner.Client, new Coordinate(2, 2));
            message.Pieces = new Piece[] { piece };
            return message;
        }

        private static Piece GetPiece(Rank rank, PieceOwner pieceOwner, Coordinate coordinate)
        {
            Piece piece = new Piece(rank, pieceOwner);
            piece.Coordinate = coordinate;
            return piece;

        }
    }
}
