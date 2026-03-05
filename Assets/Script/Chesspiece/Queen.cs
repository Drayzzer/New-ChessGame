using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Queen : Piece
    {
        public override int Value => 9;
        
        public Queen(ColorPiece color) : base(color) {}
        
        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            // Right
            for (int i = 1; i < board.GetLength(0); i++)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(i, 0))) break;
            }
            
            // Left
            for (int i = -1; i >= 0; i--)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(-i, 0))) break;
            }
            
            // Top
            for (int i = 1; i < board.GetLength(0); i++)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(0, i))) break; 
            }
            
            //Bottom
            for (int i = -1; i >= 0; i--)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(0, -i))) break;
            }
            
            // Right.Top
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int( i, i))) break;
            }
            
            // left.Top
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(- i, i))) break;
            }
            
            // Right.Bottom
            for (int i = 1; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int( i, - i))) break;
            }
            
            // Left.Bottom
            for (int i = -1; i < board.GetLength(0); i--) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(- i, - i))) break;
            }
            return moves;
        }
    }
}