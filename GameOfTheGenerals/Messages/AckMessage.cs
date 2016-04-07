using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public abstract class AckMessage : Message
    {
        private MovePieceResult result;
        private Piece[] _pieces;
        private MessageOrigination _messageOrigination;
        private short _turnNumber;
        private MessageType _messageType;

   

        public Header GetHeader()
        {
            return CreateHeader();
        }

        public static byte[] Serialize(AckMessage message)
        {
            return SerializerDeserializer.SerializeAckMessage(message);
        }

        public static AckMessage Deserialize(byte[] serializedMessage)
        {
            return SerializerDeserializer.DeserializeAckMessage(serializedMessage);
        }

        public abstract Header CreateHeader();

        public byte GetNumberOfPiecesInBoard()
        {
            return BoardStateUtil.GetNumberOfPiecesInBoard(Pieces);
        }

        public MovePieceResult Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
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
