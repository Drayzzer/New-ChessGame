using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Rook : Piece
    {
        public override int Value => 5;
        
        public Rook(ColorPiece color) : base(color) { }

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            // Right
            for (int i = 1; i < board.GetLength(0); i++)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(i, 0))) break;
            }
            
            //Left
            for (int i = 1; i >= 0; i--)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(-i, 0))) break;
            }
            
            // Top
            for (int i = 1; i < board.GetLength(0); i++)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(0, i))) break; 
            }
            
            // Bottom
            for (int i = 1; i >= 0; i--)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(0, -i))) break;
            }
            return moves;
        }
    }
}