using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;
using System.Net.Sockets;
using System.Threading;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class HostSetupTest
    {

        ClientListener hostSocket;


        [TestInitialize]
        public void InitTest()
        {
            hostSocket = new ClientListener();
        }


        [TestMethod]
        public void ThereShouldBeAStateObject()
        {
            StateObject stateObject = new StateObject();
        }

        [TestMethod]
        public void ThereShouldBeClassThatEstablishesTheHost()
        {
            hostSocket = new ClientListener();
        }

        [TestMethod]
        [Ignore]
        public void WhenHostSocketListens_ItShouldBeAbleToListenAtPort_10801()
        {
            hostSocket.StartListening();
        }

        [TestMethod]
        public void WhenAClientConnectsToTheHost_TheSocketShouldBeStoredInTheHost()
        {
            MockAsyncResult result = CreateMockAsyncRsult();
            hostSocket.OtherPlayerSocketAdapter = GetMockSocketAdapter();
            hostSocket.AcceptCallBack(result);
            Assert.IsNotNull(hostSocket.OtherPlayerSocketAdapter);
        }


        [TestMethod]
        public void WhenAClientConnectsToTheHost_TheLockSetInHostShouldBeUnlocked()
        {
            MockAsyncResult result = CreateMockAsyncRsult();
            hostSocket.OtherPlayerConnected = new ManualResetEvent(false);
            hostSocket.OtherPlayerSocketAdapter = GetMockSocketAdapter();


            hostSocket.AcceptCallBack(result);

            Assert.AreEqual(true, hostSocket.OtherPlayerConnected.WaitOne(0));
        }

        private static MockAsyncResult CreateMockAsyncRsult()
        {
            MockAsyncResult result = new MockAsyncResult();
            MockSocketAdapter expectedSocket = GetMockSocketAdapter();
            result.FakeAsyncState = expectedSocket;
            return result;
        }

        private static MockSocketAdapter GetMockSocketAdapter()
        {
            return new MockSocketAdapter(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
