using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Bishop : Piece
    {
        public override int Value => 3;

        public Bishop(ColorPiece color) : base(color) {}

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            //right.Top
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(Pos.x + i, Pos.y + i))) break;
            }
            // left.Top
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(Pos.x - i, Pos.y + i))) break;
            }
            
            // Right.Bottom
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(Pos.x + i, Pos.y - i))) break;
            }
            // Left.Bottom
            for (int i = 1; i < board.GetLength(0); i--) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(Pos.x - i, Pos.y - i))) break;
            }
            return moves;
        }
    }
}
