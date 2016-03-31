using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;


namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class GameOfTheGeneralUnitTests
    {
        Piece piece;
        Player game;

        [TestInitialize]
        public void InitTest()
        {
            piece = new Piece();
            game = new Player();
        }

        [TestMethod]
        public void ThereShouldBeAGameClass()
        {
        }

        [TestMethod()]
        public void ThereShouldBeAnEnumOfRanks()
        {
            Assert.AreEqual(15, Enum.GetNames(typeof(Rank)).Length);
        }


        [TestMethod()]
        public void PieceShouldHaveACanEliminateMethod()
        {
            piece.CanEliminate(piece);
        }

        [TestMethod()]
        public void WhenAPrivateEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.Private;

            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
        }

        [TestMethod()]
        public void PrivateShouldEliminateASpy()
        {
            piece.Rank = Rank.Private;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void PrivateShouldBeAbleToEliminateAFlag()
        {
            piece.Rank = Rank.Private;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }


        [TestMethod()]
        public void WhenASergeantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.Sergeant;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
        }

        [TestMethod()]
        public void ASergeantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.Sergeant;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenASecondLieutenantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.SecondLieutenant;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void ASecondLieutenantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.SecondLieutenant;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }


        [TestMethod()]
        public void WhenAFirstLieutenantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.FirstLieutenant;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AFirstLieutenantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.FirstLieutenant;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenACaptainEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.Captain;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void ACaptainShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.Captain;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAMajorEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.Major;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AMajorShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.Major;
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenALieutenantColonelEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.LieutenantColonel;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void ALieutenantColonelShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.LieutenantColonel;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAColonelEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.Colonel;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AColonelShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.Colonel;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }



        [TestMethod()]
        public void WhenABrigadierGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.BrigadierGeneral;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void ABrigadierGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.BrigadierGeneral;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAMajorGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.MajorGeneral;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AMajorGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.MajorGeneral;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenALieutenantGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.LieutenantGeneral;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void ALieutenantGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.LieutenantGeneral;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.General;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.General;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAGeneralOfTheArmyEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece.Rank = Rank.General;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Spy)));
        }

        [TestMethod()]
        public void AGeneralOfTheArmyShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece.Rank = Rank.GeneralOfTheArmy;

            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.General)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(new Piece(Rank.Flag)));
        }

        [TestMethod]
        public void ASpyShouldNotBeAbleToEliminateAPrivate()
        {
            piece.Rank = Rank.Spy;
            Assert.AreEqual(false, piece.CanEliminate(new Piece(Rank.Private)));
        }

        [TestMethod]
        [Ignore]
        public void TheGameShouldHave8by9Array()
        {

        }




    }
}
