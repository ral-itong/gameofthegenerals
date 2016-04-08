using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class GoodToGoMessage : Message
    {
        private MessageOrigination _messageOrigination;
        private short _turnNumber;

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

        public Header GetHeader()
        {
            Header header = new Header();
            header.MessageLength = Header.SerialLength;
            header.MessageOrigination = MessageOrigination;
            header.MessageType = MessageType.GoodToGo;
            header.TurnNumber = TurnNumber;

            return header;
        }

        public static byte[] Serialize(GoodToGoMessage message)
        {
            return SerializerDeserializer.SerializeGoodToGoMessage(message);
        }

        public static GoodToGoMessage Deserialize(byte[] serializedMessage)
        {
            return SerializerDeserializer.DeserializeGoodToMessage(serializedMessage);
        }
    }
}
