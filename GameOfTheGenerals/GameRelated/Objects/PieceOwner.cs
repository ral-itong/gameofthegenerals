using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public enum PieceOwner
    {
        Host = 0x00,
        Client = 0x01,
        OverlappingPieces = 0x02,
        Empty = 0xFF
    }
}
