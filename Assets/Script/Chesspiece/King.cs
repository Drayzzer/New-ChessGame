using System.Collections.Generic;

using UnityEngine;

namespace Chesspiece
{
    public class King : Piece
    {
        public override int Value => int.MaxValue;

        public override void MovePiece(Piece[,] board, Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }

        public King(ColorPiece color) : base(color)
        {
        }

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();

            // Right
            if (Pos.x + 1 < board.GetLength(0))
            {
                TryAddPosition(board, moves, new Vector2Int(1, 0));
            }

            // Left
            if (Pos.x - 1 >= 0)
            {
                TryAddPosition(board, moves, new Vector2Int(-1, 0));
            }

            // Top
            if (Pos.y + 1 < board.GetLength(1))
            {
                TryAddPosition(board, moves, new Vector2Int(0, 1));
            }

            // Bottom
            if (Pos.y - 1 >= 0)
            {
                TryAddPosition(board, moves, new Vector2Int(0, -1));
               
            }
            
            // Right.Top
            if (Pos.x + 1 < board.GetLength(0) && Pos.y + 1 < board.GetLength(1))
            {  
                TryAddPosition(board, moves, new Vector2Int(1, 1));
            }
                
            // left.Top
            if (Pos.x - 1 >= 0 && Pos.y + 1 < board.GetLength(1))
            {
                TryAddPosition(board, moves, new Vector2Int(-1, 1));
            }
                
            // Right.Bottom
            if (Pos.x + 1 < board.GetLength(0) && Pos.y - 1 > 0)
            {
                TryAddPosition(board, moves, new Vector2Int(1, -1)); 
            }
                
            // Left.Bottom
            if (Pos.x - 1 >= 0 && Pos.y - 1 >= 0)
            { 
                TryAddPosition(board, moves, new Vector2Int(-1, -1)); 
            }
            return moves;
        }
    }
}