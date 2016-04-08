using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class BoardStateUtil
    {
        public static byte GetNumberOfPiecesInBoard(Piece[] pieces)
        {
            byte numOfPieces = 0;

            foreach (Piece piece in pieces)
                if (piece.Rank != Rank.Empty)
                    numOfPieces++;

            return numOfPieces;
        }

        public static short GetTotalLengthOfBoardStateMessage(int numberOfPieces)
        {
            byte lengthOfPieces = Convert.ToByte(Piece.SerialLength * numberOfPieces);
            short lengthOfHeader = Header.SerialLength;
            byte numOfPiecesInBoard = 1;

            short total = Convert.ToByte((lengthOfPieces + lengthOfHeader + numOfPiecesInBoard));
            return total;
        }
    }
}
