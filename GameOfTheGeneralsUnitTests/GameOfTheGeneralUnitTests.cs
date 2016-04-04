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
            game = new Player();
        }

        [TestMethod]
        public void ThereShouldBeAGameClass()
        {
        }

        [TestMethod()]
        public void ThereShouldBeAnEnumOfRanks()
        {
            Assert.AreEqual(16, Enum.GetNames(typeof(Rank)).Length);
        }


        [TestMethod()]
        public void PieceShouldHaveACanEliminateMethod()
        {
            piece = GetPiece(Rank.Private);
            piece.CanEliminate(piece);
        }

        [TestMethod()]
        public void WhenAPrivateEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.Private);

            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
        }



        [TestMethod()]
        public void PrivateShouldEliminateASpy()
        {
            piece = GetPiece(Rank.Private);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void PrivateShouldBeAbleToEliminateAFlag()
        {
            piece = GetPiece(Rank.Private);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }


        [TestMethod()]
        public void WhenASergeantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.Sergeant);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
        }

        [TestMethod()]
        public void ASergeantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.Sergeant);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenASecondLieutenantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.SecondLieutenant);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void ASecondLieutenantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.SecondLieutenant);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }


        [TestMethod()]
        public void WhenAFirstLieutenantEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.FirstLieutenant);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AFirstLieutenantShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.FirstLieutenant);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenACaptainEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.Captain);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void ACaptainShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.Captain);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAMajorEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.Major);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AMajorShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.Major);
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenALieutenantColonelEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.LieutenantColonel);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void ALieutenantColonelShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.LieutenantColonel);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAColonelEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.Colonel);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AColonelShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.Colonel);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }



        [TestMethod()]
        public void WhenABrigadierGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.BrigadierGeneral);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void ABrigadierGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.BrigadierGeneral);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAMajorGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.MajorGeneral);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AMajorGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.MajorGeneral);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenALieutenantGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.LieutenantGeneral);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void ALieutenantGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.LieutenantGeneral);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAGeneralEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.General);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.GeneralOfTheArmy)));
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AGeneralShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.General);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod()]
        public void WhenAGeneralOfTheArmyEliminatesAPieceHigherThanItself_ItShouldReturnFalse()
        {
            piece = GetPiece(Rank.General);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Spy)));
        }

        [TestMethod()]
        public void AGeneralOfTheArmyShouldBeAbleToEliminatePiecesLowerThanHimself()
        {
            piece = GetPiece(Rank.GeneralOfTheArmy);

            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.General)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.MajorGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.BrigadierGeneral)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Colonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.LieutenantColonel)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Major)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Captain)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.FirstLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.SecondLieutenant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Sergeant)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Private)));
            Assert.AreEqual(true, piece.CanEliminate(GetPiece(Rank.Flag)));
        }

        [TestMethod]
        public void ASpyShouldNotBeAbleToEliminateAPrivate()
        {
            piece = GetPiece(Rank.Spy);
            Assert.AreEqual(false, piece.CanEliminate(GetPiece(Rank.Private)));
        }

        private static Piece GetPiece(Rank rank)
        {
            return new Piece(rank, PieceOwner.Client);
        }

        [TestMethod]
        [Ignore]
        public void TheGameShouldHave8by9Array()
        {

        }




    }
}
