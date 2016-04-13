using GameOfTheGenerals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameShouldBeAbleToListenToClients()
        {
            Game game = new Game();

            var mockSocket = new Mock<ISocket>();
            var mockAsyncResult = new Mock<IAsyncResult>();
            var mockTcpUtil = new Mock<TcpUtil>();
            

            mockAsyncResult.Setup(foo => foo.AsyncState).Returns(mockSocket.Object);
            mockSocket.Setup(foo => foo
            .BeginAccept(
                It.IsAny<AsyncCallback>(),
                It.IsAny<ISocket>())
                )
            .Callback<AsyncCallback, ISocket >(
                (asyncCallback, socket) => asyncCallback.Invoke(mockAsyncResult.Object));

            game.HostSocket = mockSocket.Object;
            game.StartGame();
        }


    }
}
