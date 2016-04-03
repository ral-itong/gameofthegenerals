using System;
using System.IO;

namespace GameOfTheGenerals
{
    public class Piece
    {
        private byte _xCoordinate;
        private byte _yCoordinate;
        private PieceOwner _pieceOwner;
        private Rank _rank;


        public Piece()
        {

        }

        public Piece(Rank rank)
        {
            this._rank = rank;
        }

        public bool CanEliminate(Piece piece)
        {
            if (_rank == Rank.Private && piece.Rank == Rank.Spy)
                return true;
            else if (_rank == Rank.Spy && piece.Rank == Rank.Private)
                return false;


            return _rank > piece.Rank;
        }

        public byte[] ToByteArray()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(Convert.ToByte(_xCoordinate));
            writer.Write(Convert.ToByte(_yCoordinate));
            writer.Write(Convert.ToByte(_pieceOwner));
            writer.Write(Convert.ToByte(_rank));

            return stream.ToArray();

        }

        public Rank Rank
        {
            get
            {
                return _rank;
            }

            set
            {
                _rank = value;
            }
        }

        public byte XCoordinate
        {
            get
            {
                return _xCoordinate;
            }

            set
            {
                _xCoordinate = value;
            }
        }

        public byte YCoordinate
        {
            get
            {
                return _yCoordinate;
            }

            set
            {
                _yCoordinate = value;
            }
        }

        public PieceOwner PieceOwner
        {
            get
            {
                return _pieceOwner;
            }

            set
            {
                _pieceOwner = value;
            }
        }


    }
}