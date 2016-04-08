using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class BoardSyncingTest
    {
        ClientReader syncer;
        [TestInitialize]
        public void InitTest()
        {
            syncer = new ClientReader(new BoardSyncReadCallback(), new MockSocketAdapter());

        }

  

        [TestMethod]
        public void TheSyncerShouldListenToTheClientReadyMessage()
        {
            syncer.ListenForClientsReadyMessage();
        }

    }
}
