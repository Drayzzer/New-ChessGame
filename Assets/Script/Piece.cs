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

        protected bool TryAddPosition(Piece[,] board, List<Vector2Int> moves, Vector2Int dir)
        {
            Piece piece = board[Pos.x + dir.x, Pos.y + dir.y];
            if (piece == null)
            {
                moves.Add(new Vector2Int(Pos.x + dir.x, Pos.y + dir.y));
                return true;
            }

            if (piece.Color != Color)
            {
                moves.Add(new Vector2Int(Pos.x + dir.x, Pos.y + dir.y));
            }

            return false;
        }
    }
}