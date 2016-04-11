using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;
using Moq;
using System.Net.Sockets;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class BoardSyncingTest
    {
        [TestInitialize]
        public void InitTest()
        {

        }

      
        [TestMethod]
        public void WhenBoardSyncReadCallbackIsCalledSetEventShouldBeCalled()
        {
            Mock<IManualResetEvent> resetEvent = CreateMockManualResetEvent();
            BoardSyncReadCallback readCallback = CreateMockBoardSyncReadCallback(resetEvent);
            var mockSocket = new Mock<ISocket>();

            StateObject stateObject = CreateMockStateObject(mockSocket);
            Mock<IAsyncResult> mockResult = CreateMockAsyncResult(stateObject);

            mockSocket.Setup(foo =>
            foo.BeginReceive(It.IsAny<byte[]>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<SocketFlags>(),
            It.IsAny<AsyncCallback>(),
            It.IsAny<Object>()))
            .Callback<byte[], int, int, SocketFlags, AsyncCallback, Object>(
                (buffer, offset, size, socketFlags, callback, state) =>

                callback.Invoke(mockResult.Object)
            );

            mockSocket.Setup(foo => foo.EndReceive(It.IsAny<IAsyncResult>())).Returns(0);

            TcpListenerSender.Listen(readCallback, mockSocket.Object);
            
            resetEvent.Verify(foo => foo.Set(), Times.AtLeastOnce());
        }

       
        private static Mock<IAsyncResult> CreateMockAsyncResult(StateObject stateObject)
        {
            var mockResult = new Mock<IAsyncResult>();
            mockResult.Setup(foo => foo.AsyncState).Returns(stateObject);
            return mockResult;
        }

        private static StateObject CreateMockStateObject(Mock<ISocket> mockSocket)
        {
            StateObject stateObject = new StateObject();
            stateObject.workSocket = mockSocket.Object;
            return stateObject;
        }

        private static BoardSyncReadCallback CreateMockBoardSyncReadCallback(Mock<IManualResetEvent> resetEvent)
        {
            BoardSyncReadCallback readCallback = new BoardSyncReadCallback();
            readCallback.ResetEvent = resetEvent.Object;
            return readCallback;
        }

        private static Mock<IManualResetEvent> CreateMockManualResetEvent()
        {
            return new Mock<IManualResetEvent>();
        }
    }
}
