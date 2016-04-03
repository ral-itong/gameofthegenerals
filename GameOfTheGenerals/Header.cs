﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public enum MessageType
    {
        BoardState = 0x00,
        Ready = 0x01,
        SetupFail = 0x02,
        MovePiece = 0x03,
        MovePieceAck = 0x04,
        GoodToGo = 0x05,
        RemovePiece = 0x06,
        RemovePieceAck = 0x07
    }


    public enum MessageOrigination
    {
        Host = 0x00,
        Client = 0x01
    }



    public class Header
    {

        private MessageType _messageType;
        private byte _messageLength;
        private MessageOrigination _messageOrigination;
        private byte _turnNumber;
        public const ushort HeaderConstant = 0xAAAA;

        public byte[] ToByteArray()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);
            writer.Write(HeaderConstant);
            writer.Write(_messageLength);
            writer.Write(Convert.ToByte(_messageOrigination));
            writer.Write(Convert.ToByte(_messageType));
            writer.Write(_turnNumber);

            return stream.ToArray();
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

        public byte MessageLength
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

        public MessageOrigination MessageOrigination1
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