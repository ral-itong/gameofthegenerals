using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public abstract class MessageWithBoard
    {

        private Piece[] _pieces;
        private MessageOrigination _messageOrigination;
        private byte _turnNumber;
        private MessageType _messageType;


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
            header.MessageType = MessageType;
            header.TurnNumber = _turnNumber;

            return header;
        }


        public abstract byte GetTotalLengthOfMessage();

        protected byte GetLengthOfHeaderLengthOfPieceAndNumberOfPieces()
        {
            byte lengthOfPieces = Convert.ToByte(Piece.SerialLength * Pieces.Length);
            byte lengthOfHeader = Header.SerialLength;
            byte numOfPiecesInBoard = 1;

            byte total = Convert.ToByte((lengthOfPieces + lengthOfHeader + numOfPiecesInBoard));
            return total;
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

        protected MessageType MessageType
        {
            get
            {
                return _messageType;
            }

            set
            {
                _messageType = value;
            }
        }
    }
}
