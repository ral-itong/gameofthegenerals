using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class BoardState
    {
        private MessageType _headerType = MessageType.BoardState;
        private Piece[] _pieces;


        public byte[] ToByteArray()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Convert.ToByte(_headerType));
            writer.Write(GetNumberOfPiecesInBoard());
            foreach (Piece piece in _pieces)
                writer.Write(Piece.ToByteArray(piece));

            return stream.ToArray();
        }

        private byte GetNumberOfPiecesInBoard()
        {
            byte numOfPieces = 0;

            foreach (Piece piece in _pieces)
                if (piece.Rank != Rank.Empty)
                    numOfPieces++;

            return numOfPieces;
        }

        public Piece[] Pieces
        {
            get
            {
                return _pieces;
            }

            set
            {
                _pieces = value;
            }
        }
    }
}
