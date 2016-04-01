using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public enum Rank
    {
        Flag = 0x00,
        Private = 0x01,
        Sergeant = 0x02,
        SecondLieutenant = 0x03,
        FirstLieutenant = 0x04,
        Captain = 0x05,
        Major = 0x06,
        LieutenantColonel = 0x07,
        Colonel = 0x08,
        BrigadierGeneral = 0x09,
        MajorGeneral = 0x0A,
        LieutenantGeneral = 0x0B,
        General = 0x0C,
        GeneralOfTheArmy = 0x0D,
        Spy = 0x0E
    };
}
