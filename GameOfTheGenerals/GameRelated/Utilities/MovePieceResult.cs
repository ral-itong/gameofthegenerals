using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public enum MovePieceResult
    {
        Sucessful = 0x00,
        PieceNotFoundInCoordinate = 0x01,
        IllegalMove = 0x02
    }
}
