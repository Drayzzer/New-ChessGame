using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Pawn : Piece
    {
        public override int Value => 1;
        public Pawn(ColorPiece color) : base(color) {}

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
           
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
            return moves;
        }
    }
}
