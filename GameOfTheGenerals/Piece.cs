using System;

namespace GameOfTheGenerals
{
    public class Piece
    {
        private Rank _rank;

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

        public bool CanEliminate(Piece piece)
        {
            if (_rank == Rank.Private && piece.Rank == Rank.Spy)
                return true;
            else if (_rank == Rank.Spy && piece.Rank == Rank.Private)
                return false;


            return _rank > piece.Rank;
        }
    }
}