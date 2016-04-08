using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class ReadyMessage : BoardStateMessage
    {
        public ReadyMessage()
        {
            MessageType = MessageType.Ready;
        }


    }
}
