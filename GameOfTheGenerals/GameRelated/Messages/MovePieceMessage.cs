using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals {

    public class MovePieceMessage : Message
    {
        private MessageOrigination _origination;
        private short _turnNumber;
        private Coordinate _fromCoordinate;
        private Coordinate _toCoordinate;
        private Rank _rank;

        public Header GetHeader()
        {
            Header header = new Header();
            header.MessageLength = GetTotalLengthOfMessage();
            header.MessageType = MessageType.MovePiece;
            header.MessageOrigination = _origination;
            header.TurnNumber = _turnNumber;

            return header;
        }

        public byte GetTotalLengthOfMessage()
        {
            byte lengthOfMessageOrigination = 1;
            byte lengthOfFromCoordinate = 2;
            byte lengthOfToCoordinate = 2;
            byte lengthOfPieceRank = 1;
            

            return Convert.ToByte(lengthOfMessageOrigination + lengthOfFromCoordinate +
                lengthOfToCoordinate + lengthOfPieceRank + Header.SerialLength);
        }

        public static byte[] Serialize(MovePieceMessage message)
        {
            return SerializerDeserializer.SerializeMovePieceMessage(message);
        }

        public static MovePieceMessage Deserialize(byte[] byteArray)
        {
            return SerializerDeserializer.DeserializeMovePieceMessage(byteArray);
        }

        public MessageOrigination MessageOrigination
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

        public short TurnNumber
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
    }
}
