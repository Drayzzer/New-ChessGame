using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public enum ColorPiece 
    {
        Black,
        White,
    }

    public abstract class Piece : ICloneable
    {
        public ColorPiece Color;
        public Vector2Int Pos;

        public abstract int Value { get; }

        //constructeur
        protected Piece(ColorPiece color)
        {
            Color = color;
        }
        
        public abstract List<Vector2Int> GetAvailableMoves(Piece[,] board);

        public abstract void MovePiece(Piece[,] board,Vector2Int movement);
        
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}