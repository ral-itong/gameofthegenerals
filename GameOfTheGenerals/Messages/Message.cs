using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public interface Message
    {
        MessageOrigination Origination { get; set; }
        byte TurnNumber { get; set; }
        Header GetHeader();
        byte[] ToByteArray();

    }
}
