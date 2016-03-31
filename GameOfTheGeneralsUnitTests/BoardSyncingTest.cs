using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class BoardSyncingTest
    {
        BoardSyncer syncer;
        [TestInitialize]
        public void InitTest()
        {
            syncer = new BoardSyncer();
            syncer.ClientSocket = new MockSocketAdapter();
        }

        [TestMethod]
        public void TheSyncerShouldHaveAClientSocket()
        {
            syncer.ClientSocket = new MockSocketAdapter();
        }

        [TestMethod]
        public void TheSyncerShouldListenToTheClientReadyMessage()
        {
            syncer.ListenForClientsReadyMessage();
        }

    }
}
