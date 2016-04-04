using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public abstract class MessageWithBoard
    {

        protected Piece[] _pieces;
        protected MessageOrigination _messageOrigination;
        protected byte _turnNumber;
        protected MessageType _messageType;


        public MessageWithBoard()
        {
            _turnNumber = 0;
        }


        public byte GetNumberOfPiecesInBoard()
        {
            byte numOfPieces = 0;

            foreach (Piece piece in _pieces)
                if (piece.Rank != Rank.Empty)
                    numOfPieces++;

            return numOfPieces;
        }

        public Header GetHeader()
        {
            Header header = new Header();

            byte total = GetTotalLengthOfMessage();

            header.MessageLength = total;
            header.MessageOrigination = _messageOrigination;
            header.MessageType = _messageType;
            header.TurnNumber = _turnNumber;

            return header;
        }


        protected abstract byte GetTotalLengthOfMessage();


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

        public MessageOrigination MessageOrigination
        {
            get
            {
                return _messageOrigination;
            }

            set
            {
                _messageOrigination = value;
            }
        }

        public byte TurnNumber
        {
            get
            {
                return _turnNumber;
            }

            set
            {
                _turnNumber = value;
            }
        }

  

    
    }
}
