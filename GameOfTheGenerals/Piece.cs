using System;
using System.IO;

namespace GameOfTheGenerals
{
    public class Piece
    {
        private Rank _rank;
        private byte _xCoordinate;
        private byte _yCoordinate;


        public Piece()
        {

        }

        public Piece(Rank rank)
        {
            this._rank = rank;
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

        public bool CanEliminate(Piece piece)
        {
            if (_rank == Rank.Private && piece.Rank == Rank.Spy)
                return true;
            else if (_rank == Rank.Spy && piece.Rank == Rank.Private)
                return false;


            return _rank > piece.Rank;
        }

        public byte[] ToArray()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write((byte)_rank);
            writer.Write(this.XCoordinate);
            writer.Write(this.YCoordinate);

            return stream.ToArray();

        }
    }
}