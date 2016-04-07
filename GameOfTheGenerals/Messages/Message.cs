using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public interface Message
    {
        MessageOrigination MessageOrigination { get; set; }
        short TurnNumber { get; set; }
        Header GetHeader();

    }
}
