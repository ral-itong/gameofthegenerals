using System;
using System.IO;

namespace GameOfTheGenerals
{
    public class Piece
    {
        byte _xCoordinate;
        byte _yCoordinate;
        readonly PieceOwner _pieceOwner;
        readonly Rank _rank;

        public const byte SerialLength = 4;

        public Piece(Rank rank, PieceOwner pieceOwner)
        {
            this._rank = rank;
            this._pieceOwner = pieceOwner;
        }

        public bool CanEliminate(Piece piece)
        {
            if (_rank == Rank.Private && piece.Rank == Rank.Spy)
                return true;
            else if (_rank == Rank.Spy && piece.Rank == Rank.Private)
                return false;


            return _rank > piece.Rank;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Piece otherPiece = obj as Piece;
            if (otherPiece == null)
                return false;

            return (this.PieceOwner == otherPiece.PieceOwner)
                && (this.Rank == otherPiece.Rank)
                && (this.XCoordinate == otherPiece.XCoordinate)
                && (this.YCoordinate == otherPiece.YCoordinate);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = (hash * 7) + _rank.GetHashCode();
            hash = (hash * 7) + _pieceOwner.GetHashCode();

            return hash;
        }

        public static Piece Deserialize(byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BinaryReader reader = new BinaryReader(stream);

            byte xCoordinate = reader.ReadByte();
            byte yCoordinate = reader.ReadByte();
            PieceOwner pieceOwner = (PieceOwner)Enum.ToObject(typeof(PieceOwner), reader.ReadByte());
            Rank rank = (Rank)Enum.ToObject(typeof(Rank), reader.ReadByte());


            Piece piece = new Piece(rank, pieceOwner);
            piece.XCoordinate = xCoordinate;
            piece.YCoordinate = yCoordinate;

            return piece;
        }

        public static byte[] ToByteArray(Piece piece)
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            writer.Write(piece.XCoordinate);
            writer.Write(piece.YCoordinate);
            writer.Write(Convert.ToByte(piece.PieceOwner));
            writer.Write(Convert.ToByte(piece.Rank));

            return stream.ToArray();

        }

        public Rank Rank
        {
            get
            {
                return _rank;
            }

        }

        public PieceOwner PieceOwner
        {
            get
            {
                return _pieceOwner;
            }
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



    }
}