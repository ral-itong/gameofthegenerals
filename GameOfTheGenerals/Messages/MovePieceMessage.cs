using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals {

    public class MovePieceMessage : Message
    {
        private MessageOrigination _origination;
        private byte _turnNumber;
        private Coordinate _fromCoordinate;
        private Coordinate _toCoordinate;
        private Piece _piece;

        public Header GetHeader()
        {
            Header header = new Header();
            header.MessageType = MessageType.MovePiece;
            header.MessageOrigination = _origination;
            header.TurnNumber = _turnNumber;

            return header;
        }

        public byte[] ToByteArray()
        {
            return SerializerDeserializer.SerializeMovePieceMessage(this);
        }

        public MessageOrigination Origination
        {
            get
            {
                return _origination;
            }

            set
            {
                _origination = value;
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

        public Coordinate FromCoordinate
        {
            get
            {
                return _fromCoordinate;
            }

            set
            {
                _fromCoordinate = value;
            }
        }

        public Coordinate ToCoordinate
        {
            get
            {
                return _toCoordinate;
            }

            set
            {
                _toCoordinate = value;
            }
        }

        public Piece Piece
        {
            get
            {
                return _piece;
            }

            set
            {
                _piece = value;
            }
        }
    }
}
