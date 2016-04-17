using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class BoardStateMessage : Message
    {

        private Piece[] _pieces;
        private MessageOrigination _messageOrigination;
        private short _turnNumber;
        private MessageType _messageType;


        public BoardStateMessage()
        {
            _turnNumber = 0;
            _messageType = MessageType.BoardState;
        }


        public byte GetNumberOfPiecesInBoard()
        {
            return BoardStateUtil.GetNumberOfPiecesInBoard(Pieces);
        }

        public Header GetHeader()
        {
            Header header = new Header();

            short total = GetTotalLengthOfMessage();

            header.MessageLength = total;
            header.MessageOrigination = _messageOrigination;
            header.MessageType = MessageType;
            header.TurnNumber = _turnNumber;

            return header;
        }

        private short GetTotalLengthOfMessage()
        {
            return BoardStateUtil.GetTotalLengthOfBoardStateMessage(Pieces.Length);
        }


        public static byte[] Serialize(BoardStateMessage boardStateMessage)
        {
            return SerializerDeserializer.SerializeBoardStateMessage(boardStateMessage);
        }

        public static BoardStateMessage Deserialize(byte[] result)
        {
            return SerializerDeserializer.DeserializeBoardStateMessage(result);
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

        public MessageType MessageType
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
