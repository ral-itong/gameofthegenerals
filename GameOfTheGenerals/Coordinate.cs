using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfTheGenerals
{
    public class Coordinate
    {
        private byte _xCoordinate;
        private byte _yCoordinate;


        public Coordinate(byte xCoordinate, byte yCoordinate)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        public byte XCoordinate
        {
            get
            {
                return _xCoordinate;
            }

            set
            {
                _xCoordinate = value;
            }
        }

        public byte YCoordinate
        {
            get
            {
                return _yCoordinate;
            }

            set
            {
                _yCoordinate = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Coordinate otherCoordinate = obj as Coordinate;
            if (otherCoordinate == null)
                return false;

            return (XCoordinate == otherCoordinate.XCoordinate)
                && (YCoordinate == otherCoordinate.YCoordinate);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 13) + XCoordinate.GetHashCode();
            hash = (hash * 13) + YCoordinate.GetHashCode();

            return hash;
        }
    }
}
