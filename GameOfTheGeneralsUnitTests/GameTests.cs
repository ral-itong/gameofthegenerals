using GameOfTheGenerals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            game.ListenToClients();
        }


    }
}
