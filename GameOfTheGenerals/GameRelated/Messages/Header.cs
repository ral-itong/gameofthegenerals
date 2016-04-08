using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{

    public class Header
    {

        private short _messageLength;
        private MessageType _messageType;
        private short _turnNumber;
        private MessageOrigination _messageOrigination;
        public const ushort HeaderConstant = 0xAAAA;
        public const short SerialLength = 8;

        public static byte[] Serialize(Header header)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);
            writer.Write(HeaderConstant);
            writer.Write(header.MessageLength);
            writer.Write(Convert.ToByte(header.MessageOrigination));
            writer.Write(Convert.ToByte(header.MessageType));
            writer.Write(header.TurnNumber);

            return stream.ToArray();
        }

        public static Header Deserialize(byte[] byteArray)
        {
            Header header = new Header();
            MemoryStream stream = new MemoryStream(byteArray);
            BinaryReader reader = new BinaryReader(stream);

            SkipHeaderConstant(reader);
            header.MessageLength = reader.ReadInt16();
            header.MessageOrigination = (MessageOrigination)Enum.ToObject(typeof(MessageOrigination), reader.ReadByte());
            header.MessageType = (MessageType)Enum.ToObject(typeof(MessageType), reader.ReadByte());
            header.TurnNumber = reader.ReadInt16();

            return header;
        }

        private static void SkipHeaderConstant(BinaryReader reader)
        {
            reader.ReadBytes(2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Header otherHeader = obj as Header;
            if (otherHeader == null)
                return false;

            return (MessageLength == otherHeader.MessageLength) &&
                 (MessageType == otherHeader.MessageType) &&
                (MessageOrigination == otherHeader.MessageOrigination) &&
                (TurnNumber == otherHeader.TurnNumber);
        }

        public override int GetHashCode()
        {
            int hash = 31;
            hash = (hash * 31) + MessageLength.GetHashCode();
            hash = (hash * 31) + MessageType.GetHashCode();
            hash = (hash * 31) + MessageOrigination.GetHashCode();
            hash = (hash * 31) + TurnNumber.GetHashCode();

            return hash;
        }

        public short MessageLength
        {
            get
            {
                return _messageLength;
            }

            set
            {
                _messageLength = value;
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
    }
}
