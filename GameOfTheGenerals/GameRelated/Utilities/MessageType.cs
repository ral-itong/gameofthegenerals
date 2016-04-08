using System;
using System.Collections.Generic;
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

}
