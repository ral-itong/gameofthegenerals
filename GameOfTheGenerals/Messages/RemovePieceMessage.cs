using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class RemovePieceMessage : Message
    {
        private short _turnNumber;
        private MessageOrigination _messageOrigination;
        private PieceToBeRemoved _pieceToBeRemoved;
        private Piece _piece;

        public Header GetHeader()
        {
            Header header = new Header();
            short lengthOfOrigination = 1;
            
            header.MessageLength = Convert.ToInt16(Header.SerialLength +  lengthOfOrigination + Piece.SerialLength);
            header.MessageOrigination = MessageOrigination;
            header.MessageType = MessageType.RemovePiece;
            header.TurnNumber = TurnNumber;

            return header;
        }

        public static byte[] Serialize(RemovePieceMessage removePiece)
        {
            return SerializerDeserializer.SerializeRemovePieceMessage(removePiece);
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

        public PieceToBeRemoved PieceToBeRemoved
        {
            get
            {
                return _pieceToBeRemoved;
            }

            set
            {
                _pieceToBeRemoved = value;
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

        public static RemovePieceMessage Deserialize(byte[] serializedMessage)
        {
            return SerializerDeserializer.DeserializeRemovePieceMessage(serializedMessage);
        }
    }
}
