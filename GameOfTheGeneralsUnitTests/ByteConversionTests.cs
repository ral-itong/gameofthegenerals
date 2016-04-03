using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfTheGenerals;
using System.IO;

namespace GameOfTheGeneralsUnitTests
{
    [TestClass]
    public class ByteConversionTests
    {
        [TestMethod]
        public void PieceShouldBeShouldHaveAByteConverter()
        {
            Piece piece = new Piece(Rank.BrigadierGeneral);
            piece.XCoordinate = 10;
            piece.YCoordinate = 10;
            
            piece.ToByteArray();
        }

        [TestMethod]
        public void WhenWritingABoardPieceArray()
        {
            Piece piece = new Piece(Rank.Private);
            piece.XCoordinate = 11;
            piece.YCoordinate = 12;
            piece.PieceOwner = PieceOwner.Client;

            byte[] pieceByteArray = piece.ToByteArray();

            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(pieceByteArray);

            Assert.AreEqual(4, stream.ToArray().Length);

        }

    }
}
