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

        public string DebugInfo() {
            string info = "La pièce avec la value" + Value + " est à la posision" + Pos;
            return info;
        }
        
        public abstract List<Vector2Int> GetAvailableMoves(Piece[,] board);

        public void MovePiece(Piece[,] board,Vector2Int movement)
        {
            if (movement.x < 0 || movement.x > 7)
                Debug.LogError("Something goes wrong with " + GetType().FullName + " x: " + movement.x);
            
            if (movement.y < 0 || movement.y > 7)
                Debug.LogError("Something goes wrong with " + GetType().FullName + " y: " + movement.y);
            
            board[movement.x, movement.y] = this;
            //Debug.Log(GetType().FullName +  " Move From " + Pos + " to " + movement);
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        
        public object Clone()
        {
            return MemberwiseClone();
        }
        
            protected bool TryAddPosition(Piece[,] board, List<Vector2Int> moves, Vector2Int dir)
            {
                int x = Pos.x + dir.x;
                int y = Pos.y + dir.y;

                if (x < 0 || x >= board.GetLength(0)) return false;
                if (y < 0 || y >= board.GetLength(1)) return false;

                Piece piece = board[x, y];

                if (piece == null)
                {
                    moves.Add(new Vector2Int(x, y));
                    return true;
                }

                if (piece.Color != Color)
                {
                    moves.Add(new Vector2Int(x, y));
                }
                else
                {
                    // du même côté
                }
                return false;
            }
    }
}