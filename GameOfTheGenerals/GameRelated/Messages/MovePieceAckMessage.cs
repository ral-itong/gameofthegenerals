using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class MovePieceAckMessage : AckMessage
    {
        public override Header CreateHeader()
        {
            Header header = new Header();
            header.MessageLength = Convert.ToInt16(BoardStateUtil.GetTotalLengthOfBoardStateMessage(Pieces.Length) + 1);
            header.MessageOrigination = MessageOrigination;
            header.MessageType = MessageType.MovePieceAck;
            header.TurnNumber = TurnNumber;

            return header;
        }


    }
}
